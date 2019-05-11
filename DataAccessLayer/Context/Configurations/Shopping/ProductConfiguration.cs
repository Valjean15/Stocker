namespace DataAccessLayer.Context.Configurations.Shopping
{
    using Util.Constants;
    using Models.Shopping;
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
            Builder.ToTable(nameof(Product), Modules.Shopping);
            Builder.HasKey(product => product.Id);

            Builder.HasOne(product => product.Brand)
                .WithMany(brand => brand.Products)
                .HasForeignKey(product => product.BrandId);

            Builder.HasOne(product => product.Currency)
                .WithOne()
                .HasForeignKey<Product>(product => product.CurrencyId);
        }
    }
}
