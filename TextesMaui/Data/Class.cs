namespace TextesMaui.Data;

public partial class Class
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Identificador { get; set; }

    public string Sala { get; set; }

    public string Turma { get; set; }

    public float? Preco { get; set; }

    public string Turno { get; set; }

    public int AnoId { get; set; }

    public string Exame { get; set; }

    public int? Orden { get; set; }

    public virtual Ano Ano { get; set; }

    public virtual ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();

    public virtual ICollection<MiniPautum> MiniPauta { get; set; } = new List<MiniPautum>();

    public virtual ICollection<TurmaDoAluno> TurmaDoAlunos { get; set; } = new List<TurmaDoAluno>();
}
