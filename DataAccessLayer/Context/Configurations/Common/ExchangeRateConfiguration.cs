namespace DataAccessLayer.Context.Configurations.Common
{
    using Util.Constants;
    using Models.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de tasa de cambios
    /// </summary>
    internal class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<ExchangeRate> Builder)
        {
            Builder.ToTable(nameof(ExchangeRate), Modules.Common);
            Builder.HasKey(exchangeRate => exchangeRate.Id);

            Builder.HasOne(exchangeRate => exchangeRate.Currency)
                .WithMany(currency => currency.ExchangesRates)
                .HasForeignKey(exchangeRate => exchangeRate.CurrencyId);
        }
    }
}
