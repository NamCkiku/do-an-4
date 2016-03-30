using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudyOnline.Startup))]
namespace StudyOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
