namespace Models
{
    using System;

    /// <summary>
    ///     Clase base que utilizan todos los modelos de la base de datos
    /// </summary>
    /// <typeparam name="TKey">
    ///     Tipo de que representa el Id de la entidad
    /// </typeparam>
    public interface IEntityBase<TKey> : IEquatable<IEntityBase<TKey>> where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     Id único de la entidad
        /// </summary>
        TKey Id { get; set; }
    }
}
