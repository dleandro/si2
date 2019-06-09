using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace BaseDeDados
{
    public abstract class AbstractSession : ISession
    {

        private SqlTransaction currentTrans = null;
        private SqlConnection currentConn = null;
        private string cs;
        private bool TransactionVotes;

        public AbstractSession()
        {
            cs = "Server = ls_2019; Database = si2; User Id = ls_2019_user; Password = ls_2019";
        }

        public bool BeginTran()
        {
            bool st = false;
            if (currentConn == null)
            {
                throw new Exception("Connection is closed");
            }
            if (currentTrans == null)
            {
                currentTrans = currentConn.BeginTransaction();
                TransactionVotes = true;
                st = true;
            }
            return st;
        }

        public void EndTransaction(bool MyVote, bool isMyTransaction)
        {
            TransactionVotes &= MyVote;
            if (isMyTransaction)
            {
                if (TransactionVotes)
                    currentTrans.Commit();
                else
                    currentTrans.Rollback();
                currentTrans = null;
            }

        }

        public bool OpenConnection()
        {
            bool sc = false;
            if (currentConn == null)
            {
                currentConn = new SqlConnection(cs);
                currentConn.Open();
                sc = true;
            }
            return sc;
        }

        public void CloseConnection(bool isMyConnection)
        {
            if (isMyConnection && currentConn != null)
            {
                currentConn.Close();
                currentConn = null;
            }
        }

        //public SqlCommand CreateCommand()
        //{
        //    SqlCommand cmd = currentConn.CreateCommand();

        //    cmd.Transaction = currentTrans;

        //    return cmd;
        //}


        public SqlConnection GetCurrConn()
        {
            return currentConn;
        }

        public SqlTransaction GetCurrTr()
        {
            return currentTrans;
        }


        public void Dispose()
        {
            if (currentConn != null)
                currentConn.Dispose();
        }


    }
}
