namespace DataAccess.Context.Configurations.Shopping
{
    using Util.Constants;
    using Models.Shopping;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de los items de un lote
    /// </summary>
    internal class BundleItemConfiguration : IEntityTypeConfiguration<BundleItem>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<BundleItem> Builder)
        {
            Builder.ToTable(nameof(BundleItem), Modules.Shopping);
            Builder.HasKey(BundleItem => BundleItem.Id);

            Builder.HasOne(BundleItem => BundleItem.Currency)
                .WithOne()
                .HasForeignKey<BundleItem>(BundleItem => BundleItem.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(BundleItem => BundleItem.Bundle)
                .WithMany(Bundle => Bundle.Items)
                .HasForeignKey(BundleItem => BundleItem.BundleId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(BundleItem => BundleItem.Product)
                .WithMany(Product => Product.BundleItems)
                .HasForeignKey(BundleItem => BundleItem.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
