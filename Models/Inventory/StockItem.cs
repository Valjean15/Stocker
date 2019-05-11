namespace Models.Inventory 
{
    using Models.Shopping;
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Hace referencia un elemento de inventario
    /// </summary>
    public class StockItem : EntityBase<int>
    {
        /// <summary>
        ///      Construtor base de la entidad
        /// </summary>
        public StockItem()
        {
            Stock = new Stock();
            BundleItem = new BundleItem();
            Movements = new HashSet<MovementStockItem>();
        }

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
        ///     Llave foranea de la entidad <see cref="Shopping.BundleItem"/>
        /// </summary>
        public int BundleItemId { get; set; }

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
        ///     Propiedad virtual de la llave foranea de <see cref="BundleItemId"/>
        /// </para>
        /// <para>
        ///     Indica a que elemento de lote representa
        /// </para>
        /// </summary>
        public virtual BundleItem BundleItem { get; set; }

        /// <summary>
        ///     Representa todos los movientos que sufre este elemento en este inventario
        /// </summary>
        public virtual ICollection<MovementStockItem> Movements { get; set; }

        #endregion
    }
}
