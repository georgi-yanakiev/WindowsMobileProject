using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Parse;

namespace MyOnlineBanker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public async void LoginUser()
        {
            try
            {
                await ParseUser.LogInAsync(this.UsernameTextBox.Text, this.PasswordTextBox.Password);
                // Login was successful.
                LoginButton.IsEnabled = false;
                LogoutButton.IsEnabled = true;
//                Frame.Navigate(typeof(CustomerDetailsPage));
                this.UsernameTextBox.Text = string.Empty;
                this.PasswordTextBox.Password = string.Empty;
            }
            catch (Exception e)
            {
                // The login failed. Check the error to see why.
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this.LoginUser();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            ParseUser.LogOut();
            LogoutButton.IsEnabled = false;
            LoginButton.IsEnabled = true;
        }

        private void Contacts_Click(object sender, RoutedEventArgs e)
        {
//            Frame.Navigate(typeof(ContactsPage));
        }

        private void Maps_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MapPage));
        }
    }


}
