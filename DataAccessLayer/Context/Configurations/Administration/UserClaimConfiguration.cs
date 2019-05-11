namespace DataAccessLayer.Context.Configurations.Administration
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de reclamaciones que el usuario posee.
    /// </summary>
    internal class UserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<String>>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<IdentityUserClaim<String>> Builder)
        {
            Builder.ToTable("UserClaim", "Administration");
        }
    }
}
