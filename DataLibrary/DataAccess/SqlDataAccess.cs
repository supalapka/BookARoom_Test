using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.DataAccess
{
    public class SqlDataAccess
    {
        public static string connectionString; 
        public static string GetConnectionString()
        {
            return connectionString;
        }

        public static async Task<List<T>> LoadDataAsync<T>(string sql)
        {
            using (IDbConnection ctx = new SqlConnection(GetConnectionString()))
            {
                var result =  await ctx.QueryAsync<T>(sql);
                return result.ToList();
            }
        }

        public static async Task SaveDataAsync<T>(string sql, T data)
        {
            using (IDbConnection ctx = new SqlConnection(GetConnectionString()))
            {
                await ctx.ExecuteAsync(sql, data);
            }
        }

        public static async Task<T> GetOjbectAsync<T>(string dbTable, string paramName, string paramValue)
        {
            using (IDbConnection ctx = new SqlConnection(GetConnectionString()))
            {
                var result = await ctx.QueryAsync<T>($"select * from dbo.{dbTable} where {paramName} = '{paramValue}'");
                return result.FirstOrDefault();
            }
        }

        public static async Task<List<T>> SelectOjbectsAsync<T>(string dbTable, string paramName, string paramValue)
        {
            using (IDbConnection ctx = new SqlConnection(GetConnectionString()))
            {
                var result = await ctx.QueryAsync<T>($"select * from dbo.{dbTable} where {paramName} = {paramValue}");
                return result.ToList();
            }
        }

        public static async Task ExecuteSqlRequestAsync(string sql)
        {
            using (IDbConnection ctx = new SqlConnection(GetConnectionString()))
            {
                await ctx.ExecuteAsync(sql);
            }
        }

        public static async Task<int> GetSumAsync(string sql) //rename and set generic type
        {
            using (IDbConnection ctx = new SqlConnection(GetConnectionString()))
            {
                return Convert.ToInt32(await ctx.QueryAsync<int>(sql));
            }
        }
    }
}
