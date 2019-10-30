namespace Models.Sale
{
    using Models.Common;

    /// <summary>
    ///     Representa elemento dentro de una venta
    /// </summary>
    public class SaleItem : EntityBase<int>
    {
        /// <summary>
        ///     Valor del item
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        ///     Cantidad de items a vender
        /// </summary>
        public int Quantity { get; set; }

        #region Foreing Keys

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Sale"/>
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Product"/>
        /// </summary>
        public int ProductId { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="SaleId"/>
        /// </para>
        /// <para>
        ///     Indica a que venta pertenece el elemtento
        /// </para>
        /// </summary>
        public virtual Sale Sale { get; set; }

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="ProductId"/>
        /// </para>
        /// <para>
        ///     Indica a que producto representa
        /// </para>
        /// </summary>
        public virtual Product Product { get; set; }

        #endregion
    }
}
