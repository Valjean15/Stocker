namespace Models.Workflow
{
    using System.Collections.Generic;

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
            Flow = new Flow();
            Transitions = new HashSet<Transition>();
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

        /// <summary>
        ///     Transiciones relacionados al estado
        /// </summary>
        public virtual ICollection<Transition> Transitions { get; set; }

        #endregion
    }
}
