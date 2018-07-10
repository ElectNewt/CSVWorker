using CSV.Map.Common;
using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CSV.Map.Writer
{
    public class WriteMap<T> : IWriterMap<T>
    {
        private int CsvPosition { get; set; }
        private PropertyInfo TargetField { get; set; }
        private Formatter Formatter { get; set; }
        private string CsvHeaderName { get; set; }
        private bool CsvVisible { get; set; }


        public WriteMap(Expression<Func<T, dynamic>> targetField, int position = 0, string headername = "", bool visible = true)
        {
            CsvPosition = position;
            TargetField = TargetField = typeof(T).GetProperties().FirstOrDefault(a => a.Name == (targetField.Body as MemberExpression ?? ((UnaryExpression)targetField.Body).Operand as MemberExpression).Member.Name);
            CsvHeaderName = headername;
            CsvVisible = visible;
            Formatter = new Formatter() { Format = "", Provider = CultureInfo.CurrentCulture };
        }

        public PropertyInfo GetProperty() => TargetField;
        public Formatter Format() => Formatter;
        public IWriterMap<T> Format(string format) => Format(format, Formatter.Provider);
        public IWriterMap<T> Format(IFormatProvider provider) => Format(Formatter.Format, provider);
        public IWriterMap<T> Format(string format, IFormatProvider provider)
        {
            Formatter.Format = format;
            Formatter.Provider = provider;
            return this;
        }

        public IWriterMap<T> Position(int index)
        {
            CsvPosition = index;
            return this;
        }

        public int Position() => CsvPosition;

        public string HeaderName() => CsvHeaderName;

        public bool Visible() => CsvVisible;

        public IWriterMap<T> HeaderName(string headerName)
        {
            CsvHeaderName = headerName;
            return this;
        }
        public IWriterMap<T> Visible(bool visibility)
        {
            CsvVisible = visibility;
            return this;
        }


    }
}
