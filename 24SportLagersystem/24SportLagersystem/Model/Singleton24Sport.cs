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
            Customers = new ObservableCollection<Customer>();
            Orders = new ObservableCollection<Order>();
            OrderLines = new ObservableCollection<OrderLine>();
            ProductLines = new ObservableCollection<ProductLine>();
            ProductParts = new ObservableCollection<ProductPart>();
            LoadOrdersAsync();
        }

        #region AddMethodsWithObjectParameter
        //public void AddProduct(Product newProduct)
        //{
        //    Products.Add(newProduct);
        //}

        //public void AddProductPart(ProductPart newProductPart)
        //{
        //    ProductParts.Add(newProductPart);
        //}

        //public void AddProductLine(ProductLine newProductLine)
        //{
        //    ProductLines.Add(newProductLine);
        //}

        //public void AddCustomer(Customer newCustomer)
        //{
        //    Customers.Add(newCustomer);
        //}

        public void AddOrder(Order newOrder)
        {
            Orders.Add(newOrder);
        }

        //public void AddOrderLine(OrderLine newOrderLine)
        //{
        //    OrderLines.Add(newOrderLine);
        //}
        #endregion

        #region AddMethodsWithoutObjectParameter
        public void AddProduct(int productId, string productName, double height, double price, int amountMade,
        int amountMakeable)
        {
            Product myProduct = new Product(productId, productName, height, price, amountMade, amountMakeable);
            Products.Add(myProduct);
        }

        public void AddProductPart(int productPartId, int productPartNo, string description, int amount, double pricePerDkk, double pricePerEur,
            double priceTotalDkk, double priceTotalEur)
        {
            ProductPart myProductPart = new ProductPart(productPartId, productPartNo, description, amount, pricePerDkk, pricePerEur, priceTotalDkk, priceTotalEur);
            ProductParts.Add(myProductPart);
        }

        public void AddProductLine(int productLineId, int amount)
        {
            ProductLine myProductLine = new ProductLine(productLineId, amount);
            ProductLines.Add(myProductLine);
        }

        public void AddOrder(int orderId, DateTime orderDate, DateTime deliveryDate, int customerId)
        {
            Order myOrder = new Order(orderId, orderDate, deliveryDate, customerId);
            Orders.Add(myOrder);
            PersistencyService.SaveOrdersAsJsonAsync(myOrder);
        }


        public void AddOrderLine(int orderLineId, int amount)
        {
            OrderLine myOrderLine = new OrderLine(orderLineId, amount);
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
            var orders = await PersistencyService.LoadProductFromJsonAsync();
            if (orders != null)
                foreach (var order in orders)
                {
                    Orders.Add(order);
                }
            else
            {
                Orders.Add(new Order(50, DateTime.Now, DateTime.Now, 2));
                Orders.Add(new Order(51, DateTime.Now, DateTime.Now, 2));
            }

        }

        public void DeleteOrder(Order orderToBeRemoved)
        {
            Orders.Remove(orderToBeRemoved);
            PersistencyService.DeleteOrdersAsAsync(orderToBeRemoved);
        }

        public void EditOrder(Order orders)
        {
            PersistencyService.EditOrdersAsJsonAsync(orders);
        }
    }
}
