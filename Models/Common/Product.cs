namespace Models.Common
{
    using Models.Interfaces;
    using Models.Inventory;
    using Models.Sale;
    using Models.Shopping;
    using Models.Workflow;
    using System.Collections.Generic;

    /// <summary>
    ///     Entidad que representa un item de compra
    /// </summary>
    public class Product : EntityBase<int>, IWorkflowState
    {
        /// <summary>
        ///     Construtor base de la entidad
        /// </summary>
        public Product()
        {
            Name = string.Empty;
        }

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
        ///     LLave foranea de la entidad <see cref="Brand"/>
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Common.Currency"/>
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Common.Currency"/>
        /// </summary>
        public int StateId { get; set; }

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

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="StateId"/>
        /// </para>
        /// <para>
        ///     Indica el estado actual del producto
        /// </para>
        /// </summary>
        public virtual State State { get; set; }

        /// <summary>
        ///     Todos los items de compra asociados a este producto
        /// </summary>
        public virtual ICollection<BundleItem> BundleItems { get; set; }

        /// <summary>
        ///     Todos los items de ventas asociados a este producto
        /// </summary>
        public virtual ICollection<SaleItem> SaleItems { get; set; }

        /// <summary>
        ///     Todos los items de inventario asociados a este producto
        /// </summary>
        public virtual ICollection<StockItem> StockItems { get; set; }

        #endregion
    }
}
