using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
namespace InstrumentedApp
{
    public partial class App : Application
    {
        public static string ApiKey = "4a50dce6081255feb798d50bdcd8f238";
        public static string BaseUrl = "http://api.weatherstack.com";
        public static string Endpoint = "http://api.weatherstack.com/current.json?access_key=f4a33bfe56d84a7b895210819181510&query={0}";

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            Microsoft.AppCenter.AppCenter.Start("ios=125b8cd1-fcf1-4ee3-b129-3719997dd7b9;",
                     typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
