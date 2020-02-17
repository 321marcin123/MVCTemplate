using Autofac;
using Autofac.Integration.Mvc;
using MvcTest.Services;
using System.Web.Mvc;

namespace MvcTest.App_Start
{
    public class IoCConfig
    {
        public static void Setup()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);


            builder.RegisterGeneric(typeof(GenericRepository<>))
               .AsImplementedInterfaces();

            // register your custom class here

            var container = builder.Build();


            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


    }
}