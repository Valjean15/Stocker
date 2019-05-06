using System;

namespace Models.Workflow
{
    /// <summary>
    /// Clase encargada de contener el log de cambios de los flujos
    /// </summary>
    public class FlowLog
    {
        /// <summary>
        /// Llave primaria
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Fecha que se registro el Log
        /// </summary>
        public DateTime Log { get; set; }

        #region Foreing Keys

        /// <summary>
        /// Id del flujo involucrado
        /// </summary>
        public int FlowId { get; set; }

        /// <summary>
        /// Id del estado inicial 
        /// </summary>
        public int EndStateId { get; set; }

        /// <summary>
        /// Id del estado final 
        /// </summary>
        public int StartStateId { get; set; }

        /// <summary>
        /// Id de la transicion ejecutada
        /// </summary>
        public int TransitionId { get; set; }

        /// <summary>
        /// Id de la entidad involucrada
        /// </summary>
        public int EntityId { get; set; }
        #endregion
    }
}
