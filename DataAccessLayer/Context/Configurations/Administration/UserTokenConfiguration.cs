namespace DataAccessLayer.Context.Configurations.Administration
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de tokens de autenticación usados para el usuario.
    /// </summary>
    internal class UserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<String>>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<IdentityUserToken<String>> Builder)
        {
            Builder.ToTable("UserToken", "Administration");
        }
    }
}
