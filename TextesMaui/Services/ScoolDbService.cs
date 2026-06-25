using Microsoft.EntityFrameworkCore;
using TextesMaui.Data;
using TextesMaui.Models;

namespace TextesMaui.Services
{
    public partial class ScoolDbService : IScoolDbService
    {
        AppgeContext context;

        public ScoolDbService(AppgeContext _context)
        {
            context = _context;
        }

        public List<AlunosDevedores> Devedores(Classes nomeclasse)
        {
            var query = context.Database.SqlQuery<AlunosDevedores>($@"
                SELECT row_number() over (order by al.nome) AS Orden,
                       al.nome AS Nome,
                       classes.nome AS Classe,
                       GROUP_CONCAT(DISTINCT mes.mes ORDER BY mes.mes SEPARATOR ', ') AS MesesDivida,
                       al.valor_conta AS Conta,
                       al.id AS AlunoId
                FROM alunos AS al
                JOIN turma_do_aluno AS turma ON turma.alunos_id = al.id
                JOIN classes ON turma.classe_id = classes.id
                JOIN propina ON propina.alunos_id = al.id
                JOIN mes ON propina.mes_id = mes.id
                WHERE turma.data_matri <= propina.data_inicio_mes
                  AND propina.data_inicio_mes <= CURDATE()
                  AND (propina.estado = 'dívida' OR propina.data_pagamento IS NULL)
                  AND turma.estado_aluno = 'existente'
                  AND classes.nome = {nomeclasse.Nome}
                  AND classes.turma = {nomeclasse.Turma}
                GROUP BY al.nome, classes.nome").ToList();

            return query;

        }
        public List<AlunosDevedores> DevedoresAteProximoMes(Classes nomeclasse)
        {
            var query = context.Database.SqlQuery<AlunosDevedores>($@"
                SELECT row_number() over (order by al.nome) AS Orden,
                       al.nome AS Nome,
                       classes.nome AS Classe,
                       GROUP_CONCAT(DISTINCT mes.mes ORDER BY mes.mes SEPARATOR ', ') AS MesesDivida,
                       al.valor_conta AS Conta,
                       al.id AS AlunoId
                FROM alunos AS al
                JOIN turma_do_aluno AS turma ON turma.alunos_id = al.id
                JOIN classes ON turma.classe_id = classes.id
                JOIN propina ON propina.alunos_id = al.id
                JOIN mes ON propina.mes_id = mes.id
                WHERE turma.data_matri <= propina.data_inicio_mes
                  AND propina.data_inicio_mes <= LAST_DAY(DATE_ADD(CURDATE(), INTERVAL 1 MONTH))
                  AND (propina.estado = 'dívida' OR propina.data_pagamento IS NULL)
                  AND turma.estado_aluno = 'existente'
                  AND classes.nome = {nomeclasse.Nome}
                  AND classes.turma = {nomeclasse.Turma}
                GROUP BY al.nome, classes.nome").ToList();

            return query;

        }

        public List<AlunosDevedores> AlunosContasAPagar(Classes nomeclasse)
        {
            var alunosClasse = context.Alunos
                .Include(p => p.Propinas)
                .Include(t => t.TurmaDoAlunos)
                .ThenInclude(c => c.Classe)
                .Where(a => a.ValorConta < 0 && a.TurmaDoAlunos.Any(c => c.Classe.Nome == nomeclasse.Nome)
                        && a.TurmaDoAlunos.Any(c => c.Classe.Turma == nomeclasse.Turma))
                .Select(a => new AlunosDevedores
                {
                    AlunoId = a.Id,
                    Classe = a.TurmaDoAlunos.Select(c => c.Classe.Nome).FirstOrDefault(),
                    Nome = a.Nome,
                    Conta = a.ValorConta ?? 0
                }).ToList();

            return alunosClasse;

        }

        public InforEscola InfoEscola()
        {
            InforEscola query = new InforEscola();
            try
            {

                query = context.InforEscolas.FirstOrDefault();
                return query;
            }
            catch (Exception error)
            {
                return query;
            }
        }

        public AnoLectivo ListOfAnoLectivo()
        {
            var ano = context.Anos.FirstOrDefault(ano => ano.Estado == "actual");

            return new AnoLectivo
            {
                Id = ano.Id,
                Nome = ano.Nome,
                Estado = ano.Estado,
                DataCocmeco = ano.DataCocmeco,
                DataFim = ano.DataFim,
                Orden = ano.Orden,
                Uso = ano.Uso
            };
        }

        public List<Classes> ListOfClasses()
        {
            AnoLectivo ano = ListOfAnoLectivo();
            var classes = context.Classes.Where(ClasseWhere => ClasseWhere.AnoId == ano.Id).OrderBy(ClaO => ClaO.Orden).ToList();
            var classList = classes.Select((item, index) => new Classes
            {
                Id = item.Id,
                Nome = item.Nome,
                Preco = item.Preco,
                Sala = item.Sala,
                Turma = item.Turma,
                Turno = item.Turno,
                Identificador = item.Identificador,
                AnoId = ano.Id,
                Exame = item.Exame,
                Orden = item.Orden,
            }).ToList();

            return classList;
        }
    }
}
