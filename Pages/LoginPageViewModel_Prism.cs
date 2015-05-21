using System;
using Prism.Mvvm;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace MVVMEasy.Pages
{
    public class LoginPageViewModel_Prism : BindableBase
    {
        private string _errorMessage;
        private bool _loginInProgress;
        private string _password = "";
        private string _username = "";

        public LoginPageViewModel_Prism ()
        {
            ErrorMessage = "";
            LoginInProgress = false;
            Login = new Command (async _ => {
                ErrorMessage = "";
                LoginInProgress = true;
                Login.ChangeCanExecute ();
                try {
                    // perform login
                    await Task.Delay (5000);
                } catch (Exception e) {
                    ErrorMessage = e.Message;
                }
                LoginInProgress = false;
                Login.ChangeCanExecute ();
            }, _ => !LoginInProgress && (Username.Length > 0 && Password.Length > 0));
        }

        public Command Login { get; set; }

        public string ErrorMessage {
            get { return _errorMessage; }
            set {
                if (SetProperty (ref _errorMessage, value))
                    OnPropertyChanged (() => IsError);
            }
        }

        public bool IsError {
            get { return ErrorMessage != ""; }
        }

        public bool LoginInProgress {
            get { return _loginInProgress; }
            set {
                if (SetProperty (ref _loginInProgress, value)) {
                    OnPropertyChanged (() => LoginNotInProgress);
                }
            }
        }

        public bool LoginNotInProgress { get { return !LoginInProgress; } }

        public string Username {
            get { return _username; }
            set {
                if (SetProperty (ref _username, value)) {
                    Login.ChangeCanExecute ();
                }
            }
        }

        public string Password {
            get { return _password; }
            set {
                if (SetProperty (ref _password, value)) {
                    Login.ChangeCanExecute ();
                }
            }
        }

    }
}
