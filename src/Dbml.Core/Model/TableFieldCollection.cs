using System;
using System.Collections;
using System.Collections.Generic;

namespace Dbml.Model
{
    public class TableFieldCollection : ICollection<Field>
    {
        readonly Table _table;

        readonly List<Field> _fields = new List<Field>();

        internal TableFieldCollection(Table table)
        {
            _table = table;
        }

        public int Count => _fields.Count;

        public bool IsReadOnly => false;

        public void Add(Field item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Field item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Field[] array, int arrayIndex) => _fields.CopyTo(array, arrayIndex);

        public IEnumerator<Field> GetEnumerator() => _fields.GetEnumerator();
        
        public bool Remove(Field item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => _fields.GetEnumerator();
    }
}