using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCenter.Analytics.Metrics;
using Microsoft.AppCenter.Crashes;
using MyWeather;
using Refit;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace InstrumentedApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            bool didAppCrash = await Crashes.HasCrashedInLastSessionAsync();

            if(didAppCrash)
                await DisplayAlert("Sorry for that!", "Looks like something wrong happened, we are currently looking into that so there is nothing to worry about.", "ok");


            await SearchWeather("Santo Domingo");
        }

        public async void Handle_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxCity.Text))
            {
                await SearchWeather(tbxCity.Text);
            }
        }

        private async Task SearchWeather(string city)
        {
            try
            {

                Microsoft.AppCenter.Analytics.Analytics.TrackEvent("Requesting Weather",
                new Dictionary<string, string> {
                    { "DeviceName", DeviceInfo.Name},
                    { "CityParameter", city }
                });

                using (AnalyticsMetrics.TrackTimedEvent("Weather Request"))
                {
                    var apiClient = RestService.For<IMyWeatherApiClient>(App.BaseUrl);

                    var resultObject = await apiClient.GetWeatherFromCity(city, App.ApiKey);

                    BindingContext = resultObject;
                }
            }
            catch (Exception ex)
            {


                Microsoft.AppCenter.Crashes.Crashes.TrackError(ex,
                new Dictionary<string, string> {
                    { "DeviceName", DeviceInfo.Name},
                    { "CityParameter", city },
                    { "Exception message", ex.Message }
                });


                await DisplayAlert("Error", ex.Message, "ok");
            }
        }

        public void Handle_Crash_Clicked(object sender, EventArgs args)
        {
//            Crashes.GenerateTestCrash();

            throw new Exception("Oh no! you clicked the button :C");
        }
    }
}
