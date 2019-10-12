namespace Models.Inventory
{
    using System;
    using Models.Interfaces;

    /// <summary>
    ///     Indica el movimiento del item en el inventario
    /// </summary>
    public class TransferMovement : EntityBase<int>, IStockMovement
    {
        /// <summary>
        ///     Fecha del movimiento
        /// </summary>
        public DateTime MovementDate { get; set; }

        /// <summary>
        ///     Numero de elementos del movimiento
        /// </summary>
        public int Quantity { get; set; }

        #region Foreing Keys

        /// <summary>
        ///     Llave foranea de la entidad <see cref="StockItem"/>
        /// </summary>
        public int StockItemId { get; set; }

        /// <summary>
        ///     Llave foranea de la entidad <see cref="TargetStockItem"/>
        /// </summary>
        public int TargetStockItemId { get; set; }

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
        public virtual StockItem StockItem { get; set; }

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="TargetStockItemId"/>
        /// </para>
        /// <para>
        ///     Indica a que venta pertenece
        /// </para>
        /// </summary>
        public virtual StockItem TargetStockItem { get; set; }

        #endregion
    }
}
