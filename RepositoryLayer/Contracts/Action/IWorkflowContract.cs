namespace RepositoryLayer.Contracts.Action
{
    using Store;
    using Models.Interfaces;
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
        /// <param name="Transition">
        ///     Transicion a ejecutar
        /// </param>
        /// <param name="Entity">
        ///     Entidad a la cual se le realiza cambio de estado
        /// </param>
        void ExecuteTransition(IWorkflowState Entity, Transition Transition);

        /// <summary>
        ///     Obtiene todas las transiciones de salida de un estado
        /// </summary>
        /// <param name="State">
        ///     Estado a obtener transiciones de salida
        /// </param>
        /// <returns>
        ///     HashSet de transiciones
        /// </returns>
        HashSet<Transition> GetExitTransition(State State);

        /// <summary>
        ///     Realiza un retorno de la ultima transicion ejecutada
        /// </summary>
        /// <param name="Entity">
        ///     Entidad a realizar rollback de transicion
        /// </param>
        void RollBackTransition(IWorkflowState Entity);
    }
}
