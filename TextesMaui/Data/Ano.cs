namespace TextesMaui.Data;

public partial class Ano
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public DateOnly DataCocmeco { get; set; }

    public DateOnly DataFim { get; set; }

    public string Estado { get; set; }

    public string Uso { get; set; }

    public uint? Orden { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

    public virtual ICollection<MiniPautum> MiniPauta { get; set; } = new List<MiniPautum>();

    public virtual ICollection<OutrosPagamento> OutrosPagamentos { get; set; } = new List<OutrosPagamento>();

    public virtual ICollection<PagamentoEmulumento> PagamentoEmulumentos { get; set; } = new List<PagamentoEmulumento>();

    public virtual ICollection<PagamentoFuncio> PagamentoFuncios { get; set; } = new List<PagamentoFuncio>();

    public virtual ICollection<PagamentoUniforme> PagamentoUniformes { get; set; } = new List<PagamentoUniforme>();

    public virtual ICollection<PresencaAluno> PresencaAlunos { get; set; } = new List<PresencaAluno>();

    public virtual ICollection<PresencaFuncionario> PresencaFuncionarios { get; set; } = new List<PresencaFuncionario>();

    public virtual ICollection<Propina> Propinas { get; set; } = new List<Propina>();

    public virtual ICollection<TurmaDoAluno> TurmaDoAlunos { get; set; } = new List<TurmaDoAluno>();
}
