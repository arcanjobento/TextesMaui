namespace TextesMaui.Data;

public partial class GrupoChat
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Foto { get; set; }

    public string Identificador { get; set; }

    public int Admin { get; set; }

    public virtual Funcionario AdminNavigation { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();
}
