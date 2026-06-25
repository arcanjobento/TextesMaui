namespace TextesMaui.Data;

public partial class Membro
{
    public int FuncionarioId { get; set; }

    public int GrupoChatId { get; set; }

    public virtual Funcionario Funcionario { get; set; }

    public virtual GrupoChat GrupoChat { get; set; }
}
