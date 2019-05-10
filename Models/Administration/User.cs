namespace Models.Administration
{
    using Microsoft.AspNetCore.Identity;
    using System;

    /// <summary>
    ///     Usuario del sistema
    /// </summary>
    public class User : IdentityUser, IEntityBase<String>
    {
        /// <summary>
        ///     Comparador personalizado para poder comparar directamente con los Id
        /// </summary>
        /// <param name="Other">
        ///     Objeto con el que se va a comparar
        /// </param>
        /// <returns>
        ///     Regresa true, si ambas entidades tienen el mismo Id, en caso contrario false
        /// </returns>
        public bool Equals(IEntityBase<String> Other) => Other?.Id.Equals(Id) ?? false;

        /// <summary>
        ///     Comparador personalizado para poder comparar directamente con los Id
        /// </summary>
        /// <param name="Obj">
        ///     Objeto con el que se va a comparar
        /// </param>
        /// <returns>
        ///     Regresa true, si ambas entidades tienen el mismo Id, en caso contrario false
        /// </returns>

        public override bool Equals(object Obj) => Equals(Obj as IEntityBase<String>);

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
        public override string ToString() => Id;
    }
}
