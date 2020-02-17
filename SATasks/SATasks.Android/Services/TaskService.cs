using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace SATasks.Droid.Services
{
    [Service]
    public class TaskService : Service
    {
        private static BroadcastReceiver notificationReceiver;
        private System.Timers.Timer aTimer;
        IBinder binder;

        //public TaskService()
        //{
        //    aTimer = new System.Timers.Timer(1000);
        //    aTimer.Elapsed += OnTimedEvent;
        //    aTimer.AutoReset = true;
        //    aTimer.Enabled = true;
        //}

        public override void OnCreate()
        {
            base.OnCreate();
            //Log.Debug(logTag, "OnCreate called in the Location Service");            
            RegisterBroadcastReceiver();

            // Создаем таймер
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public override void OnDestroy()
        {
            Application.Context.UnregisterReceiver(notificationReceiver);
            notificationReceiver = null;
        }

        // Вызывается один раз, когда клиент привязывается к сервису и возвращает экземпляр LocationServiceBinder
        // Остальные клиенты будут использовать тот-же экземпляр        
        public override IBinder OnBind(Intent intent)
        {
            //Log.Debug(logTag, "Client now bound to service");

            binder = new TaskServiceBinder(this);
            return binder;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if(DateTime.Now.Second == 20)
            {
                FileAdd(DateTime.Now.Second.ToString());
            }
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

        private void RegisterBroadcastReceiver()
        {
            notificationReceiver = new BackgroundReceiver();

            IntentFilter filter = new IntentFilter("com.xamarin.example.TEST");
            Application.Context.RegisterReceiver(notificationReceiver, filter);
        }
    }
}