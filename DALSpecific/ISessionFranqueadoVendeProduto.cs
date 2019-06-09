﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BaseDeDados;

namespace EntidadeFranqueadoVendeProduto
{
    public interface ISessionFranqueadoVendeProduto:ISession
    {
        IMapperFranqueadoVendeProduto CreateMapperFranqueadoVendeProduto();
    }
}
