using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EmployeeApplication.DataModel
{
    [Serializable]
    public abstract class Base
    {
        public bool isDataPopulated { get; set; }
        public Base()
        {
            isDataPopulated = false;
        }

        public Base(DataRow dataRow) : this()
        {

        }
        internal int GetInteger(DataRow dataRow, string column)
        {
            object Intvalue = ReturnValue(dataRow, column);
            return (Intvalue == null ? -1 : Convert.ToInt32(Intvalue));
        }

        internal string GetString(DataRow dataRow, string columnName)
        {
            object stringValue = ReturnValue(dataRow, columnName);
            return (stringValue == null ? "" : Convert.ToString(stringValue));
        }

        internal DateTime GetDateTime(DataRow pData, string columnName)
        {
            object dateValue = ReturnValue(pData, columnName);
            return (dateValue == null ? DateTime.MinValue : Convert.ToDateTime(dateValue));
        }
        internal bool GetBoolean(DataRow pData, string columnName)
        {
            object booleanValue = ReturnValue(pData, columnName);
            return (booleanValue == null ? false : Convert.ToBoolean(booleanValue));
        }
        private object ReturnValue(DataRow dataRow, string columnName)
        {
            bool columnExists = dataRow.Table.Columns.Contains(columnName);

            switch (columnExists)
            {
                case true:
                    return (dataRow[columnName] == DBNull.Value ? null : dataRow[columnName]);
                case false:
                    throw new Exception($"{GetType().Name} requires the column [{columnName}] to be returned from the database.");
            }

            return null;
        }
    }
}