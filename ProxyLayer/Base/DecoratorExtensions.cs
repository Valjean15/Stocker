namespace Proxy.Base
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Microsoft.CSharp.RuntimeBinder;

    /// <summary>
    ///     Extensiones para los decoradores
    /// </summary>
    public static class DecoratorExtensions
    {
        /// <summary>
        ///     Decora una clase con un proxy
        /// </summary>
        /// <typeparam name="TDecorated">
        ///     Tipo de la clase a decorar
        /// </typeparam>
        /// <typeparam name="TProxy">
        ///     Tipo del decorador a aplicar
        /// </typeparam>
        /// <param name="Target">
        ///     Clase a aplicar proxy
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TDecorated Decorate<TDecorated, TProxy>(this TDecorated Target)
            where TDecorated : class
            where TProxy : Decorator<TDecorated>
        {
            object Proxy = DispatchProxy.Create<TDecorated, TProxy>();
            (Proxy as TProxy).SetTarget(Target);

            return Proxy as TDecorated;
        }

        /// <summary>
        ///     Decora una clase con un proxy
        /// </summary>
        /// <typeparam name="TDecorated">
        ///     Tipo de la clase a decorar
        /// </typeparam>
        /// <typeparam name="TProxy">
        ///     Tipo del decorador a aplicar
        /// </typeparam>
        /// <param name="Target">
        ///     Clase a aplicar proxy
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TDecorated Decorate<TDecorated, TProxy>(this object Target)
            where TDecorated : class
            where TProxy : Decorator<object>
        {
            object Proxy = DispatchProxy.Create<TDecorated, TProxy>();
            (Proxy as TProxy).SetTarget(Target);

            return Proxy as TDecorated;
        }


        /// <summary>
        ///     Decora una clase con un proxy
        /// </summary>
        /// <typeparam name="TDecorated">
        ///     Tipo de la clase a decorar
        /// </typeparam>
        /// <typeparam name="TProxy">
        ///     Tipo del decorador a aplicar
        /// </typeparam>
        /// <param name="Target">
        ///     Clase a aplicar proxy
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object Decorate<TProxy>(this object Target)
            where TProxy : Decorator<object>
        {
            var LastInteface = Target.GetType().GetInterfaces().LastOrDefault();
            if (LastInteface is null) return Target;

            var InvokeSite = CallSite<Func<CallSite, Type, object>>.Create(
                Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(
                    CSharpBinderFlags.None,
                    nameof(DispatchProxy.Create),
                    new[] { LastInteface, typeof(TProxy) },
                    typeof(DecoratorExtensions),
                    new CSharpArgumentInfo[]
                    {
                        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
                    }
                )
            );

            object Proxy = InvokeSite.Target(InvokeSite, typeof(DispatchProxy));
            (Proxy as TProxy).SetTarget(Target);

            return Proxy;
        }
    }
}
