using RotaViagem.Domain.Entities;

namespace RotaViagem.Domain.Dtos.Funcionario
{
    public class RotaDTO
    {
        public string Origem  { get; set; }
        public string Destino { get; set; }

        public RotaDTO()
        {

        }
        public RotaDTO(Rota rota)
        {            
            this.Origem = rota.Origem;
            this.Destino = rota.Destino;
        }

    }
}
