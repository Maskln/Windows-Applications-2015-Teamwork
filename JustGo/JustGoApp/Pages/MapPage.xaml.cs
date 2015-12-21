namespace JustGoApp.Pages
{
    using System;
    using System.Threading.Tasks;
    using Windows.Devices.Geolocation;
    using Windows.Services.Maps;
    using Windows.System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Maps;
    public sealed partial class MapPage : Page
    {
        public MapPage()
        {
            this.InitializeComponent();
            myMap.Loaded += MyMap_Loaded;
            myMap.MapTapped += MyMap_MapTapped;
        }

        private async void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                Geolocator geolocator = new Geolocator();
                Geoposition pos = await geolocator.GetGeopositionAsync();
                Geopoint myLocation = pos.Coordinate.Point;

                myMap.Center = myLocation;
                myMap.ZoomLevel = 12;
                myMap.LandmarksVisible = true;
            }
            else
            {
                await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
            }
        }

        private async void MyMap_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            MapAddress address = null;
            var tappedGeoPosition = args.Location.Position;
            address = await this.GetAddres(tappedGeoPosition.Latitude, tappedGeoPosition.Longitude);
            var m = address.FormattedAddress;
        }

        public async Task<MapAddress> GetAddres(double latitude, double longtitude)
        {
            BasicGeoposition location = new BasicGeoposition()
            {
                Latitude = latitude,
                Longitude = longtitude
            };

            Geopoint pointToReverseGeocode = new Geopoint(location);

            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            MapAddress addres = null;

            if (result.Locations != null)
            {
                addres = result.Locations[0].Address;
            }

            return addres;
        }

    }
}
