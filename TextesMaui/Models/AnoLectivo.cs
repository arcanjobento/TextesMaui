namespace TextesMaui.Models
{
    public class AnoLectivo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateOnly DataCocmeco { get; set; }

        public DateOnly DataFim { get; set; }

        public string Estado { get; set; }

        public string Uso { get; set; }

        public uint? Orden { get; set; }
    }
}
