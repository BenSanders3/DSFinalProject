using System;

namespace DSFinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(DateTime.Now.ToString("HH:mm tt"));
            Ticket shbumph = new Ticket("Deanna", "104");
            Console.WriteLine();
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine(shbumph.ToString());
        }
    }
}
