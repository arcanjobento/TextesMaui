
using TextesMaui.Data;
using TextesMaui.Models;

namespace TextesMaui.Services
{
    public interface IScoolDbService
    {
        public List<AlunosDevedores> Devedores(Classes nome);
        public AnoLectivo ListOfAnoLectivo();
        public List<Classes> ListOfClasses();
        public InforEscola InfoEscola();
    }

}
