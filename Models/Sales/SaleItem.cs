using Models.Inventory;

namespace Models.Sales
{
    /// <summary>
    /// Representa elemento dentro de una venta
    /// </summary>
    public class SaleItem
    {
        /// <summary>
        /// Llave primaria
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Valor del item
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Cantidad de items a vender
        /// </summary>
        public int Quantity { get; set; }

        #region Foreing Keys

        /// <summary>
        /// Llave foranea de la entidad <see cref="Sale"/>
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Llave foranea de la entidad <see cref="StockItem"/>
        /// </summary>
        public int StockItemId { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        /// <para>Propiedad virtual de la llave foranea de <see cref="SaleId"/></para>
        /// <para>Indica a que venta pertenece el elemtento</para>
        /// </summary>
        public virtual Sale Sale { get; set; }

        /// <summary>
        /// <para>Propiedad virtual de la llave foranea de <see cref="StockItemId"/></para>
        /// <para>Indica que elemento de que inventario pertenece</para>
        /// </summary>
        public virtual StockItem StockItem { get; set; }

        #endregion
    }
}
