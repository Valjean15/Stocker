namespace Models.Common
{
    /// <summary>
    ///     Entida representa una sucursal o lugar 
    /// </summary>
    public class Store : EntityBase<int>
    {
        /// <summary>
        ///     Nombre de la sucursal
        /// </summary>
        public string Name { get; set; }
    }
}
