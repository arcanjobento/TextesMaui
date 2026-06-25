namespace TextesMaui.Data;

public partial class Encarregado
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Contacto1 { get; set; }

    public string Contacto2 { get; set; }

    public string Foto { get; set; }

    public float? Desconto { get; set; }

    public virtual ICollection<EncarregadoDosAluno> EncarregadoDosAlunos { get; set; } = new List<EncarregadoDosAluno>();
}
