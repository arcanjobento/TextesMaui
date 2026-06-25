namespace TextesMaui.Data;

public partial class PresencaFuncionario
{
    public int Id { get; set; }

    public string Estado { get; set; }

    public DateOnly Data { get; set; }

    public string HoraChegada { get; set; }

    public int AnoId { get; set; }

    public string Descricacao { get; set; }

    public int FuncionarioId { get; set; }

    public virtual Ano Ano { get; set; }

    public virtual Funcionario Funcionario { get; set; }
}
