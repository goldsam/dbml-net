using System;

namespace Dbml.Model
{
    public class IndexColumn
    {
        public Index? ParentIndex { get; internal set;}

        public string Value { get; set; }

        public IndexColumnType Type { get; set; }
        
        public IndexColumn(string name)
        {
            Value = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}