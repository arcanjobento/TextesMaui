

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TextesMaui.Models;
using TextesMaui.PdfsRelatorios;
using TextesMaui.Services;

namespace TextesMaui.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        ScoolDbService _service;

        RelatorioAlunosDivida _relatorioPdf;

        [ObservableProperty]
        ObservableCollection<AlunosDevedores> lista;

        [ObservableProperty]
        ObservableCollection<Classes> listaClasses;

        [ObservableProperty]
        Classes classesSelected;

        [ObservableProperty]
        string numberOfDevedoresTotal;

        [ObservableProperty]
        string numberOfDevedoresClasse;

        [ObservableProperty]
        bool isBuzzy = false;

        public MainViewModel(ScoolDbService service, RelatorioAlunosDivida relatorioPdf)
        {
            _service = service;
            Lista = new();
            ListaClasses = new();
            _relatorioPdf = relatorioPdf;
            TakeClassesList();

        }


        void TakeDevedores(Classes classes)
        {
            if (classes is null)
                return;
            Lista.Clear();
            var result = _service.Devedores(classes);
            for (var item = 0; item < result.Count; item++)
            {
                Lista.Add(result[item]);
            }

            NumberOfDevedoresClasse = $"Devedores {classes.Nome}    Turma {classes.Turma}  Total {result.Count}";

        }

        void TakeClassesList()
        {
            var listResult = _service.ListOfClasses();

            if (listResult.Count == 0)
                return;

            ListaClasses.Clear();

            for (var item = 0; item < listResult.Count; item++)
            {
                if (item == 0)
                {
                    ListDevedoresClass(listResult[item]);
                }
                ListaClasses.Add(listResult[item]);
            }
        }

        [RelayCommand]
        void ListDevedoresClass(Classes classes)
        {
            ClassesSelected = classes;
            TakeDevedores(classes);
        }

        [RelayCommand]
        async Task PdfTurma()
        {

            try
            {
                IsBuzzy = true;
                await _relatorioPdf.GerarPdfTurma(ClassesSelected);

                await Application.Current.MainPage.DisplayAlertAsync("Feito", "", "Ok");
                IsBuzzy = false;
            }
            catch (Exception error)
            {
                IsBuzzy = false;
                Application.Current.MainPage.DisplayAlertAsync("Erro Inesperado", $"Erro inesperado ao tentar Lista de Devedores desta turma - {error.Message}", "Ok");
            }
        }

        [RelayCommand]
        async Task PdfTurmaAteProximoMes()
        {

            try
            {
                IsBuzzy = true;
                await _relatorioPdf.GerarPdfTurmaProximoMes(ClassesSelected);

                await Application.Current.MainPage.DisplayAlertAsync("Feito", "", "Ok");
                IsBuzzy = false;
            }
            catch (Exception error)
            {
                IsBuzzy = false;
                Application.Current.MainPage.DisplayAlertAsync("Erro Inesperado", $"Erro inesperado ao tentar Lista de Devedores desta turma - {error.Message}", "Ok");
            }
        }

        [RelayCommand]
        async Task PdfDevedores()
        {
            try
            {
                IsBuzzy = true;
                await _relatorioPdf.GerarPdfDevedores(ListaClasses);

                await Application.Current.MainPage.DisplayAlertAsync("Feito", "", "Ok");
                IsBuzzy = false;
            }
            catch (Exception error)
            {
                IsBuzzy = false;
                Application.Current.MainPage.DisplayAlertAsync("Erro Inesperado", $"Erro inesperado ao tentar criar lista dos devedores - {error.Message}", "Ok");
            }
        }
        [RelayCommand]
        async Task PdfDevedoresAteProximoMes()
        {
            try
            {
                IsBuzzy = true;
                await _relatorioPdf.GerarPdfDevedoresProximoMes(ListaClasses);

                await Application.Current.MainPage.DisplayAlertAsync("Feito", "", "Ok");
                IsBuzzy = false;
            }
            catch (Exception error)
            {
                IsBuzzy = false;
                Application.Current.MainPage.DisplayAlertAsync("Erro Inesperado", $"Erro inesperado ao tentar criar lista dos devedores - {error.Message}", "Ok");
            }
        }

        [RelayCommand]
        async Task Nota()
        {

            try
            {
                IsBuzzy = true;
                await _relatorioPdf.GerarPdfNotaDevedores(ListaClasses);
                await Application.Current.MainPage.DisplayAlertAsync("Feito", "", "Ok");

            }
            catch (Exception error)
            {
                await Application.Current.MainPage.DisplayAlertAsync("Erro Inesperado", $"Erro inesperado ao tentar criar comunicados - {error.Message}", "Ok");
            }
            finally
            {
                IsBuzzy = false;
            }
        }

        [RelayCommand]
        async Task NotaTurmaUnica()
        {

            try
            {
                IsBuzzy = true;
                await _relatorioPdf.GerarPdfNotaDevedoresProximoMes(ClassesSelected);
                await Application.Current.MainPage.DisplayAlertAsync("Feito", "", "Ok");

            }
            catch (Exception error)
            {
                await Application.Current.MainPage.DisplayAlertAsync("Erro Inesperado", $"Erro inesperado ao tentar criar comunicados - {error.Message}", "Ok");
            }
            finally
            {
                IsBuzzy = false;
            }
        }
        [RelayCommand]
        async Task NotaTurmaUnicaTodasTurmasAteProximoMes()
        {

            try
            {
                IsBuzzy = true;
                await _relatorioPdf.GerarPdfNotaDevedoresTodasTurmasProximoMes(ListaClasses);
                await Application.Current.MainPage.DisplayAlertAsync("Feito", "", "Ok");

            }
            catch (Exception error)
            {
                await Application.Current.MainPage.DisplayAlertAsync("Erro Inesperado", $"Erro inesperado ao tentar criar comunicados - {error.Message}", "Ok");
            }
            finally
            {
                IsBuzzy = false;
            }
        }

    }
}
