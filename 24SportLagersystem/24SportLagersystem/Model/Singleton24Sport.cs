using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24SportLagersystem.Persistency;

namespace _24SportLagersystem.Model
{
    class Singleton24Sport
    {
        //her laver vi et objekt af singleton 
        private static Singleton24Sport _instance = new Singleton24Sport();

        //denne get metode tjekker om der er oprettet et singleton objekt og er der ikke dette, laver den et og kun et objekt.
        public static Singleton24Sport Instance
        {   
            get { return _instance ?? (_instance = new Singleton24Sport()); }
        }

        //her laver vi en masse observablecollection med datatypen Product,Customer,Order,OrderLine,ProductLine,ProductPart og giver dem efterfølgende et navn
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
        public ObservableCollection<OrderLine> OrderLines { get; set; }
        public ObservableCollection<ProductLine> ProductLines { get; set; }
        public ObservableCollection<ProductPart> ProductParts { get; set; }
        
        //dette er vores singleton konstruktør som kun kan tilgås via vores Instance metode. i vores konstruktør bliver der lavet et nyt observablecollection objekt af product, og der der bliver også kaldt en load metode af vores products
        private Singleton24Sport()
        {
            Products = new ObservableCollection<Product>();
            LoadProductsAsync();
        }

        
        public void AddProduct(Product newProduct)
        {
            Products.Add(newProduct);
        }

        public void AddProduct(int productId, string productName, double height, double price, int amountMade,
            int amountMakeable)
        {
            Product myProduct = new Product(productId, productName, height, price, amountMade, amountMakeable);
            Products.Add(myProduct);
        }

        public void AddProductPart(int productPartId, string description, int amount, double pricePerDkk, double pricePerEur,
            double priceTotalDkk, double priceTotalEur)
        {
            ProductPart myProductPart = new ProductPart(productPartId, description, amount, pricePerDkk, pricePerEur, priceTotalDkk, priceTotalEur);
            ProductParts.Add(myProductPart);
        }

        public async void LoadProductsAsync()
        {
            var products = await PersistencyService.LoadProductFromJsonAsync();
            if (products != null)
                foreach (var ev in products)
                {
                    Products.Add(ev);
                }

        }
    }
}
