using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24SportLagersystem.Persistency;
using _24SportLagersystem.ViewModel;

namespace _24SportLagersystem.Model
{
    class Singleton24Sport
    {
        //her laver vi en instans af singleton
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

        // Dette er vores singleton konstruktør som kun kan tilgås via vores Instance metode. I vores konstruktør bliver observablecollection initialiseret, og der der bliver også kaldt en load metode af vores products
        private Singleton24Sport()
        {
            Products = new ObservableCollection<Product>();
            Customers = new ObservableCollection<Customer>();
            Orders = new ObservableCollection<Order>();
            OrderLines = new ObservableCollection<OrderLine>();
            ProductLines = new ObservableCollection<ProductLine>();
            ProductParts = new ObservableCollection<ProductPart>();
            LoadOrdersAsync();
            LoadProductsAsync();
            LoadProductPartsAsync();
        }

        #region AddMethodsWithObjectParameter
        public void AddProduct(Product newProduct)
        {
            Products.Add(newProduct);
        }

        public void AddProductPart(ProductPart newProductPart)
        {
            ProductParts.Add(newProductPart);
        }

        public void AddProductLine(ProductLine newProductLine)
        {
            ProductLines.Add(newProductLine);
        }

        public void AddCustomer(Customer newCustomer)
        {
            Customers.Add(newCustomer);
        }

        public void AddOrder(Order newOrder)
        {
            Orders.Add(newOrder);
        }

        public void AddOrderLine(OrderLine newOrderLine)
        {
            OrderLines.Add(newOrderLine);
        }
        #endregion

        #region AddMethodsWithoutObjectParameter
        public void AddProduct(int productId, string productName, double height, double price, int amountMade,
        int amountMakeable)
        {
            Product myProduct = new Product(productId, productName, height, price, amountMade, amountMakeable);
            Products.Add(myProduct);
        }

        public void AddProductLine(int productLineId, int productId, int productPartId, int amount)
        {
            ProductLine myProductLine = new ProductLine(productLineId, productId, productPartId, amount);
            ProductLines.Add(myProductLine);
        }

        public void AddOrder(int orderId, int customerId, DateTime orderDate, DateTime deliveryDate)
        {
            Order myOrder = new Order(orderId, customerId, orderDate, deliveryDate);
            Orders.Add(myOrder);
        }

        public void AddOrderLine(int orderLineId, int orderId, int productId, int amount)
        {
            OrderLine myOrderLine = new OrderLine(orderLineId, orderId, productId, amount);
            OrderLines.Add(myOrderLine);
        }

        public void AddCustomer(int customerId, string name, int phoneNo, string address, string email)
        {
            Customer myCustomer = new Customer(customerId, name, phoneNo, address, email);
            Customers.Add(myCustomer);
        }
        #endregion

        public async void LoadOrdersAsync()
        {
            var orders = await PersistencyService.LoadOrderFromJsonAsync();
            if (orders != null)
                foreach (var ev in orders)
                {
                    Orders.Add(ev);
                }
        }

        #region ProductCrudMethods

        public async void LoadProductsAsync()
        {
            var products = await ProductPersistencyService.LoadProductFromJsonAsync();
            if (products != null)
            {
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
        }

        #endregion

        #region ProductPartCrudMethods

        public void AddProductPart(int productPartId, int productPartNo, string description, int amount, double pricePerDkk, double pricePerEur,
            double priceTotalDkk, double priceTotalEur)
        {
            ProductPart myProductPart = new ProductPart(productPartId, productPartNo, description, amount, pricePerDkk, pricePerEur, priceTotalDkk, priceTotalEur);
            ProductParts.Add(myProductPart);
            ProductPartPersistencyService.SaveProductPartsAsJsonAsync(myProductPart);
        }

        public async void LoadProductPartsAsync()
        {
            var productParts = await ProductPartPersistencyService.LoadProductPartsFromJsonAsync();
            if (productParts != null)
            {
                foreach (var productPart in productParts)
                {
                    ProductParts.Add(productPart);
                }
            }
        }

        public void EditProductPart(ProductPart productPart)
        {
            ProductPartPersistencyService.EditProductPartAsync(ViewModel24Sport.SelectedItem);
        }

        public void DeleteProductPart(ProductPart selectedItem)
        {
            ProductParts.Remove(selectedItem);
            ProductPartPersistencyService.DeleteProductPartAsync(selectedItem);
        }

        #endregion

        public override string ToString()
        {
            return $"{nameof(Products)}: {Products}, {nameof(Customers)}: {Customers}, {nameof(Orders)}: {Orders}, {nameof(OrderLines)}: {OrderLines}, {nameof(ProductLines)}: {ProductLines}, {nameof(ProductParts)}: {ProductParts}";
        }

    }
}
