using System;

namespace Dbml.Model
{
    public class Index : Element
    {
        public string? Name { get; }

        public string Type { get; }

        public bool Unique { get; set; }

        public bool PrimaryKey { get; set; }

        public string? Note { get; set; }

        public Table? Table { get; internal set; }

        public IndexColumnCollection Columns { get; }
        
        public Index(string name, string type)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type ?? throw new ArgumentNullException(nameof(type));

            Columns = new IndexColumnCollection(this);
        }
    }
}
