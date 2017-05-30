using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppHowest.Repositories
{
    public class GPSRepository
    {
        /// <summary>
        /// Gets current coordinates from GPS, returns a double[] with: value[0] = lattitude and value[1] = longitude
        /// </summary>
        /// <returns>Task<double[]></returns>
        public async Task<double[]> GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(10000);

            double lat = position.Latitude;
            double lon = position.Longitude;
            double[] coords = new double[2];
            coords[0] = lat;
            coords[1] = lon;

            return coords;
        }
    }
}
