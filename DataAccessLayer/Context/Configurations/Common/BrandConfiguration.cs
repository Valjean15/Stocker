namespace DataAccessLayer.Context.Configurations.Shopping
{
    using Util.Constants;
    using Models.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de las marcas
    /// </summary>
    internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<Brand> Builder)
        {
            Builder.ToTable(nameof(Brand), Modules.Common);
            Builder.HasKey(brand => brand.Id);
        }
    }
}
