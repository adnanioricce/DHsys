using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    /// <summary>
    /// handles mappings from legacy domain model data to current model data
    /// </summary>
    /// <typeparam name="T">the target type </typeparam>
    /// <typeparam name="TLegacy">the legacy type to be mapped</typeparam>
    public interface ILegacyDataMapper<T,TLegacy>
    {
        /// <summary>
        /// Persist the legacy models on dbf tables to current database. The methods adds a integer Id and permits the model to be used on domain Repository
        /// </summary>
        void SaveLegacyModelOnDatabase(string tableName);
        /// <summary>
        /// Maps legacy entity model object to actual domain model 
        /// </summary>
        /// <param name="legacyEntity">the entity with legacy model</param>
        /// <returns>a entity on the current domain model</returns>
        T MapToDomainModel(TLegacy legacyEntity);
        /// <summary>
        /// Maps legacy table from dbf database to actual domain model entity 
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns>Collection of entities mapped from legacy table</returns>
        IEnumerable<T> MapTable(string tableName);
        IEnumerable<T> GetChanges(string tableName);
        
    }
}
