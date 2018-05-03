using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace IntelipostMiddleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting service...");
            WebHostListener.GetInstance(args).Host.Run();
        }        
    }
}
