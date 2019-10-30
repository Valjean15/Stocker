namespace Models.Shopping
{
    using Models.Common;

    /// <summary>
    ///     Producto de compra dentro de un lote
    /// </summary>
    public class BundleItem : EntityBase<int>
    {
        /// <summary>
        ///     Numero de items ordenados
        /// </summary>
        public int Quantity { get; set; }

        #region Bundle Currency Values

        /// <summary>
        ///     Impuesto Local del lote de compra
        /// </summary>
        public decimal LocalTax { get; set; }

        /// <summary>
        ///     Flete Local de la compra
        /// </summary>
        public decimal LocalFreight { get; set; }

        /// <summary>
        ///     Impuesto Extranjero del lote de compra
        /// </summary>
        public decimal ForeignTax { get; set; }

        /// <summary>
        ///     Flete Extranjero de la compra
        /// </summary>
        public decimal ForeignFreight { get; set; }

        /// <summary>
        ///     Valor unitario del producto
        /// </summary>
        public decimal UnitValue { get; set; }

        /// <summary>
        ///     Porcentaje de descuento del valor total del item
        /// </summary>
        public decimal Discount { get; set; }

        #endregion

        #region Foreing Keys

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Common.Currency"/>
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Shopping.Bundle"/>
        /// </summary>
        public int BundleId { get; set; }

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Common.Product"/>
        /// </summary>
        public int ProductId { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="CurrencyId"/>
        /// </para>
        /// <para>
        ///     Indica la moneda en que se encuntran los montos del Lote
        /// </para>
        /// </summary>
        public virtual Currency Currency { get; set; }

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="BundleId"/>
        /// </para>
        /// <para>
        ///     Lote al cual pertenece el respectivo Item
        /// </para>
        /// </summary>
        public virtual Bundle Bundle { get; set; }

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="ProductId"/>
        /// </para>
        /// <para>
        ///     Producto al cual reprenta el item
        /// </para>
        /// </summary>
        public virtual Product Product { get; set; }

        #endregion
    }
}
