using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MonitorAppXam.Services;

namespace MonitorAppXam.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        private string selectedRelation;
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            ApiAccountService apiServices = new ApiAccountService();
            selectedRelation = PickerRelation.SelectedItem as string;
            bool response = await apiServices.RegisterUser(EntEmail.Text, EntPassword.Text, EntConfirmPassword.Text, selectedRelation);

            if (!response)
            {
                await DisplayAlert("Alert", "Something went wrong...", "Close");
            }
            else
            {
                await DisplayAlert("Success", "Account created", "OK");
                await Navigation.PopToRootAsync();
            }
        }

    }
}