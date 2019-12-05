using MonitorAppXam.Services;
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
    public partial class SignInPage : ContentPage
    {

        ApiAccountService apiService;

        public SignInPage()
        {
            apiService = new ApiAccountService();
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            //if (!Validators.IsEmail(EntEmail.Text))
            //{
            //    await DisplayAlert("test", "test", "Cancel");
            //}
            //else
            //{
                StartActivityIndicator();
                bool response = await apiService.LoginUser(EntEmail.Text, EntPassword.Text);



                if (!response)
                {
                    EndActivityIndicator();
                    await DisplayAlert("Alert", "Something went wrong...", "Close");
                }
                else
                {
                    EndActivityIndicator();
                    Navigation.InsertPageBefore(new HomePage(), this);
                    await Navigation.PopAsync();
                }
            //}
            
        }

        private void StartActivityIndicator()
        {
            activityIndicator.IsEnabled = true;
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;
        }

        private void EndActivityIndicator()
        {
            activityIndicator.IsVisible = false;
            activityIndicator.IsRunning = false;
            activityIndicator.IsEnabled = false;
        }

        private void TapSignUp_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }
    }
}