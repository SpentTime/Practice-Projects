using System;

namespace RIW
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                doWork();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void doWork()
        {
            ScreenManipulator screenInfo = new ScreenManipulator();
            do
            {
                screenInfo.getInput(Console.ReadKey(true));
                Console.Clear();
                foreach (var i in screenInfo.ScreenText)
                    Console.WriteLine(i);
                Console.CursorLeft = screenInfo.LeftPosition;
                Console.CursorTop = screenInfo.TopPosition;

            } while (true);
        }
    }
}
