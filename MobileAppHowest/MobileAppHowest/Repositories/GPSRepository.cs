﻿using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MobileAppHowest.Models;
using System.Net;
using System.Xml.Linq;

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

        /// <summary>
        /// fills in the distance propperty of campus items in the givven List
        /// </summary>
        /// <param name="campusList"></param>
        /// <param name="currentLatLong"></param>
        public static void GetCampusDistances(List<Campus> campusList, double[] currentLatLong)
        {
            foreach (Campus campus in campusList)
            {
                campus.Distance = CalculateDistance(campus.LatLong, currentLatLong);
            }
        }

        /// <summary>
        /// calculate the distance between 2 coordinates
        /// </summary>
        /// <param name="latLong1"></param>
        /// <param name="latLong2"></param>
        /// <returns></returns>
        public static double CalculateDistance(double[] latLong1, double[] latLong2)
        {
            double x1 = latLong1[1];
            double y1 = latLong1[0];
            double x2 = latLong2[1];
            double y2 = latLong2[0];
            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            return distance;
        }

        /// <summary>
        /// returns the latLong coords from an address
        /// </summary>
        /// <param name="campusList">list of campusses </param>
        /// <returns>LatLong coordinates</returns>
        public async static Task<List<Campus>> FillCoordsFromAddress(List<Campus> campusList)
        {
            foreach (Campus campus in campusList)
            {
                if (campus.LatLong == null)
                {
                    string address = campus.Address;
                    //do api shit and get coord
                    IGeocoder geocoder = new GoogleGeocoder() { ApiKey = "AIzaSyC7EOq3zAJYXSmycgDp11WA5jV7fF_5R_Y" };
                    double lat = 0;
                    double lon = 0;
                    campus.LatLong = new double[2];
                    campus.LatLong[0] = lat;
                    campus.LatLong[1] = lon;
                }

            }


        //            campus.LatLong = new double[2];
        //            campus.LatLong[0] = lat;
        //            campus.LatLong[1] = lon;
        //        }

            return campusList;
        }
    }
}