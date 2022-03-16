namespace Dbml.Model
{
    public class Database
    {
        public Project Project { get; }

        public DatabaseTableCollection Tables { get; }

        public DatabaseEnumCollection Enums { get; }

        public DatabaseRefCollection Refs { get; }

        public TableGroupCollection TableGroups { get; }

        public SchemaCollection Schemas { get; }

        public Database(Project? project = null)
        {
            Project = project ?? new Project();

            Schemas = new SchemaCollection(this);
            Tables = new DatabaseTableCollection(this);
            Enums = new DatabaseEnumCollection(this);
            Refs = new DatabaseRefCollection(this);
            TableGroups = new TableGroupCollection(this);
        }
    }
}
