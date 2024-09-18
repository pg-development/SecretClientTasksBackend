using Microsoft.AspNetCore.Mvc;
using SecretClientTasksBackend.API_Setup;
using SecretClientTasksBackend.Models;
using SecretClientTasksBackend.Repository;

namespace SecretClientTasksBackend.APIs
{
    public class SaveSCTasks : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/SaveSCTasks", async (SaveTasksRequest request, [FromServices] ISCTaskRepository taskRepository) =>
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Email) || request.Tasks == null || !request.Tasks.Any())
                    {
                        return Results.BadRequest(new { Message = "Invalid input data. Please provide valid name, email, and tasks." });
                    }
                    await taskRepository.SaveUserTasks(request.Name, request.Email, request.Tasks);
                    return Results.Ok(new { Message = "Tasks successfully saved." });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(error: ex);
                }
            })
            .WithMetadata(new EndpointNameMetadata("SaveSCTasks"));
        }

        public record SaveTasksRequest(string Name, string Email, List<long> Tasks);
    }
}
