namespace TextesMaui.Data;

public partial class InforEscola
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Foto { get; set; }

    public DateOnly? DataCri { get; set; }

    public string? DirGeral { get; set; }

    public string? Tipo { get; set; }

    public string? Codigo { get; set; }

    public string? CodigoTutela { get; set; }

    public string? Localiz { get; set; }

    public string? Contacto1 { get; set; }

    public string? Contacto2 { get; set; }

    public string? Email { get; set; }

    public int? DiaCobrarPropina { get; set; }

    public int? MesCobrarPropina { get; set; }

    public int? ValorMatricula { get; set; }

    public int? ValorConfirmaca { get; set; }

    public int? ValorUniforme { get; set; }
}
