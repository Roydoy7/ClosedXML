using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClosedXML.Excel.Drawings
{
    internal class XLGroupShapes : IEnumerable<IXLGroupShape>, IXLGroupShapes
    {
        private readonly List<IXLGroupShape> _groupShapes = new List<IXLGroupShape>();
        private readonly XLWorksheet _worksheet;

        public XLGroupShapes(XLWorksheet worksheet)
        {
            this._worksheet = worksheet;
        }

        public IXLGroupShape AddGroupShape(string name, int id)
        {
            var groupShape = new XLGroupShape(_worksheet);
            groupShape.SetName(name);
            groupShape.Id = id;
            _groupShapes.Add(groupShape);
            return groupShape;
        }

        IEnumerator<IXLGroupShape> IEnumerable<IXLGroupShape>.GetEnumerator()
        {
            return _groupShapes.Cast<IXLGroupShape>().GetEnumerator();
        }

        public IEnumerator<IXLGroupShape> GetEnumerator()
        {
            return ((IEnumerable<IXLGroupShape>)_groupShapes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
