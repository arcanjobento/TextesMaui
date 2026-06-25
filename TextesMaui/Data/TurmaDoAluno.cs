namespace TextesMaui.Data;

public partial class TurmaDoAluno
{
    public int Id { get; set; }

    public int ClasseId { get; set; }

    public int AlunosId { get; set; }

    public string ConfirMatri { get; set; }

    public string EstadoAluno { get; set; }

    public DateOnly DataMatri { get; set; }

    public DateOnly? DataEstado { get; set; }

    public string RepitenteClasse { get; set; }

    public int FuncionarioId { get; set; }

    public int? ValorMatrConf { get; set; }

    public int AnoId { get; set; }

    public string PagoPor { get; set; }

    public string TransacaoPagamentoId { get; set; }

    public virtual Aluno Alunos { get; set; }

    public virtual Ano Ano { get; set; }

    public virtual Class Classe { get; set; }

    public virtual ICollection<DocumentosAluno> DocumentosAlunos { get; set; } = new List<DocumentosAluno>();

    public virtual Funcionario Funcionario { get; set; }
}
