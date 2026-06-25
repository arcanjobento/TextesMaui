namespace TextesMaui.Data;

public partial class Aluno
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public DateOnly? DataNascimento { get; set; }

    public string Sexo { get; set; }

    public string Doente { get; set; }

    public string DescriDoente { get; set; }

    public string Foto { get; set; }

    public string AlunosDescri { get; set; }

    public string Municipio { get; set; }

    public string Bairrro { get; set; }

    public string Rua { get; set; }

    public string Quarteirao { get; set; }

    public string Casa { get; set; }

    public float? ValorConta { get; set; }

    public string Codigo { get; set; }

    public string Pai { get; set; }

    public string Mae { get; set; }

    public string Comuna { get; set; }

    public string MunicipioDoc { get; set; }

    public string ProvinciaDoc { get; set; }

    public string NumeroDoc { get; set; }

    public DateOnly? DataDoc { get; set; }

    public virtual ICollection<DocumentosAluno> DocumentosAlunos { get; set; } = new List<DocumentosAluno>();

    public virtual ICollection<EncarregadoDosAluno> EncarregadoDosAlunos { get; set; } = new List<EncarregadoDosAluno>();

    public virtual ICollection<MiniPautum> MiniPauta { get; set; } = new List<MiniPautum>();

    public virtual ICollection<OutrosPagamento> OutrosPagamentos { get; set; } = new List<OutrosPagamento>();

    public virtual ICollection<PagamentoEmulumento> PagamentoEmulumentos { get; set; } = new List<PagamentoEmulumento>();

    public virtual ICollection<PagamentoUniforme> PagamentoUniformes { get; set; } = new List<PagamentoUniforme>();

    public virtual ICollection<PresencaAluno> PresencaAlunos { get; set; } = new List<PresencaAluno>();

    public virtual ICollection<Propina> Propinas { get; set; } = new List<Propina>();

    public virtual ICollection<TurmaDoAluno> TurmaDoAlunos { get; set; } = new List<TurmaDoAluno>();
}
