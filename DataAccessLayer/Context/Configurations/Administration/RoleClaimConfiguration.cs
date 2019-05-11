namespace DataAccessLayer.Context.Configurations.Administration
{
    using Util.Constants;
    using System;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla que representa un reclamo que se otorga a todos los usuarios dentro de un rol.
    /// </summary>
    internal class RoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<String>>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<String>> Builder)
        {
            Builder.ToTable("RoleClaim", Modules.Administration);
        }
    }
}
