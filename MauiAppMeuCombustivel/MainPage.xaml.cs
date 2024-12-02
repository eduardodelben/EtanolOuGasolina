using System;
using System.Globalization; // Necessário para lidar com culturas e conversão de números

namespace MauiAppMeuCombustivel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Verificar se os campos estão preenchidos
                if (string.IsNullOrWhiteSpace(txt_etanol.Text) || string.IsNullOrWhiteSpace(txt_gasolina.Text))
                {
                    DisplayAlert("Erro", "Por favor, preencha ambos os campos.", "Fechar");
                    return;
                }

                // Tentar converter os valores para double
                bool etanolValido = double.TryParse(
                    txt_etanol.Text.Replace(",", "."),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out double etanol);

                bool gasolinaValida = double.TryParse(
                    txt_gasolina.Text.Replace(",", "."),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out double gasolina);

                // Validar conversão
                if (!etanolValido || !gasolinaValida)
                {
                    DisplayAlert("Erro", "Insira valores numéricos válidos.", "Fechar");
                    return;
                }

                // Calcular e exibir o resultado
                string mensagem = etanol <= (gasolina * 0.7)
                    ? "O etanol está compensando."
                    : "A gasolina está compensando.";

                DisplayAlert("Resultado", mensagem, "Ok");
            }
            catch (Exception ex)
            {
                // Captura exceções inesperadas
                DisplayAlert("Ops!", $"Algo deu errado :( Detalhes: {ex.Message}", "Fechar");
            }
        }
    }
}
