namespace Proxy.ErrorHandler
{
    using System;
    using System.Reflection;
    using Proxy.Base;

    /// <summary>
    ///     Decorador dedicado a el control de errores
    /// </summary>
    public class ErrorHandler : Decorator<object>
    {
        /// <summary>
        ///     Funcion que realiza la invocacion de la funcion a decorar
        /// </summary>
        /// <param name="targetMethod">
        ///     Metodo objetivo
        /// </param>
        /// <param name="args">
        ///     Argumentos del metodo
        /// </param>
        protected override object InvokeCall(MethodInfo targetMethod, object[] args)
        {
            try
            {
                return targetMethod.Invoke(Target, args);
            }
            catch (TargetInvocationException targetException)
            {
                // Agregar error al manejador de errores global
            }
            catch (Exception exception)
            {
                // Agregar error al manejador de errores global
            }

            return null;
        }
    }
}
