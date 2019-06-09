using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDeDados;
using Entities;

namespace EntidadeProduto
{
    public interface IMapperProduto:IMapper<Produto, int>
    {
        SqlCommand CreateCommand();
    }
}
