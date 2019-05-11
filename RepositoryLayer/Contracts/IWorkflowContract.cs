namespace RepositoryLayer.Contracts
{
    using Store;
    using System.Collections.Generic;
    using Models.Workflow;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    ///     Contiene todas las acciones relacionadas a Workflow
    /// </summary>
    /// <typeparam name="TContext">
    ///     Tipo del contexto
    /// </typeparam>
    internal interface IWorkflowContract<TContext> : IDbContext<TContext> where TContext : DbContext
    {
        /// <summary>
        ///     Ejecuta una transicion de workflow
        /// </summary>
        /// <param name="transition">
        ///     Transicion a ejecutar
        /// </param>
        void ExecuteTransition(int entityId, string tableName, Transition transition);

        /// <summary>
        ///     Obtiene todas las transiciones de salida de un estado
        /// </summary>
        /// <param name="state">
        ///     Estado a obtener transiciones de salida
        /// </param>
        /// <returns>
        ///     HashSet de transiciones
        /// </returns>
        HashSet<Transition> GetExitTransition(State state);

        /// <summary>
        ///     Realiza un retorno de la ultima transicion ejecutada
        /// </summary>
        /// <param name="entityId">
        ///     Id de la entidad relacionada
        /// </param>
        /// <param name="tableName">
        ///     Nombre de la entidad relacionada
        /// </param>
        void RollBackTransition(int entityId, string tableName);
    }
}
