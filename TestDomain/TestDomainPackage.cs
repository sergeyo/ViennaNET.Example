using SimpleInjector;
using SimpleInjector.Packaging;
using ViennaNET.Orm.Seedwork;

namespace TestDomain
{
    public class TestDomainPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Collection.Append<IBoundedContext, TestDomainContext>(Lifestyle.Singleton);
        }
    }
}
