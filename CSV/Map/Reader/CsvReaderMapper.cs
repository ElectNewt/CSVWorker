using CSV.Map.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CSV.Map.Reader
{
    public class CsvReaderMapper<T>
    {
        private List<IReaderMap<T>> MapList { get; set; }

        public CsvReaderMapper()
        {
            MapList = new List<IReaderMap<T>>();
        }
        
        /// <summary>
        /// set new maplist
        /// </summary>
        /// <param name="maplist">List</param>
        public void SetMap(List<IReaderMap<T>> maplist)
        {
            MapList = maplist;
        }
        
        /// <summary>
        /// Get maplist
        /// </summary>
        /// <returns></returns>
        public List<IReaderMap<T>> Get() => MapList;
        
        /// <summary>
        /// Get index of the property in the map
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public int Get(PropertyInfo property)
        {
            try
            {
                return MapList.FirstOrDefault(a => a.IsProperty(property)).GetPosition();
            }
            catch (Exception)
            {
                return -1;
            }
        }
       
        /// <summary>
        /// GEt map name based on the property field.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public string GetField(PropertyInfo property)
        {
            try
            {
                return MapList.FirstOrDefault(a => a.IsProperty(property)).GetPropertyName();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get format of the property in the map.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public Formatter GetFormat(PropertyInfo property)
        {
            try
            {
                return MapList.FirstOrDefault(a => a.IsProperty(property)).Format();
            }
            catch (Exception)
            {
                return new Formatter() { Format = "", Provider = CultureInfo.CurrentCulture };
            }
        }
        
        /// <summary>
        /// add map based on index and expression
        /// </summary>
        /// <param name="csvIndex"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public IndexReaderMap<T> Add(int csvIndex, Expression<Func<T, dynamic>> destination)
        {
            var newmap = new IndexReaderMap<T>(csvIndex, destination);
            MapList.Add(newmap);
            return newmap;
        }
        
        /// <summary>
        /// add map based on header name and expression
        /// </summary>
        /// <param name="csvField"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public FieldReaderMap<T> Add(string csvField, Expression<Func<T, dynamic>> destination)
        {
            var newmap = new FieldReaderMap<T>(csvField, destination);
            MapList.Add(newmap);
            return newmap;
        }

        

    }
}
