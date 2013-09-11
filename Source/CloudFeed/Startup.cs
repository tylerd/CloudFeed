using Owin;

namespace CloudFeed
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
