namespace TextesMaui.Data;

public partial class Funcionario
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Foto { get; set; }

    public string Cargo { get; set; }

    public string AreaDeFormacao { get; set; }

    public string Tel { get; set; }

    public string Tel2 { get; set; }

    public string Morada { get; set; }

    public DateOnly? DataComecoTrabalho { get; set; }

    public DateOnly? DataFimTrabalho { get; set; }

    public string Biografia { get; set; }

    public string Citacao { get; set; }

    public DateOnly DataAdesa { get; set; }

    public string Privilegio { get; set; }

    public string Gerente { get; set; }

    public string Codigo { get; set; }

    public string Aprovado { get; set; }

    public string Descricacao { get; set; }

    public float? Salario { get; set; }

    public string AreaDaActuacao { get; set; }

    public string Contrato { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    public virtual ICollection<ControlDeSesao> ControlDeSesaos { get; set; } = new List<ControlDeSesao>();

    public virtual ICollection<GrupoChat> GrupoChats { get; set; } = new List<GrupoChat>();

    public virtual ICollection<NotificationView> NotificationViews { get; set; } = new List<NotificationView>();

    public virtual ICollection<PresencaFuncionario> PresencaFuncionarios { get; set; } = new List<PresencaFuncionario>();

    public virtual ICollection<TurmaDoAluno> TurmaDoAlunos { get; set; } = new List<TurmaDoAluno>();

    public virtual ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
}
