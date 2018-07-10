using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
   internal class BooleanConverter : BaseConverter
    {
        public BooleanConverter(object value) : base(value)
        {
        }

        public override object ConvertToObject(string format, IFormatProvider provider) => Convert.ToBoolean(Value, provider);
        

        public override string GetString(string format, IFormatProvider provider) => Convert.ToBoolean(Value).ToString(provider);
    }
}
