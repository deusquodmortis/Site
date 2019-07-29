using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(TestSite.App_Start.Startup1))]

namespace TestSite.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType="ApplicationCookie",
                LoginPath=new PathString("/Account/Login")
            });


            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
