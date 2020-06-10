using System.Threading;
using System.Threading.Tasks;
using ViennaNET.Mediator;

namespace TestApplication.Queries.GetEcho
{
    internal class GetEchoQueryHandler : IMessageHandlerAsync<GetEchoQuery, string>
    {
        public Task<string> HandleAsync(GetEchoQuery message, CancellationToken cancellationToken)
        {
            return Task.FromResult("Handler: " + message.Echo);
        }
    }
}
