using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace appTekoArte.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand => new RelayCommand(Login);
        public LoginViewModel()
        {
            this.Email = "prueba@gmail.com";
            this.Password = "Passw0rd";
        }
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Tienes que escribir un Email.",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Tienes que escribir un Password.",
                    "Aceptar");
                return;
            }

            if (!this.Email.Equals("pruba@gmail.com") || !this.Password.Equals("Passw0rd"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Password o Usuario mal.",
                    "Aceptar");
                return;
            }

            MainViewModel.GetInstance().tekoArteViewModel = new TekoArteViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new Page());
        }
    }
}
