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
    public partial class AddPatientPage : ContentPage
    {
        public AddPatientPage()
        {
            InitializeComponent();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            EntFirstName.Text = "";
            EntPatientID.Text = "";
            await DisplayAlert("Notice", "If a patient with the supplied name and ID exists, they will receive a notification. If they accept your request, the patient will appear in 'My Patients' found on the Home page.", "OK");
        }
    }
}