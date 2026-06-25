namespace TextesMaui.Data;

public partial class PagamentoUniforme
{
    public int Id { get; set; }

    public string TipoUniforme { get; set; }

    public string Tamanho { get; set; }

    public string ParteDoUniforme { get; set; }

    public string Desci { get; set; }

    public int? ValorPago { get; set; }

    public DateOnly? DataPagamento { get; set; }

    public int AnoId { get; set; }

    public int AlunosId { get; set; }

    public string PagoPor { get; set; }

    public string TransacaoPagamentoId { get; set; }

    public virtual Aluno Alunos { get; set; }

    public virtual Ano Ano { get; set; }
}
