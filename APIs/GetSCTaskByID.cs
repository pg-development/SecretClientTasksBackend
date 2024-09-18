using Microsoft.AspNetCore.Mvc;
using SecretClientTasksBackend.API_Setup;
using SecretClientTasksBackend.Models;
using SecretClientTasksBackend.Repository;

namespace SecretClientTasksBackend.APIs
{
    public class GetSCTaskByID : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetSCTaskByID", async (long id, [FromServices] ISCTaskRepository scTaskRepository) =>
            {
                var scTask = await scTaskRepository.GetSCTaskByID(id);
                return Results.Ok(scTask);
            })
                .WithMetadata(new EndpointNameMetadata("GetSCTaskByID"));
        }
    }
}
