using SimpleInjector;
using SimpleInjector.Packaging;
using TestApplication.Queries.GetEcho;
using TestApplication.Queries.GetRegisteredVaccineCount;
using ViennaNET.Mediator;

namespace TestApplication
{
    public class ApplicationPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Collection.Append<IMessageHandlerAsync, GetEchoQueryHandler>(Lifestyle.Singleton);
            container.Collection.Append<IMessageHandlerAsync, GetRegisteredVaccineCountQueryHandler>(Lifestyle.Singleton);
        }
    }
}
