namespace Mapper.Common.ViewModel
{
    /// <summary>
    ///     ViewModel - Marca de producto
    /// </summary>
    public class Brand : Base.IViewModel<Models.Common.Brand>
    {
        /// <summary>
        ///     Id de la marca
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Nombre de la marca
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Map del viewmodel a entidad correspondiente
        /// </summary>
        public Models.Common.Brand ToModel()
        {
            return new Models.Common.Brand
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
