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
            var result = InvokeCall(targetMethod, args);
            AfterInvoke(targetMethod, args, result);

            return result;
        }

        /// <summary>
        ///     Metodo a ejecutar antes de la invoacion del metodo a decorar
        /// </summary>
        /// <param name="targetMethod">
        ///     Metodo objetivo
        /// </param>
        /// <param name="args">
        ///     Parametros
        /// </param>
        protected virtual void BeforeInvoke(MethodInfo targetMethod, object[] args) { }

        /// <summary>
        ///     Funcion que realiza la invocacion de la funcion a decorar
        /// </summary>
        /// <param name="targetMethod">
        ///     Metodo objetivo
        /// </param>
        /// <param name="args">
        ///     Argumentos del metodo
        /// </param>
        protected virtual object InvokeCall(MethodInfo targetMethod, object[] args)
            => targetMethod.Invoke(Target, args);

        /// <summary>
        ///     Metodo a ejecutar antes de la invoacion del metodo a decorar
        /// </summary>
        /// <param name="targetMethod">
        ///     Metodo objetivo
        /// </param>
        /// <param name="args">
        ///     Parametros
        /// </param>
        /// <param name="result">
        ///     Resultado de la invoacion
        /// </param>
        protected virtual void AfterInvoke(MethodInfo targetMethod, object[] args, object result) { }
    }
}
