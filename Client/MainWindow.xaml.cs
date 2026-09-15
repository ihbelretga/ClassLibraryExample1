using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
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
using Server1;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private readonly Server1.Services.DataServerInterface server;
        public MainWindow()
        {
            InitializeComponent();

            var tcp = new NetTcpBinding();
            var factory = new ChannelFactory<Server1.Services.DataServerInterface>(tcp, new EndpointAddress("net.tcp://localhost:8000/DataServer"));
            server = factory.CreateChannel();

            Total_Items_Label.Content = server.GetNumEntries().ToString();
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = int.Parse(Index_.Text);
                server.GetvaluesForEntry(index, out uint acctNo, out uint pin, out int balance, out string fName, out string lName);
                First_name.Text = fName;
                Last_Name.Text = lName;
                AcctNo.Text = acctNo.ToString();
                Balance.Text = balance.ToString();

            }
            catch (FaultException<IndexOutOfRangeFault> ex)
            {
                MessageBox.Show(ex.Detail.Issue, "Invalid index");
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }
    }
}
