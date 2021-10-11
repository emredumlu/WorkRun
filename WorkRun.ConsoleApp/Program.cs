using System;

namespace WorkRun.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DateOnly date = DateOnly.FromDateTime(DateTime.Today);
            DateTimeOffset dateTimeOffset = date.ToDateTime(new());
        }
    }
}
