using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SportLagersystem.Model
{
    class Singleton24Sport
    {
        public PersistencyService.PersistencyService PersistencyService { get; set; }

        private static Singleton24Sport _instance = new Singleton24Sport();
        public static Singleton24Sport Instance
        {


            get { return _instance ?? (_instance = new Singleton24Sport()); }

        }

        public ObservableCollection<Product> Products { get; set; }

        private Singleton24Sport()
        {
            Products = new ObservableCollection<Product>();
            //LoadProductsAsync();
        }



        //public async void LoadProductsAsync()
        //{
        //    var products = await PersistencyService.LoadProductFromJsonAsync();
        //    if (products != null)
        //        foreach (var ev in products)
        //        {
        //            Products.Add(ev);
        //        }

        //}
    }
}
