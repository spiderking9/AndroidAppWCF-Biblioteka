using System;
using System.Collections.Generic;
using System.Text;
using ServiceReferenceBiblioteka;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BibliotekaApp.Services
{
    public abstract class ItemDataStore<T> : IDataStore<T>
    {
        public List<T> items;
        public IServiceBiblioteka bibliotekaServices { get; set; }
        public ItemDataStore()
        {
            bibliotekaServices = DependencyService.Get<ServiceReferenceBiblioteka.IServiceBiblioteka>();
        }
        public async Task<bool> AddItemAsync(T item)
        {
            AddItem(item);
            items.Add(item);
            return await Task.FromResult(true);
        }

        public abstract T Find(T item);
        public abstract T Find(int id);
        public abstract void AddItem(T item);

        public async Task<bool> UpdateItemAsync(T item)
        {
            var oldItem = Find(item);
            items.Remove(oldItem);
            items.Add(item);
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Find(id);
            items.Remove(oldItem);
            return await Task.FromResult(true);
        }
        public async Task<T> GetItemAsync(int id)
        {
            return await Task.FromResult(Find(id));
        }
        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
