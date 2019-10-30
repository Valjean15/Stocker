namespace DataAccess.Context.Configurations.Administration
{
    using Util.Constants;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models.Administration;

    /// <summary>
    ///     Configuraciones de la tabla de Usuarios
    /// </summary>
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<User> Builder)
        {
            Builder.ToTable(nameof(User), Modules.Administration);
        }
    }
}
