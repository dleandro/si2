using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BaseDeDados
{
    public interface ISession : IDisposable
    {
        bool BeginTran();
        bool OpenConnection();
        void EndTransaction(bool MyVote, bool isMyTransaction);
        void CloseConnection(bool isMyTransaction);
        SqlConnection GetCurrConn();
        SqlTransaction GetCurrTr();
    }
}
