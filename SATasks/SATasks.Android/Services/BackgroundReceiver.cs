using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace SATasks.Droid.Services
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { "com.xamarin.example.TEST" })]
    public class BackgroundReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            PowerManager pm = (PowerManager)context.GetSystemService(Context.PowerService);
            PowerManager.WakeLock wakeLock = pm.NewWakeLock(WakeLockFlags.Partial, "BackgroundReceiver");
            wakeLock.Acquire();

            // Run your code here

            if (DateTime.Now.Second == 20)
            {
                FileAdd(DateTime.Now.Second.ToString());
            }

            wakeLock.Release();
        }

        public async Task FileAdd(string data)
        {
            var filename = DateTime.Now.ToString("yyyy.MM.dd") + ".csv";

            var dateStamp = DateTime.Now.ToString();
            var pathLocation = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "BitoobitLocation");
            if (!Directory.Exists(pathLocation))
            {
                Directory.CreateDirectory(pathLocation);
            }

            var backingFile = Path.Combine(pathLocation, filename);
            using (var writer = File.AppendText(backingFile))
            {
                await writer.WriteLineAsync($"SSSSSSS;");
                //await writer.WriteLineAsync($"{dateStamp};{data};");
            }
        }
    }

}