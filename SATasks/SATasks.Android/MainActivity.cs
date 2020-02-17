using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Refractored.XamForms.PullToRefresh.Droid;
using SATasks.Droid.Services;
using Android.Content;
using System.Threading.Tasks;
using Android.Util;
using Matcha.BackgroundService.Droid;

namespace SATasks.Droid
{
    [Activity(Label = "Помни", Icon = "@mipmap/IconApp", RoundIcon = "@mipmap/IconCicle", Theme = "@style/MainTheme", ScreenOrientation = ScreenOrientation.Portrait, MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            Init(savedInstanceState);
            LoadApplication(new App());
        }

        public void Init(Bundle savedInstanceState)
        {
            PullToRefreshLayoutRenderer.Init();
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            BackgroundAggregator.Init(this);
            //var myreceiver = new BootReceiver();
            //var intentfilter = new IntentFilter("BOOT_COMPLETED");
            //RegisterReceiver(myreceiver, intentfilter);

            //var myreceiver2 = new BackgroundReceiver();
            //RegisterReceiver(myreceiver2,  new IntentFilter("com.xamarin.example.TEST"));

            //var intent1 = new Intent(Application.Context, typeof(TaskService));
            //StartLocationService(intent1);

            //Intent service = new Intent(this, typeof(TaskService));
            //StartService(service);
            //StartLocationService(service);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public static void StartLocationService(Intent intent)
        {
            // Запуск сервиса в фоновом потоке
            new Task(() =>
            {
                Log.Debug("App", "Calling StartService");

                // Для Android 8.0 и выше
                if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                {
                    Application.Context.StartForegroundService(intent);
                }
                else // Для старых версий
                {
                    Application.Context.StartService(intent);
                }

                // bind our service (Android goes and finds the running service by type, and puts a reference
                // on the binder to that service)
                // The Intent tells the OS where to find our Service (the Context) and the Type of Service
                // we're looking for (LocationService)
                //var locationServiceIntent = new Intent(Application.Context, typeof(LocationService));
                Log.Debug("App", "Calling service binding");

                // Finally, we can bind to the Service using our Intent and the ServiceConnection we
                // created in a previous step.
                //Application.Context.BindService(locationServiceIntent, locationServiceConnection, Bind.AutoCreate);
            }).Start();
        }
    }
}