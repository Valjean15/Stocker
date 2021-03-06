﻿namespace DataAccess.Context.Configurations.Common
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
            Builder.HasKey(ExchangeRate => ExchangeRate.Id);

            Builder.HasOne(ExchangeRate => ExchangeRate.Currency)
                .WithMany(Currency => Currency.ExchangesRates)
                .HasForeignKey(ExchangeRate => ExchangeRate.CurrencyId);
        }
    }
}
