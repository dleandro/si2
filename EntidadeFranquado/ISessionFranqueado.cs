using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDeDados;

namespace EntidadeFranqueado
{
    public interface ISessionFranqueado:ISession
    {
        IMapperFranqueado CreateMapperFranqueado();
    }
}
