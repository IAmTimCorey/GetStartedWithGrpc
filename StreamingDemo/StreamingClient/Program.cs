

using Shared;
using Grpc.Net.Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7124");
var client = new Employee.EmployeeClient(channel);
var cancellationToken = new CancellationToken(false);
var newEmployees = client.AddNewEmployees(cancellationToken: cancellationToken);
string name;

do
{
    Console.Write("Enter a name: ");
    name = Console.ReadLine()!;
    if (name.ToLower() != "exit")
    {
        await newEmployees.RequestStream.WriteAsync(new EmployeeModel { Name = name });
    }
} while (name.ToLower() != "exit");

await newEmployees.RequestStream.CompleteAsync();

var result = newEmployees.ResponseAsync.Result;

Console.WriteLine($"Response from server: {result.ProcessResult}");

Console.WriteLine("Application completed");
Console.ReadLine();