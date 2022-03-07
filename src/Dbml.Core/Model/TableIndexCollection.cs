using System;
using System.Collections;
using System.Collections.Generic;

namespace Dbml.Model
{
    public class TableIndexCollection : ICollection<Index>
    {
        readonly Table _table;

        readonly List<Index> _indices = new List<Index>();

        internal TableIndexCollection(Table table)
        {
            _table = table;
        }

        public int Count => _indices.Count;

        public bool IsReadOnly => false;

        public void Add(Index item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Index item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Index[] array, int arrayIndex) => _indices.CopyTo(array, arrayIndex);


        public bool Remove(Index item)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<Index> GetEnumerator() => _indices.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _indices.GetEnumerator();
    }
}