namespace Drawing.Domain
{
    public interface ICanvas
    {
        int Width { get; set; }
        int Height { get; set; }
        char[,] Points { get; set; }
    }
}
