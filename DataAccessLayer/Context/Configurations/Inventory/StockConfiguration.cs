namespace DataAccessLayer.Context.Configurations.Inventory
{
    using Models.Inventory;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de inventarios
    /// </summary>
    internal class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<Stock> Builder)
        {
            Builder.ToTable(nameof(Stock), "Inventory");
        }
    }
}
