namespace Drawing.Domain
{
    public class Canvas : ICanvas
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public char[,] Points { get; set; }
    }
}
