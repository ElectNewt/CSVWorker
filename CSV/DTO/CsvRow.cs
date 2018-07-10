using System.Collections.Generic;
using System.Linq;

namespace CSV.DTO
{
    public class CsvRow
    {
        internal List<CsvField> FieldValue { get; set; }
       
        /// <summary>
        /// Get row information by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public dynamic this[int index] => GetFieldByPosition(index);

        /// <summary>
        /// Get row information by headername
        /// </summary>
        /// <param name="searchField"></param>
        /// <returns></returns>
        public dynamic this[string searchField] => GetFieldByString(searchField);

        public CsvRow()
        {
            FieldValue = new List<CsvField>();
        }

        private dynamic GetFieldByPosition(int position)
        {
            return FieldValue.ElementAt(position).Value.ToString();
        }

        private dynamic GetFieldByString(string searchField)
        {
            return FieldValue.First(a => a.Field.ToUpper() == searchField.ToUpper()).Value;
        }
    }
}
