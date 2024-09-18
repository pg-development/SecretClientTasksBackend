using Microsoft.AspNetCore.Mvc;
using SecretClientTasksBackend.API_Setup;
using SecretClientTasksBackend.Models;
using SecretClientTasksBackend.Repository;
using System.Transactions;

namespace SecretClientTasksBackend.APIs
{
    public class InsertSCTask : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/InsertSCTask", async ([FromBody] SCTask scTask,
                                            [FromServices] ISCTaskRepository scTaskRepository) =>
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await scTaskRepository.InsertSCTask(scTask);
                    scope.Complete();
                    return Results.Ok();
                }
            })
                .WithMetadata(new EndpointNameMetadata("InsertSCTask"));
        }
    }
}
