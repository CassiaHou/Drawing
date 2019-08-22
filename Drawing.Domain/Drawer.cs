using System;
using System.Collections.Generic;
using System.Linq;

namespace Drawing.Domain
{
    public class Drawer : IDrawer
    {
        private readonly IDrawingCommandCreator commandCreator;
        private ICanvas Canvas;

        public Drawer()
        {
            Canvas = new Canvas();
            commandCreator = new DrawingCommandCreator();
        }
        public List<string> Draw(string input)
        {
            var command = commandCreator.Create(input);
            if (!(command is NewCanvasCommand) && (Canvas.Points == null || Canvas.Points.Length == 0))
                throw new InvalidOperationException("Please create a canvas first.");
          
            command.Excute(Canvas);
            return getDrawingLines().ToList();
        }

        private IEnumerable<string> getDrawingLines()
        {
            for (var hi = 0; hi < Canvas.Height; hi++)
            {
                var str = "";

                for (var wi = 0; wi < Canvas.Width; wi++)
                {
                    str += Canvas.Points[wi, hi];
                }
                yield return str;
            }

        }
    }
}
