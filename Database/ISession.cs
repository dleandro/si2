using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    interface ISession : IDisposable
    {
        void EndTransaction(bool MyVote, bool isMyTransaction, bool pessimisticLock);
        void CloseConnection(bool isMyTransaction);
        void CreateScope(bool pessimisticLock, out bool isMyTr, out bool isMyConn);
        MyDBContext GetDBCtx();
    }
}
