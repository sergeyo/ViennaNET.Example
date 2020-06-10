using SimpleInjector;
using SimpleInjector.Packaging;
using TestApplication;
using TestDomain;
using ViennaNET.Mediator.DefaultConfiguration;
using ViennaNET.Orm.DefaultConfiguration;
using ViennaNET.Orm.PostgreSql.DefaultConfiguration;

namespace TestService
{
    public class ServicePackage :IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterPackages(new []
            {
                typeof(ApplicationPackage).Assembly,
                typeof(MediatorPackage).Assembly,
                typeof(TestDomainPackage).Assembly,
                typeof(OrmPackage).Assembly,
                typeof(PostgreSqlOrmPackage).Assembly,
            });
        }
    }
}
