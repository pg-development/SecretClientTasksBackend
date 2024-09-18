using Microsoft.AspNetCore.Mvc;
using SecretClientTasksBackend.DBContexts;
using SecretClientTasksBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Data;
using ClosedXML.Excel;

namespace SecretClientTasksBackend.Repository
{
    public class CsvFileRepository : ICsvFileRepository
    {
        private readonly SCTasksDBContext _dbContext;

        public CsvFileRepository(SCTasksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DownloadCsvFile(IFormFile file)
        {
            try
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    stream.Position = 0; // Ustaw pozycję na początku strumienia

                    using (XLWorkbook workbook = new XLWorkbook(stream))
                    {
                        var worksheet = workbook.Worksheets.First();
                        var rows = worksheet.RowsUsed();

                        bool firstRow = true;
                        foreach (var row in rows)
                        {
                            if(firstRow)
                            {
                                firstRow = false;
                                continue;
                            }

                            var cells = row.Cells().ToList();

                            SCTask scTask = SCTask.GetDefaultSCTask();

                            foreach (IXLCell cell in cells)
                            {
                                switch (cell.Address.ColumnNumber)
                                {
                                    case 1: scTask.Name = cell.GetString(); break;
                                    case 2: scTask.City = cell.GetString(); break;
                                    case 3: scTask.Voivodeship = cell.GetString(); break;
                                    case 4: scTask.Address = cell.GetString(); break;
                                    case 5: scTask.Gratification = cell.GetString(); break;
                                    case 6: scTask.StartDate = cell.GetDateTime(); break;
                                    case 7: scTask.EndDate = cell.GetDateTime(); break;
                                    case 8: scTask.WaitingPeriod = cell.GetString(); break;
                                }
                            }

                            await _dbContext.SCTasks.AddAsync(scTask);
                        }

                        await _dbContext.SaveChangesAsync();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<FileContentResult> UploadCsvFile()
        {
            try
            {
                var scTasks = await _dbContext.SCTasks.ToListAsync();

                List<byte> fileContent = new List<byte>();

                DataTable csv = Models.SCTask.GetDataTable();

                foreach (SCTask task in scTasks)
                {
                    csv.Rows.Add(task.Name, task.Description, task.City, task.Voivodeship, task.Address, task.Gratification, task.StartDate, task.EndDate, task.WaitingPeriod, task.SCEmails);
                }

                var excelFile = Models.SCTask.GetExcelFileByteArray(csv);

                var result = new FileContentResult(excelFile, @"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                result.FileDownloadName = $"Zadania_{DateTime.Now.ToShortDateString()}_{DateTime.Now.ToShortTimeString()}.xlsx";
                return result;
            }
            catch (Exception ex)
            {
                return new FileContentResult(new byte[0], @"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                throw;
            }
        }

        private byte[] GenerateCsvByteArray(DataTable input)
        {
            var stream = new MemoryStream();
            StreamWriter sw = new StreamWriter(stream);

            for (int i = 0; i < input.Columns.Count; i++)
            {
                sw.Write(input.Columns[i]);
                if (i < input.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow row in input.Rows)
            {
                for (int i = 0; i < input.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(row[i]))
                    {
                        string value = row[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(row[i].ToString());
                        }
                    }
                    if (i < input.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();

            return stream.ToArray();

        }
    }
}
