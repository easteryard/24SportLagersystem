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
        public ProductLineHandler ProductLineHandler { get; set; }
        public ProductPartHandler ProductPartHandler { get; set; }

        private ICommand _createProductPartCommand;
        private ICommand _deleteProductPartCommand;
        private ICommand _editProductPartCommand;
        private ICommand _createProductCommand;
        private ICommand _editProductCommand;
        private ICommand _deleteProductCommand;
        private ICommand _createOrderCommand;
        private ICommand _editOrderCommand;
        private ICommand _deleteOrderCommand;


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
        private ICommand _createProductLineCommand;
        private ICommand _editProductLineCommand;
        private ICommand _deleteProductLineCommand;

        public static Customer Customer { get; set; }


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

        public int OrderLineId { get; set; }
        public int Amount { get; set; }
        
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
            OrderHandler = new OrderHandler(this);
            ProductHandler = new ProductHandler(this);
            ProductLineHandler = new ProductLineHandler(this);
            ProductPartHandler = new ProductPartHandler(this);

            Singleton24Sport = Singleton24Sport.Instance;

            DateTime dt = System.DateTime.Now;

            OrderDateDate = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, new TimeSpan());
            OrderDateTime = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
            DeliveryDateDate = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, new TimeSpan());
            DeliveryDateTime = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            //OrderDate = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            //DeliveryDate = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            //_timeSpan = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
