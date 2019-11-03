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
            Builder.HasKey(SaleMovement => SaleMovement.Id);

            Builder.HasOne(SaleMovement => SaleMovement.StockItem)
                .WithMany(StockItem => StockItem.SaleMovements)
                .HasForeignKey(SaleMovement => SaleMovement.StockItemId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(SaleMovement => SaleMovement.SaleItem)
                .WithMany()
                .HasForeignKey(SaleMovement => SaleMovement.SaleItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
