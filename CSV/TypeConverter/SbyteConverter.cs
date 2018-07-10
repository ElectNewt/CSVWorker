using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]

namespace CSV.TypeConverter
{
    internal class SbyteConverter : BaseConverter
    {
        public SbyteConverter(object value) : base(value)
        {
        }

        public override object ConvertToObject(string format, IFormatProvider provider) => Convert.ToSByte(Value, provider);

        public override string GetString(string format, IFormatProvider provider)=> Convert.ToSByte(Value, provider).ToString(format, provider);
      
    }
}
