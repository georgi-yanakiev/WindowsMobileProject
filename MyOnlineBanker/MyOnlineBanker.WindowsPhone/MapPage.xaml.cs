using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MyOnlineBanker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        public MapPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var locator = new Geolocator {DesiredAccuracyInMeters = 15};

            var position = await locator.GetGeopositionAsync();

            await Map.TrySetViewAsync(position.Coordinate.Point, 15D);
            
            AddMapIcon();

        }

        public void AddMapIcon()
        {
            var mapIcon1 = new MapIcon
            {
                Location = new Geopoint(new BasicGeoposition()
                {
                    Latitude = 42.6521,
                    Longitude = 023.3746
                }),
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                Title = "Branch 1"
            };

            var mapIcon2 = new MapIcon
            {
                Location = new Geopoint(new BasicGeoposition()
                {
                    Latitude = 42.6545,
                    Longitude = 023.3788
                }),
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                Title = "Branch 2"
            };

            var mapIcon3 = new MapIcon
            {
                Location = new Geopoint(new BasicGeoposition()
                {
                    Latitude = 42.6517,
                    Longitude = 023.3725
                }),
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                Title = "Branch 3"
            };

            var mapIcon4 = new MapIcon
            {
                Location = new Geopoint(new BasicGeoposition()
                {
                    Latitude = 42.6488,
                    Longitude = 023.3797
                }),
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                Title = "Branch 4"
            };

            Map.MapElements.Add(mapIcon1);
            Map.MapElements.Add(mapIcon2);
            Map.MapElements.Add(mapIcon3);
            Map.MapElements.Add(mapIcon4);
        }

        private void MapBack_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (MainPage));
        }
    }
}
