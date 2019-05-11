namespace RepositoryLayer.Manager.Workflow
{
    using Store;
    using Contracts;
    using DataAccessLayer.Context;
    using Models.Workflow;
    using System.Collections.Generic;

    /// <summary>
    ///     Clase encargada de realizar todas las acciones relacionadas a workflow
    /// </summary>
    public class WorkflowManager : EntityStore<Flow, StockerContext, int>, IWorkflowContract<StockerContext>
    {
        /// <summary>
        ///     Contructor base de manager de workflow
        /// </summary>
        /// <param name="context">
        ///     Contexto a utilizar
        /// </param>
        public WorkflowManager(StockerContext context) : base(context)
        {

        }

        /// <summary>
        ///     Ejecuta una transicion de workflow
        /// </summary>
        /// <param name="transition">
        ///     Transicion a ejecutar
        /// </param>
        public void ExecuteTransition(int entityId, string tableName, Transition transition)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///     Obtiene todas las transiciones de salida de un estado
        /// </summary>
        /// <param name="state">
        ///     Estado a obtener transiciones de salida
        /// </param>
        /// <returns>
        ///     HashSet de transiciones
        /// </returns>
        public HashSet<Transition> GetExitTransition(State state)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///     Realiza un retorno de la ultima transicion ejecutada
        /// </summary>
        /// <param name="entityId">
        ///     Id de la entidad relacionada
        /// </param>
        /// <param name="tableName">
        ///     Nombre de la entidad relacionada
        /// </param>
        public void RollBackTransition(int entityId, string tableName)
        {
            throw new System.NotImplementedException();
        }
    }
}
