namespace TextesMaui.Data;

public partial class Despesa
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public DateOnly? Data { get; set; }

    public string NomeFuncionario { get; set; }

    public string Descri { get; set; }

    public float? Valor { get; set; }

    public int? Quantidade { get; set; }
}
