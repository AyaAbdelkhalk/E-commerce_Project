using Autofac;
using E_commerce.Application.Interfaces;
using E_commerce.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Presentation
{
    public class AppAutoFac
    {
        public static IContainer Inject()
        {
            var builder = new ContainerBuilder();
            // Register your services here
            // Example: builder.RegisterType<MyService>().As<IMyService>();


            var container = builder.Build();
            return container;
        }
    }
}
