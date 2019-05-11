namespace Models.Workflow
{
    using System;

    /// <summary>
    ///     Clase encargada de contener el log de cambios de los flujos
    /// </summary>
    public class FlowLog : EntityBase<int>
    {
        /// <summary>
        ///     Construtor base de la entidad
        /// </summary>
        public FlowLog()
        {
            TableName = string.Empty;
        }

        /// <summary>
        ///     Fecha que se registro el Log
        /// </summary>
        public DateTime Log { get; set; }

        /// <summary>
        ///     Nombre de la tabla asociada al workflow
        /// </summary>
        public string TableName { get; set; }

        #region Foreing Keys

        /// <summary>
        ///     Id del flujo involucrado
        /// </summary>
        public int FlowId { get; set; }

        /// <summary>
        ///     Id del estado inicial 
        /// </summary>
        public int EndStateId { get; set; }

        /// <summary>
        ///     Id del estado final 
        /// </summary>
        public int StartStateId { get; set; }

        /// <summary>
        ///     Id de la transicion ejecutada
        /// </summary>
        public int TransitionId { get; set; }

        /// <summary>
        ///     Id de la entidad involucrada
        /// </summary>
        public int EntityId { get; set; }
        #endregion
    }
}
