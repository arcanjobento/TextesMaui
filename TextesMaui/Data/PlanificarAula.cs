namespace TextesMaui.Data;

public partial class PlanificarAula
{
    public int Id { get; set; }

    public DateOnly? DataAula { get; set; }

    public string Tema { get; set; }

    public int? Lesson { get; set; }

    public string ObjtivoGeral { get; set; }

    public string ObjectivoEspecifico { get; set; }

    public string Materia { get; set; }

    public int DisciplinaId { get; set; }

    public virtual Disciplina Disciplina { get; set; }
}
