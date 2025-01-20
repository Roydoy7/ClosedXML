using System;
using System.Drawing;
using System.IO;

namespace ClosedXML.Excel.Drawings
{
    public interface IXLGroupShape
    {
        IXLPictures Pictures { get; }
        IXLShapes Shapes { get; }
        Int32 Id { get; }
        Int32 Width { get; set; }
        Int32 Height { get; set; }
        Int32 ChildWidth { get; set; }
        Int32 ChildHeight { get; set; }
        Int32 Left { get; set; }
        Int32 Top { get; set; }
        Int32 ChildLeft { get; set; }
        Int32 ChildTop { get; set; }
        String Name { get; }
        public IXLPicture AddPicture(Stream stream, string name, int Id);
        XLPicturePlacement Placement { get; set; }
        IXLWorksheet Worksheet { get; }
        IXLGroupShape MoveTo(IXLCell fromCell, IXLCell toCell);
        IXLGroupShape MoveTo(IXLCell fromCell, Int32 fromCellXOffset, Int32 fromCellYOffset, IXLCell toCell, Int32 toCellXOffset, Int32 toCellYOffset);
        IXLGroupShape MoveTo(IXLCell fromCell, Point fromOffset, IXLCell toCell, Point toOffset);
    }
}
