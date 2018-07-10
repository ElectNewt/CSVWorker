using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
    internal class UlongConverter : BaseConverter
    {
        public UlongConverter(object value) : base(value)
        {
        }

        public override object ConvertToObject(string format, IFormatProvider provider) => Convert.ToUInt64(Value, provider);

        public override string GetString(string format, IFormatProvider provider) => Convert.ToUInt64(Value).ToString(format, provider);

    }
}