namespace TextesMaui.Data;

public partial class Documento
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string DocumentoDescri { get; set; }

    public int Quantidade { get; set; }

    public int ClassesId { get; set; }

    public virtual Class Classes { get; set; }

    public virtual ICollection<DocumentosAluno> DocumentosAlunos { get; set; } = new List<DocumentosAluno>();
}
