namespace DataAccessLayer.Repositories.Base
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;


    /// <summary>
    /// Repositorio base para implementarse de manera génerica
    /// </summary>
    /// <typeparam name="TEntity">Entidad a interactuar</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Obtiene DatabaseSet de la entidad
        /// </summary>
        DbSet<TEntity> DbSet { get; }

        #region Operaciones Basicas

        /// <summary>
        /// Anexa entidad a base de datos
        /// </summary>
        /// <param name="entity">Entidad</param>
        void Add(TEntity entity);

        /// <summary>
        /// Elimina una entidad de base de datos
        /// </summary>
        /// <param name="entity">Entidad</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Edita una entidad
        /// </summary>
        /// <param name="entity">Entidad</param>
        void Edit(TEntity entity);

        /// <summary>
        /// Guarda una entidad
        /// </summary>
        void Save();

        #endregion

        #region Operaciones Compuestas

        /// <summary>
        /// Anexa muchas entidades
        /// </summary>
        /// <param name="entites">Entidades</param>
        void AddRange(IEnumerable<TEntity> entites);

        /// <summary>
        /// Realiza actualizacion parcial de una entidad en ciertas propiedades
        /// </summary>
        /// <param name="entity">Entidades</param>
        /// <param name="properties">Propiedades a actualizar</param>
        void Patch(TEntity entity, IEnumerable<string> properties);

        /// <summary>
        /// Elimina una entidad que contenga ciertos parametros y retorna
        /// una copia de la entidad eliminada
        /// </summary>
        /// <param name="keyValues">Valores</param>
        TEntity? Delete(params object[] keyValues);

        /// <summary>
        /// Elimina una entidad que cumpla con cierta condicion
        /// </summary>
        /// <param name="predicate">Condicion</param>
        void DeleteBy(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Busqueda

        /// <summary>
        /// Obtiene todas las entidades
        /// </summary>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Encuentra una entidad bajo una condicion
        /// </summary>
        /// <param name="predicate">Condicion</param>
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Encuentra una entidad bajo cierta condicion
        /// </summary>
        /// <param name="predicate">Condicion</param>
        TEntity? FirstBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Comprueba si existe una entidad bajo cierta condicion
        /// </summary>
        /// <param name="predicate">Condicion</param>
        bool Any(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Encuenta una entidad bajo ciertos parametros
        /// </summary>
        /// <param name="keyValues">Parametros</param>
        TEntity? FindByKey(params object[] keyValues);

        /// <summary>
        /// Obtiene la primera coincidencia de una entidad
        /// bajo cierta condicion, si no retorna el valor por defecto
        /// </summary>
        /// <param name="predicate">Condicion</param>
        TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }
}
