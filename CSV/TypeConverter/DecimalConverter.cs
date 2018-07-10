using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
    internal class DecimalConverter : BaseConverter
    {
        public DecimalConverter(object value) : base(value)
        {
        }

        public override object ConvertToObject(string format, IFormatProvider provider)=> Convert.ToDecimal(Value, provider);

        public override string GetString(string format, IFormatProvider provider)=> Convert.ToDecimal(Value).ToString(format, provider);
    }
}
