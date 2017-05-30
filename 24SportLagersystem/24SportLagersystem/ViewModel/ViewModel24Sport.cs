using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using _24SportLagersystem.Annotations;
using _24SportLagersystem.Common;
using _24SportLagersystem.Model;
using _24SportLagersystem.Handler;
using _24SportLagersystem.View;

namespace _24SportLagersystem.ViewModel
{
    class ViewModel24Sport : INotifyPropertyChanged
    {
        public Singleton24Sport Singleton24Sport { get; set; }

        public Handler.Handler24Sport Handler24Sport { get; set; }

        public CustomerHandler CustomerHandler { get; set; }
        public OrderHandler OrderHandler { get; set; }
        public OrderLineHandler OrderLineHandler { get; set; }
        public ProductHandler ProductHandler { get; set; }
        public ProductLineHandler ProductLineHandler { get; set; }
        public ProductPartHandler ProductPartHandler { get; set; }
        

        private ICommand _createCustomerCommand;
        private ICommand _editCustomerCommand;
        private ICommand _deleteCustomerCommand;

        private ICommand _createOrderCommand;
        private ICommand _editOrderCommand;
        private ICommand _deleteOrderCommand;
        private ICommand _createOrderLineCommand;
        private ICommand _editOrderLineCommand;
        private ICommand _deleteOrderLineCommand;
        private ICommand _createProductCommand;
        private ICommand _editProductCommand;
        private ICommand _deleteProductCommand;
        private ICommand _createProductLineCommand;
        private ICommand _editProductLineCommand;
        private ICommand _deleteProductLineCommand;
        private ICommand _createProductPartCommand;
        private ICommand _deleteProductPartCommand;
        private ICommand _editProductPartCommand;
        
        #region CustomerCommands
        public ICommand CreateCustomerCommand
        {
            get { return _createCustomerCommand ?? (_createCustomerCommand = new RelayCommand(CustomerHandler.CreateCustomer)); }
            set { _createCustomerCommand = value; }
        }

        public ICommand EditCustomerCommand
        {
            get { return _editCustomerCommand ?? (_editCustomerCommand = new RelayCommand(CustomerHandler.EditCustomer)); }
            set { _editCustomerCommand = value; }
        }

        public ICommand DeleteCustomerCommand
        {
            get { return _deleteCustomerCommand ?? (_deleteCustomerCommand = new RelayCommand(CustomerHandler.DeleteCustomer)); }
            set { _deleteCustomerCommand = value; }
        }

        #endregion

        #region OrderRelayCommands

        public ICommand CreateOrderCommand
        {
            get { return _createOrderCommand ?? (_createOrderCommand = new RelayCommand(OrderHandler.CreateOrder)); }
            set { _createOrderCommand = value; }
        }

        public ICommand EditOrderCommand
        {
            get { return _editOrderCommand ?? (_editOrderCommand = new RelayCommand(OrderHandler.EditOrder)); }
            set { _editOrderCommand = value; }
        }

        public ICommand DeleteOrderCommand
        {
            get { return _deleteOrderCommand ?? (_deleteOrderCommand = new RelayCommand(OrderHandler.DeleteOrder)); }
            set { _deleteOrderCommand = value; }
        }

        #endregion

        #region OrderLineCommands

        public ICommand CreateOrderLineCommand
        {
            get
            {
                return _createOrderLineCommand ??
                       (_createOrderLineCommand = new RelayCommand(OrderLineHandler.CreateOrderLine));
            }
            set { _createOrderLineCommand = value; }
        }

        public ICommand EditOrderLineCommand
        {
            get
            {
                return _editOrderLineCommand ??
                       (_editOrderLineCommand = new RelayCommand(OrderLineHandler.EditOrderLine));
            }
            set { _editOrderLineCommand = value; }
        }

        public ICommand DeleteOrderLineCommand
        {
            get
            {
                return _deleteOrderLineCommand ??
                       (_deleteOrderLineCommand = new RelayCommand(OrderLineHandler.DeleteOrderLine));
            }
            set { _deleteOrderLineCommand = value; }
        }

        #endregion

        #region ProductRelayCommands

        public ICommand CreateProductCommand
        {
            get
            {
                return _createProductCommand ?? (_createProductCommand = new RelayCommand(ProductHandler.CreateProduct));
            }
            set { _createProductCommand = value; }
        }

        public ICommand EditProductCommand
        {
            get
            {
                return _editProductCommand ?? (_editProductCommand = new RelayCommand(ProductHandler.EditProduct));
            }
            set { _editProductCommand = value; }
        }

        public ICommand DeleteProductCommand
        {
            get
            {
                return _deleteProductCommand ??
                    (_deleteProductCommand = new RelayCommand(ProductHandler.DeleteProduct));
            }
            set { _deleteProductCommand = value; }
        }

        #endregion

        #region ProductLineCommands

