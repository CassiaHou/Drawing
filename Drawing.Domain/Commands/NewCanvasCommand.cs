using System.Linq;

namespace Drawing.Domain
{
    public class NewCanvasCommand : IDrawingCommand
    {
        private readonly int _width;
        private readonly int _height;

        public NewCanvasCommand(int width, int height)
        {
            _width = width;
            _height = height;
        }
        public void Excute(ICanvas canvas)
        {
            canvas.Width = _width + 2;
            canvas.Height = _height + 2;

            canvas.Points = new char[canvas.Width, canvas.Height];
            var widthPoints = Enumerable.Range(0, canvas.Width);
            var heightPoints = Enumerable.Range(0, canvas.Height);
            foreach (var wi in widthPoints)
            {
                foreach (var hi in heightPoints)
                {
                    var isTheFirstOrLastLine = hi == 0 || hi == canvas.Height - 1;
                    var isFirstOfMiddleLine = wi == 0 || wi == canvas.Width - 1;
                    if (isTheFirstOrLastLine)
                        canvas.Points[wi, hi] = ((char)Color.Width);
                    else if (isFirstOfMiddleLine)
                        canvas.Points[wi, hi] = ((char)Color.Height);
                    else
                        canvas.Points[wi, hi] = ((char)Color.Space);
                }

            }

        }
    }
}
