namespace TextesMaui.Data;

public partial class NotificationView
{
    public int Id { get; set; }

    public string View { get; set; }

    public int FuncionarioId { get; set; }

    public int NotificationId { get; set; }

    public virtual Funcionario Funcionario { get; set; }

    public virtual Notification Notification { get; set; }
}
