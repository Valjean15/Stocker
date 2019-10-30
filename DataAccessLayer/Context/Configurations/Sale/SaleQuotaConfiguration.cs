namespace DataAccess.Context.Configurations.Sale
{
    using Util.Constants;
    using Models.Sale;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de las cuotas de la venta
    /// </summary>
    internal class SaleQuotaConfiguration : IEntityTypeConfiguration<SaleQuota>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<SaleQuota> Builder)
        {
            Builder.ToTable(nameof(SaleQuota), Modules.Sale);
            Builder.HasKey(saleQuota => saleQuota.Id);

            Builder.HasOne(saleQuota => saleQuota.Sale)
                .WithMany(sale => sale.Quotas)
                .HasForeignKey(saleQuota => saleQuota.SaleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
