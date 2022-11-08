using Grpc.Core;
using Shared;

namespace SimpleServer.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<FullNameReply> CreateFullName(FullNameRequest request, ServerCallContext context)
        {
            FullNameReply output = new();

            output.FullName = $"{request.FirstName} {request.LastName}";
            output.LoginName = $"{request.FirstName.Substring(0,1)}{request.LastName}";

            return Task.FromResult(output);
        }
    }
}