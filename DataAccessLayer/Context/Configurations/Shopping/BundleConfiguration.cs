namespace DataAccess.Context.Configurations.Shopping
{
    using Util.Constants;
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
            Builder.ToTable(nameof(Bundle), Modules.Shopping);
            Builder.HasKey(Bundle => Bundle.Id);

            Builder.HasOne(Bundle => Bundle.Currency)
                .WithOne()
                .HasForeignKey<Bundle>(Bundle => Bundle.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(Bundle => Bundle.State)
                .WithMany()
                .HasForeignKey(Bundle => Bundle.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(Bundle => Bundle.User)
                .WithMany(User => User.Bundles)
                .HasForeignKey(Bundle => Bundle.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
