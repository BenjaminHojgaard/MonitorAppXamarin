using MonitorAppXam.Models;
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
    public partial class PatientPage : ContentPage
    {
        public string FirstName { get; set; }
        public PatientPage(PatientInfo patient)
        {
            InitializeComponent();
            FirstName = patient.FirstName;
            FirstNameLabel.Text = patient.FirstName;
            PatientIDLabel.Text = "Patient ID: " + Convert.ToString(patient.PatientID);
            LastMeasurementLabel.Text = "Newest Measurement: " + String.Format("{0:dd/MM/yyyy HH:mm}", patient.LastMeasurement);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrendsPage());
        }
    }
}