using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NHibernate.Linq;
using TestDomain.Entities;
using ViennaNET.Mediator;
using ViennaNET.Orm.Seedwork;

namespace TestApplication.Queries.GetRegisteredVaccineCount
{
    internal class GetRegisteredVaccineCountQueryHandler : IMessageHandlerAsync<GetRegisteredVaccineCountQuery, int>
    {
        private readonly IEntityRepositoryFactory _entityRepositoryFactory;

        public GetRegisteredVaccineCountQueryHandler(IEntityRepositoryFactory entityRepositoryFactory)
        {
            _entityRepositoryFactory = entityRepositoryFactory;
        }

        public async Task<int> HandleAsync(GetRegisteredVaccineCountQuery message, CancellationToken cancellationToken)
        {
            var allManufacturers = await _entityRepositoryFactory.Create<Manufacturer>()
                .Query()
                .FetchMany(m => m.TradeMarks)
                .Where(m => m.HasMedicalLicense)
                .ToListAsync(cancellationToken);

            return allManufacturers.SelectMany(m => m.TradeMarks)
                .Count(tm => tm.IsActiveVaccine());
        }
    }
}
