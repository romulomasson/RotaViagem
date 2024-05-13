using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces;

namespace RotaViagem.Domain.Helpers;

public class UserHelper : IUserHelper
{
    public UserHelper() { }

    public UserIdentity LoggedUser
    {
        get
        {
            return null;
        }
    }
}




