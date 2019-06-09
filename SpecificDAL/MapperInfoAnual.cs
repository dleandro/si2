using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadeInfoAnual
{
    public class MapperInfoAnual
    {
        private ISessionInfoAnual MySession;
        private bool isMyConnection;
        private bool isMyTransaction;

        public MapperInfoAnual(ISessionInfoAnual s)
        {

            MySession = s;

        }

        public SqlCommand CreateCommand(string procedure)
        {
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

        }
    }
}
