using Owin;
using System.Net;
using System.Web.Http;

namespace TicketMaster.IntegrationTests
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            if (appBuilder.Properties.ContainsKey("System.Net.HttpListener"))
            {
                HttpListener listener = (HttpListener)appBuilder.Properties["System.Net.HttpListener"];
                listener.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication;
            }

            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);

            appBuilder.UseWebApi(config);
        }
    }
}
