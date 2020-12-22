using BibliotekaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekaApp.Services
{
    public class MockDataStore : ItemDataStore<Item>
    {

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item {  Text = "First item", Description="This is an item description." },
                new Item { Text = "Second item", Description="This is an item description." },
                new Item {Text = "Third item", Description="This is an item description." },
                new Item {Text = "Fourth item", Description="This is an item description." },
                new Item { Text = "Fifth item", Description="This is an item description." },
                new Item {  Text = "Sixth item", Description="This is an item description." }
            };
        }

        public override void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public override Item Find(Item item)
        {
            return items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
        }
        public override Item Find(int id)
        {
            return items.Where((Item arg) => arg.Id == id).FirstOrDefault();
        }
    }
}