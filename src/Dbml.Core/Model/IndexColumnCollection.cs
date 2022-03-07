using System;
using System.Collections;
using System.Collections.Generic;

namespace Dbml.Model
{
    public class IndexColumnCollection : ICollection<IndexColumn>
    {
        readonly Index _index;

        readonly List<IndexColumn> _columns = new List<IndexColumn>();

        internal IndexColumnCollection(Index index)
        {
            _index= index;
        }

        public int Count => _columns.Count;

        public bool IsReadOnly => false;

        public void Add(IndexColumn indexColumn)
        {
            if (indexColumn == null)
            {
                throw new ArgumentNullException(nameof(indexColumn));
            }

            if (indexColumn.ParentIndex != _index)
            {
                return;
            }
            else if (indexColumn.ParentIndex != null)
            {
                throw new ArgumentException("IndexColumn has already been added to another Index.", nameof(indexColumn));
            }

            _columns.Add(indexColumn);
            indexColumn.ParentIndex = _index;
        }

        public void Clear()
        {
            _columns.ForEach(c => c.ParentIndex = null);
            _columns.Clear();
        }

        public bool Contains(IndexColumn indexColumn) => indexColumn.ParentIndex == _index;

        public void CopyTo(IndexColumn[] array, int arrayIndex) => _columns.CopyTo(array, arrayIndex);

        public bool Remove(IndexColumn indexColumn)
        {
            if (indexColumn == null)
            {
                throw new ArgumentNullException(nameof(indexColumn));
            }

            if (indexColumn.ParentIndex != _index)
            {
                return false;
            }

            indexColumn.ParentIndex = null;
            return _columns.Remove(indexColumn);
        }

        public IEnumerator<IndexColumn> GetEnumerator() => _columns.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _columns.GetEnumerator();
    }
}
