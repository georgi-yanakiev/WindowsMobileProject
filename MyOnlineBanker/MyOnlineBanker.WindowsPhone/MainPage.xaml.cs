using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Popups;
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

            var context = new AppViewModel();
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
                
                ShowNotification("Login successful!");
                LoginButton.IsEnabled = false;
                LogoutButton.IsEnabled = true;
                Frame.Navigate(typeof (CustomerDetailsPage));
                this.UsernameTextBox.Text = string.Empty;
                this.PasswordTextBox.Password = string.Empty;
                System.Threading.Tasks.Task.Delay(2000).Wait();
                ToastNotificationManager.History.Clear();

            }
            catch (Exception e)
            {
                ShowNotification(e.Message);
                System.Threading.Tasks.Task.Delay(2000).Wait();
                ToastNotificationManager.History.Clear();
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this.LoginUser();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            ParseUser.LogOut();
            ShowNotification("You were logged out!");
            LogoutButton.IsEnabled = false;
            LoginButton.IsEnabled = true;
            System.Threading.Tasks.Task.Delay(2000).Wait();
            ToastNotificationManager.History.Clear();
        }

        private void Maps_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (MapPage));
        }

        private void Contacts_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (ContactsPage));
        }

        public static void ShowNotification(string message)
        {
            const ToastTemplateType template =
                Windows.UI.Notifications.ToastTemplateType.ToastText01;
            var toastXml =
                Windows.UI.Notifications.ToastNotificationManager.GetTemplateContent(template);

            var toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(message));

            var toast = new Windows.UI.Notifications.ToastNotification(toastXml);

            var toastNotifier =
                Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier();
            toastNotifier.Show(toast);
            
            
        }

        private void UIElement_OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X < 0 && ParseUser.CurrentUser != null)
            {
                this.Frame.Navigate(typeof (CustomerDetailsPage));
            }
        }

    }
}