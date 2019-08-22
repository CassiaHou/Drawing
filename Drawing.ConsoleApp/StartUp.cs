using Drawing.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Drawing.ConsoleApp
{
    public class StartUp
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDrawer, Drawer>();
            services.AddTransient<IDrawingCommandCreator, DrawingCommandCreator>();
        }

    }
}
