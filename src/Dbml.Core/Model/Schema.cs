namespace Dbml.Model
{
    public class Schema
    {
        public static string DefaultSchemaName { get; } = "public";

        public string Name { get; }

        public Database Database { get; }

        public string? Note { get; set; }

        public string? Alias { get; set; }

        public Schema(string name, Database database)
        {
            Name = name;
            Database = database;
        }
    }
}