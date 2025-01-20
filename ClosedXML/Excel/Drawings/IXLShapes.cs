using System.Collections.Generic;

namespace ClosedXML.Excel.Drawings
{
    public interface IXLShapes : IEnumerable<IXLShape>
    {
        int Count { get; }
        IXLShape Add(string name, int id);
    }
}
