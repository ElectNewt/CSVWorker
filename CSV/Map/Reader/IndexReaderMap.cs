using CSV.Map.Common;
using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CSV.Map.Reader
{
    public class IndexReaderMap<T> : IReaderMap<T>
    {
        private int CsvPositionField { get; set; }
        private PropertyInfo TargetField { get; set; }
        private Formatter Formatter { get; set; }

        public IndexReaderMap(int index, Expression<Func<T, dynamic>> targetField)
        {
            CsvPositionField = index;
            TargetField = TargetField = typeof(T).GetProperties().FirstOrDefault(a => a.Name == (targetField.Body as MemberExpression ?? ((UnaryExpression)targetField.Body).Operand as MemberExpression).Member.Name);
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

        public int GetPosition() => CsvPositionField;

        public string GetPropertyName() => null;

        public Formatter Format() => Formatter;
        public void Format(string format) => Format(format, CultureInfo.CurrentCulture);
        public void Format(IFormatProvider provider) => Format(Formatter.Format, provider);
        public void Format(string format, IFormatProvider provider)
        {
            Formatter.Format = format;
            Formatter.Provider = provider;
        }

        
    }
}
