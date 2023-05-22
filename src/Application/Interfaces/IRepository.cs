namespace Application.Interfaces
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Return a list of the type
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Get();

        /// <summary>
        /// Add a new type
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Update a type (or create with it doesn't exists)
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Delete a type
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}
