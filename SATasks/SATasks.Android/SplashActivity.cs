using Android.App;
using Android.Content.PM;
using Android.OS;

namespace SATasks.Droid
{
    [Activity(Label = "Помни", Icon = "@mipmap/IconApp", RoundIcon = "@mipmap/IconCicle", Theme = "@style/MyTheme.Splash", ScreenOrientation = ScreenOrientation.Portrait, MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        public const string TAG = "MainActivity";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(typeof(MainActivity));
        }
    }
}