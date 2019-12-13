using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonitorAppXam.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Tblogout_Clicked(object sender, EventArgs e)
        {
            Settings.UserName = "";
            Settings.Password = "";
            Settings.AccessToken = "";
            Navigation.InsertPageBefore(new SignInPage(), this);
            Navigation.PopAsync();
        }

        

        private async void AddPatient_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPatientPage());
        }

        private async void MyPatients_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyPatientsPage());
        }

        private async void Notifications_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotificationsPage());
        }
        private async void Help_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpPage());
        }

    }
}