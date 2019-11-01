namespace Proxy.Base
{
    using System.Reflection;

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
        /// <param name="target">
        ///     Clase a aplicar proxy
        /// </param>
        public static TDecorated Decorate<TDecorated, TProxy>(this TDecorated target)
            where TDecorated : class
            where TProxy : Decorator<TDecorated>
        {
            object proxy = DispatchProxy.Create<TDecorated, TProxy>();
            ((TProxy)proxy).SetTarget(target);

            return (TDecorated)proxy;
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
        /// <param name="target">
        ///     Clase a aplicar proxy
        /// </param>
        public static TDecorated Decorate<TDecorated, TProxy>(this object target)
            where TDecorated : class
            where TProxy : Decorator<object>
        {
            object proxy = DispatchProxy.Create<TDecorated, TProxy>();
            ((TProxy)proxy).SetTarget(target);

            return (TDecorated)proxy;
        }
    }
}
