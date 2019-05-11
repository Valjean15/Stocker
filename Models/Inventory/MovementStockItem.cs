namespace Models.Inventory
{
    using System;

    /// <summary>
    ///     Indica el movimiento del item en el inventario
    /// </summary>
    public class MovementStockItem : EntityBase<int>
    {
        /// <summary>
        ///     Fecha del movimiento
        /// </summary>
        public DateTime MovementDate { get; set; }

        /// <summary>
        ///     Numero de elementos actualizados para este elemento
        /// </summary>
        public int Quantity { get; set; }

        #region Foreing Keys

        /// <summary>
        ///     Llave foranea de la entidad <see cref="StockItem"/>
        /// </summary>
        public int StockItemId { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="StockItemId"/>
        /// </para>
        /// <para>
        ///     Indica a que elemento pertenece este movimiento
        /// </para>
        /// </summary>
        public virtual StockItem? StockItem { get; set; }

        #endregion
    }
}
