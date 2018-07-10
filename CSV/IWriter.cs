using CSV.Map.Writer;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CSV.Configuration;

namespace CSV
{
    public interface IWriter<T>
    {

        CsvWriterConfiguration Configuration { get; set; }

        bool Write(string filepath, bool containsHeaders = true);
        bool Write(List<T> content, string filepath, bool containsHeaders = true);
        void AssignContent(List<T> content);
        IWriterMap<T> Map(Expression<Func<T, dynamic>> origin);
        IWriterMap<T> Map(Expression<Func<T, dynamic>> origin, string name);
        IWriterMap<T> Map(Expression<Func<T, dynamic>> origin, string headerName, bool visible);
        IWriterMap<T> Map(Expression<Func<T, dynamic>> origin, int position, string headerName, bool visible);
        IWriterMap<T> Map(Expression<Func<T, dynamic>> origin, int position, bool visible);
        IWriterMap<T> Map(Expression<Func<T, dynamic>> origin, bool visible);
    }
}
