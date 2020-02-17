Remeber to do following steps :

1. Edit your connections strings
2. If you want use ApiControllers with IoC Container register it in IoCConfig.cs class
3. The same with other classes you want to use further in your application. 
4. If you want to use WebApi controllers aswell you have to edit IoC Config like below. 
But it is recmonaded to add another project as web api application. 








================================================IoCConfig for WebApi and MVC=====================================

 public class IoCConfig
    {
        public static void Setup()
        {
            var builder = new ContainerBuilder();

            //1. Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // 2. RegisterTypes
            #region RegisterTypes

            builder.RegisterType(typeof(ApplicationDbContext))
               .AsSelf()
               .AsImplementedInterfaces()
               .As(typeof(IContext))
               .InstancePerRequest();


            //---------------------------- register Modules-------------
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            builder.RegisterAssemblyModules(assemblies.ToArray());
            //--------------------------------------------------


            // Register your Web API controllers.
            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(typeof(WebApiConfig).Assembly);


            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();


            // custom class register register =====================================================

            //builder.RegisterType(typeof(ClassName)).AsImplementedInterfaces();

            // register ApplicationDbContext
            #endregion

            // 3.build container
            var container = builder.Build();

            // 4.Set the dependency resolver to be Autofac.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }