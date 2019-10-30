namespace Models.Interfaces
{
    using System;
    using Models.Inventory;

    /// <summary>
    ///     Movimiento de elemento de stock de inventario
    /// </summary>
    public interface IStockMovement
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

        #endregion
    }
}
