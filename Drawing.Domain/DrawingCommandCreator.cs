using System;

namespace Drawing.Domain
{
    public interface IDrawingCommandCreator
    {
        IDrawingCommand Create(string input);
    }
    public class DrawingCommandCreator : IDrawingCommandCreator
    {
        public IDrawingCommand Create(string input)
        {
            var parameters = input.Split(' ');
            if (parameters.Length == 0)
            {
                throw new ArgumentException("Input is invalid.");
            }
            CommandType commandType;
            if (!Enum.TryParse(parameters[0], out commandType))
            {
                throw new ArgumentException("Input is invalid.");
            }

            int x1, y1, x2, y2;
            switch (commandType)
            {
                case CommandType.C:
                    int width;
                    int height;
                    if (parameters.Length != 3
                        || !int.TryParse(parameters[1], out width)
                        || !int.TryParse(parameters[2], out height))
                        throw new ArgumentException("Input is invalid.");
                    return new NewCanvasCommand(width, height);
                case CommandType.L:
                    if (parameters.Length != 5
                        || !int.TryParse(parameters[1], out x1)
                        || !int.TryParse(parameters[2], out y1)
                        || !int.TryParse(parameters[3], out x2)
                        || !int.TryParse(parameters[4], out y2)
                        || (x1 != x2 && y1 != y2))
                        throw new ArgumentException("Input is invalid.");
                    return new NewLineCommand(x1, y1, x2, y2);
                case CommandType.R:
                    if (parameters.Length != 5
                        || !int.TryParse(parameters[1], out x1)
                        || !int.TryParse(parameters[2], out y1)
                        || !int.TryParse(parameters[3], out x2)
                        || !int.TryParse(parameters[4], out y2))
                        throw new ArgumentException("Input is invalid.");
                    return new NewRectangleCommand(x1, y1, x2, y2);

                case CommandType.B:

                    if (parameters.Length != 4
                        || !int.TryParse(parameters[1], out x1)
                        || !int.TryParse(parameters[2], out y1)
                        || string.IsNullOrEmpty(parameters[3]))
                        throw new ArgumentException("Input is invalid.");
                    var color = parameters[3].ToCharArray()[0];
                    return new BucketFillCommand(x1, y1, color);

            }
            return null;

        }
    }
}
