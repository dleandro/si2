using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadeFranqueadoVendeProduto
{
    public class MapperFranqueadoVendeProduto
    {
        private ISessionFranqueadoVendeProduto MySession;
        private bool isMyConnection;
        private bool isMyTransaction;




        public MapperFranqueadoVendeProduto(ISessionFranqueadoVendeProduto s)
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

        public SqlCommand CreateCommand()
        {
            SqlCommand cmd = MySession.GetCurrConn().CreateCommand();

            cmd.Transaction = MySession.GetCurrTr();

            return cmd;
        }

        public void Create(FranqueadoVendeProduto a)
        {
            SqlCommand cmd = this.CreateCommand("franq_vende_new_prod");
            SqlParameter param;


            cmd.CommandType = CommandType.StoredProcedure;
            param = cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Char, 13));
            param.Value = a.codigo;

            param = cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Decimal, 4));
            param.Value = a.IdFranqueado;

            param = cmd.Parameters.Add(new SqlParameter("@min_stock", SqlDbType.Int));
            param.Value = a.MinStock;

            param = cmd.Parameters.Add(new SqlParameter("@max_stock", SqlDbType.Int));
            param.Value = a.MaxStock;

            param = cmd.Parameters.Add(new SqlParameter("@stock_atual", SqlDbType.Int));
            param.Value = a.StockAtual;

            param = cmd.Parameters.Add(new SqlParameter("@preco", SqlDbType.Decimal, 5));
            param.Value = a.preco;

            param = cmd.Parameters.Add(new SqlParameter("@venda_ano_atual", SqlDbType.Int));
            param.Value = a.VendaAnoAtual;

            param = cmd.Parameters.Add(new SqlParameter("@data_ultima_venda", SqlDbType.Date));
            param.Value = a.DataUltimaVenda;
        }

        public void FranquadoFornecimento(FranqueadoVendeProduto f, int quantidade)
        {
            SqlCommand cmd = this.CreateCommand("fran_fornecimento");
            SqlParameter param;

            cmd.CommandType = CommandType.StoredProcedure;
            param = cmd.Parameters.Add(new SqlParameter("@id_franq", SqlDbType.Decimal, 4));
            param.Value = f.IdFranqueado;

            param = cmd.Parameters.Add(new SqlParameter("@cod_prod", SqlDbType.NVarChar, 13));
            param.Value = f.codigo;

            param = cmd.Parameters.Add(new SqlParameter("@quantidade", SqlDbType.Decimal, 4));
            param.Value = quantidade;
        }

        public void ProductPurchase(FranqueadoVendeProduto f, int quantidade, double IdCustomer)
        {
            SqlCommand cmd = this.CreateCommand("product_purchase");
            SqlParameter param;

            cmd.CommandType = CommandType.StoredProcedure;

            param = cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.NVarChar, 13));
            param.Value = f.codigo;

            param = cmd.Parameters.Add(new SqlParameter("@id_customer", SqlDbType.Decimal, 4));
            param.Value = IdCustomer;            

            param = cmd.Parameters.Add(new SqlParameter("@quantity", SqlDbType.Int));
            param.Value = quantidade;
        }

        public double TotalDeVendas(FranqueadoVendeProduto f)
        {
            isMyConnection = MySession.OpenConnection();

            SqlCommand cmd = CreateCommand();
            cmd.CommandText = "SELECT @venda_ano_atual = venda_ano_atual from Franqueado_Vende_Produto WHERE id_franqueado =" + f.IdFranqueado;
            SqlParameter p1 = cmd.Parameters.Add("@venda_ano_atual", SqlDbType.Int);
            p1.Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            if (p1.Value is System.DBNull)
                throw new Exception("Não existem vendas no ano atual para este franqueado " + f.IdFranqueado);

            MySession.CloseConnection(isMyConnection);

            return Convert.ToDouble(p1.Value);
        }

    }
}
