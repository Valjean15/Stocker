using System.Collections.Generic;

namespace Models.Workflow
{
    /// <summary>
    /// <para>
    /// Workflow, entidad base del modulo.
    /// Indican los flujos que o series de estados los cuales una
    /// entidad se comporta en el sistema
    /// </para>
    /// <para>Estos contienen estados que definen la etapa en la cual se encuentra la entidad (referencia: <see cref="State"/>)</para>
    /// <para>Estos usan transiciones para poder cambiar de estados (referencia: <see cref="Transition"/>)</para>
    /// <para>Estos generan un LOG en el cual registran las actividades del workflow por entidad (referencia: <see cref="FlowLog"/>)</para>
    /// </summary>
    public class Flow
    {
        /// <summary>
        /// Llave primaria
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del flujo
        /// </summary>
        public string Name { get; set; }

        #region Virtual Properties

        /// <summary>
        /// Estados al cual pertenece al flujo
        /// </summary>
        public virtual ICollection<State> States { get; set; }

        #endregion
    }
}
