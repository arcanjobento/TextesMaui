using CommunityToolkit.Mvvm.ComponentModel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using TextesMaui.Models;
using TextesMaui.Services;

namespace TextesMaui.PdfsRelatorios
{
    public partial class RelatorioAlunosDivida : ObservableObject
    {
        ScoolDbService _DbService;

        public RelatorioAlunosDivida(ScoolDbService DbService)
        {
            _DbService = DbService;
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public async Task GerarPdfTurma(Classes classesSelected)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    //Cabeçalho

                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Text("Alunos com Dívidas").Italic().FontSize(9);
                        row.ConstantItem(3, Unit.Centimetre).Text($"{DateTime.Now:dd/MM/yyyy}").AlignLeft().Italic().FontSize(9);
                        row.Spacing(10);
                    });

                    // corpo
                    page.Content().Column(column =>
                    {
                        column.Spacing(5);
                        column.Item().AlignLeft().Text("Relatório dos alunos com Dívida").Bold().FontSize(14);

                        column.Item().AlignCenter().Text(classesSelected.Nome).FontSize(24).Bold();

                        var lista1 = _DbService.Devedores(classesSelected);

                        var listaAlunosCountasPagar = _DbService.AlunosContasAPagar(classesSelected);

                        foreach (var alunos in listaAlunosCountasPagar)
                        {
                            if (!lista1.Any(a => a.AlunoId == alunos.AlunoId))
                            {
                                lista1.Add(alunos);
                            }
                        }

                        var lista = lista1.OrderBy(a => a.Nome);

                        column.Item();
                        column.Spacing(20);

                        column.Item().AlignCenter().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(1, Unit.Centimetre);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.ConstantColumn(2, Unit.Centimetre);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text("Nº").Bold().FontSize(12);
                                header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).AlignLeft().Text("Nome").Bold().FontSize(12);
                                header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text("Meses Com Dívida").Bold().FontSize(12);
                                header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text("OBS").Bold().FontSize(12);

                            });

                            var cont = 0;
                            foreach (var alunosDevedores in lista)
                            {
                                var nome = alunosDevedores.Nome;
                                cont++;
                                if (alunosDevedores.Nome.Split(" ").Length > 3)
                                {
                                    var partes = alunosDevedores.Nome.Split(" ");
                                    nome = $"{partes[0]} {partes[1]} {partes.Last()}";
                                }
                                table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text($"{cont}");
                                table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).PaddingRight(25).Text($"{nome}");
                                table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text($"{alunosDevedores.MesesDivida}");
                                table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text($" ");
                            }

                        });


                    });

                    page.Footer().AlignRight().Text(x =>
                    {
                        x.CurrentPageNumber();
                        x.Span("/");
                        x.TotalPages();
                    });

                });
            });

            var path = Path.Combine(Path.GetTempPath(), "relatorio.pdf");

            using (var arqStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                document.GeneratePdf(arqStream);
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });

            try
            {
                await Task.Delay(10000);
                File.Delete(path);
            }
            catch
            {

            }

        }
        public async Task GerarPdfDevedores(ObservableCollection<Classes> listaClasses)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    //Cabeçalho

                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Text("Alunos com Dívidas").Italic().FontSize(9);
                        row.ConstantItem(3, Unit.Centimetre).Text($"{DateTime.Now:dd/MM/yyyy}").AlignLeft().Italic().FontSize(9);
                        row.Spacing(10);
                    });

                    // corpo
                    page.Content().Column(column =>
                    {
                        column.Spacing(5);
                        column.Item().AlignLeft().Text("Relatório dos alunos com Dívida").Bold().FontSize(14);

                        foreach (var el in listaClasses)
                        {
                            column.Item().AlignCenter().Text(el.Nome).FontSize(24).Bold();

                            var lista1 = _DbService.Devedores(el);

                            var listaAlunosCountasPagar = _DbService.AlunosContasAPagar(el);

                            foreach (var alunos in listaAlunosCountasPagar)
                            {
                                if (!lista1.Any(a => a.AlunoId == alunos.AlunoId))
                                {
                                    lista1.Add(alunos);
                                }
                            }

                            var lista = lista1.OrderBy(a => a.Nome);

                            column.Item();
                            column.Spacing(20);

                            column.Item().AlignCenter().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(1, Unit.Centimetre);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.ConstantColumn(2, Unit.Centimetre);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text("Nº").Bold().FontSize(12);
                                    header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).AlignLeft().Text("Nome").Bold().FontSize(12);
                                    header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text("Meses Com Dívida").Bold().FontSize(12);
                                    header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text("Conta").Bold().FontSize(12);

                                });

                                var cont = 0;
                                foreach (var alunosDevedores in lista)
                                {
                                    var nome = alunosDevedores.Nome;
                                    cont++;
                                    if (alunosDevedores.Nome.Split(" ").Length > 3)
                                    {
                                        var partes = alunosDevedores.Nome.Split(" ");
                                        nome = $"{partes[0]} {partes[1]} {partes.Last()}";
                                    }
                                    table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text($"{cont}");
                                    table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).PaddingRight(25).Text($"{nome}");
                                    table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text($"{alunosDevedores.MesesDivida}");
                                    table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text("");
                                }

                            });
                        }


                    });

                    page.Footer().AlignRight().Text(x =>
                    {
                        x.CurrentPageNumber();
                        x.Span("/");
                        x.TotalPages();
                    });

                });
            });

            var path = Path.Combine(Path.GetTempPath(), "relatorio.pdf");

            using (var arqStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                document.GeneratePdf(arqStream);
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });

            try
            {
                await Task.Delay(10000);
                File.Delete(path);
            }
            catch
            {

            }

        }
        public async Task GerarPdfNotaDevedores(ObservableCollection<Classes> listaClasses)
        {
            var inforescola = _DbService.InfoEscola();
            if (inforescola is null)
                return;

            CultureInfo cultura = new CultureInfo("pt-PT");

            // Dividir lista em grupos de 10
            var grupos = listaClasses
                .SelectMany(turma => _DbService.Devedores(turma)) // pega todos os alunos devedores
                .Select((aluno, index) => new { aluno, index })
                .GroupBy(x => x.index / 10)
                .Select(g => g.Select(x => x.aluno).ToList())
                .ToList();

            var document = Document.Create(container =>
            {
                foreach (var grupo in grupos)
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(0.5f, Unit.Centimetre);
                        page.DefaultTextStyle(x => x.FontSize(12));
                        page.Content().Row(row =>
                        {
                            // Coluna esquerda (até 5 alunos)
                            row.RelativeItem().Column(col =>
                            {
                                foreach (var aluno in grupo.Take(5))
                                {
                                    col.Item().Height(5.6f, Unit.Centimetre)
                                        .Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#000000"))
                                        .Padding(5).Column(info =>
                                        {
                                            info.Item().AlignCenter().Text($"{inforescola.Nome}").FontSize(14).Bold();
                                            info.Spacing(5);
                                            info.Item().AlignCenter().Text("Comunicado").Italic().Underline().FontSize(10);
                                            info.Spacing(5);
                                            info.Item().Text(text =>
                                            {
                                                DateTime data = DateTime.Now;

                                                int dia = data.Day;

                                                string mes = data.ToString("MMMM");

                                                var texteSplit = aluno.MesesDivida.Split(",");

                                                if (texteSplit.Length > 1)
                                                {
                                                    text.Justify();
                                                    text.Span("A Direção do complexo escolar acima referida, vem por este meio convocar o Encarregado de educação de ");
                                                    text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                    text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                    text.Span(", que se dirija à secretária do colégio para liquidar a sua conta dos meses de ");

                                                    var newText = String.Join(", ", texteSplit);

                                                    if (texteSplit.Length > 3)
                                                    {
                                                        newText = string.Join(", ",
                                                            texteSplit.Select(x =>
                                                            {
                                                                if (string.IsNullOrEmpty(x) || x.Length < 3)
                                                                    return x;
                                                                return char.ToUpper(x[0]) + x.Substring(1, 2).ToLower();
                                                            })
                                                            );
                                                    }
                                                    text.Span(newText).Bold();
                                                }
                                                else
                                                {
                                                    if (dia > inforescola.DiaCobrarPropina)
                                                    {

                                                        text.Justify();
                                                        text.Span("A Direção do complexo escolar acima referida, vem por este meio convocar o Encarregado de educação de ");
                                                        text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                        text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                        text.Span(", que se dirija à secretária do colégio para liquidar a sua conta do mês de");

                                                        var newText = char.ToUpper(texteSplit[0][0]) + texteSplit[0].Substring(1).ToLower();

                                                        text.Span(newText).Bold();
                                                    }
                                                    else
                                                    {
                                                        text.Justify();
                                                        text.Span("A Direção do complexo escolar acima referida, vem por este meio dar a " +
                                                            "conhecer ao Encarregado de educação de ");
                                                        text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                        text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                        text.Span(", que está em curso a cobrança da propina do mês de ");

                                                        var newText = char.ToUpper(texteSplit[0][0]) + texteSplit[0].Substring(1).ToLower();

                                                        text.Span(newText).Bold();

                                                        text.Span(". Pedimos encarecidamente que se dirija a secretária para liquidar a sua conta.");

                                                    }

                                                }
                                            });
                                        });
                                }
                            });

                            // Coluna direita (até 5 alunos)
                            row.RelativeItem().Column(col =>
                            {
                                foreach (var aluno in grupo.Skip(5).Take(5))
                                {
                                    col.Item().Height(5.6f, Unit.Centimetre)
                                        .Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#000000"))
                                        .Padding(5).Column(info =>
                                        {
                                            info.Item().AlignCenter().Text($"{inforescola.Nome}").FontSize(14).Bold();
                                            info.Spacing(5);
                                            info.Item().AlignCenter().Text("Comunicado").Italic().Underline().FontSize(10);
                                            info.Spacing(5);
                                            info.Item().Text(text =>
                                            {
                                                DateTime data = DateTime.Now;
                                                int dia = data.Day;
                                                string mes = data.ToString("MMMM");

                                                var texteSplit = aluno.MesesDivida.Split(",");

                                                if (texteSplit.Length > 1)
                                                {
                                                    text.Justify();
                                                    text.Span("A Direção do complexo escolar acima referida, vem por este meio convocar o Encarregado de educação de ");
                                                    text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                    text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                    text.Span(", que se dirija à secretária do colégio para liquidar a sua conta dos meses de ");

                                                    var newText = String.Join(", ", texteSplit);

                                                    if (texteSplit.Length > 3)
                                                    {
                                                        newText = string.Join(", ",
                                                            texteSplit.Select(x =>
                                                            {
                                                                if (string.IsNullOrEmpty(x) || x.Length < 3)
                                                                    return x;
                                                                return char.ToUpper(x[0]) + x.Substring(1, 2).ToLower();
                                                            })
                                                            );
                                                    }
                                                    text.Span(newText).Bold();
                                                }
                                                else
                                                {
                                                    if (dia > inforescola.DiaCobrarPropina)
                                                    {
                                                        text.Justify();
                                                        text.Span("A Direção do complexo escolar acima referida, vem por este meio convocar o Encarregado de educação de ");
                                                        text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                        text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                        text.Span(", que se dirija à secretária do colégio para liquidar a sua conta do mês de ");

                                                        var newText = char.ToUpper(texteSplit[0][0]) + texteSplit[0].Substring(1).ToLower();

                                                        text.Span(newText).Bold();
                                                    }
                                                    else
                                                    {
                                                        text.Justify();
                                                        text.Span("A Direção do complexo escolar acima referida, vem por este meio dar a " +
                                                            "conhecer ao Encarregado de educação de ");
                                                        text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                        text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                        text.Span(", que está em curso a cobrança da propina do mês de ");

                                                        var newText = char.ToUpper(texteSplit[0][0]) + texteSplit[0].Substring(1).ToLower();

                                                        text.Span(newText).Bold();

                                                        text.Span(". Pedimos encarecidamente que se dirija a secretária para liquidar a sua conta.");

                                                    }

                                                }
                                            });
                                        });
                                }
                            });
                        });

                    });
                }
            });

            var path = Path.Combine(Path.GetTempPath(), "relatorio.pdf");

            using (var arqStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                document.GeneratePdf(arqStream);
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });

            try
            {
                await Task.Delay(10000);
                File.Delete(path);
            }
            catch
            {

            }
        }


        //Gerar Devedores até o mes a seguir
        public async Task GerarPdfTurmaProximoMes(Classes classesSelected)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    //Cabeçalho

                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Text("Alunos com Dívidas").Italic().FontSize(9);
                        row.ConstantItem(3, Unit.Centimetre).Text($"{DateTime.Now:dd/MM/yyyy}").AlignLeft().Italic().FontSize(9);
                        row.Spacing(10);
                    });

                    // corpo
                    page.Content().Column(column =>
                    {
                        column.Spacing(5);
                        column.Item().AlignLeft().Text("Relatório dos alunos com Dívida").Bold().FontSize(14);

                        column.Item().AlignCenter().Text(classesSelected.Nome).FontSize(24).Bold();

                        var lista1 = _DbService.DevedoresAteProximoMes(classesSelected);

                        var listaAlunosCountasPagar = _DbService.AlunosContasAPagar(classesSelected);

                        foreach (var alunos in listaAlunosCountasPagar)
                        {
                            if (!lista1.Any(a => a.AlunoId == alunos.AlunoId))
                            {
                                lista1.Add(alunos);
                            }
                        }

                        var lista = lista1.OrderBy(a => a.Nome);

                        column.Item();
                        column.Spacing(20);

                        column.Item().AlignCenter().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(1, Unit.Centimetre);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.ConstantColumn(2, Unit.Centimetre);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text("Nº").Bold().FontSize(12);
                                header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).AlignLeft().Text("Nome").Bold().FontSize(12);
                                header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text("Meses Com Dívida").Bold().FontSize(12);
                                header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text("OBS").Bold().FontSize(12);

                            });

                            var cont = 0;
                            foreach (var alunosDevedores in lista)
                            {
                                var nome = alunosDevedores.Nome;
                                cont++;
                                if (alunosDevedores.Nome.Split(" ").Length > 3)
                                {
                                    var partes = alunosDevedores.Nome.Split(" ");
                                    nome = $"{partes[0]} {partes[1]} {partes.Last()}";
                                }
                                table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text($"{cont}");
                                table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).PaddingRight(25).Text($"{nome}");
                                table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text($"{alunosDevedores.MesesDivida}");
                                table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text($" ");
                            }

                        });


                    });

                    page.Footer().AlignRight().Text(x =>
                    {
                        x.CurrentPageNumber();
                        x.Span("/");
                        x.TotalPages();
                    });

                });
            });

            var path = Path.Combine(Path.GetTempPath(), "relatorio.pdf");

            using (var arqStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                document.GeneratePdf(arqStream);
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });

            try
            {
                await Task.Delay(10000);
                File.Delete(path);
            }
            catch
            {

            }

        }
        public async Task GerarPdfDevedoresProximoMes(ObservableCollection<Classes> listaClasses)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    //Cabeçalho

                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Text("Alunos com Dívidas").Italic().FontSize(9);
                        row.ConstantItem(3, Unit.Centimetre).Text($"{DateTime.Now:dd/MM/yyyy}").AlignLeft().Italic().FontSize(9);
                        row.Spacing(10);
                    });

                    // corpo
                    page.Content().Column(column =>
                    {
                        column.Spacing(5);
                        column.Item().AlignLeft().Text("Relatório dos alunos com Dívida").Bold().FontSize(14);

                        foreach (var el in listaClasses)
                        {
                            column.Item().AlignCenter().Text(el.Nome).FontSize(24).Bold();

                            var lista1 = _DbService.DevedoresAteProximoMes(el);

                            var listaAlunosCountasPagar = _DbService.AlunosContasAPagar(el);

                            foreach (var alunos in listaAlunosCountasPagar)
                            {
                                if (!lista1.Any(a => a.AlunoId == alunos.AlunoId))
                                {
                                    lista1.Add(alunos);
                                }
                            }

                            var lista = lista1.OrderBy(a => a.Nome);

                            column.Item();
                            column.Spacing(20);

                            column.Item().AlignCenter().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(1, Unit.Centimetre);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.ConstantColumn(2, Unit.Centimetre);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text("Nº").Bold().FontSize(12);
                                    header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).AlignLeft().Text("Nome").Bold().FontSize(12);
                                    header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text("Meses Com Dívida").Bold().FontSize(12);
                                    header.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text("Conta").Bold().FontSize(12);

                                });

                                var cont = 0;
                                foreach (var alunosDevedores in lista)
                                {
                                    var nome = alunosDevedores.Nome;
                                    cont++;
                                    if (alunosDevedores.Nome.Split(" ").Length > 3)
                                    {
                                        var partes = alunosDevedores.Nome.Split(" ");
                                        nome = $"{partes[0]} {partes[1]} {partes.Last()}";
                                    }
                                    table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text($"{cont}");
                                    table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).PaddingRight(25).Text($"{nome}");
                                    table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text($"{alunosDevedores.MesesDivida}");
                                    table.Cell().Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#CDCBCB")).Padding(4).Text($"{alunosDevedores.Conta}");
                                }

                            });
                        }


                    });

                    page.Footer().AlignRight().Text(x =>
                    {
                        x.CurrentPageNumber();
                        x.Span("/");
                        x.TotalPages();
                    });

                });
            });

            var path = Path.Combine(Path.GetTempPath(), "relatorio.pdf");

            using (var arqStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                document.GeneratePdf(arqStream);
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });

            try
            {
                await Task.Delay(10000);
                File.Delete(path);
            }
            catch
            {

            }

        }
        public async Task GerarPdfNotaDevedoresProximoMes(Classes listaClasses)
        {
            var inforescola = _DbService.InfoEscola();
            if (inforescola is null)
                return;

            CultureInfo cultura = new CultureInfo("pt-PT");

            
            var alunos = _DbService.DevedoresAteProximoMes(listaClasses);

            var grupos = alunos
                .Select((aluno, index) => new { aluno, index })
                .GroupBy(x => x.index / 10)
                .Select(g => g.Select(x => x.aluno).ToList())
                .ToList();

            var document = Document.Create(container =>
            {
                foreach (var grupo in grupos)
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(0.5f, Unit.Centimetre);
                        page.DefaultTextStyle(x => x.FontSize(12));
                        page.Content().Row(row =>
                        {
                            // Coluna esquerda (até 5 alunos)
                            row.RelativeItem().Column(col =>
                            {
                                foreach (var aluno in grupo.Take(5))
                                {
                                    col.Item().Height(5.6f, Unit.Centimetre)
                                        .Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#000000"))
                                        .Padding(5).Column(info =>
                                        {
                                            info.Item().AlignCenter().Text($"{inforescola.Nome}").FontSize(14).Bold();
                                            info.Spacing(5);
                                            info.Item().AlignCenter().Text("Comunicado").Italic().Underline().FontSize(10);
                                            info.Spacing(5);
                                            info.Item().Text(text =>
                                            {
                                                DateTime data = DateTime.Now;

                                                int dia = data.Day;

                                                string mes = data.ToString("MMMM");

                                                var texteSplit = aluno.MesesDivida.Split(",");

                                                if (texteSplit.Length > 1)
                                                {
                                                    text.Justify();
                                                    text.Span("A Direção do complexo escolar acima referida, vem por este meio convocar o Encarregado de educação de ");
                                                    text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                    text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                    text.Span(", que se dirija à secretária do colégio para liquidar a sua conta dos meses de ");

                                                    var newText = String.Join(", ", texteSplit);

                                                    if (texteSplit.Length > 3)
                                                    {
                                                        newText = string.Join(", ",
                                                            texteSplit.Select(x =>
                                                            {
                                                                if (string.IsNullOrEmpty(x) || x.Length < 3)
                                                                    return x;
                                                                return char.ToUpper(x[0]) + x.Substring(1, 2).ToLower();
                                                            })
                                                            );
                                                    }
                                                    text.Span(newText).Bold();
                                                }
                                                else
                                                {
                                                    if (dia > inforescola.DiaCobrarPropina)
                                                    {

                                                        text.Justify();
                                                        text.Span("A Direção do complexo escolar acima referida, vem por este meio convocar o Encarregado de educação de ");
                                                        text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                        text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                        text.Span(", que se dirija à secretária do colégio para liquidar a sua conta do mês de");

                                                        var newText = char.ToUpper(texteSplit[0][0]) + texteSplit[0].Substring(1).ToLower();

                                                        text.Span(newText).Bold();
                                                    }
                                                    else
                                                    {
                                                        text.Justify();
                                                        text.Span("A Direção do complexo escolar acima referida, vem por este meio dar a " +
                                                            "conhecer ao Encarregado de educação de ");
                                                        text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                        text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                        text.Span(", que está em curso a cobrança da propina do mês de ");

                                                        var newText = char.ToUpper(texteSplit[0][0]) + texteSplit[0].Substring(1).ToLower();

                                                        text.Span(newText).Bold();

                                                        text.Span(". Pedimos encarecidamente que se dirija a secretária para liquidar a sua conta.");

                                                    }

                                                }
                                            });
                                        });
                                }
                            });

                            // Coluna direita (até 5 alunos)
                            row.RelativeItem().Column(col =>
                            {
                                foreach (var aluno in grupo.Skip(5).Take(5))
                                {
                                    col.Item().Height(5.6f, Unit.Centimetre)
                                        .Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#000000"))
                                        .Padding(5).Column(info =>
                                        {
                                            info.Item().AlignCenter().Text($"{inforescola.Nome}").FontSize(14).Bold();
                                            info.Spacing(5);
                                            info.Item().AlignCenter().Text("Comunicado").Italic().Underline().FontSize(10);
                                            info.Spacing(5);
                                            info.Item().Text(text =>
                                            {
                                                DateTime data = DateTime.Now;
                                                int dia = data.Day;
                                                string mes = data.ToString("MMMM");

                                                var texteSplit = aluno.MesesDivida.Split(",");

                                                if (texteSplit.Length > 1)
                                                {
                                                    text.Justify();
                                                    text.Span("A Direção do complexo escolar acima referida, vem por este meio convocar o Encarregado de educação de ");
                                                    text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                    text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                    text.Span(", que se dirija à secretária do colégio para liquidar a sua conta dos meses de ");

                                                    var newText = String.Join(", ", texteSplit);

                                                    if (texteSplit.Length > 3)
                                                    {
                                                        newText = string.Join(", ",
                                                            texteSplit.Select(x =>
                                                            {
                                                                if (string.IsNullOrEmpty(x) || x.Length < 3)
                                                                    return x;
                                                                return char.ToUpper(x[0]) + x.Substring(1, 2).ToLower();
                                                            })
                                                            );
                                                    }
                                                    text.Span(newText).Bold();
                                                }
                                                else
                                                {
                                                    if (dia > inforescola.DiaCobrarPropina)
                                                    {
                                                        text.Justify();
                                                        text.Span("A Direção do complexo escolar acima referida, vem por este meio convocar o Encarregado de educação de ");
                                                        text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                        text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                        text.Span(", que se dirija à secretária do colégio para liquidar a sua conta do mês de ");

                                                        var newText = char.ToUpper(texteSplit[0][0]) + texteSplit[0].Substring(1).ToLower();

                                                        text.Span(newText).Bold();
                                                    }
                                                    else
                                                    {
                                                        text.Justify();
                                                        text.Span("A Direção do complexo escolar acima referida, vem por este meio dar a " +
                                                            "conhecer ao Encarregado de educação de ");
                                                        text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                        text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                        text.Span(", que está em curso a cobrança da propina do mês de ");

                                                        var newText = char.ToUpper(texteSplit[0][0]) + texteSplit[0].Substring(1).ToLower();

                                                        text.Span(newText).Bold();

                                                        text.Span(". Pedimos encarecidamente que se dirija a secretária para liquidar a sua conta.");

                                                    }

                                                }
                                            });
                                        });
                                }
                            });
                        });

                    });
                }
            });

            var path = Path.Combine(Path.GetTempPath(), "relatorio.pdf");

            using (var arqStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                document.GeneratePdf(arqStream);
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });

            try
            {
                await Task.Delay(10000);
                File.Delete(path);
            }
            catch
            {

            }
        }
        public async Task GerarPdfNotaDevedoresTodasTurmasProximoMes(ObservableCollection<Classes> listaClasses)
        {
            var inforescola = _DbService.InfoEscola();
            if (inforescola is null)
                return;

            CultureInfo cultura = new CultureInfo("pt-PT");

            // Dividir lista em grupos de 10
            var grupos = listaClasses
                .SelectMany(turma => _DbService.DevedoresAteProximoMes(turma)) // pega todos os alunos devedores
                .Select((aluno, index) => new { aluno, index })
                .GroupBy(x => x.index / 10)
                .Select(g => g.Select(x => x.aluno).ToList())
                .ToList();

            var document = Document.Create(container =>
            {
                foreach (var grupo in grupos)
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(0.5f, Unit.Centimetre);
                        page.DefaultTextStyle(x => x.FontSize(12));
                        page.Content().Row(row =>
                        {
                            // Coluna esquerda (até 5 alunos)
                            row.RelativeItem().Column(col =>
                            {
                                foreach (var aluno in grupo.Take(5))
                                {
                                    col.Item().Height(5.6f, Unit.Centimetre)
                                        .Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#000000"))
                                        .Padding(5).Column(info =>
                                        {
                                            info.Item().AlignCenter().Text($"{inforescola.Nome}").FontSize(14).Bold();
                                            info.Spacing(5);
                                            info.Item().AlignCenter().Text("Comunicado").Italic().Underline().FontSize(10);
                                            info.Spacing(5);
                                            info.Item().Text(text =>
                                            {
                                                DateTime data = DateTime.Now;

                                                int dia = data.Day;

                                                string mes = data.ToString("MMMM");

                                                var texteSplit = aluno.MesesDivida.Split(",");

                                                if (texteSplit.Length > 1)
                                                {
                                                    text.Justify();
                                                    text.Span("A Direção do complexo escolar acima referida, vem por este meio convocar o Encarregado de educação de ");
                                                    text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                    text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                    text.Span(", que se dirija à secretária do colégio para liquidar a sua conta dos meses de ");

                                                    var newText = String.Join(", ", texteSplit);

                                                    if (texteSplit.Length > 3)
                                                    {
                                                        newText = string.Join(", ",
                                                            texteSplit.Select(x =>
                                                            {
                                                                if (string.IsNullOrEmpty(x) || x.Length < 3)
                                                                    return x;
                                                                return char.ToUpper(x[0]) + x.Substring(1, 2).ToLower();
                                                            })
                                                            );
                                                    }
                                                    text.Span(newText).Bold();
                                                }
                                                else
                                                {
                                                    if (dia > inforescola.DiaCobrarPropina)
                                                    {

                                                        text.Justify();
                                                        text.Span("A Direção do complexo escolar acima referida, vem por este meio convocar o Encarregado de educação de ");
                                                        text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                        text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                        text.Span(", que se dirija à secretária do colégio para liquidar a sua conta do mês de");

                                                        var newText = char.ToUpper(texteSplit[0][0]) + texteSplit[0].Substring(1).ToLower();

                                                        text.Span(newText).Bold();
                                                    }
                                                    else
                                                    {
                                                        text.Justify();
                                                        text.Span("A Direção do complexo escolar acima referida, vem por este meio dar a " +
                                                            "conhecer ao Encarregado de educação de ");
                                                        text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                        text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                        text.Span(", que está em curso a cobrança da propina do mês de ");

                                                        var newText = char.ToUpper(texteSplit[0][0]) + texteSplit[0].Substring(1).ToLower();

                                                        text.Span(newText).Bold();

                                                        text.Span(". Pedimos encarecidamente que se dirija a secretária para liquidar a sua conta.");

                                                    }

                                                }
                                            });
                                        });
                                }
                            });

                            // Coluna direita (até 5 alunos)
                            row.RelativeItem().Column(col =>
                            {
                                foreach (var aluno in grupo.Skip(5).Take(5))
                                {
                                    col.Item().Height(5.6f, Unit.Centimetre)
                                        .Border(1).BorderColor(QuestPDF.Infrastructure.Color.FromHex("#000000"))
                                        .Padding(5).Column(info =>
                                        {
                                            info.Item().AlignCenter().Text($"{inforescola.Nome}").FontSize(14).Bold();
                                            info.Spacing(5);
                                            info.Item().AlignCenter().Text("Comunicado").Italic().Underline().FontSize(10);
                                            info.Spacing(5);
                                            info.Item().Text(text =>
                                            {
                                                DateTime data = DateTime.Now;
                                                int dia = data.Day;
                                                string mes = data.ToString("MMMM");

                                                var texteSplit = aluno.MesesDivida.Split(",");

                                                if (texteSplit.Length > 1)
                                                {
                                                    text.Justify();
                                                    text.Span("A Direção do complexo escolar acima referida, vem por este meio convocar o Encarregado de educação de ");
                                                    text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                    text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                    text.Span(", que se dirija à secretária do colégio para liquidar a sua conta dos meses de ");

                                                    var newText = String.Join(", ", texteSplit);

                                                    if (texteSplit.Length > 3)
                                                    {
                                                        newText = string.Join(", ",
                                                            texteSplit.Select(x =>
                                                            {
                                                                if (string.IsNullOrEmpty(x) || x.Length < 3)
                                                                    return x;
                                                                return char.ToUpper(x[0]) + x.Substring(1, 2).ToLower();
                                                            })
                                                            );
                                                    }
                                                    text.Span(newText).Bold();
                                                }
                                                else
                                                {
                                                    if (dia > inforescola.DiaCobrarPropina)
                                                    {
                                                        text.Justify();
                                                        text.Span("A Direção do complexo escolar acima referida, vem por este meio convocar o Encarregado de educação de ");
                                                        text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                        text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                        text.Span(", que se dirija à secretária do colégio para liquidar a sua conta do mês de ");

                                                        var newText = char.ToUpper(texteSplit[0][0]) + texteSplit[0].Substring(1).ToLower();

                                                        text.Span(newText).Bold();
                                                    }
                                                    else
                                                    {
                                                        text.Justify();
                                                        text.Span("A Direção do complexo escolar acima referida, vem por este meio dar a " +
                                                            "conhecer ao Encarregado de educação de ");
                                                        text.Span(cultura.TextInfo.ToTitleCase(aluno.Nome.ToLower())).Bold();
                                                        text.Span($", {aluno.Classe.ToUpper()}").Bold();
                                                        text.Span(", que está em curso a cobrança da propina do mês de ");

                                                        var newText = char.ToUpper(texteSplit[0][0]) + texteSplit[0].Substring(1).ToLower();

                                                        text.Span(newText).Bold();

                                                        text.Span(". Pedimos encarecidamente que se dirija a secretária para liquidar a sua conta.");

                                                    }

                                                }
                                            });
                                        });
                                }
                            });
                        });

                    });
                }
            });

            var path = Path.Combine(Path.GetTempPath(), "relatorio.pdf");

            using (var arqStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                document.GeneratePdf(arqStream);
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });

            try
            {
                await Task.Delay(10000);
                File.Delete(path);
            }
            catch
            {

            }
        }



    }
}
