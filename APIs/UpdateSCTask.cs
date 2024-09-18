using Microsoft.AspNetCore.Mvc;
using SecretClientTasksBackend.API_Setup;
using SecretClientTasksBackend.Models;
using SecretClientTasksBackend.Repository;
using System.Transactions;

namespace SecretClientTasksBackend.APIs
{
    public class UpdateSCTask : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPut("/UpdateSCTask", (long id, [FromBody] SCTask scTask, [FromServices] ISCTaskRepository scTaskRepository) =>
            {
                if (scTask != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        scTaskRepository.UpdateSCTask(id, scTask);
                        scope.Complete();
                        return Results.Ok();
                    }
                }
                return Results.NoContent();
            })
                .WithMetadata(new EndpointNameMetadata("UpdateSCTask"));
        }
    }
}
