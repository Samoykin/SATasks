using Matcha.BackgroundService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SATasks.Helpers
{
    public class PeriodicWebCall : IPeriodicTask
    {
        public PeriodicWebCall(int seconds)
        {
            Interval = TimeSpan.FromSeconds(seconds);
        }

        public TimeSpan Interval { get; set; }

        public Task<bool> StartJob()
        {
            // YOUR CODE HERE
            // THIS CODE WILL BE EXECUTE EVERY INTERVAL

            var task = Task.Run(async () => await  FileAdd("ffdddd"));



            return Task.FromResult<bool>(true); ; //return false when you want to stop or trigger only once
        }

        public async Task FileAdd(string data)
        {
            var filename = DateTime.Now.ToString("yyyy.MM.dd") + ".csv";

            var dateStamp = DateTime.Now.ToString();
            var backingFile = Path.Combine(Xamarin.Essentials.FileSystem.CacheDirectory, filename);

            //var pathLocation = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "BitoobitLocation");
            //if (!Directory.Exists(pathLocation))
            //{
            //    Directory.CreateDirectory(pathLocation);
            //}

            //var backingFile = Path.Combine(pathLocation, filename);
            using (var writer = File.AppendText(backingFile))
            {
                await writer.WriteLineAsync($"SSSSSSS;");
                //await writer.WriteLineAsync($"{dateStamp};{data};");
            }
        }
    }
}
