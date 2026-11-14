
using CadastroEventos.Models;
using System.Globalization;

namespace CadastroEventos;

public partial class ResumoPage : ContentPage
{
    public ResumoPage(Evento evento)
    {
        InitializeComponent();

        BindingContext = evento;

        CultureInfo cultura = new CultureInfo("pt-BR");

        ValorIndividual.Text =
            evento.CustoPorParticipante.ToString("C2", cultura);

        ValorTotal.Text =
            evento.CustoTotal.ToString("C2", cultura);
    }

    private async void OnVoltarCadastro(
        object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
