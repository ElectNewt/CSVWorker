using System;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
    internal class DateTimeConverter : BaseConverter
    {
        public DateTimeConverter(object value) : base(value)
        {
        }

        public override object ConvertToObject(string format, IFormatProvider provider) => DateTime.ParseExact(Value.ToString(), format, provider);
        public override string GetString(string format, IFormatProvider provider) => DateTime.Parse(Value.ToString()).ToString(format, provider);
    }
}
