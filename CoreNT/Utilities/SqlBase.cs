using Core.Utilities.Result;
using CoreNT.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CoreNT.Utilities
{
    public class SqlBase
    {
        private SqlConnection sqlConnection;
        readonly string conStr;
        public SqlBase(StringValue value)
        {
            conStr = value.Value;
        }


        public DataTable GetDataTable(string tableName)
        {
            DataTable dt;
            using (sqlConnection = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM {tableName}", sqlConnection);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
            }
            return dt;
        }

        public List<string> GetTables()
        {
            return getTables();
        }
        public List<DataColumn> GetDataColumns(string tableName)
        {
            return getColumns(tableName);
        }
        public IResult QueryExecute(string query)
        {
            try
            {
                using (sqlConnection = new SqlConnection(conStr))
                {
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    //command.Connection.Open();
                    openSql();
                    command.ExecuteNonQuery();
                    closeSql();
                }
                return new SuccessResult("Başarılı");
            }
            catch (Exception err)
            {
                return new ErrorResult("Hata:" + err.Message);
            }
        }

        public IResult DeleteAllRows(string tableName)
        {

            string query = $"DELETE FROM {tableName}";
            try
            {
                using (sqlConnection = new SqlConnection(conStr))
                {
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    //command.Connection.Open();
                    openSql();
                    command.ExecuteNonQuery();
                    closeSql();
                }
                return new SuccessResult("Başarılı");
            }
            catch (Exception err)
            {
                return new ErrorResult("Hata:" + err.Message);
            }
        }

        public IResult DeleteTable(string tableName)
        {
            string query = $"DROP TABLE {tableName}";
            try
            {
                using (sqlConnection = new SqlConnection(conStr))
                {
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    //command.Connection.Open();
                    openSql();
                    command.ExecuteNonQuery();
                    closeSql();
                }
                return new SuccessResult("Başarılı");
            }
            catch (Exception err)
            {
                return new ErrorResult("Hata:" + err.Message);
            }
        }

        private List<string> getTables()
        {
            List<string> result = new List<string>();
            using (sqlConnection = new SqlConnection(conStr))
            {
                SqlCommand sqlCommand = new SqlCommand(
                                $"SELECT NAME FROM {sqlConnection.Database}.SYS.TABLES",
                                sqlConnection
                                );

                openSql();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(reader[0].ToString());
                }
                closeSql();
            }


            return result;
        }

        private List<DataColumn> getColumns(string tableName)
        {
            List<DataColumn> columns = new List<DataColumn>();
            using (sqlConnection = new SqlConnection(conStr))
            {
                SqlCommand sqlCommand = new SqlCommand(
                $"SELECT * FROM {tableName}",
                sqlConnection
                );

                openSql();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    DataColumn dataColumn = new DataColumn(reader.GetName(i));
                    dataColumn.DataType = reader.GetFieldType(i);
                    columns.Add(dataColumn);
                }
                closeSql();
            }

            return columns;
        }

        private void openSql()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }

        private void closeSql()
        {
            sqlConnection.Close();
        }
    }
}
