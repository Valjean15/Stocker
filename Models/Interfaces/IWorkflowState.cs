namespace Models.Interfaces
{
    /// <summary>
    ///     Representa el comportamiento de una entidad dentro de un workflow
    /// </summary>
    public interface IWorkflowState : IEntityBase<int>
    {
        /// <summary>
        ///     Id del estado en que se encuentra la entidad
        /// </summary>
        public int StateId { get; set; }
    }
}
