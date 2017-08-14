using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YY.Edu.Sys.WebForm.Startup))]
namespace YY.Edu.Sys.WebForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
