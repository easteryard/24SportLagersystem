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

        public static Order SelectedOrder { get; set; }
        public ICommand EditOrderCommand { get; set; }
        public ICommand ToOrderEditPagecCommand { get; set; }

        #region RelayCommands
        private ICommand _createCommand;
        private ICommand _selectCommand;
        private ICommand _deleteCommand;


        public ICommand CreateCommand
        {
            get
            {
                if (_createCommand == null) _createCommand = new RelayCommand(Handler24Sport.CreateOrder);
                return _createCommand; }

            set { _createCommand = value; }
        }

        public ICommand SelectCommand
        {
            get { return _selectCommand ?? (_selectCommand = new RelayArgCommand<Order>(order => Handler24Sport.SetSelectedOrder(order))); }
            set { _selectCommand = value; }
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new RelayCommand(Handler24Sport.DeleteOrder)); }
            set { _deleteCommand = value; }
        }


        #endregion


        #region CustomerProps

        private int _customerId;
        private string _name;
        private int _phoneNo;
        private string _address;
        private string _email;

        public static Customer Customer { get; set; }


        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; OnPropertyChanged(); }
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

        #region OrderProps
        private int _orderId;
        private DateTimeOffset _deliveryDate;
        private DateTimeOffset _orderDate;
        private TimeSpan _timeSpanDeliveryDate;
        private TimeSpan _timeSpanOrderDate;

        public static Order Order { get; set; }

        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; OnPropertyChanged(); }
        }

        public DateTimeOffset DeliveryDate
        {
            get { return _deliveryDate; }
            set { _deliveryDate = value; }
        }

        public DateTimeOffset OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }

        public TimeSpan TimeSpanDeliveryDate
        {
            get { return _timeSpanDeliveryDate; }
            set { _timeSpanDeliveryDate = value; }
        }

        public TimeSpan TimeSpanOrdreDate
        {
            get { return _timeSpanOrderDate; }
            set { _timeSpanOrderDate = value; }
        }

        #endregion

        #region OrderLineProps
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

        #region ProductProps
        private int _productId;
        private string _productName;
        private double _price;
        private double _height;
        private int _amountMade;
        private int _amountMakeable;

        public static Product Product { get; set; }

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int AmountMade
        {
            get { return _amountMade; }
            set { _amountMade = value; }
        }

        public int AmountMakeable
        {
            get { return _amountMakeable; }
            set { _amountMakeable = value; }
        }

        #endregion

        #region ProductLineProps
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

        #region ProductPartProps
        private int _productPartId;
        private int _productPartNo;
        private string _description;
        private int _productPartAmount;
        private double _pricePerDkk;
        private double _pricePerEur;
        private double _priceTotalDkk;
        private double _priceTotalEur;

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
            Singleton24Sport = Singleton24Sport.Instance;
            DateTime dt = System.DateTime.Now;

            _orderDate = new DateTimeOffset(2018, 6, dt.Day, 0, 0, 0, 0, new TimeSpan());
            _deliveryDate = new DateTimeOffset(2018, 6, dt.Day, 0, 0, 0, 0, new TimeSpan());
            //_timeSpanDeliveryDate = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
            //_timeSpanOrderDate = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            EditOrderCommand = new RelayCommand(Handler24Sport.EditOrder);
            ToOrderEditPagecCommand = new RelayCommand(NavigateToEditEventPage);
        }

        public void NavigateToEditEventPage()
        {
            Frame f = GetFrame();
            f.Navigate(typeof(OrderEdit));
        }

        public Frame GetFrame()
        {
            return Window.Current.Content as Frame;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
