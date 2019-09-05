using CSV.Map.Writer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CSV.ExtensionMethods;
using System.Linq.Expressions;
using System.IO;
using CSV.Configuration;
using CSV.Utilities;

namespace CSV
{
    internal class CsvWriter<T> : IWriter<T>
    {
        internal CsvWriterMapper<T> Mapper { get; set; } = new CsvWriterMapper<T>();
        public CsvWriterConfiguration Configuration { get; set; } = new CsvWriterConfiguration();
        private List<T> ListContent { get; set; }
        private string FilePath { get; set; }

        public CsvWriter()
        {
            ListContent = new List<T>();
        }

        public CsvWriter(List<T> content)
        {
            AssignContent(content);
        }

        public bool Write(string filepath, bool containsHeaders = true)
        {
            try
            {
                WriteFile(filepath, containsHeaders);
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public bool Write(List<T> content, string filepath, bool containsHeaders = true)
        {
            try
            {
                AssignContent(content);
                WriteFile(filepath, containsHeaders);
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        private void WriteFile(string filepath, bool containsHeaders)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Configuration.EmptyFilesExtension) && !ListContent.Any())
                    filepath = string.Format(filepath + "{0}", Configuration.EmptyFilesExtension);

               SetFilePath(filepath);
                Configuration.SetContainsHeaders(containsHeaders);
                var fileContent = SetFileContent();
                WriteInfile(fileContent);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void WriteInfile(string fileContent)
        {
            try
            {
                File.WriteAllText(FilePath, fileContent);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AssignContent(List<T> content)
        {
            ListContent = content;
        }

        private void SetFilePath(string filepath)
        {
            FilePath = filepath;
            if (Configuration.CreateDirectory)
            {
                new CreateDirectory(filepath).Create();
            }
        }

        private string  SetFileContent()
        {
            try
            {
                var csv = new StringBuilder();
                AppendHeaders(csv);
                foreach (var row in ListContent)
                {
                    csv.AppendLine(GenerateRow(row));
                }
                return csv.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AppendHeaders(StringBuilder csv)
        {

            if (Configuration.GetContainsHeaders())
            {
                if (Mapper.Get().Any())
                {
                    GenerateHeaderFromMapper(csv);
                }
                else
                {
                    GenerateHeaderFromClass(csv);
                }

            }
        }

        private void GenerateHeaderFromMapper(StringBuilder headersrow)
        {
            var header = new StringBuilder();
            var mapper = Mapper.Get();
            foreach (var map in mapper.Where(b => b.Visible()).OrderBy(a => a.Position()))
            {
                header.AppendDelimitter(Configuration.GetDelimiter());
                header.Append(map.HeaderName());
            }
            headersrow.AppendLine(header.ToString());
        }

        private void GenerateHeaderFromClass(StringBuilder headersrow)
        {
            var header = new StringBuilder();
            var instance = Activator.CreateInstance(typeof(T));
            foreach (var property in typeof(T).GetProperties())
            {
                header.AppendDelimitter(Configuration.GetDelimiter());
                header.Append(property.Name);
            }
            headersrow.AppendLine(header.ToString());
        }

        private string GenerateRow(T element)
        {
            if (Mapper.Get().Any())
            {
                return RowMapper(element);
            }
            else
            {
                return RowNoMapper(element);
            }
        }

        private string RowMapper(T element)
        {
            var contentRow = new StringBuilder();
            var mapper = Mapper.Get();
            var fields = typeof(T).GetProperties().ToList();
            foreach (var map in mapper.Where(b => b.Visible()).OrderBy(a => a.Position()))
            {
                contentRow.AppendDelimitter(Configuration.GetDelimiter());
                var field = fields.FirstOrDefault(a => a.Name == map.GetProperty().Name);
                contentRow.Append(ValidateCommas(field.GetValue(element)));
            }
            return contentRow.ToString();
        }

        private string RowNoMapper(T element)
        {
            return "";
        }
        
        private object ValidateCommas(object content)
        {
            if (content !=null && content.ToString().Contains(","))
            {
                return $"\"{content}\"";
            }

            return content;
        }

        public IWriterMap<T> Map(Expression<Func<T, dynamic>> origin)
        {
            var memberName = (origin.Body as MemberExpression ?? ((UnaryExpression)origin.Body).Operand as MemberExpression).Member.Name;
            return AddMap(origin, 0, memberName, true);
        }

        public IWriterMap<T> Map(Expression<Func<T, dynamic>> origin, string name)
        {
            return AddMap(origin, 0, name, true);
        }

        public IWriterMap<T> Map(Expression<Func<T, dynamic>> origin, string headerName, bool visible)
        {
            return AddMap(origin, 0, headerName, visible);
        }

        public IWriterMap<T> Map(Expression<Func<T, dynamic>> origin, int position, string headerName, bool visible)
        {
            return AddMap(origin, position, headerName, visible);
        }

        public IWriterMap<T> Map(Expression<Func<T, dynamic>> origin, int position, bool visible)
        {
            return AddMap(origin, position, "", visible);
        }

        public IWriterMap<T> Map(Expression<Func<T, dynamic>> origin, bool visible)
        {
            return AddMap(origin, 0, "", visible);
        }

        private IWriterMap<T> AddMap(Expression<Func<T, dynamic>> origin, int position, string headerName, bool visible)
        {
            return Mapper.Add(origin, position, headerName, visible);
        }

    }
}
