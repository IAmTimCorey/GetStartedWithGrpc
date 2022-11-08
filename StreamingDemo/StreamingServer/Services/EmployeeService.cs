using Grpc.Core;
using Shared;

namespace StreamingServer.Services;

public class EmployeeService : Employee.EmployeeBase
{
    public override async Task<EmployeesResult> AddNewEmployees(
        IAsyncStreamReader<EmployeeModel> requestStream,
        ServerCallContext context)
    {
        await foreach (var emp in requestStream.ReadAllAsync())
        {
            Console.WriteLine(emp.Name);
        }

        return new() {  ProcessResult = "Process Completed Successfully" };
    }
}
