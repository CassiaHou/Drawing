namespace Drawing.Domain
{
    public interface IDrawingCommand
    {
        void Excute(ICanvas canvas);
    }
}
