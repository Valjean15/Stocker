namespace DataAccessLayer.Context.Configurations.Sale
{
    using Util.Constants;
    using Models.Sale;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de ventas
    /// </summary>
    internal class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<Sale> Builder)
        {
            Builder.ToTable(nameof(Sale), Modules.Sale);
            Builder.HasKey(sale => sale.Id);

            Builder.HasOne(sale => sale.Currency)
                .WithMany()
                .HasForeignKey(sale => sale.CurrencyId);

            Builder.HasOne(sale => sale.State)
                .WithMany()
                .HasForeignKey(sale => sale.StateId);
        }
    }
}
