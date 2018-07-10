using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
    internal class BaseConverter : ITypeConverter
    {
        internal readonly object Value;

        public BaseConverter(object value)
        {
            Value = value;
        }

        public virtual object ConvertToObject(string format, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public virtual string GetString(string format, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
