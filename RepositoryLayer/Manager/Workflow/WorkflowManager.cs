namespace RepositoryLayer.Manager.Workflow
{
    using Store;
    using Contracts.Action;
    using DataAccessLayer.Context;
    using Models.Workflow;
    using System.Collections.Generic;
    using Models.Interfaces;

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

        public void ExecuteTransition(IWorkflowState Entity, Transition Transition)
        {
            throw new System.NotImplementedException();
        }

        public HashSet<Transition> GetExitTransition(State State)
        {
            throw new System.NotImplementedException();
        }

        public void RollBackTransition(IWorkflowState Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
