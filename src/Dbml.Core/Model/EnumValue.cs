using System;

namespace Dbml.Model
{
    public class EnumValue : Element
    {
        public string Name{ get; }

        public string? Note { get; set; }

        public Enum? ParentEnum { get; internal set; }

        public EnumValue(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}