using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BibliotekaApp.Services;

namespace BibliotekaApp.ViewModels.Lista
{
    public abstract class AItemsViewModel<T> : BaseViewModel
    {
        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
        private T _selectedItem;
        public ObservableCollection<T> Items { get; set; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<T> ItemTapped { get; }

        public Command SortCommand { get; }
        public AItemsViewModel()
        {
            Items = new ObservableCollection<T>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<T>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
            SortCommand = new Command(OnSortItem);
        }


        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = default(T);
        }

        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        public abstract void GoToAddPage();
        private async void OnAddItem(object obj)
        {
            GoToAddPage();
        }
        public async virtual void GoToEditPage(T item)
        {
        }

        private async void OnItemSelected(T item)
        {

            if (item == null)
                return;
            // to jest przejście 
            GoToEditPage(item);
            //await Shell.Current.GoToAsync($"{nameof(KlientDetailPage)}?{nameof(KlientDetailViewModel.ItemId)}={item.IdKlienta}");
        }



        public string FindText { get; set; }
        public virtual void Sort() { }

        private async void OnSortItem()
        {
            Sort();
        }
    }
}
