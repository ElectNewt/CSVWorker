using CSV.Configuration;
using CSV.DTO;
using CSV.Map;
using CSV.Map.Common;
using CSV.Map.Reader;
using CSV.Utilities;
using CSV.TypeConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSV
{
    internal class CsvReader<T>  : IReader<T>
    {
        public List<CsvRow> Rows => GetRows();
        public List<CsvField> Headers => GetHeaders();

        private string Filepath { get; set; }
        private CsvContent CsvContent { get; set; } = new CsvContent();
        private CsvReaderMapper<T> Mapper { get; set; } = new CsvReaderMapper<T>();
        public CsvReaderConfiguration Configuration { get; set; } = new CsvReaderConfiguration();

        public CsvReader(string path, string file, bool containsHeaders = true) 
        {
            Configuration.SetContainsHeaders(containsHeaders);
            Filepath = path + "\\" + file;
            
        }
        public CsvReader(string filepath, bool containsHeaders = true) 
        {
            Configuration.SetContainsHeaders(containsHeaders);
            Filepath = filepath;
        }

        /// <summary>
        /// Get all the rows of the csv file
        /// </summary>
        /// <returns></returns>
        private List<CsvRow> GetRows()
        {
            ReadCsvContent();
            return CsvContent.Rows;
        }

        /// <summary>
        /// Get the list of headers of the CSV
        /// </summary>
        /// <returns></returns>
        private List<CsvField> GetHeaders()
        {
            ReadCsvContent();
            return CsvContent.Headers;
        }

        /// <summary>
        /// Convert the current CSV to a csv object
        /// allows to set false the second parameter to indicate that there is no headers
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private CsvContent ParseCsvData(string path)
        {
            var csv = new CsvContent();
            var parser = new ParseCsv(Configuration);
            var parsedFile = parser.FromFile(path);

            var enumerable = parsedFile as IList<string>[] ?? parsedFile.ToArray();
            if (Configuration.GetContainsHeaders())
            {
                var headrs = enumerable.Take(1);
                var counter = 0;
                foreach (var headlist in headrs)
                {
                    foreach (var element in headlist)
                    {
                        var head = new CsvField();
                        head.Field = element == null ? "" : element.ToString();
                        head.Position = counter;
                        csv.Headers.Add(head);
                        counter++;
                    }
                }
            }

            //skip the first row if contains headers
            var rows = enumerable.Skip((Configuration.GetContainsHeaders() ? 1 : 0));

            foreach (var row in rows)
            {
                var counter = 0;
                var rowline = new CsvRow();
                foreach (string element in row)
                {
                    rowline.FieldValue.Add(new CsvField { Value = element == null ? "" : element.ToString(), Position = counter, Field =  (csv.Headers.Any() ? csv.Headers.ElementAt(counter).Field:"" ) });
                    counter++;
                }
                csv.Rows.Add(rowline);
            }
            return csv;
        }

        private void ReadCsvContent()
        {
            if(!CsvContent.Rows.Any() && !CsvContent.Headers.Any())
                CsvContent = ParseCsvData(Filepath);
        }
        
        public List<T> Read()
        {
            ReadCsvContent();

            var returnedlist = new List<T>();
            foreach (var row in CsvContent.Rows)
            {
                CreateRowObject(returnedlist, row);
            }

            return returnedlist;
        }
        
        public List<T> Read(Func<CsvRow, bool> predicate)
        {
            ReadCsvContent();

            var returnedlist = new List<T>();
            foreach (var row in CsvContent.Rows.Where(predicate))
            {
                CreateRowObject(returnedlist, row);
            }

            return returnedlist;
        }

        /// <summary>
        /// Parse the information correctly
        /// </summary>
        /// <param name="returnedlist"></param>
        /// <param name="row"></param>
        private void CreateRowObject(List<T> returnedlist, CsvRow row)
        {
            var instance = Activator.CreateInstance(typeof(T));
            foreach (var property in typeof(T).GetProperties())
            {
                try
                {
                    var propertyPosition = Mapper.Get(property);

                    property.SetValue(instance, TypeAutoMapper((propertyPosition != -1 ? row[propertyPosition] : row[Mapper.GetField(property) ?? property.Name]),
                        property.PropertyType, Mapper.GetFormat(property)));
                }
                catch (Exception)
                {
                    property.SetValue(instance, null);
                }
            }
            returnedlist.Add((T)(object)instance);
        }

        public IReaderMap<T> Map(dynamic csvField, Expression<Func<T, dynamic>> destination)
        {
            return Mapper.Add(csvField, destination);
        }

        internal object TypeAutoMapper(object value, Type propertyType, Formatter formatter)
        {
            if (propertyType == typeof(string))
            {
                return new StringConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else if (propertyType == typeof(int))
            {
                return new IntConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else if (propertyType == typeof(DateTime))
            {
                return new DateTimeConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else if (propertyType == typeof(TimeSpan))
            {
                return new TimesSpanConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else if (propertyType == typeof(decimal))
            {
                return new DecimalConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else if (propertyType == typeof(bool))
            {
                return new BooleanConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else if (propertyType == typeof(byte))
            {
                return new ByteConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else if (propertyType == typeof(sbyte))
            {
                return new SbyteConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else if (propertyType == typeof(char))
            {
                return new CharConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else if (propertyType == typeof(double))
            {
                return new DoubleConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else if (propertyType == typeof(float))
            {
                return new FloatConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else if (propertyType == typeof(short))
            {
                return new ShortConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else if (propertyType == typeof(long))
            {
                return new LongConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else if (propertyType == typeof(uint))
            {
                return new UIntConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else if (propertyType == typeof(ushort))
            {
                return new UShortConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else if (propertyType == typeof(ulong))
            {
                return new UlongConverter(value).ConvertToObject(formatter.Format, formatter.Provider);
            }
            else
            {
                return null;
            }
        }

    }
}
