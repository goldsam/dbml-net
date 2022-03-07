using System;

namespace Dbml.Model
{
    public class Ref : Element
    {
        public string Name { get; }

        public Schema Schema { get; }

        public Endpoint? Endpoint1 { get; set; }

        public Endpoint? Endpoint2 { get; set; }

        public Ref(string name, Schema schema)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }
    }
}