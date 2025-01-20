using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ClosedXML.Excel.Drawings
{
    internal class XLShapes : IXLShapes, IEnumerable<XLShape>
    {
        private readonly List<XLShape> _shapes = new List<XLShape>();
        private readonly XLWorksheet _worksheet;

        public XLShapes(XLWorksheet worksheet)
        {
            _worksheet = worksheet;
            Deleted = new HashSet<string>();
        }

        internal ICollection<string> Deleted { get; private set; }
        public int Count
        {
            [DebuggerStepThrough]
            get { return _shapes.Count; }
        }

        public IXLShape Add(string name, int id)
        {
            var shape = new XLShape(_worksheet);
            shape.SetName(name);
            shape.Id = id;
            _shapes.Add(shape);
            return shape;
        }


        IEnumerator<IXLShape> IEnumerable<IXLShape>.GetEnumerator()
        {
            return _shapes.Cast<IXLShape>().GetEnumerator();
        }

        public IEnumerator<XLShape> GetEnumerator()
        {
            return ((IEnumerable<XLShape>)_shapes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
