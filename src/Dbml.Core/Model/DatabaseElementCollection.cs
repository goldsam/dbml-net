using System.Collections;
using System.Collections.Generic;

namespace Dbml.Model
{
    public abstract class DatabaseElementCollection<TElement> : ICollection<TElement> where TElement : Element
    {
        protected Database Database { get; }

        protected List<TElement> Elements { get; } = new List<TElement>();

        public int Count => Elements.Count;

        public bool IsReadOnly => false;

        protected DatabaseElementCollection(Database database)
        {
            Database = database;
        }

        public void Add(TElement item)
        {
            Elements.Add(item);
        }

        public void Clear()
        {
            Elements.Clear();
        }

        public bool Contains(TElement item) => Elements.Contains(item);

        public void CopyTo(TElement[] array, int arrayIndex) => Elements.CopyTo(array, arrayIndex);

        public bool Remove(TElement item) => Elements.Remove(item);

        public IEnumerator<TElement> GetEnumerator() => Elements.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Elements.GetEnumerator();
    }
}
