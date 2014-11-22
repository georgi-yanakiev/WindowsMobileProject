using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using MyOnlineBanker.ViewModels;
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
            LogoutButton.IsEnabled = false;

            this.NavigationCacheMode = NavigationCacheMode.Required;

//            this.DataContext = new LoginViewModel();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        public async void LoginUser()
        {
            try
            {
                await ParseUser.LogInAsync(this.UsernameTextBox.Text, this.PasswordTextBox.Password);
                ShowNotification("Login", "Login successful!");
                LoginButton.IsEnabled = false;
                LogoutButton.IsEnabled = true;
                Frame.Navigate(typeof (CustomerDetailsPage));
                this.UsernameTextBox.Text = string.Empty;
                this.PasswordTextBox.Password = string.Empty;
            }
            catch (Exception e)
            {
                
                ShowNotification("Login Error", e.Message);
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this.LoginUser();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            ParseUser.LogOut();
            ShowNotification("Logout", "You were logged out!");
            LogoutButton.IsEnabled = false;
            LoginButton.IsEnabled = true;
        }

        private void Maps_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (MapPage));
        }

        private void Contacts_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (ContactsPage));
        }

        public static void ShowNotification(string title, string message)
        {
            const ToastTemplateType template =
                Windows.UI.Notifications.ToastTemplateType.ToastText02;
            var toastXml =
                Windows.UI.Notifications.ToastNotificationManager.GetTemplateContent(template);

            var toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(title));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode(message));

            var toast = new Windows.UI.Notifications.ToastNotification(toastXml);

            var toastNotifier =
                Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier();
            toastNotifier.Show(toast);
        }


    }
}