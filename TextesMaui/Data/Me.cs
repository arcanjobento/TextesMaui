namespace TextesMaui.Data;

public partial class Me
{
    public int Id { get; set; }

    public string Mes { get; set; }

    public string Orden { get; set; }

    public virtual ICollection<PagamentoFuncio> PagamentoFuncios { get; set; } = new List<PagamentoFuncio>();

    public virtual ICollection<Propina> Propinas { get; set; } = new List<Propina>();
}
