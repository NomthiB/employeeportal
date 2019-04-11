using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeApplication.DataModel
{
    public class DatabaseAccess
    {
        private string dbConnectionString { get; set; }
        private List<SqlParameter> parametersList;
        private string dbName { get; set; }
        public DatabaseAccess()
        {
            dbConnectionString = ConfigurationManager.ConnectionStrings["Local_Connection"].ConnectionString;
            dbName = "TestDB_Nomthi";
        }

        private object ExecuteCommand(ExecutionCommands executionCommands, CommandType commandType, string command, int timeout = 30)
        {
            SqlCommand sqlCommand = null;
            SqlCommand Command = null;
            object lResult = null;

            try
            {
                //create connection
                using (SqlConnection sqlConnection = new SqlConnection(dbConnectionString))
                {
                    try
                    {
                        //open connection
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand("USE " + dbName, sqlConnection);
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.ExecuteNonQuery();


                        //create command
                        Command = new SqlCommand(command, sqlConnection);
                        if (timeout > 30) Command.CommandTimeout = timeout;
                        Command.CommandType = commandType;
                        if (commandType == CommandType.StoredProcedure)
                        {
                            foreach (SqlParameter sqlParameter in parametersList)
                            {
                                Command.Parameters.Add(sqlParameter);
                            }
                        }


                        //execute command                    
                        switch (executionCommands)
                        {
                            case ExecutionCommands.Scalar:
                                lResult = Command.ExecuteScalar();
                                break;
                            case ExecutionCommands.NonQuery:
                                lResult = Command.ExecuteNonQuery();
                                break;
                            case ExecutionCommands.DataSet:
                                DataSet lDataResult = new DataSet();
                                SqlDataAdapter lDataAdapter = new SqlDataAdapter(Command);
                                lDataAdapter.Fill(lDataResult);
                                lResult = lDataResult;
                                break;
                        }

                    }
                    catch (SqlException sqlEx)
                    {
                        switch (executionCommands)
                        {
                            case ExecutionCommands.Scalar:
                                lResult = false;
                                break;
                            case ExecutionCommands.DataSet:
                                lResult = new DataSet();
                                break;
                        }

                        throw sqlEx;
                    }
                }

            }
            catch (Exception exc)
            {
                switch (executionCommands)
                {
                    case ExecutionCommands.Scalar:
                        lResult = false;
                        break;
                    case ExecutionCommands.DataSet:
                        lResult = new DataSet();
                        break;
                }

                throw new Exception("An error occurred whilst querying the database.", exc);
            }

            return lResult;
        }

        protected DataSet ExecuteDataSet(string pCommand, int pCommandTimeOut = 30)
        {
            DataSet lResult = (DataSet)ExecuteCommand(ExecutionCommands.DataSet, CommandType.StoredProcedure, pCommand, pCommandTimeOut);
            return lResult;
        }

        protected object ExecuteScalar(string pCommand, int pCommandTimeOut = 30)
        {
            object lResult = ExecuteCommand(ExecutionCommands.Scalar, CommandType.StoredProcedure, pCommand, pCommandTimeOut);
            return lResult;
        }

        protected int ExecuteNonQuery(string pCommand, int pCommandTimeOut = 30, bool pUseTransaction = false)
        {
            int lResult = (int)ExecuteCommand(ExecutionCommands.NonQuery, CommandType.StoredProcedure, pCommand, pCommandTimeOut);
            return lResult;
        }
        protected void clearParameters()
        {
            parametersList = new List<SqlParameter>();
        }

        protected void addParameter(string parameterName, SqlDbType parameterType, object parameterValue)
        {
            SqlParameter sqlParameter;
            string parameterString = "null object";
            bool lNullDate = false;

            //check collection
            if (parametersList == null)
            {
                parametersList = new List<SqlParameter>();
            }

            //create parameter

            if (parameterType == SqlDbType.DateTime)
            {
                lNullDate = Convert.ToDateTime(parameterValue) == DateTime.MinValue;
            }
            if (parameterValue != null)
            {
                parameterString = parameterValue.ToString().Trim();
            }

            sqlParameter = new SqlParameter(parameterName, parameterType);


            //check parameter value
            if (parameterValue == null || parameterString == "" || lNullDate)
            {
                sqlParameter.Value = DBNull.Value;
            }
            else
            {
                sqlParameter.Value = parameterValue;
            }

            //add to parameter array
            parametersList.Add(sqlParameter);
        }
    }
}