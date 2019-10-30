namespace DataAccess.Context.Configurations.Sale
{
    using Util.Constants;
    using Models.Sale;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de items de ventas
    /// </summary>
    internal class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<SaleItem> Builder)
        {
            Builder.ToTable(nameof(SaleItem), Modules.Sale);
            Builder.HasKey(saleItem => saleItem.Id);

            Builder.HasOne(saleItem => saleItem.Sale)
                .WithMany(sale => sale.Items)
                .HasForeignKey(saleItem => saleItem.SaleId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(saleItem => saleItem.Product)
                .WithMany(product => product.SaleItems)
                .HasForeignKey(saleItem => saleItem.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
