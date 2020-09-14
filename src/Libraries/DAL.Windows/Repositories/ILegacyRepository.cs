using System.Linq;
using System.Collections.Generic;

namespace DAL.Windows.Repositories
{
    /// <summary>
    /// Repository to handle data access operations on legacy database
    /// </summary>
    /// <typeparam name="T">The entity representing the table</typeparam>
    public interface ILegacyRepository<T>
    {

        /// <summary>
        /// Query for a entity with the given Id
        /// </summary>
        /// <param name="id">the integer id to search</param>
        /// <returns></returns>
        T GetById(int id);
        /// <summary>
        /// Query for a entity with the given Id
        /// </summary>
        /// <param name="id">the id to search, in this case a string id, like a barcode</param>
        /// <returns>Entity with given id</returns>
        T GetById(string id);
        /// <summary>
        /// Inserts entity in the database
        /// </summary>
        /// <param name="entry">the entry to be inserted</param>
        long Add(T entry);
        /// <summary>
        /// Delete a entry from the database
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        bool Delete(T entry);
        /// <summary>
        /// Update a entry in the database
        /// </summary>
        /// <param name="entry">the entry object</param>
        /// <returns></returns>
        bool Update(T entry);
        /// <summary>
        /// executes SQL query on database and return result in entity object
        /// </summary>
        /// <param name="query">the sql query to be executed</param>
        /// <returns>a entity from the query execution</returns>
        T RawSqlQuery(string query);
        /// <summary>
        /// executes SQL query on database and return a list of entities
        /// </summary>
        /// <param name="query">the sql query to be executed</param>
        /// <returns>a IEnumerable of the entity type</returns>
        IEnumerable<T> MultipleFromRawSqlQuery(string query);
        IQueryable<T> QueryableByRawQuery(string query);
        IQueryable<T> QueryableByRawQuery();
        /// <summary>
        /// executes a command query on the databases in the given entity table
        /// </summary>
        /// <param name="query">the query to be executed</param>
        /// <param name="entity">the entity to apply the command query</param>
        void Command(string query,T entity);
        //TODO:For now it's not needed, but a delete method would be good        
    }
}