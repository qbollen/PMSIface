using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Utils
{
    public class SqlHelper
    {
        private Params myXml = new Params();

        public SqlHelper()
        {
            _currConn = DbType.Local;
        }

        private string ConnString(string path, string pwd, bool isRemote)
        {
            return @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + 
                   (isRemote ? "":@"|DataDirectory|\") + 
                   path + 
                   ";Jet OLEDB:Database Password=" + 
                   pwd;
        }

        /// <summary>
        /// 确定连接目标数据库
        /// </summary>
        private DbType _currConn;
        public DbType CurrConn
        {
            set
            {
                _currConn = value;
            }

            get
            {
                return _currConn;
            }
        }

        private string ConnStr()
        {
            if (_currConn == DbType.Remote)
            {
                return ConnString(myXml.Db_Room, "orbita91.wxy-", true);
            }

            return ConnString(myXml.Db, "orbitatech2013", false); 
        }

        public int ExecuteNonQuery(string sql, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnStr()))
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                if ((parameters != null) && (parameters.Length > 0))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
        }

        public DataSet ExecuteDataSet(string sql, string tableName, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnStr()))
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                if (parameters != null)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                }

                DataSet ds = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                if (tableName != null)
                {
                    adapter.Fill(ds, tableName);
                }
                else
                {
                    adapter.Fill(ds);
                }

                return ds;
            }

        }

        public OleDbDataReader ExecuteDataReader(string sql, params OleDbParameter[] parameters)
        {
            OleDbConnection conn = new OleDbConnection(ConnStr());
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.Open();
            if (parameters != null)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parameters);
            }

            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public object ExecuteScalar(string sql, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnStr()))
            {
                OleDbCommand cmd = new OleDbCommand(sql,conn);
                conn.Open();
                if (parameters != null)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                }

                return cmd.ExecuteScalar();
            }
        }
    }

    public enum DbType
    {
        Local,
        Remote
    }

}
