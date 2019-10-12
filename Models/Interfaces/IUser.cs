namespace Models.Interfaces
{
    /// <summary>
    ///     Representa entidades que tienen un usuario asociado
    /// </summary>
    public interface IUser
    {
        /// <summary>
        ///     Usuario asociado a la entidad
        /// </summary>
        public string UserId { get; set; }
    }
}
