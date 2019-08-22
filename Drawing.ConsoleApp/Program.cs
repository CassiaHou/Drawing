using Drawing.Domain;
using System;
using System.Collections.Generic;

namespace Drawing.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var drawer = new Drawer();
            Console.WriteLine("Welcom to Drawing");
            Console.WriteLine("Please create a convas first. For example inputing C 20 4");
            var input = Console.ReadLine();
            var isCanvasCreated = false;
            while (!isCanvasCreated)
            {
                try
                {
                    print(drawer.Draw(input));
                    isCanvasCreated = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please input valid command.");
                    input = Console.ReadLine();
                }
            }

            Console.WriteLine(@"Canvas is ready, Now try some other command? Press Q to exit.");
            input = Console.ReadLine();
            while (!input.Equals("Q", StringComparison.OrdinalIgnoreCase))
            {
                print(drawer.Draw(input));
                input = Console.ReadLine();
            }
        }

        private static void print(List<string> lines)
        {
            lines.ForEach(line => Console.WriteLine(line));
        }

    }
}
