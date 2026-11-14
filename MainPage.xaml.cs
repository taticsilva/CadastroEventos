
using CadastroEventos.Models;

namespace CadastroEventos;

public partial class MainPage : ContentPage
{
    private Evento evento;

    public MainPage()
    {
        InitializeComponent();

        evento = new Evento();

        BindingContext = evento;
    }

    private async void OnConcluirCadastro(
        object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(evento.Nome) ||
            string.IsNullOrWhiteSpace(evento.Local))
        {
            await DisplayAlert(
                "Atenção",
                "Preencha o nome e o local do evento.",
                "OK");
            return;
        }

        if (evento.DataTermino.Date < evento.DataInicio.Date)
        {
            await DisplayAlert(
                "Atenção",
                "A data de término não pode ser anterior à data de início.",
                "OK");
            return;
        }

        if (evento.NumeroParticipantes <= 0 ||
            evento.CustoPorParticipante < 0)
        {
            await DisplayAlert(
                "Atenção",
                "Informe valores válidos para participantes e custo.",
                "OK");
            return;
        }

        await Navigation.PushAsync(
            new ResumoPage(evento));
    }
}
