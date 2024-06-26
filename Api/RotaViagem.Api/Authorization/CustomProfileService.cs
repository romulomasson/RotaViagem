using RotaViagem.Api.Authorization.Dto;
using RotaViagem.Domain.Interfaces.Application;
using RotaViagem.Repository.Contexts;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.Extensions.Options;

namespace RotaViagem.Api.Authorization;

public class CustomProfileService : IProfileService
{
    private readonly IUsuarioApplication<RotaViagemContext> _application;
    private readonly AuthConfig _config;

    public CustomProfileService(IUsuarioApplication<RotaViagemContext> application, IOptions<AuthConfig> config)
    {
        _application = application;
        _config = config.Value;
    }


    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var sub = context.Subject.GetSubjectId();

        var user = _application.Get(Convert.ToInt32(sub));

        //var menus = await _application.GetMenus(user.Id);

        var claims = AuthorizationConfig.GetClaims(user, _config);

        context.IssuedClaims = claims.ToList();
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        var sub = context.Subject.GetSubjectId();
        var user = _application.Get(Convert.ToInt32(sub));
        context.IsActive = user != null;
    }
}
