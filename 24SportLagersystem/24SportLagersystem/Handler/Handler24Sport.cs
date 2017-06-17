using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using _24SportLagersystem.Converter;
using _24SportLagersystem.ViewModel;
using _24SportLagersystem.Model;

namespace _24SportLagersystem.Handler
{
    class Handler24Sport
    {
        public ViewModel24Sport ViewModel24Sport { get; set; }

        public Handler24Sport(ViewModel24Sport viewModel24Sport)
        {
            ViewModel24Sport = viewModel24Sport;
        }
/
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

    }
}
