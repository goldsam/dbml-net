using Dbml.Model;
using System.IO;

namespace Dbml.Export
{
    public interface IExporter
    {
        void Export(Stream stream, Database model);
    }
}
