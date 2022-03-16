using Dbml.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dbml.Export
{
    public class DbmlExporter : IExporter
    {
        public void Export(Stream stream, Database model)
        {
            using (var writer = new StreamWriter(stream))
            {
                Export(writer, model);
            }
        }

        public void Export(TextWriter writer, Database model)
        {
            foreach (var schema in model.Schemas)
            {
                // Write enums

                // write tables
                ExportTables(writer, model, schema);

                // Write table groups

                // Write refs
                ExportRefs(writer, model, schema);                    
            }
        }

        void ExportTables(TextWriter writer, Database model, Schema schema)
        {
            foreach (var table in model.Tables.Where(t => t.Schema == schema))
            {
                ExportTable(writer, model, table);
            }
        }

        void ExportTable(TextWriter writer, Database model, Table table)
        {
            writer.Write("Table ");

            var schema = table.Schema;
            if (ShouldWriteSchemaName(schema, model))
            {
                writer.Write("\"");
                writer.Write(schema.Name);
                writer.Write("\".");
            }

            writer.Write("\"");
            writer.Write(table.Name);
            writer.Write("\"");

            // TODO: Table content
            

            writer.WriteLine(" {");
            foreach (var field in table.Fields)
            {   
                ExportField(writer, model, field);
            }

            if (table.Indices.Any())
            {
                writer.WriteLine("  indexes {");

                foreach (var index in table.Indices)
                {
                    ExportTableIndex(writer, model, index);
                }

                writer.WriteLine("  }");
            }
            
            writer.WriteLine('}');
        }

        void ExportField(TextWriter writer, Database model, Field field)
        {
            writer.Write("    \"");
            writer.Write(field.Name);
            writer.Write("\" ");

            if (NameRequiresQuotes(field.TypeName))
            {
                writer.Write('"');
                writer.Write(field.TypeName);
                writer.Write('"');
            }
            else
            {
                writer.Write(field.TypeName);
            }

            bool firstConstraint = true;

            if (field.Unique)
            {
                writer.Write(" [unique");
                firstConstraint = false;
            }

            if (field.PrimaryKey)
            {
                writer.Write(firstConstraint ? " [pk" : ", pk");
                firstConstraint = false;
            }

            if (field.NotNull)
            {
                writer.Write(firstConstraint ? " [not null" : ", not null");
                firstConstraint = false;
            }

            if (field.Increment)
            {
                writer.Write(firstConstraint ? " [increment" : ", increment");
                firstConstraint = false;
            }

            if (field.DbDefault != null)
            {
                writer.Write(firstConstraint ? " [default: " : ", default: ");

                if (field.DbDefault.GetType() != typeof(string))
                {
                    writer.Write('"');
                    writer.Write((string)field.DbDefault);
                    writer.Write('"');
                }
                else
                {
                    writer.Write(field);
                }

                firstConstraint = false;
            }

            if (!string.IsNullOrEmpty(field.Note))
            {
                writer.Write(firstConstraint ? " [note: '" : ", note: '");
                writer.Write(field.Note);
                writer.Write('\'');
                firstConstraint = false;
            }

            if (!firstConstraint)
            {
                writer.WriteLine(']');
            } 
            else
            {
                writer.WriteLine();
            }
        }

        void ExportTableIndex(TextWriter writer, Database model, Index index)
        {
            //foreach
            writer.WriteLine("    indexes {");

            if (index.Columns.Count > 1)
            {
                writer.Write('(');

                bool firstColumn = true;

                foreach (var indexColumn in index.Columns)
                {
                    if (!firstColumn)
                    {
                        writer.Write(", ");
                    }

                    if (indexColumn.Type == IndexColumnType.Expression)
                    {
                        writer.Write('`');
                        writer.Write(indexColumn.Value);
                        writer.Write('`');
                    }
                    else
                    {
                        writer.Write(indexColumn.Value);
                    }

                    firstColumn = false;
                }

                writer.Write(')');
            }
            else
            {
                var indexColumn = index.Columns.First();
                if (indexColumn.Type == IndexColumnType.Expression)
                {
                    writer.Write('`');
                    writer.Write(indexColumn.Value);
                    writer.Write('`');
                }
                else
                {
                    writer.Write(indexColumn.Value);
                }
            }

            bool firstConstraint = true;

            if (index.PrimaryKey)
            {
                writer.Write(" [pk");
                firstConstraint = false;
            }

            if (!string.IsNullOrEmpty(index.Type))
            {
                writer.Write(firstConstraint ? " [type: " : ", type: ");
                writer.Write(index.Type.ToLowerInvariant());
                firstConstraint = false;
            }

            if (index.Unique)
            {
                writer.Write(firstConstraint ? " [unique" : ", unique");
                firstConstraint = false;
            }
            if (!string.IsNullOrEmpty(index.Name))
            {
                writer.Write(firstConstraint ? " [name: " : ", name: ");
                writer.Write(index.Name);
                firstConstraint = false;
            }

            if (!firstConstraint)
            {
                writer.WriteLine(']');
            }
            else
            {
                writer.WriteLine();
            }
        }

        void ExportRefs(TextWriter writer, Database model, Schema schema)
        {

        }

        static bool ShouldWriteSchemaName(Schema schema, Database model) =>
            !string.Equals(schema.Name, model.Schemas.DefaultSchemaName, StringComparison.OrdinalIgnoreCase) || model.Schemas.HasDefaultSchema;

        
        static bool NameRequiresQuotes(string value) => value.Any(c => char.IsWhiteSpace(c) || c == '[' || c == ']');

        static bool ShouldWriteDbDefault(object? dbDefault) =>
            (dbDefault != null) &&
                (dbDefault.GetType() != typeof(string) || !string.IsNullOrEmpty((string)dbDefault));


        static bool DbDefaultRequiresQuotes(object dbDefault)
            => dbDefault != null && dbDefault.GetType() != typeof(string);

        //static bool HasWhiteSpace(string value) => value.Any(char.IsWhiteSpace);

        //static bool HasSquareBracket(string value) => value.Any(c => );
    }
}
