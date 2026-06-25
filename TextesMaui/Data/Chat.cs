namespace TextesMaui.Data;

public partial class Chat
{
    public int Id { get; set; }

    public string TextMessage { get; set; }

    public DateOnly Data { get; set; }

    public int FuncionarioEnviou { get; set; }

    public string Visto { get; set; }

    public int GrupoChatId { get; set; }

    public virtual Funcionario FuncionarioEnviouNavigation { get; set; }

    public virtual GrupoChat GrupoChat { get; set; }
}
