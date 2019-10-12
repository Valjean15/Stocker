namespace DataAccessLayer.Context.Configurations.Shopping
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
            Builder.HasKey(bundleItem => bundleItem.Id);

            Builder.HasOne(bundleItem => bundleItem.Currency)
                .WithOne()
                .HasForeignKey<BundleItem>(bundleItem => bundleItem.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(bundleItem => bundleItem.Bundle)
                .WithMany(bundle => bundle.Items)
                .HasForeignKey(bundleItem => bundleItem.BundleId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(bundleItem => bundleItem.Product)
                .WithMany(product => product.BundleItems)
                .HasForeignKey(bundleItem => bundleItem.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
