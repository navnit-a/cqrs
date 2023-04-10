using MediatR;

namespace MyWebApi.Features
{
  public class SampleRequest : IRequest<string>
  {
    public string Message { get; set; }
  }
}
