namespace TextesMaui.Data;

public partial class PagamentoFuncio
{
    public int Id { get; set; }

    public string Estado { get; set; }

    public int MesId { get; set; }

    public int AnoId { get; set; }

    public int FuncionarioId { get; set; }

    public int FuncionarioIdPago { get; set; }

    public DateOnly? Data { get; set; }

    public float? Valor { get; set; }

    public DateOnly? PeriodoPago { get; set; }

    public virtual Ano Ano { get; set; }

    public virtual Me Mes { get; set; }
}
