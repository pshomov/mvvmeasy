using System;
using Prism.Mvvm;
using Xamarin.Forms;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MVVMEasy.Pages
{
    public class LoginPageViewModel_FodyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginPageViewModel_FodyPropertyChanged ()
        {
            ErrorMessage = "";
            LoginInProgress = false;
            Username = "";
            Password = "";
            Login = new MVVMCommand (async _ => {
                ErrorMessage = "";
                LoginInProgress = true;
                try {
                    await Task.Delay (5000);
                } catch (Exception e) {
                    ErrorMessage = e.Message;
                }
                LoginInProgress = false;
            }, _ => IsLoginEnabled);
        }

        public Command Login { get; set; }

        public bool IsLoginEnabled {
            get { return !LoginInProgress && (Username.Length > 0 && Password.Length > 0); }
        }

        public string ErrorMessage { get; set; }

        public bool IsError {
            get { return ErrorMessage != ""; }
        }

        public bool LoginInProgress { get; set; }

        public bool LoginNotInProgress { get { return !LoginInProgress; } }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
