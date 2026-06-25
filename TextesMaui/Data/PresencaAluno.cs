namespace TextesMaui.Data;

public partial class PresencaAluno
{
    public int Id { get; set; }

    public string Estado { get; set; }

    public DateOnly Data { get; set; }

    public string HoraChegada { get; set; }

    public int AlunosId { get; set; }

    public int AnoId { get; set; }

    public string Descricicao { get; set; }

    public virtual Aluno Alunos { get; set; }

    public virtual Ano Ano { get; set; }
}
