using Rg.Plugins.Popup.Extensions;
using SATasks.Models;
using SATasks.Views.Popup;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace SATasks.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            friendsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Friend selectedFriend = (Friend)e.SelectedItem;
            TaskItemPage friendPage = new TaskItemPage(selectedFriend);
            //friendPage.BindingContext = selectedFriend;
            await Navigation.PushAsync(friendPage);
        }
        // обработка нажатия кнопки добавления
        private async void AddItemBtn(object sender, EventArgs e)
        {
            Friend friend = new Friend();
            TaskItemPage friendPage = new TaskItemPage(friend, true);
            //friendPage.BindingContext = friend;
            await Navigation.PushAsync(friendPage);
        }

        private async void SettingsBtn(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new InfoPage());
        }
    }
}
