using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SATasks.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : PopupPage
    {
        public InfoPage()
        {
            InitializeComponent();

            VerLbl.Text = VersionTracking.CurrentVersion;
            BindingContext = this;
        }

        public ICommand DeveloperCommand => new Command(() =>
        {
            DevName.IsVisible = true;
        });

        public ICommand WebCommand => new Command(async () =>
        {
            await Launcher.OpenAsync($"https://github.com/Samoykin");
        });

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private async void buttonSet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAllPopupAsync();
        }
    }
}