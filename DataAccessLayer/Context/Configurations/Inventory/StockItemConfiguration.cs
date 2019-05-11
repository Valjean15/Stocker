namespace DataAccessLayer.Context.Configurations.Inventory
{
    using Models.Inventory;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de items de inventario
    /// </summary>
    internal class StockItemConfiguration : IEntityTypeConfiguration<StockItem>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<StockItem> Builder)
        {
            Builder.ToTable(nameof(StockItem), "Inventory");
        }
    }
}
