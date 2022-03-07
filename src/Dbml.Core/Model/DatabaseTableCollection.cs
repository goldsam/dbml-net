using System;
using System.Collections;
using System.Collections.Generic;

namespace Dbml.Model
{
    public class DatabaseTableCollection : ICollection<Table>
    {
        readonly Database _database;

        readonly List<Table> _tables = new List<Table>();

        internal DatabaseTableCollection(Database database)
        {
            _database = database;
        }

        public int Count => _tables.Count;

        public bool IsReadOnly => false;

        public void Add(Table item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Table item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Table[] array, int arrayIndex) => _tables.CopyTo(array, arrayIndex);

        
        public bool Remove(Table item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Table> GetEnumerator() => _tables.GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}