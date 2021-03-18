using System;
using System.Collections.Generic;
using System.Text;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.Model
{
    public class Venue
    {
        public static string GenerateURL(double latitude,double longitude)
        {
            return string.Format(Constans.VENUE_SEARCH, latitude, longitude,Constans.CLIENT_ID,Constans.CLIENT_ID,DateTime.Now.ToString("yyyyMMdd"));
        }
    }
}
