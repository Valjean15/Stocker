namespace Models
{
    using System;
    using Models.Interfaces;

    /// <summary>
    ///     Implementacion de la base que utilizan todos los modelos de la base de datos.
    /// </summary>
    /// <typeparam name="TKey">
    ///     Tipo de que representa el Id de la entidad
    /// </typeparam>
    public abstract class EntityBase<TKey> : IEntityBase<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     Id único de la entidad
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        ///     Comparador personalizado para poder comparar directamente con los Id
        /// </summary>
        /// <param name="Other">
        ///     Objeto con el que se va a comparar
        /// </param>
        /// <returns>
        ///     Regresa true, si ambas entidades tienen el mismo Id, en caso contrario false
        /// </returns>
        public bool Equals(IEntityBase<TKey> Other) => Other?.Id.Equals(Id) ?? false;

        /// <summary>
        ///     Comparador personalizado para poder comparar directamente con los Id
        /// </summary>
        /// <param name="obj">
        ///     Objeto con el que se va a comparar
        /// </param>
        /// <returns>
        ///     Regresa true, si ambas entidades tienen el mismo Id, en caso contrario false
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            return (obj is IEntityBase<TKey> ObjParsed) && Equals(ObjParsed);
        }

        /// <summary>
        ///     Obtiene el código hash del Id
        /// </summary>
        /// <returns>
        ///     Regresa el código hash del Id
        /// </returns>
        public override int GetHashCode() => Id.GetHashCode();

        /// <summary>
        ///     Regresa el Id del objeto transformado en un string
        /// </summary>
        /// <returns>
        ///     Regresa el Id del objeto transformado en un string
        /// </returns>
        public override string ToString() => Id.ToString();
    }
}
