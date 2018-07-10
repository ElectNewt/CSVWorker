using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CSV.Map.Writer
{
    public class CsvWriterMapper<T>
    {
     
        private List<IWriterMap<T>> MapList { get; set; }

        public CsvWriterMapper()
        {
            MapList = new List<IWriterMap<T>>();
        }

        /// <summary>
        /// Assign a new map
        /// </summary>
        /// <param name="maplist"></param>
        public void SetMap(List<IWriterMap<T>> maplist)
        {
            MapList = maplist;
        }

        /// <summary>
        /// Get map list
        /// </summary>
        /// <returns></returns>
        public List<IWriterMap<T>> Get() => MapList;

        /// <summary>
        /// Add new mapping based on field
        /// </summary>
        /// <param name="field">linq expression</param>
        /// <returns></returns>
        public WriteMap<T> Add(Expression<Func<T, dynamic>> field)
        {
            return AddMap(field, 0, "", true);
        }

        /// <summary>
        /// add new mapping based on field and visibility
        /// </summary>
        /// <param name="field">linq expression</param>
        /// <param name="visible">set if it is visible</param>
        /// <returns></returns>
        public WriteMap<T> Add(Expression<Func<T, dynamic>> field, bool visible)
        {
            return AddMap(field,0,"",visible);
        }

        /// <summary>
        /// Add mapping based on field, header name and visibility true by default
        /// </summary>
        /// <param name="field"></param>
        /// <param name="headername"></param>
        /// <returns></returns>
        public WriteMap<T> Add(Expression<Func<T, dynamic>> field, string headername)
        {
            return AddMap(field, 0, headername, true);
        }

        /// <summary>
        /// Add mapping based on field, header name and visibility
        /// </summary>
        /// <param name="field">linq expression</param>
        /// <param name="headername">set header name</param>
        /// <param name="visible">set if it is visible</param>
        /// <returns></returns>
        public WriteMap<T> Add(Expression<Func<T, dynamic>> field, string headername, bool visible)
        {
            return AddMap(field,  0, headername, visible);
        }

        /// <summary>
        /// Add mapping based on field, position, visibility
        /// </summary>
        /// <param name="field">linq expression</param>
        /// <param name="position">csv position</param>
        /// <param name="visible">set if it is visible</param>
        /// <returns></returns>
        public WriteMap<T> Add(Expression<Func<T, dynamic>> field, int position, bool visible)
        {
            return AddMap(field, position, "", visible);
        }

        /// <summary>
        /// Add mapping based on field, position, visibility default true
        /// </summary>
        /// <param name="field">linq expression</param>
        /// <param name="position">csv position</param>
        /// <returns></returns>
        public WriteMap<T> Add(Expression<Func<T, dynamic>> field, int position)
        {
            return AddMap(field, position, "", true);
        }

        /// <summary>
        /// Add mapping based on field, position, header name and  visibility
        /// </summary>
        /// <param name="field">linq expression</param>
        /// <param name="position">csv position</param>
        /// <param name="headername">set header name</param>
        /// <param name="visible">set if it is visible</param>
        /// <returns></returns>
        public WriteMap<T> Add(Expression<Func<T, dynamic>> field, int position, string headername, bool visible)
        {
            return AddMap(field, position, headername, visible);
        }

        /// <summary>
        /// Add mapping based on field, position, header name and  visibility
        /// </summary>
        /// <param name="field">linq expression</param>
        /// <param name="position">csv position</param>
        /// <param name="headername">set header name</param>
        /// <param name="visible">set if it is visible</param>
        /// <returns></returns>
        private WriteMap<T> AddMap(Expression<Func<T, dynamic>> field, int position, string headername, bool visible)
        {
            var writemap = new WriteMap<T>(field,  position, headername, visible);
            MapList.Add(writemap);
            return writemap;
        }

        


    }
}
