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

        #region RelayCommands

        public ICommand CreateProductPartCommand { get; set; }
        public ICommand EditProductPartCommand { get; set; }
        public ICommand DeleteProductPartCommand { get; set; }



        #endregion


        #region CustomerProps

        private int _customerId;
        private string _name;
        private int _phoneNo;
        private string _address;
        private int _email;

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

        public int phoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public int Email
        {
            get { return _email; }
            set { _email = value; }
        }
        #endregion

        #region OrderProps
        private int _orderNo;
        private DateTime _deliveryDate;
        private DateTime _orderDate;

        public static Order Order { get; set; }

        public int OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        public DateTime DeliveryDate
        {
            get { return _deliveryDate; }
            set { _deliveryDate = value; }
        }

        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
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

        public int ProductPartId { get; set; }
        public string Description { get; set; }
        public int ProductPartAmount { get; set; }
        public double PricePerDkk { get; set; }
        public double PricePerEur { get; set; }
        public double PriceTotalDkk { get; set; }
        public double PriceTotalEur { get; set; }


        public static ProductPart ProductPart { get; set; }

        #endregion

        public ViewModel24Sport()
        {
            Handler24Sport = new Handler.Handler24Sport(this);
            Singleton24Sport = Singleton24Sport.Instance;
            CreateProductPartCommand = new RelayCommand(Handler24Sport.CreateProductPart);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
