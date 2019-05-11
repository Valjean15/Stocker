namespace DataAccessLayer.Context.Configurations.Administration
{
    using Util.Constants;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de roles del sistema.
    /// </summary>
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<IdentityRole> Builder)
        {
            Builder.ToTable("Role", Modules.Administration);
        }
    }
}
