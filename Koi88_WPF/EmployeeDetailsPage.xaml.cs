using Koi88_BusinessObject;
using Koi88_Service;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Koi88_WPF
{
    /// <summary>
    /// Interaction logic for EmployeeDetailsPage.xaml
    /// </summary>
    public partial class EmployeeDetailsPage : Page
    {
        private IAccountService _accountService;
        private Account _account;
        public EmployeeDetailsPage(int accountId)
        {
            InitializeComponent();
            _accountService = new AccountService();

            // Fetch the account details using the AccountId
            _account = _accountService.GetAccountByAccountId(accountId);

            // Bind the account details to the UI
            DataContext = _account;

            // Set the ComboBox status based on the account status
            if (_account.Status.HasValue)
            {
                // Convert the boolean to an integer for comparison
                ComboBoxStatus.SelectedItem = _account.Status.Value ?
                    ComboBoxStatus.Items[0] : ComboBoxStatus.Items[1]; // true -> Active, false -> Disabled
            }
            else
            {
                // Handle the case where Status is null, if necessary
                ComboBoxStatus.SelectedItem = ComboBoxStatus.Items[1]; // Default to "Disabled" or handle as needed
            }
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            var selectedStatus = ComboBoxStatus.SelectedItem as ComboBoxItem;

            if (selectedStatus != null)
            {
                // Update the account status based on the selected item
                bool isActive = selectedStatus.Tag.ToString() == "1"; // Tag is "1" for Active, "0" for Disabled
                _account.Status = isActive; // Update the account status

                // Optionally, call a method to update the account in the database
                _accountService.UpdateAccountStatus(_account); // Ensure this method exists in your service

                // Show success message
                MessageBox.Show("Update status successfully");

                // Reload the page or refresh the data
                NavigationService.Navigate(new EmployeeDetailsPage(_account.AccountId)); // Reload the current page
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeCardPage(_account.AccountId));
        }
    }
}
