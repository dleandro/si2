﻿using System;
using System.Threading;
using System.Transactions;

namespace Database
{
    internal class Session : ISession
    {
        private TransactionScope currentTrans;
        private MyDBContext currentContext;
        private bool TransactionVotes;

        public Session()
        {

        }

        public MyDBContext GetDBCtx()
        { return currentContext; }

        public static void Init()
        {
            Thread.FreeNamedDataSlot("ThreadSession");
            Thread.AllocateNamedDataSlot("ThreadSession");
            Thread.SetData(Thread.GetNamedDataSlot("ThreadSession"), new Session());


        }


        public void CreateScope(bool pessimisticLock, out bool isMyTr, out bool isMyConn)
        {
            bool sc, st;
            if (currentContext == null)
            {
                //currentTrans = ctx.Database.Connection.BeginTransaction();
                if (pessimisticLock)
                    currentTrans = new TransactionScope();
                TransactionVotes = true;
                st = true;
            }
            else
                st = false;
            if (currentContext == null)
            {

                currentContext = new MyDBContext();
                sc = true;
            }
            else sc = false;
            isMyTr = st;
            isMyConn = sc;

        }

        public void EndTransaction(bool MyVote, bool isMyTransaction, bool pessimisticLock)
        {
            TransactionVotes &= MyVote;
            if (isMyTransaction)
            {
                if (TransactionVotes)
                {
                    currentContext.SaveChanges();
                    if (pessimisticLock)
                        currentTrans.Complete();

                }
                //else
                //    currentTrans.Rollback();
                if (pessimisticLock)
                    currentTrans.Dispose();
                currentTrans = null;
            }

        }

        public void CloseConnection(bool isMyConnection)
        {
            if (isMyConnection && currentContext != null)
            {
                currentContext.Dispose();
                currentContext = null;
                Thread.FreeNamedDataSlot("ThreadSession");
            }
        }


        public void Dispose()
        {
            if (currentContext != null)
                currentContext.Dispose();


        }



    }
}
