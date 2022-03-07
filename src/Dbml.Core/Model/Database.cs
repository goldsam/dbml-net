using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dbml.Model
{
    public class DatabaseEnumCollection : ICollection<Enum>
    {
        readonly Database _database;

        readonly List<Enum> _enums = new List<Enum>();

        public int Count => _enums.Count;

        public bool IsReadOnly => false;

        public DatabaseEnumCollection(Database database)
        {
            _database = database;
        }

        public void Add(Enum item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Enum item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Enum[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        
        public bool Remove(Enum item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Enum> GetEnumerator() => _enums.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _enums.GetEnumerator();
    }

    public class Database
    {
        public Project Project { get; }

        public DatabaseTableCollection Tables { get; }

        readonly List<Schema> _schemas = new List<Schema>();
        
        readonly List<Enum> _enums = new List<Enum>();
        readonly List<Ref> _refs = new List<Ref>();
        readonly List<TableGroup> _tableGroups = new List<TableGroup>();

        public IReadOnlyList<Schema> Schemas => _schemas.AsReadOnly();
        

        public Database(Project? project = null)
        {
            Project = project ?? new Project();

            Tables = new DatabaseTableCollection(this);
        }

        public Schema GetOrCreateSchema(string schemaName)
        {
            if (schemaName == null)
            {
                throw new ArgumentNullException(nameof(schemaName));
            }

            var schema = _schemas.FirstOrDefault(s => string.Equals(schemaName, s.Name, StringComparison.OrdinalIgnoreCase));
            if (schema == null)
            {
                schema = new Schema(schemaName, this)
                {
                    Note = string.Equals(schemaName, Schema.DefaultSchemaName, StringComparison.OrdinalIgnoreCase)
                        ? $"Default {Schema.DefaultSchemaName.ToUpper()} Schema"
                        : null
                };
                _schemas.Add(schema);
            }

            return schema;
        }

        public bool HasDefaultSchema => 
            _schemas.Any(s => string.Equals(s.Name, Schema.DefaultSchemaName, StringComparison.OrdinalIgnoreCase));

    }
}