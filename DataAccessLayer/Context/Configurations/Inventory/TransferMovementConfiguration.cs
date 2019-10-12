namespace DataAccessLayer.Context.Configurations.Inventory
{
    using Util.Constants;
    using Models.Inventory;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de los movimientos de transferencias
    /// </summary>
    internal class TransferMovementConfiguration : IEntityTypeConfiguration<TransferMovement>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<TransferMovement> Builder)
        {
            Builder.ToTable(nameof(TransferMovement), Modules.Inventory);
            Builder.HasKey(transferMovement => transferMovement.Id);

            Builder.HasOne(transferMovement => transferMovement.StockItem)
                .WithMany(stockItem => stockItem.TransferMovements)
                .HasForeignKey(transferMovement => transferMovement.StockItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
