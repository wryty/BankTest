using Microsoft.Maui.Controls;
using Mapsui.Layers;
using Mapsui.Styles;
using Mapsui.UI;
using Mapsui.Projections;
using Mapsui.Tiling;
using Mapsui.UI.Maui;

namespace BankTest.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage(MapViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

            var mapControl = new MapView();
            var map = new Mapsui.Map();
            map.Layers.Add(OpenStreetMap.CreateTileLayer());

            double latitude = 48.8566; // Широта Парижа
            double longitude = 2.3522; // Долгота Парижа

            var pin = new Pin
            {
                Label = "Париж",
                Address = "Франция",
                Position = new Position(latitude, longitude)
            };
            

            mapControl.Map = map;
            mapControl.Pins.Add(pin);
            InitializeMap(mapControl);
            Content = mapControl;
        }

        private async void InitializeMap(MapView mapControl)
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location != null)
            {
                double latitude = location.Latitude;
                double longitude = location.Longitude;

                var pin = new Pin
                {
                    Label = "Ваше местоположение",
                    Address = "Вы здесь",
                    Position = new Position(latitude, longitude)
                };

                mapControl.Pins.Add(pin);

                //map.Center = new Mapsui.Geometries.Point(latitude, longitude);
                //map.Zoom = 10; // Установите желаемый уровень масштабирования
            }
        }
    }
}
