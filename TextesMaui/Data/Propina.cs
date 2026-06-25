namespace TextesMaui.Data;

public partial class Propina
{
    public int Id { get; set; }

    public DateOnly? DataPagamento { get; set; }

    public DateOnly? DataPedido { get; set; }

    public string Estado { get; set; }

    public string QuemPagou { get; set; }

    public string QuemPediu { get; set; }

    public string FuncionarioPagamento { get; set; }

    public string FuncionarioPedido { get; set; }

    public string Descricao { get; set; }

    public float? Desconto { get; set; }

    public float? ValorPago { get; set; }

    public string Orden { get; set; }

    public int AlunosId { get; set; }

    public int AnoId { get; set; }

    public int MesId { get; set; }

    public float? Conta { get; set; }

    public DateOnly? DataInicioMes { get; set; }

    public string PagoPor { get; set; }

    public string TransacaoPagamentoId { get; set; }

    public virtual Aluno Alunos { get; set; }

    public virtual Ano Ano { get; set; }

    public virtual Me Mes { get; set; }
}
