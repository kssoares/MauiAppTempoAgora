using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Service;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null)
                    {
                        string dados_previsao = "";
                        dados_previsao = $"Latitude: {t.lat} \n" +
                                         $"Longitude: {t.lon} \n" +
                                         $"Nascer do Sol: {t.sunrise} \n" +
                                         $"Por do Sol: {t.sunset} \n" +
                                         $"Temp Max: {t.temp_max} \n" +
                                         $"Temp Min: {t.temp_min} \n" +
                                         $"Visibilidade: {t.visibility} \n" +
                                         $"Velocidade (Vento): {t.speed} \n" +
                                         $"Descrição: {t.description} \n";

                        lbl_res.Text = dados_previsao;

                    } else
                    {
                        lbl_res.Text = "Sem dados de Previsão";
                    }
                } else 
                {
                    lbl_res.Text = "Preencha a cidade.";
                }

            }catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }

}
