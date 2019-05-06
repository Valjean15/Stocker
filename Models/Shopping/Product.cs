namespace Models.Shopping
{
    public class Product
    {
        /// <summary>
        /// Llave primaria
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string Name { get; set; }

        #region Foreing Keys

        /// <summary>
        /// LLave foranea de la entidad <see cref="Shopping.Brand"/>
        /// </summary>
        public int BrandId { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        /// Propiedad virtual de la llave foranea de <see cref="BrandId"/>
        /// </summary>
        public virtual Brand Brand { get; set; }

        #endregion
    }
}
