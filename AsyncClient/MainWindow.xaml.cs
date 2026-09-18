using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessTier; 

namespace AsyncClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// //delcaring the delegate 
    public delegate String collectlastname(String name); 
    public partial class MainWindow : Window
    {
        //declaring the delegate object 
        getlastname collectlastname;
        private readonly BusinessServerInterface serverInterface; 
        IAsyncResult result;
        String stringresult; 
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                var asynctcp = new NetTcpBinding();
                var factory = new ChannelFactory<BusinessServerInterface>(asynctcp, new EndpointAddress("net.tcp://localhost:8200/BusinessServer"));
                serverInterface = factory.CreateChannel();

                outputtotalitems.Text = serverInterface.GetNumEntries().ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("errorshowing the message" + ex.Message); 
            }
        }

        private void GoButtonCLick_Click(object sender, RoutedEventArgs e) 
        {
            //in this part of the code we are goingt o try and create a thread reference to a delgate and see if it works with get lastname() 
            //declaring the delegate object 
            String name = "null";
            collectlastname = serverInterface.collectlastname;

            result = collectlastname.BeginInvoke(name, null, stringresult); 
            stringresult = collectlastname.EndInvoke(result);

            result.AsyncWaitHandle.Close(); 
            //intialising it with the database object 
        }

        private void SearchButtonCLick(object sender, RoutedEventArgs e) 
        {

        }

    }
}
