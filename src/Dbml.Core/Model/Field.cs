using System;

namespace Dbml.Model
{
    public class Field : Element
    {
        public string Name { get; }
        
        public string TypeName { get; }

        public Table? Table { get; internal set; }

        public bool Unique { get; set; }
        
        public bool PrimaryKey { get; set; }
        
        public bool NotNull { get; set; }

        public string? Note { get; set; }

        public object? DbDefault { get; set; }

        public bool Increment { get; set; }

        public Field(string name, string type)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            TypeName = type ?? throw new ArgumentNullException(nameof(type));
        }
    }
}