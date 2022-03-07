using System.Collections.Generic;

namespace Dbml.Model
{
    public class Endpoint : Element
    {
        readonly List<Field> _fields = new List<Field>();

        public string SchemaName { get; }

        public string TableName { get; }

        //public string FieldNames { get; }

        public Ref Ref { get; }

        public Endpoint(string schemaName, string tableName, string fieldNames, Ref ref_)
        {
            SchemaName = schemaName;
            TableName = tableName;
          //  FieldNames = fieldNames;
            Ref = ref_;
        }
    }
}