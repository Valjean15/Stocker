namespace Models.Administration
{
    using System.Collections.Generic;
    using Models.Interfaces;
    using Models.Sale;
    using Models.Shopping;

    /// <summary>
    ///     Usuario del sistema
    /// </summary>
    public class User : Microsoft.AspNetCore.Identity.IdentityUser, IEntityBase<string>
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
        public bool Equals(IEntityBase<string> Other) => Other?.Id.Equals(Id) ?? false;

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
            return (obj is IEntityBase<string> ObjParsed) && Equals(ObjParsed);
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
        public override string ToString() => Id;

        #region Virtual Properties

        /// <summary>
        ///     Todas las ventas asociadas a un usuario
        /// </summary>
        public virtual ICollection<Sale> Sales { get; set; }

        /// <summary>
        ///     Todos los lotes asoaciados a un usuario
        /// </summary>
        public virtual ICollection<Bundle> Bundles { get; set; }

        #endregion
    }
}
