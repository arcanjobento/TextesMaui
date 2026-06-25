namespace TextesMaui.Data;

public partial class DocumentosAluno
{
    public int Id { get; set; }

    public string Estado { get; set; }

    public int? Quantidade { get; set; }

    public string Descri { get; set; }

    public DateOnly? DataEntrega { get; set; }

    public int TurmaDoAlunoId { get; set; }

    public int DocumentosId { get; set; }

    public int AlunosId { get; set; }

    public virtual Aluno Alunos { get; set; }

    public virtual Documento Documentos { get; set; }

    public virtual TurmaDoAluno TurmaDoAluno { get; set; }
}
