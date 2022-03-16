namespace Dbml.Model
{
    public class DatabaseTableCollection : DatabaseElementCollection<Table>
    {
        internal DatabaseTableCollection(Database database) : base(database)
        {
        }
    }
}