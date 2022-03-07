using System;
using System.Collections.Generic;
using System.Linq;

namespace Dbml.Model
{
    public class Enum : Element
    {
        public string Name { get; }
        
        public Schema Schema { get; }

        public string? Note { get; set; }

        readonly List<EnumValue> _values = new List<EnumValue>();

        readonly List<Field> _fields = new List<Field>();

        public Enum(string name,Schema schema, IEnumerable<string>? values = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Schema = schema ?? throw new ArgumentNullException(nameof(schema));

            if (values != null)
            {
                foreach (var value in values)
                {
                    GetOrCreateValue(value);
                }
            }
        }

        public EnumValue GetOrCreateValue(string valueName)
        {
            var value = _values.FirstOrDefault(v => string.Equals(v.Name, valueName, StringComparison.OrdinalIgnoreCase));
            if (value == null)
            {
                value = new EnumValue(valueName)
                {
                    ParentEnum = this
                };
                _values.Add(value);
            }

            return value;
        }

        public EnumValue AddValue(string valueName)
        {
            if (valueName == null)
            {
                throw new ArgumentNullException(nameof(valueName));
            }
            if (_values.Any(v => string.Equals(v.Name, valueName, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Enum value '{valueName}' is already defined", nameof(valueName));
            }

            var value = new EnumValue(valueName) { ParentEnum = this };
            _values.Add(value);
            return value;
        }
    }
}