using Microsoft.AspNetCore.Hosting;
using ViennaNET.WebApi.Runners.BaseKestrel;

namespace TestService
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseKestrelRunner.Configure().BuildWebHost(args).Run();
        }
    }
}
