using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingExample.DataMappers
{
    public class IdentityMap<T> where T : class
    {
        //  Identity Map for Employees: use dictionary as keyed access is fast, of order O
        private Dictionary<int, T> _entities;

        /// <summary>
        /// Constructor
        /// </summary>
        public IdentityMap()
        {
            _entities = new Dictionary<int, T>();
        }

        /// <summary>
        /// Determines if the key exists in the Identity Map
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Contains(int id)
        {
            if (_entities.ContainsKey(id))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get the entity by its key, returns NULL if not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            if (_entities.ContainsKey(id))
                return (T)_entities[id];
            else
                return null;
                //return default(T);
        }

        /// <summary>
        /// Stores the entity within the Identity Map
        /// </summary>
        /// <param name="key"></param>
        /// <param name="entity"></param>
        public void Store(int key, T entity)
        {
            if (!_entities.ContainsKey(key))
                _entities.Add(key, entity);
        }

    }
}
