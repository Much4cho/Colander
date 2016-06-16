using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;

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

            builder.Register(c => new WordService.WordListService()).As<WordService.IWordListService>();
            builder.Register(c => new WordService.WordService()).As<WordService.IWordService>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        
    }
}