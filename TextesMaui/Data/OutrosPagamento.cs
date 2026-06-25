namespace TextesMaui.Data;

public partial class OutrosPagamento
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string TipoPagamento { get; set; }

    public string Desci { get; set; }

    public int? ValorPago { get; set; }

    public DateOnly? DataPagamneto { get; set; }

    public int AnoId { get; set; }

    public int AlunosId { get; set; }

    public string PagoPor { get; set; }

    public string TransacaoPagamentoId { get; set; }

    public virtual Aluno Alunos { get; set; }

    public virtual Ano Ano { get; set; }
}
