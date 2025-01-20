#nullable disable

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ClosedXML.Excel.Drawings
{
    internal class XLGroupShape : IXLGroupShape
    {
        private const String InvalidNameChars = @":\/?*[]";
        private readonly XLWorksheet _worksheet;
        private readonly XLPictures _pictures;
        private readonly XLShapes _shapes;
        private String _name = string.Empty;
        internal IDictionary<XLMarkerPosition, XLMarker> Markers { get; private set; }
        public XLPicturePlacement Placement { get; set; }

        private Int32 _id;
        private Int32 _height;
        private Int32 _width;
        private Int32 _left;
        private Int32 _top;
        private Int32 _childHeight;
        private Int32 _childWidth;
        private Int32 _childLeft;
        private Int32 _childTop;


        public IXLPictures Pictures { get { return _pictures; } }
        public IXLShapes Shapes { get { return _shapes; } }

        public XLGroupShape(XLWorksheet worksheet)
        {
            _worksheet = worksheet;
            _pictures = new(worksheet);
            _shapes = new(worksheet);
            this.Markers = new Dictionary<XLMarkerPosition, XLMarker>()
            {
                [XLMarkerPosition.TopLeft] = null,
                [XLMarkerPosition.BottomRight] = null
            };
        }

        public Int32 Id
        {
            get { return _id; }
            internal set
            {
                _id = value;
            }
        }

        public Int32 Width
        {
            get { return _width; }
            set
            {
                //if (this.Placement == XLPicturePlacement.MoveAndSize)
                //    throw new ArgumentException("To set the width, the placement should be FreeFloating or Move");
                _width = value;
            }
        }

        public Int32 Height
        {
            get { return _height; }
            set
            {
                //if (this.Placement == XLPicturePlacement.MoveAndSize)
                //    throw new ArgumentException("To set the width, the placement should be FreeFloating or Move");
                _height = value;
            }
        }

        public Int32 ChildWidth
        {
            get { return _childWidth; }
            set
            {
                //if (this.Placement == XLPicturePlacement.MoveAndSize)
                //    throw new ArgumentException("To set the width, the placement should be FreeFloating or Move");
                _childWidth = value;
            }
        }

        public Int32 ChildHeight
        {
            get { return _childHeight; }
            set
            {
                //if (this.Placement == XLPicturePlacement.MoveAndSize)
                //    throw new ArgumentException("To set the width, the placement should be FreeFloating or Move");
                _childHeight = value;
            }
        }

        public Int32 Left
        {
            get { return _left; }
            set
            {
                //if (this.Placement == XLPicturePlacement.MoveAndSize)
                //    throw new ArgumentException("To set the width, the placement should be FreeFloating or Move");
                _left = value;
            }
        }

        public Int32 Top
        {
            get { return _top; }
            set
            {
                //if (this.Placement == XLPicturePlacement.MoveAndSize)
                //    throw new ArgumentException("To set the width, the placement should be FreeFloating or Move");
                _top = value;
            }
        }

        public Int32 ChildLeft
        {
            get { return _childLeft; }
            set
            {
                //if (this.Placement == XLPicturePlacement.MoveAndSize)
                //    throw new ArgumentException("To set the width, the placement should be FreeFloating or Move");
                _childLeft = value;
            }
        }

        public Int32 ChildTop
        {
            get { return _childTop; }
            set
            {
                //if (this.Placement == XLPicturePlacement.MoveAndSize)
                //    throw new ArgumentException("To set the width, the placement should be FreeFloating or Move");
                _childTop = value;
            }
        }

        public IXLCell TopLeftCell
        {
            get
            {
                return Markers[XLMarkerPosition.TopLeft].Cell;
            }

            private set
            {
                if (!value.Worksheet.Equals(this.Worksheet))
                    throw new InvalidOperationException("A picture and its anchor cells must be on the same worksheet");

                this.Markers[XLMarkerPosition.TopLeft] = new XLMarker(value);
            }
        }

        public IXLCell BottomRightCell
        {
            get
            {
                return Markers[XLMarkerPosition.BottomRight].Cell;
            }

            private set
            {
                if (!value.Worksheet.Equals(this.Worksheet))
                    throw new InvalidOperationException("A picture and its anchor cells must be on the same worksheet");

                this.Markers[XLMarkerPosition.BottomRight] = new XLMarker(value);
            }
        }

        public IXLWorksheet Worksheet { get { return _worksheet; } }

        public String Name
        {
            get { return _name; }
        }

        internal void SetName(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Picture names cannot be empty");

            if (value.IndexOfAny(InvalidNameChars.ToCharArray()) != -1)
                throw new ArgumentException($"Picture names cannot contain any of the following characters: {InvalidNameChars}");

            if (value.Length > 31)
                throw new ArgumentException("Picture names cannot be more than 31 characters");

            _name = value;
        }

        public IXLGroupShape MoveTo(IXLCell fromCell, IXLCell toCell)
        {
            return MoveTo(fromCell, 0, 0, toCell, 0, 0);
        }

        public IXLGroupShape MoveTo(IXLCell fromCell, Int32 fromCellXOffset, Int32 fromCellYOffset, IXLCell toCell, Int32 toCellXOffset, Int32 toCellYOffset)
        {
            return MoveTo(fromCell, new Point(fromCellXOffset, fromCellYOffset), toCell, new Point(toCellXOffset, toCellYOffset));
        }

        public IXLGroupShape MoveTo(IXLCell fromCell, Point fromOffset, IXLCell toCell, Point toOffset)
        {
            if (fromCell == null) throw new ArgumentNullException(nameof(fromCell));
            if (toCell == null) throw new ArgumentNullException(nameof(toCell));
            this.Placement = XLPicturePlacement.MoveAndSize;

            this.TopLeftCell = fromCell;
            this.Markers[XLMarkerPosition.TopLeft].Offset = fromOffset;

            this.BottomRightCell = toCell;
            this.Markers[XLMarkerPosition.BottomRight].Offset = toOffset;

            return this;
        }

        public IXLPicture AddPicture(Stream stream, string name, int Id)
        {
            return ((XLPictures)Pictures).Add(stream, name, Id);
        }
    }
}
