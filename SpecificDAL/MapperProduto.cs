using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadeProduto
{
    public class MapperProduto
    {
        private ISessionProduto MySession;
        private bool isMyConnection;
        private bool isMyTransaction;




        public MapperProduto(ISessionProduto s)
        {

            MySession = s;

        }

        public SqlCommand CreateCommand(String procedure)
        {
            SqlConnection con = MySession.GetCurrConn();

            SqlCommand cmd = new SqlCommand(procedure);
            cmd.Transaction = MySession.GetCurrTr();

            return cmd;
        }


        public void Create(Produto a)
        {
            SqlCommand cmd = this.CreateCommand("prod_in");
            SqlParameter param;
            

            cmd.CommandType = CommandType.StoredProcedure;
            param = cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Char, 13));
            param.Value = a.codigo;

            param = cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.NVarChar, 100));
            param.Value = a.Descricao;

            param = cmd.Parameters.Add(new SqlParameter("@min_stock", SqlDbType.Int));
            param.Value = a.MinStock;

            param = cmd.Parameters.Add(new SqlParameter("@max_stock", SqlDbType.Int));
            param.Value = a.MaxStock;

            param = cmd.Parameters.Add(new SqlParameter("@stock_atual", SqlDbType.Int));
            param.Value = a.StockAtual;

            param = cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.NVarChar, 15));
            param.Value = a.Tipo;

        }

        public void Update(Produto a)
        {
            SqlCommand cmd = this.CreateCommand("prod_up");
            SqlParameter param;

            cmd.CommandType = CommandType.StoredProcedure;
            param = cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Char, 13));
            param.Value = a.codigo;

            param = cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.NVarChar, 100));
            param.Value = a.Descricao;

            param = cmd.Parameters.Add(new SqlParameter("@min_stock", SqlDbType.Int));
            param.Value = a.MinStock;

            param = cmd.Parameters.Add(new SqlParameter("@max_stock", SqlDbType.Int));
            param.Value = a.MaxStock;

            param = cmd.Parameters.Add(new SqlParameter("@stock_atual", SqlDbType.Int));
            param.Value = a.StockAtual;

            param = cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.NVarChar, 15));
            param.Value = a.Tipo;

        }

        public void Delete(Produto a)
        {
            SqlCommand cmd = this.CreateCommand("prod_del");
            SqlParameter param;

            cmd.CommandType = CommandType.StoredProcedure;
            param = cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Char, 13));
            param.Value = a.codigo;

        }

        public void DeleteEverythingAboutProduct(Produto a)
        {
            SqlCommand cmd = this.CreateCommand("geral_prod_del");
            SqlParameter param;

            cmd.CommandType = CommandType.StoredProcedure;
            param = cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Char, 13));
            param.Value = a.codigo;
        }

    }
}
