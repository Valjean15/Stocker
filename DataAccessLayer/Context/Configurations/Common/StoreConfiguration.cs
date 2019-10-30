namespace DataAccess.Context.Configurations.Common
{
    using Util.Constants;
    using Models.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de Sucursales
    /// </summary>
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<Store> Builder)
        {
            Builder.ToTable(nameof(Store), Modules.Common);
            Builder.HasKey(store => store.Id);
        }
    }
}
