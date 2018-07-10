using System.Collections.Generic;

namespace CSV.DTO
{
    public class CsvContent
    {
        internal List<CsvField> Headers { get; set; }
        internal List<CsvRow> Rows { get; set; }
        public CsvContent()
        {
            Headers = new List<DTO.CsvField>();
            Rows = new List<CsvRow>();
        }
    }
}
