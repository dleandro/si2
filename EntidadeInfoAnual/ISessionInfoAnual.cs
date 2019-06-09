using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDeDados;

namespace EntidadeInfoAnual
{
    public interface ISessionInfoAnual:ISession
    {
        IMapperInfoAnual CreateMapperInfoAnual();
    }
}
