
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CadastroEventos.Models
{
    public class Evento : INotifyPropertyChanged
    {
        private string nome = "";
        private DateTime dataInicio = new DateTime(2026, 11, 23);
        private DateTime dataTermino = new DateTime(2026, 11, 25);
        private int numeroParticipantes = 2000;
        private string local = "Teatro Principal";
        private decimal custoPorParticipante = 100m;

        public string Nome
        {
            get => nome;
            set { nome = value; OnPropertyChanged(); }
        }

        public DateTime DataInicio
        {
            get => dataInicio;
            set
            {
                dataInicio = value;
                OnPropertyChanged();
                AtualizarDuracao();
            }
        }

        public DateTime DataTermino
        {
            get => dataTermino;
            set
            {
                dataTermino = value;
                OnPropertyChanged();
                AtualizarDuracao();
            }
        }

        public int NumeroParticipantes
        {
            get => numeroParticipantes;
            set
            {
                numeroParticipantes = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CustoTotal));
            }
        }

        public string Local
        {
            get => local;
            set { local = value; OnPropertyChanged(); }
        }

        public decimal CustoPorParticipante
        {
            get => custoPorParticipante;
            set
            {
                custoPorParticipante = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CustoTotal));
            }
        }

        public TimeSpan Duracao =>
            DataTermino.Date - DataInicio.Date;

        public int DuracaoEmDias => Duracao.Days;

        public decimal CustoTotal =>
            NumeroParticipantes * CustoPorParticipante;

        public string DuracaoFormatada =>
            $"{DuracaoEmDias} dias ({Duracao.TotalHours:0} horas)";

        private void AtualizarDuracao()
        {
            OnPropertyChanged(nameof(Duracao));
            OnPropertyChanged(nameof(DuracaoEmDias));
            OnPropertyChanged(nameof(DuracaoFormatada));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string propriedade = "")
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propriedade));
        }
    }
}
