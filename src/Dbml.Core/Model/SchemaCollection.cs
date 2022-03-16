using System;
using System.Linq;

namespace Dbml.Model
{
    public class SchemaCollection : DatabaseElementCollection<Schema>
    {
        public string DefaultSchemaName { get; set; } = "public";

        internal SchemaCollection(Database database) : base(database)
        {
        }

        public Schema GetOrCreateSchema(string schemaName)
        {
            if (schemaName == null)
            {
                throw new ArgumentNullException(nameof(schemaName));
            }

            var schema = Elements.FirstOrDefault(s => string.Equals(schemaName, s.Name, StringComparison.OrdinalIgnoreCase));
            if (schema == null)
            {
                schema = new Schema(schemaName)
                {
                    Note = string.Equals(schemaName, DefaultSchemaName, StringComparison.OrdinalIgnoreCase)
                        ? $"Default {DefaultSchemaName.ToUpper()} Schema"
                        : null
                };
                Elements.Add(schema);
            }

            return schema;
        }

        public bool HasDefaultSchema => Elements.Any(s => string.Equals(s.Name, DefaultSchemaName, StringComparison.OrdinalIgnoreCase));
    }
}
