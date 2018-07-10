using CSV.Map.Common;
using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CSV.Map.Reader
{
    public class FieldReaderMap<T> : IReaderMap<T>
    {
        private string CsvField { get; set; }
        private PropertyInfo TargetField { get; set; }
        private Formatter Formatter { get; set; }

        public FieldReaderMap(string sourceField, Expression<Func<T, dynamic>> targetField)
        {
            TargetField = typeof(T).GetProperties().FirstOrDefault(a => a.Name == (targetField.Body as MemberExpression ?? ((UnaryExpression)targetField.Body).Operand as MemberExpression).Member.Name);
            CsvField = sourceField;
            Formatter = new Formatter() { Format = "", Provider = CultureInfo.CurrentCulture };
        }

        public bool IsProperty(PropertyInfo property)
        {
            if (property == TargetField)
            {
                return true;
            }
            return false;
        }

        public int GetPosition()
        {
            throw new Exception("Field Mapping doesnt contains position");
        }

        public string GetPropertyName() => CsvField;
        public Formatter Format() => Formatter;
        public void Format(string format) => Format(format, Formatter.Provider);
        public void Format(IFormatProvider provider) => Format(Formatter.Format, provider);
        public void Format(string format, IFormatProvider provider)
        {
            Formatter.Format = format;
            Formatter.Provider = provider;
        }

      

    }
}
