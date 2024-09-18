using Microsoft.AspNetCore.Mvc;
using SecretClientTasksBackend.API_Setup;
using SecretClientTasksBackend.Repository;

namespace SecretClientTasksBackend.APIs
{
    public class GetSCTasks : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetSCTasks", async ([FromServices] ISCTaskRepository scTaskRepository) =>
            {
                var scTasks = await scTaskRepository.GetSCTasks();
                return Results.Ok(scTasks);
            })
        .WithMetadata(new EndpointNameMetadata("GetSCTasks"));
        }
    }
}
