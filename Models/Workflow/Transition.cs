namespace Models.Workflow
{
    /// <summary>
    ///     Representa un cambio de estado 
    /// </summary>
    public class Transition : EntityBase<int>
    {
        /// <summary>
        ///     Construtor base de la entidad
        /// </summary>
        public Transition()
        {
            Name = string.Empty;
        }

        /// <summary>
        ///     Nombre de la transicion
        /// </summary>
        public string Name { get; set; }

        #region Foreing Keys

        /// <summary>
        /// <para>
        ///     Estado de entrada de la transicion
        /// </para>
        /// <para>
        ///     Llave foranea de la entidad <see cref="Workflow.State"/>
        /// </para>
        /// </summary>
        public int StartStateId { get; set; }

        /// <summary>
        /// <para>
        ///     Estado de salida de la transicion
        /// </para>
        /// <para>
        ///     Llave foranea de la entidad <see cref="Workflow.State"/>
        /// </para>
        /// </summary>
        public int EndStateId { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="FlowId"/>
        /// </para>
        /// <para>
        ///     Estado de entrada de la transicion
        /// </para>
        /// </summary>
        public virtual State? StartState { get; set; }

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="FlowId"/>
        /// </para>
        /// <para>
        ///     Estado de llegada de la transicion
        /// </para>
        /// </summary>
        public virtual State? EndState { get; set; }

        #endregion
    }
}
