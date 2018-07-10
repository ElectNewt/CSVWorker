using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
    internal class ByteConverter : BaseConverter
    {
        public ByteConverter(object value) : base(value)
        {
        }

        public override object ConvertToObject(string format, IFormatProvider provider) => Convert.ToByte(Value, provider);

        public override string GetString(string format, IFormatProvider provider) => Convert.ToByte(Value).ToString(format, provider);
    }
}
