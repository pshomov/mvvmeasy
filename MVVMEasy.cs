﻿using System;

using Xamarin.Forms;
using MVVMEasy.Pages;

namespace MVVMEasy
{
    public class App : Application
    {
        public App ()
        {
            // The root page of your application
            MainPage = new LoginView(){BindingContext = new LoginPageViewModel_Prism()};
            MainPage = new LoginView(){BindingContext = new LoginPageViewModel_FodyPropertyChanged()};
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}
