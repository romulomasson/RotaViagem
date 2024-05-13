using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotaViagem.Domain.Entities;

namespace RotaViagem.Domain.Interfaces
{
    public interface IUserHelper
    {
        UserIdentity LoggedUser { get; }
    }
}



