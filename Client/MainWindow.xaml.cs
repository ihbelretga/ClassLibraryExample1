using BusinessTier; 
using Server1;
using Server1.Services;
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

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private readonly BusinessServerInterface server; 
        
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                var tcp = new NetTcpBinding();
                var factory = new ChannelFactory<BusinessServerInterface>(tcp, new EndpointAddress("net.tcp://localhost:8200/BusinessServer"));
                server = factory.CreateChannel();

                Total_Items_Label.Content = server.GetNumEntries().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when connecting: " + ex.Message);
            }
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

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            String entername= "input"; 
            inputhere.IsReadOnly = true;
            getlastnametextbox.IsReadOnly = true;
            First_name.IsReadOnly = true;
            Last_Name.IsReadOnly = true;
            AcctNo.IsReadOnly = true;
            Balance.IsReadOnly = true;
            Total_Items.IsReadOnly = true;
            Index_.IsReadOnly = true;
            SearchButtonClick.IsEnabled = false;
            GoButtonCLick.IsEnabled = false;
            ProgressBar.IsIndeterminate = true; 

            try
            {
                entername = inputhere.Text; 
                getlastnametextbox.Text = server.collectlastname(entername);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show( ex.Message ); 
            }

         // if (String.IsNullOrEmpty(getlastnametextbox.Text) != true)
          //{
          //    ProgressBar.Value = ProgressBar.Maximum; 
         // }
        }

        private void Progress_Bar(object sender, RoutedEventArgs e)
        {
            if (SearchButtonClick.IsEnabled == false)
            {
                ProgressBar.IsIndeterminate = true; 
            }
        }
    }
}
