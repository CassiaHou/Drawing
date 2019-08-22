using System.Collections.Generic;

namespace Drawing.Domain
{
    public interface IDrawer
    {
        List<string> Draw(string input);
    }
}
