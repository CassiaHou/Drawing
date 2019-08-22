namespace Drawing.Domain
{
    public class NewRectangleCommand : IDrawingCommand
    {
        private readonly int _x1;
        private readonly int _y1;
        private readonly int _x2;
        private readonly int _y2;

        public NewRectangleCommand(int x1, int y1, int x2, int y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }
        public void Excute(ICanvas canvas)
        {
            var colorX = (char)Color.X;
            for (var wi = _x1; wi < _x2; wi++)
            {
                canvas.Points[wi, _y1] = colorX;
                canvas.Points[wi, _y2] = colorX;
            }
            for (var hi = _y1; hi <= _y2; hi++)
            {
                canvas.Points[_x1, hi] = colorX;
                canvas.Points[_x2, hi] = colorX;
            }
        }
    }
}
