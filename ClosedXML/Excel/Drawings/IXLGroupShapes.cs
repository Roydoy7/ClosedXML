using System.Collections.Generic;

namespace ClosedXML.Excel.Drawings
{
    internal interface IXLGroupShapes : IEnumerable<IXLGroupShape>
    {
        IXLGroupShape AddGroupShape(string name, int id);
    }
}
