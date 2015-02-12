using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BMSDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapControl1 : Page
    {
        private Geolocator myGeolocator;
        public MapControl1()
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
            var endPoint = new Geopoint(
new BasicGeoposition()
{
    Latitude = Convert.ToDouble(Utility.PLaceLatitude),
    Longitude = Convert.ToDouble(Utility.PLaceLongitude)
});

            myMap.Center = endPoint;
            myMap.TrafficFlowVisible = true;
            AddPushpin(new BasicGeoposition()
{
    Latitude = Convert.ToDouble(Utility.PLaceLatitude),
    Longitude = Convert.ToDouble(Utility.PLaceLongitude)
}, "Hello");
            //myMap.   new GeoCoordinate(rootObj.result.geometry.location.lat, rootObj.result.geometry.location.lng), 16);
            // new Geopoint((BasicGeoposition)myGeoposition);//(//(Utility.CurrentLatitude, Utility.CurrentLongitude);
        }

        public void AddPushpin(BasicGeoposition location, string text)
        {
            var pin = new Grid()
            {
                Width = 50,
                Height = 50,
                Margin = new Windows.UI.Xaml.Thickness(-12)
            };

            pin.Children.Add(new Ellipse()
            {
                Fill = new SolidColorBrush(Colors.DodgerBlue),
                Stroke = new SolidColorBrush(Colors.White),
                StrokeThickness = 3,
                Width = 50,
                Height = 50
            });

            pin.Children.Add(new TextBlock()
            {
                Text = text,
                FontSize = 12,
                Foreground = new SolidColorBrush(Colors.White),
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
                VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center
            });

           MapControl.SetLocation(pin, new Geopoint(location));
            myMap. Children.Add(pin);
        }
        
        private void map1_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
