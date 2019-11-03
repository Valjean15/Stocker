namespace DataAccess.Context.Configurations.Inventory
{
    using Util.Constants;
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
            Builder.ToTable(nameof(StockItem), Modules.Inventory);
            Builder.HasKey(StockItem => StockItem.Id);

            Builder.HasOne(StockItem => StockItem.Product)
                .WithMany(Product => Product.StockItems)
                .HasForeignKey(StockItem => StockItem.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(StockItem => StockItem.Stock)
                .WithMany(Stock => Stock.Items)
                .HasForeignKey(StockItem => StockItem.StockId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
