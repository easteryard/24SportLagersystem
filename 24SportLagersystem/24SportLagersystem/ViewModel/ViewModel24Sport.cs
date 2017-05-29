using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using _24SportLagersystem.Annotations;
using _24SportLagersystem.Common;
using _24SportLagersystem.Model;
using _24SportLagersystem.Handler;

namespace _24SportLagersystem.ViewModel
{
    class ViewModel24Sport : INotifyPropertyChanged
    {
        public Singleton24Sport Singleton24Sport { get; set; }

        public Handler.Handler24Sport Handler24Sport { get; set; }

        public OrderHandler OrderHandler { get; set; }
        public ProductHandler ProductHandler { get; set; }
        public ProductPartHandler ProductPartHandler { get; set; }
        public CustomerHandler CustomerHandler { get; set; }

        public static Product SelectedProduct { get; set; }
        public static ProductPart SelectedProductPart { get; set; }

        public static Customer SelectedCustomer { get; set; }

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

        #region ProductRelayCommands

        public ICommand CreateProductCommand
        {
            get
            {
                return _createProductCommand ??
                    (_createProductCommand = new RelayCommand(ProductHandler.CreateProduct));
            }
            set { _createProductCommand = value; }
        }

        public ICommand EditProductCommand
        {
            get
            {
                return _editProductCommand ??
                    (_editProductCommand = new RelayCommand(ProductHandler.EditProduct));
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

        #region RelayCommands

        private ICommand _createCommand;
        private ICommand _selectCommand;
        private ICommand _deleteCommand;

        public ICommand CreateCommand
        {
            get { return _createCommand; }
            set { _createCommand = value; }
        }

        public ICommand SelectCommand
        {
            get { return _selectCommand; }
            set { _selectCommand = value; }
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand; }
            set { _deleteCommand = value; }
        }
        #endregion

        #region CustomerProperties

        private int _customerId;
        private string _name;
        private int _phoneNo;
        private string _address;
        private string _email;

        public static Customer Customer { get; set; }
        private ICommand _deleteCustomerCommand;
        private ICommand _editCustomerCommand;
        private ICommand _createCustomerCommand;
        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int PhoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
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
        private int _orderLineId;
        private int _amount;

        public static OrderLine OrderLine { get; set; }


        public int OrderLineId
        {
            get { return _orderLineId; }
            set { _orderLineId = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        #endregion

        #region ProductProperties

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Height { get; set; }
        public int AmountMade { get; set; }
        public int AmountMakeable { get; set; }

        public static Product Product { get; set; }

        #endregion

        #region ProductLineProperties
        private int _productLineId;
        private int _productLineAmount;

        public static ProductLine ProductLine { get; set; }

        public int ProductLineId
        {
            get { return _productLineId; }
            set { _productLineId = value; }
        }

        public int ProductLineAmount
        {
            get { return _productLineAmount; }
            set { _productLineAmount = value; }
        }



        #endregion

        #region ProductPartProperties
        private int _productPartId;
        private int _productPartNo;
        private string _description;
        private int _productPartAmount;
        private double _pricePerDkk;
        private double _pricePerEur;
        private double _priceTotalDkk;
        private double _priceTotalEur;
        private ICommand _createProductPartCommand;
        private ICommand _deleteProductPartCommand;
        private ICommand _editProductPartCommand;
        private ICommand _createProductCommand;
        private ICommand _editProductCommand;
        private ICommand _deleteProductCommand;
        private ICommand _createOrderCommand;
        private ICommand _editOrderCommand;
        private ICommand _deleteOrderCommand;

        public static ProductPart ProductPart { get; set; }

        public int ProductPartId
        {
            get { return _productPartId; }
            set { _productPartId = value; }
        }

        public int ProductPartNo
        {
            get { return _productPartNo; }
            set { _productPartNo = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int ProductPartAmount
        {
            get { return _productPartAmount; }
            set { _productPartAmount = value; }
        }

        public double PricePerDkk
        {
            get { return _pricePerDkk; }
            set { _pricePerDkk = value; }
        }

        public double PricePerEur
        {
            get { return _pricePerEur; }
            set { _pricePerEur = value; }
        }

        public double PriceTotalDkk
        {
            get { return _priceTotalDkk; }
            set { _priceTotalDkk = value; }
        }

        public double PriceTotalEur
        {
            get { return _priceTotalEur; }
            set { _priceTotalEur = value; }
        }
        #endregion

        public ViewModel24Sport()
        {
            Handler24Sport = new Handler.Handler24Sport(this);
            OrderHandler = new OrderHandler(this);
            ProductHandler = new ProductHandler(this);
            ProductPartHandler = new ProductPartHandler(this);
            CustomerHandler = new CustomerHandler(this);

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
