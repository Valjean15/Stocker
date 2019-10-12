namespace DataAccessLayer.Context.Configurations.Inventory
{
    using Util.Constants;
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
            Builder.ToTable(nameof(Stock), Modules.Inventory);
            Builder.HasKey(stock => stock.Id);

            Builder.HasOne(stock => stock.Store)
                .WithMany(store => store.Stocks)
                .HasForeignKey(stock => stock.StoreId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(stock => stock.State)
                .WithMany()
                .HasForeignKey(stock => stock.StateId);
        }
    }
}
