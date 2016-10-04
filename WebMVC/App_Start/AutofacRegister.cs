using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Npgsql;

namespace WebMVC
{
    public static class AutofacRegister
    {
        public static void Register()
        {
            var builder=new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            //builder.Register(c => new SqlConnection(ConfigurationManager.ConnectionStrings["ToDo"].ConnectionString)).As<IDbConnection>().InstancePerRequest();

            builder.Register(c => new NpgsqlConnection(ConfigurationManager.ConnectionStrings["cuahang"].ConnectionString)).As<IDbConnection>().InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(c=>c.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}