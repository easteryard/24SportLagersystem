using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using _24SportLagersystem.Converter;
using _24SportLagersystem.Model;
using _24SportLagersystem.ViewModel;

namespace _24SportLagersystem.Handler
{
    class HandlerOrder
    {
        public ViewModel24Sport ViewModel24Sport { get; set; }

        public HandlerOrder(ViewModel24Sport viewModel24Sport)
        {
            ViewModel24Sport = viewModel24Sport;
        }

        public void CreateOrder()
        {
            ViewModel24Sport.Singleton24Sport.AddOrder(ViewModel24Sport.OrderId, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(ViewModel24Sport.OrderDate, ViewModel24Sport.TimeSpanOrdreDate), DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(ViewModel24Sport.DeliveryDate, ViewModel24Sport.TimeSpanDeliveryDate), ViewModel24Sport.CustomerId);
        }


        public void SetSelectedOrder(Order order)
        {
            ViewModel24Sport.SelectedOrder = order;
        }

        public async void DeleteOrder()
        {


            //ViewModel24Sport.Singleton24Sport.DeleteOrder(ViewModel24Sport.SelectedOrder);
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog("Are you sure you want to Delete the Event: " + ViewModel24Sport.SelectedOrder.OrderId + " ?");

            //Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand("No", null));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressedC:\Users\Andreas\GitHub\24SportLagersystem\24SportLagersystem\24SportLagersystem\Handler\Handler24Sport.cs
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog

            await messageDialog.ShowAsync();

        }

        private void CommandInvokedHandler(IUICommand command)
        {
            ViewModel24Sport.Singleton24Sport.DeleteOrder(ViewModel24Sport.SelectedOrder);
        }

        public void EditOrder()
        {
            ViewModel24Sport.Singleton24Sport.EditOrder(ViewModel24Sport.SelectedOrder);
        }






        public void CreateCustomer()
        {
            ViewModel24Sport.Singleton24Sport.AddCustomer(ViewModel24Sport.CustomerId, ViewModel24Sport.Name, ViewModel24Sport.PhoneNo, ViewModel24Sport.Address, ViewModel24Sport.Email);
        }


        public void SetSelectedCustomer(Customer customers)
        {
            ViewModel24Sport.SelectedCustomer = customers;
        }

        public async void DeleteCustomer()
        {


            //ViewModel24Sport.Singleton24Sport.DeleteOrder(ViewModel24Sport.SelectedOrder);
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog("Er du sikker på du vil slette denne kunde: " + ViewModel24Sport.SelectedCustomer.CustomerId + " ?");

            //Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand("Ja", new UICommandInvokedHandler(this.CommandInvokedHandlerCustomer)));
            messageDialog.Commands.Add(new UICommand("Nej", null));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressedC:\Users\Andreas\GitHub\24SportLagersystem\24SportLagersystem\24SportLagersystem\Handler\Handler24Sport.cs
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog

            await messageDialog.ShowAsync();

        }

        private void CommandInvokedHandlerCustomer(IUICommand command)
        {
            ViewModel24Sport.Singleton24Sport.DeleteCustomer(ViewModel24Sport.SelectedCustomer);
        }

        public void EditCustomer()
        {
            ViewModel24Sport.Singleton24Sport.EditCustomer(ViewModel24Sport.SelectedCustomer);
        }
    }
}
