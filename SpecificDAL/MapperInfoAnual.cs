using BaseDeDados;
using Entities;
using InterfacesImapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadeInfoAnual
{
    public class MapperInfoAnual : IMapperInfoAnual
    {
        private ISession MySession;
        private bool isMyConnection;
        private bool isMyTransaction;

        public MapperInfoAnual(ISession s)
        {

            MySession = s;

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

        public void AvgYearSales(InfoAnual a)
        {
            SqlCommand cmd = this.CreateCommand("avg_year_sales");
            SqlParameter param;

            cmd.CommandType = CommandType.StoredProcedure;
            param = cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Char, 13));
            param.Value = a.CodigoProduto;

            param = cmd.Parameters.Add(new SqlParameter("@year", SqlDbType.SmallInt));
            param.Value = a.ano;

            MySession.EndTransaction(true, isMyTransaction);
            MySession.CloseConnection(isMyConnection);

        }

        public void Create(InfoAnual entity)
        {
            throw new NotImplementedException();
        }

        public InfoAnual Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(InfoAnual entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(InfoAnual entity)
        {
            throw new NotImplementedException();
        }
    }
}
