using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
            InitializeComponent();
            GetPermissions();


        }

        private async void GetPermissions()
        {
            Console.WriteLine("kaminkr1 GetPermissions");
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        System.Console.WriteLine("kaminkr1 Need your location", "We need to access your location", "Ok");
                        await DisplayAlert("kaminkr1 Need your location", "We need to access your location", "Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                    if (results.ContainsKey(Permission.LocationWhenInUse))
                        status = results[Permission.LocationWhenInUse];
                }

                if (status == PermissionStatus.Granted)
                {
                    locationsMap.IsShowingUser = true;
                }
                else
                {
                    System.Console.WriteLine("kaminkr1 Location denied", "You didn't give us permission to access location, so we can't show you where you are", "Ok");
                    await DisplayAlert("kaminkr1 Location denied", "You didn't give us permission to access location, so we can't show you where you are", "Ok");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("kaminkr1 Error", ex.Message, "Ok");
                await DisplayAlert("kaminkr1 Error", ex.Message, "Ok");
            }
        }
    }
}