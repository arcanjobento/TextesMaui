namespace TextesMaui.Data;

public partial class Notification
{
    public int Id { get; set; }

    public string NomeFuncionario { get; set; }

    public int IdActo { get; set; }

    public string NomeActo { get; set; }

    public DateTime Date { get; set; }

    public virtual ICollection<NotificationView> NotificationViews { get; set; } = new List<NotificationView>();
}
