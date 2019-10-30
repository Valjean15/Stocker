namespace DataAccess.Context
{
    using Microsoft.EntityFrameworkCore;
    using Models.Common;
    using Models.Contact;
    using Models.Inventory;
    using Models.Sale;
    using Models.Shopping;
    using Models.Workflow;

    /// <summary>
    ///     Contiene todos los <see cref="DbSet{TEntity}"/> de la aplicacion segmentados
    ///     por regiones de cada modulo
    /// </summary>
    public partial class StockerContext
    {
        #region Common

        /// <summary>
        ///     Repositorio de Monedas
        /// </summary>
        public DbSet<Currency> Currencies { get; set; }

        /// <summary>
        ///     Repositorio de Tasa de cambios
        /// </summary>
        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        /// <summary>
        ///     Repositorio de Sucursales
        /// </summary>
        public DbSet<Store> Stores { get; set; }

        #endregion

        #region Contact

        /// <summary>
        ///     Repositorio de Contactos
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        #endregion

        #region Inventory

        /// <summary>
        ///     Repositorio de Inventario
        /// </summary>
        public DbSet<Stock> Stocks { get; set; }

        /// <summary>
        ///     Repositorio de Items de Inventario
        /// </summary>
        public DbSet<StockItem> StockItems { get; set; }

        /// <summary>
        ///     Repositorio de Movimientos de compras inventario
        /// </summary>
        public DbSet<BundleMovement> BundleMovements { get; set; }

        /// <summary>
        ///     Repositorio de Movimientos de ventas inventario
        /// </summary>
        public DbSet<SaleMovement> SaleMovements { get; set; }

        /// <summary>
        ///     Repositorio de Movimientos de trasferencias de inventario
        /// </summary>
        public DbSet<TransferMovement> TransferMovements { get; set; }

        #endregion

        #region Sale

        /// <summary>
        ///     Repositorio de Ventas
        /// </summary>
        public DbSet<Sale> Sale { get; set; }

        /// <summary>
        ///     Repositorio de Items de venta
        /// </summary>
        public DbSet<SaleItem> SaleItems { get; set; }

        /// <summary>
        ///     Repositorio de Cuotas de las ventas
        /// </summary>
        public DbSet<SaleQuota> SaleQuotas { get; set; }

        #endregion

        #region Shopping

        /// <summary>
        ///     Repositorio de Marcas de Productos
        /// </summary>
        public DbSet<Brand> Brands { get; set; }

        /// <summary>
        ///     Repositorio de Productos
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        ///     Repositorio de Lotes
        /// </summary>
        public DbSet<Bundle> Bundles { get; set; }

        /// <summary>
        ///     Repositorio de Lotes de productos
        /// </summary>
        public DbSet<BundleItem> BundleItems { get; set; }

        #endregion

        #region Workflow

        /// <summary>
        ///     Repositorio de Flujos de trabajo
        /// </summary>
        public DbSet<Flow> Flows { get; set; }

        /// <summary>
        ///     Repositorio de los Estados del flujo de trabajo
        /// </summary>
        public DbSet<State> States { get; set; }

        /// <summary>
        ///     Repositorio de las Transiciones del flujo de trabajo
        /// </summary>
        public DbSet<Transition> Transitions { get; set; }

        /// <summary>
        ///     Repositorio del historial del flujo de trabajo
        /// </summary>
        public DbSet<FlowLog> FlowLogs { get; set; }

        #endregion
    }
}
