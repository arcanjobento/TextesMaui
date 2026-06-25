namespace TextesMaui.Data;

public partial class Disciplina
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Identificador { get; set; }

    public int ClassesId { get; set; }

    public int AnoId { get; set; }

    public int? Orden { get; set; }

    public virtual Ano Ano { get; set; }

    public virtual Class Classes { get; set; }

    public virtual ICollection<MiniPautum> MiniPauta { get; set; } = new List<MiniPautum>();

    public virtual ICollection<PlanificarAula> PlanificarAulas { get; set; } = new List<PlanificarAula>();

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
}
