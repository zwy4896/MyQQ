/*
 定义数据库连接字符串和数据库连接对象
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MyQQ
{
    class DataOperator
    {
        // 数据库连接字符串
        private static string connString = @"Data Source=ZEETOP\ZWYSQLSERVER;Database=db_MyQQ;User ID=sa;Pwd=ZWY785@zwy;";
        // 数据库连接对象
        public static SqlConnection connection = new SqlConnection(connString);

        public int ExecSQL(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);  //指定要执行的sql语句
            if (connection.State == ConnectionState.Closed)  // 如果当前数据库连接处于关闭状态
            {
                connection.Open();  // 打开数据库连接
            }
            int num = Convert.ToInt32(command.ExecuteScalar());  //执行查询
            connection.Close();
            return num;
        }

        public int ExecSQLResult(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);  // 指定要执行的sql语句
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            int result = command.ExecuteNonQuery();  //执行SQL语句
            connection.Close();  //关闭数据库连接
            return result;
        }

        public DataSet GetDataSet(string sql)
        {
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();  //创建数据集对象
            sqlda.Fill(ds);  // 填充数据集
            return ds;  //返回数据集
        }

        //  GetDataReader方法，用来执行SQL查询，并返回SqlDataReader。
        public SqlDataReader GetDataReader(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);
            if (connection.State == ConnectionState.Open)  //如果当前数据库连接处于打开状态
            {
                connection.Close();  //关闭数据库连接  ？？为什么要这么做？
            }
            connection.Open();  //  打开连接
            SqlDataReader dataReader = command.ExecuteReader();
            return dataReader;
        }
    }
}
