using System.Text;
using BibliotekaApp.Models;
using BibliotekaApp.ViewModels.Edytuj;
using BibliotekaApp.Views.Edytuj;
using BibliotekaApp.Views.Nowy;
using Xamarin.Forms;

namespace BibliotekaApp.ViewModels.Lista
{
    public class CzytelnikViewModel : AItemsViewModel<Czytelnicy>
    {
        public CzytelnikViewModel()
            : base()
        {
            Title = "Czytelnicy";
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NowyCzytelnikPage));
        }
        public async override void GoToEditPage(Czytelnicy item)
        {
            await Shell.Current.GoToAsync($"{nameof(CzytelnikDetailPage)}?{nameof(CzytelnikDetailViewModel.IdCzytelnika)}={item.IdCzytelnika}");
        }
    }
}