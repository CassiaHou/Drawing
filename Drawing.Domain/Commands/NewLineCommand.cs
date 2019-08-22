namespace Drawing.Domain
{
    public class NewLineCommand : IDrawingCommand
    {
        private readonly int _x1;
        private readonly int _y1;
        private readonly int _x2;
        private readonly int _y2;

        public NewLineCommand(int x1, int y1, int x2, int y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }
        public void Excute(ICanvas canvas)
        {
            var isVerticalLine = _x1 == _x2;
            var isHorizontalLine = _y1 == _y2;

            if (isHorizontalLine)
            {
                for (var wi = _x1; wi < _x2 + 1; wi++)
                {
                    if (wi != 0 && wi != canvas.Width - 1)
                        canvas.Points[wi, _y1] = (char)Color.X;
                }
                return;
            }
            if (isVerticalLine)
            {
                for (var hi = _y1; hi < _y2 + 1; hi++)
                {
                    if (hi != 0 && hi != canvas.Height - 1)
                        canvas.Points[_x1, hi] = (char)Color.X;
                }
                return;
            }
        }
    }
}
