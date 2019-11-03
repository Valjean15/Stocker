namespace DataAccess.Context.Configurations.Shopping
{
    using Util.Constants;
    using Models.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla del productos
    /// </summary>
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<Product> Builder)
        {
            Builder.ToTable(nameof(Product), Modules.Common);
            Builder.HasKey(Product => Product.Id);

            Builder.HasOne(Product => Product.Brand)
                .WithMany(Brand => Brand.Products)
                .HasForeignKey(Product => Product.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(Product => Product.Currency)
                .WithMany()
                .HasForeignKey(Product => Product.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(Product => Product.State)
                .WithMany()
                .HasForeignKey(Product => Product.StateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
