namespace DataAccess.Context.Configurations.Sale
{
    using Util.Constants;
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
            Builder.ToTable(nameof(Sale), Modules.Sale);
            Builder.HasKey(Sale => Sale.Id);

            Builder.HasOne(Sale => Sale.Currency)
                .WithMany()
                .HasForeignKey(Sale => Sale.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(Sale => Sale.State)
                .WithMany()
                .HasForeignKey(Sale => Sale.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(Sale => Sale.Contact)
                .WithOne()
                .HasForeignKey<Sale>(Sale => Sale.ContactId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(Sale => Sale.User)
                .WithMany(User => User.Sales)
                .HasForeignKey(Sale => Sale.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
