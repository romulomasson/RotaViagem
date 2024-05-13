using IdentityServer4.Models;
using IdentityServer4.Validation;
using RotaViagem.Domain.Entities;
using RotaViagem.Repository.Contexts;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using RotaViagem.Api.Authorization.Dto;
using RotaViagem.Domain.Interfaces.Application;

namespace RotaViagem.Api.Authorization
{
    public class GrantValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUsuarioApplication<RotaViagemContext> _usuarioApplication;
        private readonly AuthConfig _authConfig;

        public GrantValidator(IUsuarioApplication<RotaViagemContext> usuarioApplication, IOptions<AuthConfig> authConfig)
        {
            _usuarioApplication = usuarioApplication;
            _authConfig = authConfig.Value;
        }
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {

            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Validando Login");

                Usuario usuario = _usuarioApplication.GetAll(e => e.Login == context.UserName).FirstOrDefault();

                if (usuario != null)
                    Console.WriteLine($"Usuario Obtido do banco: " + usuario.Nome);

                if (usuario == null)
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.UnauthorizedClient, "Login inv�lido.");
                    return Task.FromResult(0);
                }

                var origemSaude = context.Request.Raw["origem"];
                //usuario.AlterarOrigemSaude(origemSaude != null && origemSaude.Equals("saude"));

                if (usuario.Senha != context.Password)
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.UnauthorizedClient, "Senha inv�lida.");
                    return Task.FromResult(0);
                }

                context.Result = new GrantValidationResult(subject: usuario.Id.ToString(), authenticationMethod: "custom", claims: AuthorizationConfig.GetClaims(usuario, _authConfig));
                Console.WriteLine($"Usuario no Claims " + usuario.Nome);
                Console.ResetColor();
                return Task.FromResult(0);
            }
            catch (Exception ex)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidClient, $"{ex.Message}");
                return Task.FromResult(1);
            }
        }
    }
}







