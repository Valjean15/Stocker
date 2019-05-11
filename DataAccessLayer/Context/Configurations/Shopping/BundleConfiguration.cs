namespace DataAccessLayer.Context.Configurations.Shopping
{
    using Models.Shopping;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla del Lotes
    /// </summary>
    internal class BundleConfiguration : IEntityTypeConfiguration<Bundle>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<Bundle> Builder)
        {
            Builder.ToTable(nameof(Bundle), "Shopping");
        }
    }
}
