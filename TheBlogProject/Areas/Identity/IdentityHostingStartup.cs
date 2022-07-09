using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(TheBlogProject.Areas.Identity.IdentityHostingStartup))]
namespace TheBlogProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}