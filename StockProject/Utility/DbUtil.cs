using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class DbUtil : IDisposable
    {
        #region インスタンス変数の定義
        private DbConnection _conn = null;
        private DbTransaction _tran = null;
        #endregion

        public DbUtil()
        {
            DBConnect();
        }

        /// <summary>
        /// DB接続
        /// </summary>
        private void DBConnect()
        {
            if (!_conn.IsEmpty()) return;

            _conn = DbProviderFactories.GetFactory("System.Data.SQLite").CreateConnection();
            _conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            _conn.Open();

            _tran = _conn.BeginTransaction();
            return;    

        }

        /// <summary>
        /// SELECTを発行して結果を取得する
        /// </summary>
        /// <typeparam name="T">戻り値の型</typeparam>
        /// <param name="SqlString">SQL文字列</param>
        /// <param name="param">SQL文のバインド値のリスト</param>
        /// <returns>SQLで取得した結果のList</returns>
        public List<T> DBSelect<T>(string SqlString, object param = null)
        {
            return _conn.Query<T>(SqlString, param).ToList<T>();
        }

        public int DBInsert(string SqlString, object param = null)
        {
            return DBExecute(SqlString, param);
        }

        public int DBUpdate(string SqlString, object param = null)
        {
            return DBExecute(SqlString, param);
        }

        private int DBExecute(string SqlString, object param = null)
        {
            try
            {
                int rowCount = _conn.Execute(SqlString, param);
                return rowCount;
            }
            catch (Exception e)
            {
                _tran.Rollback();
                _tran.Dispose();
                _tran = null;
                throw e;
            }
        }

        public void DBExecuteSQL(string SqlString)
        {
            try
            {
                _conn.Execute(SqlString);
            }
            catch (Exception e)
            {
                _tran.Rollback();
                _tran.Dispose();
                _tran = null;
                throw e;
            }
        }

        private void DBCommit()
        {
            if (!_tran.IsEmpty())
            {
                _tran.Commit();
            }
        }

        private void DBRollback()
        {
            if (!_tran.IsEmpty())
            {
                _tran.Rollback();
            }
        }


        public void Dispose()
        {
            if (!_tran.IsEmpty())
            {
                _tran.Commit();
                _tran.Dispose();
                _tran = null;
            }
            if (!_conn.IsEmpty())
            {
                _conn.Close();
                _conn.Dispose();
                _conn = null;
            }
        }
    }
}
