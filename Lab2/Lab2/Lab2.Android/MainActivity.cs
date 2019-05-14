using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Lab2.Droid
{
    [Activity(Label = "Lab2", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity, FormFragment.IOnFragmentInteractionListener // global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        public string noChoosen { get; set; }

        public void OnTypeProductChoosen(string typeProduct)
        {
            if (string.Equals(typeProduct, noChoosen))
            {
                typeProduct = string.Empty;
            }
            var resultFragment = FragmentManager.FindFragmentById(Resource.Id.resultFragment) as ResultFragment;
            if (resultFragment != null)
            {

                resultFragment.SetTypeProduct(typeProduct);
            }
        }

        public void OnVendorChoosen(string vendor)
        {
            if (string.Equals(vendor, noChoosen))
            {
                vendor = string.Empty;
            }
            var resultFragment = FragmentManager.FindFragmentById(Resource.Id.resultFragment) as ResultFragment;
            if (resultFragment != null)
            {
                resultFragment.SetVendor(vendor);
            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
          //  TabLayoutResource = Resource.Layout.Tabbar;
          //  ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            // global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            // LoadApplication(new App());
            SetContentView(Resource.Layout.MainActivity);
        }
    }
}