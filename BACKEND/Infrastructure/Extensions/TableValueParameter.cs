﻿using Dapper;
using System.Data;
using System.Reflection;

namespace Infrastructure.Extensions
{
    public static class TableValueParameter
    {
        /// <summary>
        /// This extension converts an enumerable set to a Dapper TVP
        /// </summary>
        /// <typeparam name="T">type of enumerbale</typeparam>
        /// <param name="enumerable">list of values</param>
        /// <param name="typeName">database type name</param>
        /// <param name="orderedColumnNames">if more than one column in a TVP, 
        /// columns order must mtach order of columns in TVP</param>
        /// <returns>a custom query parameter</returns>
        public static SqlMapper.ICustomQueryParameter AsTableValuedParameter<T>
                   (this IEnumerable<T> enumerable,
                   string typeName, bool typecolumns, IEnumerable<string> columns, IEnumerable<string> orderedColumnNames = null)
        {
            var dataTable = new DataTable();
            if (typeof(T).IsValueType || typeof(T).FullName.Equals("System.String"))
            {
                dataTable.Columns.Add(orderedColumnNames == null ?
                    "NONAME" : orderedColumnNames.First(), typeof(T));
                foreach (T obj in enumerable)
                {
                    dataTable.Rows.Add(obj);
                }
            }
            else
            {
                PropertyInfo[] properties = typeof(T).GetProperties
                    (BindingFlags.Public | BindingFlags.Instance);
                PropertyInfo[] readableProperties = properties.Where
                    (w => w.CanRead).ToArray();

                //if (readableProperties.Length > 1 && orderedColumnNames == null)
                //    throw new ArgumentException("Ordered list of column names must be provided when TVP contains more than one column");

                string[] columnNames;

                if (typecolumns)
                    columnNames = (orderedColumnNames ?? readableProperties.Select(s => s.Name)).Where(h => columns.Contains(h)).ToArray();
                else
                    columnNames = (orderedColumnNames ?? readableProperties.Select(s => s.Name)).ToArray();


                try
                {
                    foreach (string name in columnNames)
                    {
                        //dataTable.Columns.Add(name, readableProperties.Single(s => s.Name.Equals(name)).PropertyType);
                        var pi = readableProperties.Single(s => s.Name.Equals(name));
                        dataTable.Columns.Add(name, Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType);
                    }
                }
                catch //(Exception ex)
                {

                    throw;
                }

                foreach (T obj in enumerable)
                {
                    dataTable.Rows.Add(
                        columnNames.Select(s => readableProperties.Single
                            (s2 => s2.Name.Equals(s)).GetValue(obj))
                            .ToArray());
                }
            }
            return dataTable.AsTableValuedParameter(typeName);
        }
    }
}