using Microsoft.Owin;
using Owin;
using System.Web.Http;

using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using JustGoWebApp.Common.Constants;

[assembly: OwinStartup(typeof(JustGoWebApp.Web.Api.Startup))]

namespace JustGoWebApp.Web.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutoMapperConfig.RegisterMappings(Assemblies.WebApi);

            ConfigureAuth(app);

            var httpConfig = new HttpConfiguration();
            
            WebApiConfig.Register(httpConfig);

            httpConfig.EnsureInitialized();

            app
                .UseNinjectMiddleware(NinjectConfig.CreateKernel)
                .UseNinjectWebApi(httpConfig);
        }
    }
}
