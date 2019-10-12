namespace DataAccessLayer.Context.Configurations.Shopping
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
            Builder.HasKey(product => product.Id);

            Builder.HasOne(product => product.Brand)
                .WithMany(brand => brand.Products)
                .HasForeignKey(product => product.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(product => product.Currency)
                .WithOne()
                .HasForeignKey<Product>(product => product.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(product => product.State)
                .WithOne()
                .HasForeignKey<Product>(product => product.StateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
