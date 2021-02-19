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
        private ObservableCollection<T> _Items;
        public ObservableCollection<T> Items 
        {
            get
            {
                return _Items;
            }
            set
            {
                if (_Items != value)
                {
                    _Items = value;
                    OnPropertyChanged("Items");
                }
            }
        }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<T> ItemTapped { get; }

        #region Sort
        public string SortField { get; set; }

        public List<string> SortComboboxItems
        {
            get
            {
                return GetComboboxSortList();
            }
        }

        public Command SortCommand { get; }

        public virtual List<string> GetComboboxSortList() { return new List<string>(); }

        public virtual void Sort() { }

        public async void OnSortItem()
        {
            Sort();
        }
        #endregion Sort

        #region Filtr
        public string FiltrField { get; set; }

        public Command FiltrCommand { get; }

        public virtual void Filtr() { }

        public async void OnFiltrItem()
        {
            Filtr();
        }

        #endregion Filtr
        public AItemsViewModel()
        {
            Items = new ObservableCollection<T>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<T>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
            SortCommand = new Command(OnSortItem);
            FiltrCommand = new Command(OnFiltrItem);
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




    }
}
