using Autofac;
using Autofac.Integration.Mvc;
using GroceryMinder.Data.Infrastructure;
using GroceryMinder.Data.Repositories;
using GroceryMinder.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace GroceryMinder.Web.App_Start
{
    public class AutoFacConfig
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(GroceryItemRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(GroceryItemService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}