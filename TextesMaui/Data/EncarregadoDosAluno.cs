namespace TextesMaui.Data;

public partial class EncarregadoDosAluno
{
    public int EncarregadoId { get; set; }

    public int AlunosId { get; set; }

    public string GrauParentesco { get; set; }

    public string Descri { get; set; }

    public virtual Aluno Alunos { get; set; }

    public virtual Encarregado Encarregado { get; set; }
}
