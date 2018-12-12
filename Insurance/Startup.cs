using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Insurance.Model.Interfaces;
using Insurance.Models.Principal;
using Insurance.Services.DataSourse;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Owin;

[assembly: OwinStartup(typeof(Insurance.Startup))]
namespace Insurance
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var containerBuilder = new ContainerBuilder();

            var connectionString = ConfigurationManager.ConnectionStrings["InsuranceDbConnection"].ConnectionString;
            var assemblyService = typeof (BaseService).Assembly;
            containerBuilder.RegisterAssemblyTypes(assemblyService).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope()
                                                                   .OnActivated(args => {
                                                                       var baseService = args.Instance as BaseService;
                                                                       if (baseService != null) baseService.Connection = new SqlConnection(connectionString);
                                                                   });

            containerBuilder.RegisterType<AuthenticationManager>().As<IAuthentication>()
                .WithParameter(Autofac.Core.ResolvedParameter.ForNamed<IContactService>("ContactService"));

            containerBuilder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();

            var assembly = Assembly.GetExecutingAssembly();
            containerBuilder.RegisterApiControllers(assembly);
            containerBuilder.RegisterControllers(assembly);

            var container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            app.UseAutofacMiddleware(container);

            var config = new HttpConfiguration();
            app.UseWebApi(config);
            app.UseAutofacWebApi(config);
            WebApiConfig.Register(config);

            app.UseCookieAuthentication(new CookieAuthenticationOptions { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie });
        }
    }
}
