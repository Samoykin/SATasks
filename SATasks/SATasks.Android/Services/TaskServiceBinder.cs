using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SATasks.Droid.Services
{
    //Подкласс Binder
    public class TaskServiceBinder : Binder
    {
        protected TaskService service;

        public TaskServiceBinder(TaskService service)
        {
            this.service = service;
        }

        public TaskService Service => service;

        public bool IsBound { get; set; }
    }
}