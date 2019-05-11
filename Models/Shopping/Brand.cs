namespace Models.Shopping
{
    using System.Collections.Generic;

    /// <summary>
    ///     Entidad que representa el nombre de una marca
    /// </summary>
    public class Brand : EntityBase<int>
    {
        /// <summary>
        ///     Construtor base de la entidad
        /// </summary>
        public Brand()
        {
            Name = string.Empty;
            Products = new HashSet<Product>();
        }

        /// <summary>
        ///     Nombre de la marca
        /// </summary>
        public string Name { get; set; }

        #region Virtual Properties

        /// <summary>
        ///     Productos asociados a esta marca
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        #endregion
    }
}
