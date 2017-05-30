using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Xaml.Interactions.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _24SportLagersystem.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }


       
        private async  void button_Click(object sender, RoutedEventArgs e)
        {
        
            if (Brugerlogin1.Text=="Admin" || passwordBox.Password=="123")
            {
                await new MessageDialog("Du er nu logget ind.").ShowAsync();
                this.Frame.Navigate(typeof(Search), null);
            }

            else
            {
               await new MessageDialog("Koden eller brugernavn er forkert, prøv igen.").ShowAsync();
         
            }
            
        }
    }
}
