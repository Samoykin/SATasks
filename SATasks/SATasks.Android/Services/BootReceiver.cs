using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace SATasks.Droid.Services
{
    [BroadcastReceiver(DirectBootAware = true)] //(Name = "Location.Droid.BackgroundServices.BootReceiver", Enabled = true)
    [IntentFilter(new[] { Intent.ActionBootCompleted, Intent.ActionLockedBootCompleted, "android.intent.action.QUICKBOOT_POWERON" })]
    public class BootReceiver : BroadcastReceiver
    {
        static readonly string TAG = "MainActivity";
        public override void OnReceive(Context context, Intent intent)
        {
            Log.Debug(TAG, "OnReceive: BootReceiver.");

            Intent i = new Intent(context, typeof(TaskService));

            // Для Android 8.0 и выше
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                context.StartForegroundService(i);
            }
            else // Для старых версий
            {
                context.StartService(i);
            }
        }
    }
}