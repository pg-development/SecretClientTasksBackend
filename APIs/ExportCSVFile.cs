using Microsoft.AspNetCore.Mvc;
using SecretClientTasksBackend.API_Setup;
using SecretClientTasksBackend.Repository;

namespace SecretClientTasksBackend.APIs
{
    public class ExportCSVFile : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/ExportCSVFile", async ([FromServices] ICsvFileRepository csvFielRepository) =>
            {
                var csvFile = await csvFielRepository.UploadCsvFile();
                return Results.File(csvFile.FileContents, "text/csv", csvFile.FileDownloadName);
            })
        .WithMetadata(new EndpointNameMetadata("ExportCSVFile"));
        }
    }
}
