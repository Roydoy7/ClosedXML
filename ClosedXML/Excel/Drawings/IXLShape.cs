namespace ClosedXML.Excel.Drawings
{
    public interface IXLShape
    {
        int Height { get; set; }
        int Id { get; }
        int Left { get; set; }
        string Name { get; }
        int Top { get; set; }
        int Width { get; set; }
    }
}
