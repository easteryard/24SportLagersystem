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
    class CustomerHandler
    {

        public ViewModel24Sport ViewModel24Sport { get; set; }

        public CustomerHandler(ViewModel24Sport viewModel24Sport)
        {
            ViewModel24Sport = viewModel24Sport;
        }

        public void CreateCustomer()
        {
            Singleton24Sport.Instance.AddCustomers(ViewModel24Sport.CustomerId, ViewModel24Sport.Name, ViewModel24Sport.PhoneNo, ViewModel24Sport.Address, ViewModel24Sport.Email);
        }

        public void EditCustomer()
        {
            Singleton24Sport.Instance.EditCustomers(ViewModel24Sport.SelectedCustomer);

        }

        public void DeleteCustomer()
        {
            Singleton24Sport.Instance.DeleteCustomer(ViewModel24Sport.SelectedCustomer);
        }
                
        public void SetSelectedCustomer(Customer customers)
        {
            ViewModel24Sport.SelectedCustomer = customers;
        }

        public async void DeleteCustomers()
        {


            //ViewModel24Sport.Singleton24Sport.DeleteOrder(ViewModel24Sport.SelectedOrder);
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog("Er du sikker på du vil slette denne kunde: " + ViewModel24Sport.SelectedCustomer.CustomerId + " ?");

            //Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand("Ja", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand("Nej", null));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressedC:\Users\Andreas\GitHub\24SportLagersystem\24SportLagersystem\24SportLagersystem\Handler\Handler24Sport.cs
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog

            await messageDialog.ShowAsync();

        }

        private void CommandInvokedHandler(IUICommand command)
        {
            ViewModel24Sport.Singleton24Sport.DeleteCustomer(ViewModel24Sport.SelectedCustomer);
        }
    }
}
