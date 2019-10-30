namespace Repository.Store
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    ///     Comportamiento para el uso del contexto de Base de datos
    /// </summary>
    /// <typeparam name="TContext">
    ///     Tipo del contexto de uso
    /// </typeparam>
    public interface IDbContext<out TContext> where TContext : DbContext
    {
        /// <summary>
        ///     Obtiene el contexto de Base de datos a utilizar
        /// </summary>
        TContext Context { get; }
    }
}
