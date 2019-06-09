using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDeDados;
using InterfacesImapper;

namespace EntidadeFornecedor
{
    public class MapperFornecedor : IMapperFornecedor
    {
        private ISession MySession;
        private bool isMyConnection;
        private bool isMyTransaction;

        public MapperFornecedor(ISession s)
        {
            MySession = s;
        }

        public void Create(Fornecedor entity)
        {
            throw new NotImplementedException();
        }

        public SqlCommand CreateCommand()
        {
            isMyConnection = MySession.OpenConnection();
            isMyTransaction = MySession.BeginTran();
            SqlCommand cmd = MySession.GetCurrConn().CreateCommand();

            cmd.Transaction = MySession.GetCurrTr();

            return cmd;
        }
        public SqlCommand CreateCommand(string procedure)
        {
            isMyConnection = MySession.OpenConnection();
            isMyTransaction = MySession.BeginTran();
            SqlConnection con = MySession.GetCurrConn();

            SqlCommand cmd = new SqlCommand(procedure);
            cmd.Transaction = MySession.GetCurrTr();

            return cmd;
        }

        public void Delete(Fornecedor entity)
        {
            throw new NotImplementedException();
        }

        public Fornecedor Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Fornecedor entity)
        {
            throw new NotImplementedException();
        }
    }
}
