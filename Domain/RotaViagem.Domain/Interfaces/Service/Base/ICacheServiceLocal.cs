using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Entities;

namespace RotaViagem.Domain.Interfaces.Service.Base
{
    public interface ICacheServiceLocal<TContext>
    {
        void InicializaCache();        
    }
}






