using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace IntelipostMiddleware
{
    public class WebHostListener
    {
        private static WebHostListener _singletonInstance;
        private IWebHost host;

        private WebHostListener(string[] args)
        {
            Console.WriteLine("Creating host");
            this.host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()            
                .UseUrls("http://0.0.0.0:5000/")//isso pode vir de uma config. Deixei fixo aqui porque a porta do docker vai ficar fixa
                .Build();
        }

        public static WebHostListener GetInstance(string[] args)
        {
            if(_singletonInstance is null)
            {
                _singletonInstance = new WebHostListener(args);
            }

            return _singletonInstance;
        }

        public IWebHost Host {
            get{
                return this.host;
            }
            private set { this.host = value; }
        }

    }
}
