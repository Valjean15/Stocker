namespace DataAccess.Context.Configurations.Common
{
    using Util.Constants;
    using Models.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de contactos
    /// </summary>
    internal class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<Currency> Builder)
        {
            Builder.ToTable(nameof(Currency), Modules.Common);
            Builder.HasKey(Currency => Currency.Id);
        }
    }
}
