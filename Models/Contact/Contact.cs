namespace Models.Contact
{
    using Models.Enums;

    /// <summary>
    ///     Entidad de contacto, este representa a una persona
    /// </summary>
    public class Contact : EntityBase<int>
    {
        /// <summary>
        ///     Constructor base de la entidad
        /// </summary>
        public Contact()
        {
            Name = string.Empty;
            LastName = string.Empty;
            PhoneNumber = string.Empty;
            Address = string.Empty;
        }

        /// <summary>
        ///     Nombre del contacto
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Apellidos del contacto
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Numero de contacto del contactos
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        ///     Direccion del contacto
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     Tipo de contacto
        /// </summary>
        public ContactType ContactType { get; set; }

        /// <summary>
        ///     Genero del contacto
        /// </summary>
        public Gender Gender { get; set; }
    }
}
