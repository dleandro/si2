using System;
using System.Threading;
using EntidadeFranqueado;
using EntidadeFornecedor;
using EntidadeFranqueadoVendeProduto;
using EntidadeInfoAnual;
using EntidadeProduto;
using BaseDeDados;

namespace SpecificDAL
{
    public class Session : AbstractSession, ISessionFranqueado, ISessionFornecedor, ISessionFranqueadoVendeProduto, ISessionInfoAnual, ISessionProduto
    {

        public IMapperFranqueado CreateMapperFranqueado()
        {
            return new MapperFranqueado(this);
        }

        public IMapperInfoAnual CreateMapperInfoAnual()
        {
            return new MapperInfoAnual(this);
        }

        public IMapperFornecedor CreateMapperFornecedor()
        {
            return new MapperFornecedor(this);
        }

        public IMapperFranqueadoVendeProduto CreateMapperFranqueadoVendeProduto()
        {
            return new MapperFranqueadoVendeProduto(this);
        }

        public IMapperProduto CreateMapperProduto()
        {
            return new MapperProduto(this);
        }

    }
}

