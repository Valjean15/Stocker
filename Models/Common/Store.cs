namespace Models.Common
{
    /// <summary>
    ///     Entida representa una sucursal o lugar 
    /// </summary>
    public class Store : EntityBase<int>
    {
        /// <summary>
        ///     Constructor base de la entidad
        /// </summary>
        public Store()
        {
            Name = string.Empty;
        }

        /// <summary>
        ///     Nombre de la sucursal
        /// </summary>
        public string Name { get; set; }
    }
}
