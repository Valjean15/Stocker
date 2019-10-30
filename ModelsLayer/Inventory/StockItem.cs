namespace Models.Inventory 
{
    using System;
    using System.Collections.Generic;
    using Models.Common;

    /// <summary>
    ///     Hace referencia un elemento de inventario
    /// </summary>
    public class StockItem : EntityBase<int>
    {
        /// <summary>
        ///     Fecha en el que el item ingreso al inventario
        /// </summary>
        public DateTime Entry { get; set; }

        #region Foreing Keys

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Stock"/>
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Product"/>
        /// </summary>
        public int ProductId { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="StockId"/>
        /// </para>
        /// <para>
        ///     Indica a que almacen pertenece
        /// </para>
        /// </summary>
        public virtual Stock Stock { get; set; }

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="ProductId"/>
        /// </para>
        /// <para>
        ///     Indica a que producto representa
        /// </para>
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        ///     Indica todos los movimientos de compra
        /// </summary>
        public virtual ICollection<BundleMovement> BundleMovements { get; set; }

        /// <summary>
        ///     Indica todos los movimientos de venta
        /// </summary>
        public virtual ICollection<SaleMovement> SaleMovements { get; set; }

        /// <summary>
        ///     Indica todos los movimientos de transferencias
        /// </summary>
        public virtual ICollection<TransferMovement> TransferMovements { get; set; }

        #endregion
    }
}
