using RotaViagem.Api.Helpers;
using RotaViagem.Domain.Entities;

namespace RotaViagem.Api.Models;

public class RotaViewModel : IViewModel<Rota>
{
    public int Id { get; set; }                
    public string Descricao { get; set; }
    public decimal Custo { get; set; }
    public string Origem { get; set; }
    public string Destino { get; set; }
    public Rota Model()
    {
        return new Rota(Id, Descricao, Custo, Origem,Destino);
    }
}








