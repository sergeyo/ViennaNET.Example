using ViennaNET.Mediator;

namespace TestApplication.Queries.GetEcho
{
    public class GetEchoQuery : IRequest
    {
        public string Echo { get; set; }
    }
}
