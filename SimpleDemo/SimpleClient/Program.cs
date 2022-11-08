
using Shared;
using Grpc.Net.Client;

var input = new HelloRequest { Name= "Tim" };
using var channel = GrpcChannel.ForAddress("https://localhost:7033");
var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(input);

Console.WriteLine(reply);

Console.WriteLine();

var nameInfo = new FullNameRequest { FirstName = "Tim", LastName = "Corey" };

var nameResults = await client.CreateFullNameAsync(nameInfo);

Console.WriteLine($"Full Name: {nameResults.FullName}");
Console.WriteLine($"Login Name: {nameResults.LoginName}");

Console.ReadLine();