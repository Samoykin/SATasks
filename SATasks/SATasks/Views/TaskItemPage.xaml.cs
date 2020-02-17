using SATasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SATasks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskItemPage : ContentPage
    {
        private bool IsEditItem { get; set; } = false;
        private Friend Item { get; set; }

        private ItemInfo ItemInfo { get; set; } = new ItemInfo();

        public TaskItemPage(Friend item, bool isAdd = false)
        {
            InitializeComponent();

            ItemInfo.Item = item;

            ItemInfo.IsEditItem = isAdd;

            if (isAdd)
            {
                Title = "Новая задача";
            }

            BindingContext = ItemInfo;
        }

        private void SaveItem(object sender, EventArgs e)
        {
            var friend = ItemInfo.Item; // (Friend)BindingContext;
            if (!String.IsNullOrEmpty(friend.Name))
            {
                App.Database.SaveItem(friend);
            }
            this.Navigation.PopAsync();
        }

        private async void DeleteItem(object sender, EventArgs e)
        {

            if (await DisplayAlert("Внимание", "Вы хотите удалить элемент?", "Да", "Нет"))
            {
                var friend = ItemInfo.Item; //(Friend)BindingContext;
                App.Database.DeleteItem(friend.Id);
                await this.Navigation.PopAsync();
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void EditBtn(object sender, EventArgs e)
        {
            ItemInfo.IsEditItem = true;
        }

        private async void ViewBtn(object sender, EventArgs e)
        {
            ItemInfo.IsEditItem = false;
        }

        private async void ShareItem(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {               
                Title = ItemInfo.Item.Name,
                Text = ItemInfo.Item.Description
            });
        }
    }
}