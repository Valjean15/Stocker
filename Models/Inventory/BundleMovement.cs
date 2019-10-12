namespace Models.Inventory
{
    using System;
    using Models.Interfaces;
    using Models.Shopping;

    /// <summary>
    ///     Indica el movimiento del item en el inventario
    /// </summary>
    public class BundleMovement : EntityBase<int>, IStockMovement
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
        ///     Llave foranea de la entidad <see cref="BundleItem"/>
        /// </summary>
        public int BundleItemId { get; set; }

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
        ///     Propiedad virtual de la llave foranea de <see cref="BundleItemId"/>
        /// </para>
        /// <para>
        ///     Indica a que lote pertenece
        /// </para>
        /// </summary>
        public virtual BundleItem BundleItem { get; set; }

        #endregion
    }
}
