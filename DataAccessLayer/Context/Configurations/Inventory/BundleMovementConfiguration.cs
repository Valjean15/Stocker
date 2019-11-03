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
            Builder.HasKey(BundleMovement => BundleMovement.Id);

            Builder.HasOne(BundleMovement => BundleMovement.StockItem)
                .WithMany(StockItem => StockItem.BundleMovements)
                .HasForeignKey(BundleMovement => BundleMovement.StockItemId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(BundleMovement => BundleMovement.BundleItem)
                .WithMany()
                .HasForeignKey(BundleMovement => BundleMovement.BundleItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
