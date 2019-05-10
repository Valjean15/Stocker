namespace DataAccessLayer.Context
{
    using Microsoft.EntityFrameworkCore;
    using Configurations.Administration;

    /// <summary>
    ///     Contiene todas las configuraciones de las entidades
    ///     de la Base de datos
    /// </summary>
    partial class StockerContext
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
        }

        /// <summary>
        ///     Método que configura las tablas del moduulo de administracion de las base de datos
        /// </summary>
        /// <param name="Builder">
        ///     Configuracion usada para contruccion de tablas
        /// </param>
        private void AdministrationModule(ModelBuilder Builder)
        {
            Builder.ApplyConfiguration(new UserConfiguration());
        }

        /// <summary>
        ///     Método que configura las tablas del moduulo de administracion de las base de datos
        /// </summary>
        /// <param name="Builder">
        ///     Configuracion usada para contruccion de tablas
        /// </param>
        private void ContactModule(ModelBuilder Builder)
        {

        }

        /// <summary>
        ///     Método que configura las tablas del moduulo de administracion de las base de datos
        /// </summary>
        /// <param name="Builder">
        ///     Configuracion usada para contruccion de tablas
        /// </param>
        private void CommonModule(ModelBuilder Builder)
        {

        }

        /// <summary>
        ///     Método que configura las tablas del moduulo de administracion de las base de datos
        /// </summary>
        /// <param name="Builder">
        ///     Configuracion usada para contruccion de tablas
        /// </param>
        private void SaleModule(ModelBuilder Builder)
        {

        }

        /// <summary>
        ///     Método que configura las tablas del moduulo de administracion de las base de datos
        /// </summary>
        /// <param name="Builder">
        ///     Configuracion usada para contruccion de tablas
        /// </param>
        private void ShoppingModule(ModelBuilder Builder)
        {

        }

        /// <summary>
        ///     Método que configura las tablas del moduulo de administracion de las base de datos
        /// </summary>
        /// <param name="Builder">
        ///     Configuracion usada para contruccion de tablas
        /// </param>
        private void WorkflowModule(ModelBuilder Builder)
        {

        }
    }
}
