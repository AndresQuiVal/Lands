using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Platform;
using Android.Support.V4.Content;
using Android.Support.V4.App;

namespace Lands.Droid
{
    [Activity(Label = "Lands", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //int requestPermissions = 0;
            //string cameraPermission = Android.Manifest.Permission.Camera;

            //if (!(ContextCompat.CheckSelfPermission(this, cameraPermission) == (int)Permission.Granted))
            //{
            //    ActivityCompat.RequestPermissions(this, new String[] { cameraPermission, }, requestPermissions);
            //}

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            //CachedImageRenderer.InitImageViewHandler();
            CachedImageRenderer.Init(enableFastRenderer: true); // false too

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, 
            [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
           // Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}