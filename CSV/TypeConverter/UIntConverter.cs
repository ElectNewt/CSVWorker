using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
    internal class UIntConverter : BaseConverter
    {
        public UIntConverter(object value) : base(value)
        {
        }

        public override object ConvertToObject(string format, IFormatProvider provider) => Convert.ToUInt32(Value, provider);
 

        public override string GetString(string format, IFormatProvider provider) =>  Convert.ToUInt32(Value).ToString(format, provider);
    }
}
