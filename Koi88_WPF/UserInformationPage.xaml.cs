using Koi88_DAO;
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
    /// Interaction logic for UserInformationPage.xaml
    /// </summary>
    public partial class UserInformationPage : Page
    {
        private IAccountService _accountService;
        private int _accountId;
        public UserInformationPage(int accountId)
        {
            InitializeComponent();
            _accountService = new AccountService();
            _accountId = accountId;
            LoadUserInformation();
        }

        private void LoadUserInformation()
        {
            int roleId = 1;
            var users = _accountService.GetAccountsByRoleId(roleId);

            // Debugging: Check the status of each user
            foreach (var user in users)
            {
                // Assuming each Account has at least one Customer
                int? customerId = user.Customers.FirstOrDefault()?.CustomerId; // Get the first CustomerId
                Console.WriteLine($"User: {user.Lastname}, CustomerId: {customerId}, Status: {user.Status}");
            }

            DataGridUsers.ItemsSource = users; // Bind the list of users to the DataGrid
        }

        private void ButtonDetails_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.Tag != null)
            {
                int customerId = (int)button.Tag;
                Console.WriteLine($"Navigating to UserDetailsPage with CustomerId: {customerId}");
                NavigationService.Navigate(new UserDetailsPage(customerId));
            }
            else
            {
                Console.WriteLine("Button or Tag is null.");
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagerPage(_accountId));
        }
    }
}
