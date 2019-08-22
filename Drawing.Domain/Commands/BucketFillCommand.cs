namespace Drawing.Domain
{
    public class BucketFillCommand : IDrawingCommand
    {
        private readonly int _x1;
        private readonly int _y1;
        private readonly char _color;
        private readonly char _colorSpace = (char)Color.Space;
        public BucketFillCommand(int x1, int y1, char color)
        {
            _x1 = x1;
            _y1 = y1;
            _color = color;
        }
        public void Excute(ICanvas canvas)
        {
            fill(_x1, _y1, canvas);
        }

        private void fill(int x, int y, ICanvas canvas)
        {
            
            if (x == 0
                || x == canvas.Width - 1
                || y == 0
                || y == canvas.Height - 1
                || canvas.Points[x, y] != _colorSpace)
            {
                return;
            }
            canvas.Points[x, y] = _color;
            fill(x, y - 1, canvas);
            fill(x, y + 1, canvas);
            fill(x - 1, y, canvas);
            fill(x + 1, y, canvas);
        }
    }
}
