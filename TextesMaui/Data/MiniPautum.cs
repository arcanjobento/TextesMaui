namespace TextesMaui.Data;

public partial class MiniPautum
{
    public int Id { get; set; }

    public float Nota { get; set; }

    public string Trimestre { get; set; }

    public string Tipo { get; set; }

    public int DisciplinaId { get; set; }

    public int AnoId { get; set; }

    public int AlunosId { get; set; }

    public int ClassesId { get; set; }

    public DateOnly? DataProva { get; set; }

    public string Descri { get; set; }

    public virtual Aluno Alunos { get; set; }

    public virtual Ano Ano { get; set; }

    public virtual Class Classes { get; set; }

    public virtual Disciplina Disciplina { get; set; }
}
