using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using BusinessTier;
namespace AsyncClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BusinessServerInterface serverInterface;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                // Create NetTcp binding
                NetTcpBinding binding = new NetTcpBinding();
                // Create channel factory
                ChannelFactory<BusinessServerInterface> factory =
                    new ChannelFactory<BusinessServerInterface>(
                        binding,
                        new EndpointAddress(
                            "net.tcp://localhost:8200/BusinessServer"
                        )
                    );
                // Create connection to the Business Server
                serverInterface = factory.CreateChannel();
                // Load the number of entries when the client starts
                LoadTotalItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error connecting to the server:\n" + ex.Message,
                    "Connection Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }
        /// <summary>
        /// Loads the total number of database entries.
        /// </summary>
        private async void LoadTotalItems()
        {
            try
            {
                int totalItems = await Task.Run(() =>
                    serverInterface.GetNumEntries()
                );
                outputtotalitems.Text = totalItems.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error getting total number of entries:\n" + ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }
        /// <summary>
        /// Called when the Go button is clicked.
        /// </summary>
        private async void GoButtonCLick_Click(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                // Example input
                string name = "null";
                // Disable button while operation is running
                GoButtonCLick.IsEnabled = false;
                // Call server method asynchronously
                string result = await Task.Run(() =>
                    serverInterface.collectlastname(name)
                );
                // Display the returned value
                MessageBox.Show(
                    result,
                    "Result",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
                // Example:
                // outputlastname.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error calling collectlastname:\n" + ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
            finally
            {
                GoButtonCLick.IsEnabled = true;
            }
        }
        /// <summary>
        /// Called when the Search button is clicked.
        /// </summary>
        private async void SearchButtonCLick(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Search error:\n" + ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }
    }
}
