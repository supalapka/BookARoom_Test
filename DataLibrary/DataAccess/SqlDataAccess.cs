using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary.DataAccess
{
    public class SqlDataAccess
    {
        public static string connectionString; 
        public static string GetConnectionString()
        {
            return connectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection ctx = new SqlConnection(GetConnectionString()))
            {
                return ctx.Query<T>(sql).ToList();
            }
        }

        public static void SaveData<T>(string sql, T data)
        {
            using (IDbConnection ctx = new SqlConnection(GetConnectionString()))
            {
                ctx.Execute(sql, data);
            }
        }

        public static T GetOjbect<T>(string dbTable, string paramName, string paramValue)
        {
            using (IDbConnection ctx = new SqlConnection(GetConnectionString()))
            {
                return ctx.Query<T>($"select * from dbo.{dbTable} where {paramName} = '{paramValue}'").FirstOrDefault();
            }
        }

        public static List<T> SelectOjbects<T>(string dbTable, string paramName, string paramValue)
        {
            using (IDbConnection ctx = new SqlConnection(GetConnectionString()))
            {
                return ctx.Query<T>($"select * from dbo.{dbTable} where {paramName} = {paramValue}").ToList();
            }
        }

        public static void ExecuteSqlRequest(string sql)
        {
            using (IDbConnection ctx = new SqlConnection(GetConnectionString()))
            {
                ctx.Execute(sql);
            }
        }
    }
}
