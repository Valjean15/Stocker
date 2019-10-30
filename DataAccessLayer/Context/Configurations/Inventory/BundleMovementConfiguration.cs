namespace DataAccess.Context.Configurations.Inventory
{
    using Util.Constants;
    using Models.Inventory;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de los movimientos de compras
    /// </summary>
    internal class BundleMovementConfiguration : IEntityTypeConfiguration<BundleMovement>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<BundleMovement> Builder)
        {
            Builder.ToTable(nameof(BundleMovement), Modules.Inventory);
            Builder.HasKey(bundleMovement => bundleMovement.Id);

            Builder.HasOne(bundleMovement => bundleMovement.StockItem)
                .WithMany(stockItem => stockItem.BundleMovements)
                .HasForeignKey(bundleMovement => bundleMovement.StockItemId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(bundleMovement => bundleMovement.BundleItem)
                .WithMany()
                .HasForeignKey(bundleMovement => bundleMovement.BundleItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
