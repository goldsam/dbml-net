using System;
using System.Collections.Generic;

namespace Dbml.Model
{
    public class Table : Element
    {
        public string Name { get; }
        
        public Schema Schema { get; }

        public string? Alias { get; set; }

        public string? Note { get; set; }

        public TableFieldCollection Fields { get; } 

        public TableIndexCollection Indices { get; }
        
        public Table(string name, Schema schema) 
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Schema = schema ?? throw new ArgumentNullException(nameof(schema));

            Fields = new TableFieldCollection(this);
            Indices = new TableIndexCollection(this);
        }
    }
}