using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
    internal class UShortConverter : BaseConverter
    {
        public UShortConverter(object value) : base(value)
        {
        }

        public override object ConvertToObject(string format, IFormatProvider provider) => Convert.ToUInt16(Value, provider);
        public override string GetString(string format, IFormatProvider provider) => Convert.ToUInt16(Value).ToString(format, provider);
    }
}
