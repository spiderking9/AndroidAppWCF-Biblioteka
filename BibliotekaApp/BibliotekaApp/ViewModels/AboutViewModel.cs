using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BibliotekaApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Start";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://github.com/spiderking9"));
        }

        public ICommand OpenWebCommand { get; }
    }
}