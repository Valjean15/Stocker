namespace Models.Shopping
{
    using Models.Common;

    /// <summary>
    ///     Entidad que representa un item de compra
    /// </summary>
    public class Product : EntityBase<int>
    {
        /// <summary>
        ///     Nombre del producto
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Valor de venta por unidad del producto
        /// </summary>
        public decimal SaleUnitPrice { get; set; }

        #region Foreing Keys

        /// <summary>
        ///     LLave foranea de la entidad <see cref="Shopping.Brand"/>
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Common.Currency"/>
        /// </summary>
        public int CurrencyId { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        ///     Propiedad virtual de la llave foranea de <see cref="BrandId"/>
        /// </summary>
        public virtual Brand Brand { get; set; }

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="CurrencyId"/>
        /// </para>
        /// <para>
        ///     Indica la moneda en que se encuntran los montos del producto
        /// </para>
        /// </summary>
        public virtual Currency Currency { get; set; }

        #endregion
    }
}
