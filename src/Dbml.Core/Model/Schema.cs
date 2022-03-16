namespace Dbml.Model
{
    public class Schema : Element
    {
        public string Name { get; }

        public Database? Database { get; internal set; }

        public string? Note { get; set; }

        public string? Alias { get; set; }

        public Schema(string name)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException(nameof(name));
            }

            Name = name;
        }
    }
}