namespace Mapper.Base
{
    using Models.Interfaces;

    /// <summary>
    ///     Comportamiento de un view model
    /// </summary>
    public interface IViewModel<TEntity> where TEntity : IEntityBase<int>
    {
        /// <summary>
        ///     Forma la cual se transformara entidad a modelo que representa
        /// </summary>
        TEntity ToModel();
    }
}
