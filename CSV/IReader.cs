using CSV.Configuration;
using CSV.DTO;
using CSV.Map;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CSV
{
    public interface IReader <T>
    {
        List<CsvRow> Rows { get; }
        List<CsvField> Headers {get;}
        CsvReaderConfiguration Configuration { get; set; }

        /// <summary>
        /// Convert the text to a list.
        /// </summary>
        /// <returns></returns>
        List<T> Read();

        /// <summary>
        /// Convert the text to a list.
        /// Allow to send criteria
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<T> Read(Func<CsvRow, bool> predicate);

        /// <summary>
        /// Add a mapping, allows csv field as the index or the header text
        /// </summary>
        /// <param name="csvField"></param>
        /// <param name="destination"></param>
        IReaderMap<T> Map(dynamic csvField, Expression<Func<T, dynamic>> destination);

    }
}
