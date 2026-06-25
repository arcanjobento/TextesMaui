namespace TextesMaui.Data;

public partial class ControlDeSesao
{
    public int Id { get; set; }

    public string Senha { get; set; }

    public string Email { get; set; }

    public string SecretCodeRestauro { get; set; }

    public int FuncionarioId { get; set; }

    public virtual Funcionario Funcionario { get; set; }
}
