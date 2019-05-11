namespace RepositoryLayer.Store
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    ///     Comportamiento para el uso del contexto de Base de datos
    /// </summary>
    /// <typeparam name="TContext">
    ///     Tipo del contexto de uso
    /// </typeparam>
    internal interface IDbContext<out TContext> where TContext : DbContext
    {
        /// <summary>
        ///     Obtine el contexto de Base de datos a utilizar
        /// </summary>
        TContext Context { get; }
    }
}
