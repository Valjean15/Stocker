namespace DataAccessLayer.Context
{
    using Microsoft.EntityFrameworkCore;
    using Configurations.Administration;
    using Configurations.Common;
    using Configurations.Contact;
    using Configurations.Sale;
    using Configurations.Shopping;
    using Configurations.Workflow;
    using Configurations.Inventory;

    /// <summary>
    ///     Contiene todas las configuraciones de las entidades
    ///     de la Base de datos
    /// </summary>
    public partial class StockerContext
    {
        /// <summary>
        ///     Método que configura las tablas de las base de datos
        /// </summary>
        /// <param name="Builder">
        ///     Configuracion usada para contruccion de tablas
        /// </param>
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);
            AdministrationModule(Builder);
            ContactModule(Builder);
            CommonModule(Builder);
            SaleModule(Builder);
            ShoppingModule(Builder);
            WorkflowModule(Builder);
            InventoryModule(Builder);
        }

        /// <summary>
        ///     Método que configura las tablas del modulo de administracion de las base de datos
        /// </summary>
        /// <param name="Builder">
        ///     Configuracion usada para construccion de tablas
        /// </param>
        private void AdministrationModule(ModelBuilder Builder)
        {
            Builder.ApplyConfiguration(new RoleClaimConfiguration());
            Builder.ApplyConfiguration(new RoleConfiguration());
            Builder.ApplyConfiguration(new UserClaimConfiguration());
            Builder.ApplyConfiguration(new UserLoginConfiguration());
            Builder.ApplyConfiguration(new UserConfiguration());
            Builder.ApplyConfiguration(new UserRoleConfiguration());
            Builder.ApplyConfiguration(new UserTokenConfiguration());
        }

        /// <summary>
        ///     Método que configura las tablas del modulo de contactos de las base de datos
        /// </summary>
        /// <param name="Builder">
        ///     Configuracion usada para construccion de tablas
        /// </param>
        private void ContactModule(ModelBuilder Builder)
        {
            Builder.ApplyConfiguration(new ContactConfiguration());
        }

        /// <summary>
        ///     Método que configura las tablas del modulo de comun de las base de datos
        /// </summary>
        /// <param name="Builder">
        ///     Configuracion usada para construccion de tablas
        /// </param>
        private void CommonModule(ModelBuilder Builder)
        {
            Builder.ApplyConfiguration(new ExchangeRateConfiguration());
            Builder.ApplyConfiguration(new CurrencyConfiguration());
            Builder.ApplyConfiguration(new StoreConfiguration());
        }

        /// <summary>
        ///     Método que configura las tablas del modulo de ventas de las base de datos
        /// </summary>
        /// <param name="Builder">
        ///     Configuracion usada para construccion de tablas
        /// </param>
        private void SaleModule(ModelBuilder Builder)
        {
            Builder.ApplyConfiguration(new SaleItemConfiguration());
            Builder.ApplyConfiguration(new SaleQuotaConfiguration());
            Builder.ApplyConfiguration(new SaleConfiguration());
        }

        /// <summary>
        ///     Método que configura las tablas del modulo de compras de las base de datos
        /// </summary>
        /// <param name="Builder">
        ///     Configuracion usada para construccion de tablas
        /// </param>
        private void ShoppingModule(ModelBuilder Builder)
        {
            Builder.ApplyConfiguration(new BrandConfiguration());
            Builder.ApplyConfiguration(new BundleConfiguration());
            Builder.ApplyConfiguration(new BundleItemConfiguration());
            Builder.ApplyConfiguration(new ProductConfiguration());
        }

        /// <summary>
        ///     Método que configura las tablas del moduulo de workflow de las base de datos
        /// </summary>
        /// <param name="Builder">
        ///     Configuracion usada para construccion de tablas
        /// </param>
        private void WorkflowModule(ModelBuilder Builder)
        {
            Builder.ApplyConfiguration(new FlowConfiguration());
            Builder.ApplyConfiguration(new FlowLogConfiguration());
            Builder.ApplyConfiguration(new StateConfiguration());
            Builder.ApplyConfiguration(new TransitionConfiguration());
        }

        /// <summary>
        ///     Método que configura las tablas del moduulo de inventario de las base de datos
        /// </summary>
        /// <param name="Builder">
        ///     Configuracion usada para construccion de tablas
        /// </param>
        private void InventoryModule(ModelBuilder Builder)
        {
            Builder.ApplyConfiguration(new MovementStockItemConfiguration());
            Builder.ApplyConfiguration(new StockConfiguration());
            Builder.ApplyConfiguration(new StockItemConfiguration());
        }
    }
}
