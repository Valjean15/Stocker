namespace DataAccessLayer.Context.Configurations.Administration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models.Administration;

    /// <summary>
    ///     Configuraciones de la tabla de Roles
    /// </summary>
    internal class RoleClaimConfiguration
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<User> Builder)
        {
        }
    }
}
