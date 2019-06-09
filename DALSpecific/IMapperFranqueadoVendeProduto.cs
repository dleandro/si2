using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDeDados;
using Entities;

namespace EntidadeFranqueadoVendeProduto
{
    public interface IMapperFranqueadoVendeProduto:IMapper<FranqueadoVendeProduto, int>
    {
        SqlCommand CreateCommand();
    }
}
