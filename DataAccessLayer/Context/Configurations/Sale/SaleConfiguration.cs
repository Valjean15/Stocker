namespace DataAccessLayer.Context.Configurations.Sale
{
    using Models.Sale;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de ventas
    /// </summary>
    internal class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<Sale> Builder)
        {
            Builder.ToTable(nameof(Sale), "Sale");
        }
    }
}
