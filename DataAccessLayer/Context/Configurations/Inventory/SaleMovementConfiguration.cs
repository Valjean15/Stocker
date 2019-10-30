namespace DataAccess.Context.Configurations.Inventory
{
    using Util.Constants;
    using Models.Inventory;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de los movimientos de ventas
    /// </summary>
    internal class SaleMovementConfiguration : IEntityTypeConfiguration<SaleMovement>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<SaleMovement> Builder)
        {
            Builder.ToTable(nameof(SaleMovement), Modules.Inventory);
            Builder.HasKey(saleMovement => saleMovement.Id);

            Builder.HasOne(saleMovement => saleMovement.StockItem)
                .WithMany(stockItem => stockItem.SaleMovements)
                .HasForeignKey(saleMovement => saleMovement.StockItemId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(saleMovement => saleMovement.SaleItem)
                .WithMany()
                .HasForeignKey(saleMovement => saleMovement.SaleItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
