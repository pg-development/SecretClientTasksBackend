using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using ClosedXML.Excel;

namespace SecretClientTasksBackend.Models
{
    public class SCTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public long Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Voivodeship { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Gratification { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        public string WaitingPeriod { get; set; } = string.Empty;
        public string SCEmails {  get; set; } = string.Empty;

        public static SCTask GetDefaultSCTask()
        {
            return new SCTask
            {
                Id = 0,
                Name = String.Empty,
                Description = string.Empty,
                City = String.Empty,
                Voivodeship = String.Empty,
                Address = String.Empty,
                Gratification = String.Empty,
                StartDate = DateTime.MinValue,
                EndDate = DateTime.MinValue,
                WaitingPeriod = String.Empty,
                SCEmails = String.Empty
            };
        }

        public static DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("City", typeof(string)));
            dt.Columns.Add(new DataColumn("Voivodeship", typeof (string)));
            dt.Columns.Add(new DataColumn("Address", typeof(string)));
            dt.Columns.Add(new DataColumn("Gratification", typeof(string)));
            dt.Columns.Add(new DataColumn("StartDate", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("EndDate", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("WaitingPeriod", typeof(string)));
            dt.Columns.Add(new DataColumn("SCEmails", typeof(string)));

            return dt;
        }

        public static byte[] GetExcelFileByteArray(DataTable dataTable)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Data");

                // Przeniesienie danych z DataTable do arkusza
                worksheet.Cell(1, 1).InsertTable(dataTable);

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
