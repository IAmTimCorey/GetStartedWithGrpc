using Grpc.Core;
using JsonServer;

// http file found at: https://github.com/dotnet/aspnetcore/blob/8b601c3a73ba66de4e6ca35530b5d32a48c76c5b/src/Grpc/JsonTranscoding/test/testassets/Sandbox/google/api/http.proto
// annotations file found at: https://github.com/dotnet/aspnetcore/blob/main/src/Grpc/JsonTranscoding/test/testassets/Sandbox/google/api/annotations.proto

namespace JsonServer.Services
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
                Message = "Hello " + request.FirstName + " " + request.LastName,
                Id = 123
            });
        }
    }
}