using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MyWebApi.Features
{
  public class SampleRequestHandler : IRequestHandler<SampleRequest, string>
  {
    public async Task<string> Handle(SampleRequest request, CancellationToken cancellationToken)
    {
      // Implement your request handling logic here
      return await Task.FromResult($"Received message: {request.Message}");
    }
  }
}
