using Microsoft.AspNetCore.Mvc;
using SecretClientTasksBackend.Models;

namespace SecretClientTasksBackend.Repository
{
    public interface ICsvFileRepository
    {
        Task<bool> DownloadCsvFile(IFormFile file);
        Task<FileContentResult> UploadCsvFile();
    }
}
