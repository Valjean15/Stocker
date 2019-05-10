namespace Models.Shopping
{
    /// <summary>
    ///     Entidad que representa el nombre de una marca
    /// </summary>
    public class Brand : EntityBase<int>
    {
        /// <summary>
        ///     Nombre de la marca
        /// </summary>
        public string Name { get; set; }
    }
}
