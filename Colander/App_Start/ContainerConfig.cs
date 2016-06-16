using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using Colander.WordServices;

namespace Colander.App_Start
{
    public class ContainerConfig
    {
        public static void RegisterContainer()
        {
            // Container building using autofac
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(System.Reflection.Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            builder.Register(c => new WordListRepository()).As<IWordListRepository>();
            builder.Register(c => new WordRepository()).As<IWordRepository>();
            builder.Register(c => new WordListService(c.Resolve<IWordListRepository>())).As<IWordListService>();
            builder.Register(c => new WordService(c.Resolve<IWordRepository>())).As<IWordService>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        
    }
}