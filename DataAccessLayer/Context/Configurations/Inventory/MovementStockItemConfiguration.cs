namespace DataAccessLayer.Context.Configurations.Inventory
{
    using Util.Constants;
    using Models.Inventory;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de los movimientos de los items de inventario
    /// </summary>
    internal class MovementStockItemConfiguration : IEntityTypeConfiguration<MovementStockItem>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<MovementStockItem> Builder)
        {
            Builder.ToTable(nameof(MovementStockItem), Modules.Inventory);
            Builder.HasKey(movementStockItem => movementStockItem.Id);

            Builder.HasOne(movementStockItem => movementStockItem.StockItem)
                .WithMany(stockItem => stockItem.Movements)
                .HasForeignKey(movementStockItem => movementStockItem.StockItemId);
        }
    }
}
