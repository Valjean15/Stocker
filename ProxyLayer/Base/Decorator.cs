namespace Proxy.Base
{
    using System;
    using System.Reflection;

    /// <summary>
    ///     Comportamiento general para los decoradores
    /// </summary>
    public class Decorator<TDecorated> : DispatchProxy
        where TDecorated : class
    {
        /// <summary>
        ///     Objeto a aplicar decorado
        /// </summary>
        protected TDecorated Target;

        /// <summary>
        ///     Agrega objetivo a decorars
        /// </summary>
        /// <param name="Target">
        ///     Clase a decorar
        /// </param>
        public void SetTarget(TDecorated Target)
        {
            if (Target is null)
                throw new ArgumentNullException(nameof(Target));

            this.Target = Target;
        }

        /// <summary>
        ///     Funcion que realiza la invocacion de la funcion a decorar
        /// </summary>
        /// <param name="targetMethod">
        ///     Metodo objetivo
        /// </param>
        /// <param name="args">
        ///     Argumentos del metodo
        /// </param>
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            BeforeInvoke(targetMethod, args);
            var Result = InvokeCall(targetMethod, args);
            AfterInvoke(targetMethod, args, Result);

            return Result;
        }

        /// <summary>
        ///     Metodo a ejecutar antes de la invoacion del metodo a decorar
        /// </summary>
        /// <param name="TargetMethod">
        ///     Metodo objetivo
        /// </param>
        /// <param name="Arguments">
        ///     Parametros
        /// </param>
        protected virtual void BeforeInvoke(MethodInfo TargetMethod, object[] Arguments) { }

        /// <summary>
        ///     Funcion que realiza la invocacion de la funcion a decorar
        /// </summary>
        /// <param name="TargetMethod">
        ///     Metodo objetivo
        /// </param>
        /// <param name="Arguments">
        ///     Argumentos del metodo
        /// </param>
        protected virtual object InvokeCall(MethodInfo TargetMethod, object[] Arguments)
            => TargetMethod.Invoke(Target, Arguments);

        /// <summary>
        ///     Metodo a ejecutar antes de la invoacion del metodo a decorar
        /// </summary>
        /// <param name="TargetMethod">
        ///     Metodo objetivo
        /// </param>
        /// <param name="Arguments">
        ///     Parametros
        /// </param>
        /// <param name="Result">
        ///     Resultado de la invoacion
        /// </param>
        protected virtual void AfterInvoke(MethodInfo TargetMethod, object[] Arguments, object Result) { }
    }
}
