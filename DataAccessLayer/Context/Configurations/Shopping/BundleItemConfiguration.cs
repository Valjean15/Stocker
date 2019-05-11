namespace DataAccessLayer.Context.Configurations.Shopping
{
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
            Builder.ToTable(nameof(BundleItem), "Shopping");
        }
    }
}
