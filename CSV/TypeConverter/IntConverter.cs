using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
   
    internal class IntConverter : BaseConverter
    {
        public IntConverter(object value) : base(value)
        {
        }

        public override object ConvertToObject(string format, IFormatProvider provider)=> Convert.ToInt32(Value, provider);
  

        public override string GetString(string format, IFormatProvider provider) => Convert.ToInt32(Value).ToString(format, provider);
 
    }
}
