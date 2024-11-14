using Koi88_BusinessObject;
using Koi88_Service;
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
    /// Interaction logic for UserDetailsPage.xaml
    /// </summary>
    public partial class UserDetailsPage : Page
    {
        private IAccountService _accountService;
        private Account _account;
        public UserDetailsPage(int customerId)
        {
            InitializeComponent();
            _accountService = new AccountService();
            LoadUserDetails(customerId);
        }


        private void LoadUserDetails(int customerId)
        {
            _account = _accountService.GetAccountByCustomerId(customerId); // Implement this method in your service
            DataContext = _account; // Bind the account data to the UI
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            var selectedStatus = ComboBoxStatus.SelectedItem as ComboBoxItem;

            if (selectedStatus != null)
            {
                bool isActive = selectedStatus.Tag.ToString() == "1"; // Tag "1" for Active, "0" for Disabled
                _account.Status = isActive;

                // Call the updated method and check the result
                bool updateSuccessful = _accountService.UpdateAccountStatus(_account);

                if (updateSuccessful)
                {
                    MessageBox.Show("Status updated successfully");

                    // Use FirstOrDefault to get the first customer
                    var firstCustomer = _account.Customers.FirstOrDefault();
                    if (firstCustomer != null)
                    {
                        NavigationService.Navigate(new UserDetailsPage(firstCustomer.CustomerId)); // Use the first customer's ID
                    }
                    else
                    {
                        MessageBox.Show("No customers found for this account.");
                    }
                }
                else
                {
                    MessageBox.Show("Failed to update status. Please try again.");
                }
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserInformationPage(_account.AccountId));
        }
    }
}
