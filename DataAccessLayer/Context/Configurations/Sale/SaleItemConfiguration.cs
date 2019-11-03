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
            Builder.HasKey(SaleItem => SaleItem.Id);

            Builder.HasOne(SaleItem => SaleItem.Sale)
                .WithMany(Sale => Sale.Items)
                .HasForeignKey(SaleItem => SaleItem.SaleId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(SaleItem => SaleItem.Product)
                .WithMany(Product => Product.SaleItems)
                .HasForeignKey(SaleItem => SaleItem.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
