namespace TextesMaui.Data;

public partial class PagamentoEmulumento
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Identificador { get; set; }

    public DateOnly? DataPedido { get; set; }

    public DateOnly? DataEntrega { get; set; }

    public string QuemPediu { get; set; }

    public string QuemRecebeu { get; set; }

    public string Feito { get; set; }

    public int? Valor { get; set; }

    public int AnoId { get; set; }

    public int AlunosId { get; set; }

    public string PagoPor { get; set; }

    public string TransacaoPagamentoId { get; set; }

    public virtual Aluno Alunos { get; set; }

    public virtual Ano Ano { get; set; }
}
