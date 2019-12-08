using MonitorAppXam.Models;
using MonitorAppXam.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonitorAppXam.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPatientsPage : ContentPage
    {
        private MyPatientsViewModel myPatients; 
        public MyPatientsPage()
        {
            InitializeComponent();
            myPatients = new MyPatientsViewModel();
            LvMyPatients.ItemsSource = myPatients.MyPatients;
        }

        private void LvMyPatients_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPatient = e.SelectedItem as PatientInfo;
            if (selectedPatient != null)
            {
                Navigation.PushAsync(new PatientPage(selectedPatient));
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}