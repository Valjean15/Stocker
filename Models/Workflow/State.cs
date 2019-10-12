namespace Models.Workflow
{
    /// <summary>
    ///     Representa un estado dentro del flujo de trabajo
    /// </summary>
    public class State : EntityBase<int>
    {
        /// <summary>
        ///     Construtor base de la entidad
        /// </summary>
        public State()
        {
            Name = string.Empty;
        }

        /// <summary>
        ///     Nombre del estado
        /// </summary>
        public string Name { get; set; }

        #region Foreing Keys

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Workflow.Flow"/>
        /// </summary>
        public int FlowId { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="FlowId"/>
        /// </para>
        /// <para>
        ///     Flujo de trabajo al cual pertenece
        /// </para>
        /// </summary>
        public virtual Flow Flow { get; set; }

        #endregion
    }
}
