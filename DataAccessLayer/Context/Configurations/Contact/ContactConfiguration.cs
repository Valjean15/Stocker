namespace DataAccess.Context.Configurations.Contact
{
    using Util.Constants;
    using Models.Contact;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de contactos
    /// </summary>
    internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<Contact> Builder)
        {
            Builder.ToTable(nameof(Contact), Modules.Contact);
            Builder.HasKey(contact => contact.Id);
        }
    }
}
