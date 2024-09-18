using Microsoft.AspNetCore.Mvc;
using SecretClientTasksBackend.API_Setup;
using SecretClientTasksBackend.Models;
using SecretClientTasksBackend.Repository;
using System.Transactions;

namespace SecretClientTasksBackend.APIs
{
    public class ImportCsvFile : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/ImportCsvFile", async (HttpRequest request, [FromServices] ICsvFileRepository excelRepository) =>
            {
                if (!request.HasFormContentType)
                {
                    return Results.BadRequest("Unsupported media type.");
                }

                var form = await request.ReadFormAsync();
                var file = form.Files["excelFile"];

                if (file == null || file.Length == 0)
                {
                    return Results.BadRequest("File is empty or missing.");
                }

                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await excelRepository.DownloadCsvFile(file);
                    scope.Complete();
                    return Results.Ok();
                }
            }).Accepts<IFormFile>("multipart/form-data");
        }
    }
}
