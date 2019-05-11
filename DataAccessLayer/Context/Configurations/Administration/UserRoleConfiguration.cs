namespace DataAccessLayer.Context.Configurations.Administration
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla que enlaza un usuario con un rol.
    /// </summary>
    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<String>>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<IdentityUserRole<String>> Builder)
        {
            Builder.ToTable("UserRole", "Administration");
        }
    }
}
