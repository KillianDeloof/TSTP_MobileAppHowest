using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MobileAppHowest.Models;

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


        public static void GetCampusDistances(List<Campus> campusList, double[] currentLatLong)
        {
            foreach (Campus campus in campusList)
            {
                campus.Distance = CalculateDistance(campus.LatLong, currentLatLong);
            }
        }

        public static double CalculateDistance(double[] latLong1, double[] latLong2)
        {
            double x1 = latLong1[1];
            double y1 = latLong1[0];
            double x2 = latLong2[1];
            double y2 = latLong2[0];
            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return distance;
        }
    }
}
