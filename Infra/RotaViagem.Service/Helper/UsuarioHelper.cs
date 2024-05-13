using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces;

namespace RotaViagem.Service.Helper
{
    public class UsuarioHelper: IUserHelper
    {
        public UsuarioHelper() { }

        public UserIdentity LoggedUser
        {
            get
            {
                return new UserIdentity(1, "admin", 1, 1, 1, true, 1);
            }
        }
    }
}