        public ICommand CreateProductLineCommand
        {
            get
            {
                return
                    _createProductLineCommand ??
                    (_createProductLineCommand = new RelayCommand(ProductLineHandler.CreateProductLine));
            }
            set { _createProductLineCommand = value; }
        }

        public ICommand EditProductLineCommand
        {
            get
            {
                return _editProductLineCommand ??
                       (_editProductLineCommand = new RelayCommand(ProductLineHandler.EditProductLine));
            }
            set { _editProductLineCommand = value; }
        }

        public ICommand DeleteProductLineCommand
        {
            get
            {
                return _deleteProductLineCommand ??
                       (_deleteProductLineCommand = new RelayCommand(ProductLineHandler.DeleteProductLine));
            }
            set { _deleteProductLineCommand = value; }
        }

        #endregion

        #region ProdutPartRelayCommands

        public ICommand CreateProductPartCommand
        {
            get
            {
                // Return _createProductPartCommand - if it's null; create a new relaycommand
                return _createProductPartCommand ??
                       (_createProductPartCommand = new RelayCommand(ProductPartHandler.CreateProductPart));
            }
            set { _createProductPartCommand = value; }
        }

        public ICommand EditProductPartCommand
        {
            get
            {
                return
                    _editProductPartCommand ?? (_editProductPartCommand =
                        new RelayCommand(ProductPartHandler.EditProductPart));
            }
            set { _editProductPartCommand = value; }
        }

        public ICommand DeleteProductPartCommand
        {
            get
            {
                return _deleteProductPartCommand ??
                       (_deleteProductPartCommand = new RelayCommand(ProductPartHandler.DeleteProductPart));
            }
            set { _deleteProductPartCommand = value; }
        }

        #endregion

        #region CustomerProperties

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int PhoneNo { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public static Customer SelectedCustomer { get; set; }

        public static Customer Customer { get; set; }
        
        #endregion

        #region OrderProperties

        public int OrderId { get; set; }
        public DateTimeOffset OrderDateDate { get; set; }
        public TimeSpan OrderDateTime { get; set; }
        public DateTimeOffset DeliveryDateDate { get; set; }
        public TimeSpan DeliveryDateTime { get; set; }

        public static Order SelectedOrder { get; set; }

        public static Order Order { get; set; }

        //public DateTimeOffset OrderDate { get; set; }
        //public DateTimeOffset DeliveryDate { get; set; }

        //private int _orderId;
        //private DateTimeOffset _deliveryDate;
        //private DateTimeOffset _orderDate;
        //private TimeSpan _timeSpan;

        //public int OrderId
        //{
        //    get { return _orderId; }
        //    set { _orderId = value; }
        //}

        //public DateTimeOffset DeliveryDate
        //{
        //    get { return _deliveryDate; }
        //    set { _deliveryDate = value; }
        //}

        //public DateTimeOffset OrderDate
        //{
        //    get { return _orderDate; }
        //    set { _orderDate = value; }
        //}

        //public TimeSpan TimeSpan
        //{
        //    get { return _timeSpan; }
        //    set { _timeSpan = value; }
        //}

        #endregion

        #region OrderLineProperties

        public int OrderLineId { get; set; }
        public int Amount { get; set; }

        public static OrderLine SelectedOrderLine { get; set; }

        public static OrderLine OrderLine { get; set; }

        #endregion

        #region ProductProperties

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Height { get; set; }
        public int AmountMade { get; set; }
        public int AmountMakeable { get; set; }

        public static Product SelectedProduct { get; set; }

        public static Product Product { get; set; }

        #endregion

        #region ProductLineProperties

        public int ProductLineId { get; set; }
        public int ProductLineAmount { get; set; }

        public static ProductLine SelectedProductLine { get; set; }

        public static ProductLine ProductLine { get; set; }

        #endregion

        #region ProductPartProperties

        public int ProductPartId { get; set; }
        public int ProductPartNo { get; set; }
        public string Description { get; set; }
        public int ProductPartAmount { get; set; }
        public double PricePerDkk { get; set; }
        public double PricePerEur { get; set; }
        public double PriceTotalDkk { get; set; }
        public double PriceTotalEur { get; set; }

        public static ProductPart SelectedProductPart { get; set; }

        public static ProductPart ProductPart { get; set; }

        #endregion

        public ViewModel24Sport()
        {
            Handler24Sport = new Handler.Handler24Sport(this);
            CustomerHandler = new CustomerHandler(this);
            OrderHandler = new OrderHandler(this);
            OrderLineHandler = new OrderLineHandler(this);
            ProductHandler = new ProductHandler(this);
            ProductLineHandler = new ProductLineHandler(this);
            ProductPartHandler = new ProductPartHandler(this);

            Singleton24Sport = Singleton24Sport.Instance;

            DateTime dt = System.DateTime.Now;

            OrderDateDate = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, new TimeSpan());
            OrderDateTime = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
            DeliveryDateDate = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, new TimeSpan());
            DeliveryDateTime = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
