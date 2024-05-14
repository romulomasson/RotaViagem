using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using RotaViagem.Api.Helpers;
using RotaViagem.Api.Models;
using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces.Application;
using RotaViagem.Repository.Contexts;
using RotaViagem.Domain.Dtos.Funcionario;

namespace RotaViagem.Api.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class RotaController : ControllerBase<RotaViagemContext, Rota, RotaViewModel>
{
    private readonly IRotaApplication<RotaViagemContext> _rotaApplication;
    public readonly IMapper _mapper;
    
    public RotaController(IRotaApplication<RotaViagemContext> rotaApplication, IMapper mapper)
        : base(rotaApplication, mapper)
    {
        _mapper = mapper;
        _rotaApplication = rotaApplication;
    }

    [HttpPost("ObterMelhorRota")]
    public Task<IActionResult> ObterMelhorRota([FromBody] RotaDTO model)
    {
        Rota result = _rotaApplication.ObterMelhorRota(model.Origem, model.Destino );
        return Task.FromResult<IActionResult>(Ok(new { MelhorRota = string.Concat(result.Descricao, "- R$", result.Custo) }));

    }


}






