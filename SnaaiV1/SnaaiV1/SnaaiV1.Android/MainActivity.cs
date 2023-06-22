using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Xamarin.Forms.Platform.Android;
using FFImageLoading.Forms.Droid;
using FFImageLoading.Forms;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.CurrentActivity;


namespace SnaaiV1.Droid
{
    [Activity(Label = "SnaaiV1", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {

            CrossCurrentActivity.Current.Activity = this;
            // disables the fast renderer option of hte cachedimageloading plugin, this makes sure that all images are properly rendered.
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: false);
            // Enebles the motioneventhandler in Android.
            CachedImage.FixedAndroidMotionEventHandler = true;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);



            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        // This prevents a user from being able to hit the back button and leave the login page.
        public override void OnBackPressed()
        {
        }
    }
}

