using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;

namespace TravelRecordApp.Logic
{
    public class VenueLogic
    {
        public async static Task<List<VenueRoot>> GetVenues(double latitude, double longitude)
        {
            List<VenueRoot> venues = new List<VenueRoot>();

            var url = VenueRoot.GenerateURL(latitude,longitude);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
            }


            return venues;
        }
    }
}
