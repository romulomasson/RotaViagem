using System.Security.Claims;
using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces;
using RotaViagem.Domain.Exceptions;

namespace RotaViagem.Api.Helpers;

public class UsuarioHelper : IUserHelper
{
    private IHttpContextAccessor _context;
    private UserIdentity _usuarioLogado;
    public UsuarioHelper(IHttpContextAccessor context) => _context = context;

    public UserIdentity UsuarioLogado
    {
        get
        {
            if (_usuarioLogado != null) return this._usuarioLogado;

            ClaimsPrincipal user = _context.HttpContext.User;
            var id = 1;
            var email = user.Claims.FirstOrDefault(c => c.Type == "email");
            var partnerId = user.Claims.FirstOrDefault(c => c.Type == "id_empresa");
            var idUsuarioReal = user.Claims.FirstOrDefault(c => c.Type == "id_usuario_real");
            var empresaid = user.Claims.FirstOrDefault(c => c.Type == "empresaid");
            var usuarioPerfil = 1;
            bool IsAdmin = true;
            
            //if (id == null || email == null)
            //    throw new UsuarioExpiradoException(nameof(UserIdentity), nameof(UsuarioLogado), "Usu?rio precisa refazer o login.");
#if DEBUG
            this._usuarioLogado = new UserIdentity(1, "romulomasson@gmail.com", Convert.ToInt32(idUsuarioReal?.Value), 9983, usuarioPerfil, IsAdmin, Convert.ToInt32(empresaid?.Value));
#else
            this._usuarioLogado = new UsuarioIdentity(Convert.ToInt32(id.Value), email.Value, Convert.ToInt32(idUsuarioReal?.Value), Convert.ToInt32(partnerId.Value), usuarioPerfil, IsAdmin, Convert.ToInt32(empresaid?.Value));
#endif
            return this._usuarioLogado;
        }
    }
    UserIdentity IUserHelper.LoggedUser => UsuarioLogado;

    //public string Idioma => _context.HttpContext.ObterIdioma();

}








