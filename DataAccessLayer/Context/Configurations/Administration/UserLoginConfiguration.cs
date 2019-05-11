namespace DataAccessLayer.Context.Configurations.Administration
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de inicio de seción de usuario con su proveedor asociado.
    /// </summary>
    internal class UserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<String>>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<IdentityUserLogin<String>> Builder)
        {
            Builder.ToTable("UserLogin", "Administration");
        }
    }
}
