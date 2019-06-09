using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadeFranqueado;
using Entities;

namespace EntidadeFranqueado
{
    public class MapperFranqueado
    {
        private ISessionFranqueado MySession;
        private bool isMyConnection;
        private bool isMyTransaction;




        public MapperFranqueado(ISessionFranqueado s)
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


        public void Create(Franqueado a)
        {
            SqlCommand cmd = this.CreateCommand("franq_in");
            SqlParameter param;


            cmd.CommandType = CommandType.StoredProcedure;
            param = cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Decimal, 4));
            param.Value = a.id;

            param = cmd.Parameters.Add(new SqlParameter("@nif", SqlDbType.Decimal, 10));
            param.Value = a.nif;

            param = cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar, 100));
            param.Value = a.nome;

            param = cmd.Parameters.Add(new SqlParameter("@morada", SqlDbType.VarChar, 100));
            param.Value = a.morada;

        }

        public void Update(Franqueado a)
        {
            SqlCommand cmd = this.CreateCommand("franq_up");
            SqlParameter param;
            
            cmd.CommandType = CommandType.StoredProcedure;
            param = cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Decimal, 4));
            param.Value = a.id;

            param = cmd.Parameters.Add(new SqlParameter("@nif", SqlDbType.Decimal, 10));
            param.Value = a.nif;

            param = cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar, 100));
            param.Value = a.nome;

            param = cmd.Parameters.Add(new SqlParameter("@morada", SqlDbType.VarChar, 100));
            param.Value = a.morada;
        }
        public void Delete(Franqueado a)
        {
            SqlCommand cmd = this.CreateCommand("franq_del");
            SqlParameter param;

            cmd.CommandType = CommandType.StoredProcedure;
            param = cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Decimal, 4));
            param.Value = a.id;
        }

        public void DeleteEverythingAboutFranqueado(Franqueado a)
        {

            isMyConnection = MySession.OpenConnection();

            SqlCommand cmd = CreateCommand();
            cmd.CommandText = "DELETE FROM Franqueado_Vende_Produto Where id_franqueado" + a.id;
            cmd.ExecuteNonQuery();

            cmd.CommandText = "DELETE FROM Franqueado Where id_franqueado" + a.id;
            cmd.ExecuteNonQuery();

            MySession.CloseConnection(isMyConnection);

        }

    }
}
