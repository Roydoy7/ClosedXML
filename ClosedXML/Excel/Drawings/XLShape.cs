using System;

namespace ClosedXML.Excel.Drawings
{
    internal class XLShape : IXLShape
    {
        private const String InvalidNameChars = @"\/?*[]";
        private readonly XLWorksheet _worksheet;
        private Int32 _id;
        private Int32 _height;
        private Int32 _width;
        private Int32 _left;
        private Int32 _top;


        private String _name = string.Empty;

        public XLShape(XLWorksheet worksheet)
        {
            _worksheet = worksheet;
        }

        internal void SetName(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Shape names cannot be empty");

            if (value.IndexOfAny(InvalidNameChars.ToCharArray()) != -1)
                throw new ArgumentException($"Shape names cannot contain any of the following characters: {InvalidNameChars}");

            if (value.Length > 31)
                throw new ArgumentException("Shape names cannot be more than 31 characters");

            _name = value;
        }

        public Int32 Id
        {
            get { return _id; }
            internal set
            {
                _id = value;
            }
        }

        public String Name { get { return _name; } }

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

    }
}
