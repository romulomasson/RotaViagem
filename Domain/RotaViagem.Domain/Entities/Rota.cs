namespace RotaViagem.Domain.Entities;

public class Rota : EntityBase
{
    #region "Constructors"
    public Rota(int Id, string Descricao, decimal Custo, string Origem, string Destino)
    {
        this.Ativar();
        this.Id = Id;
        this.Descricao = Descricao;
        this.Custo = Custo;
        this.Origem = Origem;
        this.Destino = Destino;
        this.AtualizarDataCadastro();
    }
    #endregion

    #region "Properties"
    public string Descricao { get; protected set; }    
    public decimal Custo { get; protected set; }
    public string Origem { get; protected set; }
    public string Destino { get; protected set; }

    #endregion

    #region "References"

    #endregion

    #region "Methods"
    public void UpdateDescricao(string Descricao) => this.Descricao = Descricao;
    public void UpdateCusto(decimal Custo) => this.Custo = Custo;
    public void UpdateOrigem(string Origem) => this.Origem = Origem;
    public void UpdateDestino(string Destino) => this.Destino = Destino;
    #endregion
}






