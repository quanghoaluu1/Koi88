using Koi88_BusinessObject;
using Koi88_Service;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.NativeInterop;
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
    /// Interaction logic for EmployeeCardPage.xaml
    /// </summary>
    public partial class EmployeeCardPage : Page
    {
        private IAccountService _accountService;
        private int _accountId;
        public EmployeeCardPage(int accountId)
        {
            InitializeComponent();
            _accountService = new AccountService();
            _accountId = accountId;
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            var roleIds = new List<int> { 3, 4, 5 };
            var employees = _accountService.GetAccountsByRoleIds(roleIds); // Ensure this method includes Role

            DataGridEmployees.ItemsSource = employees; // Bind to DataGrid
        }

        private void ButtonDetails_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null || button.Tag == null)
            {
                MessageBox.Show("Button or Tag is null.");
                return;
            }

            int accountId = (int)button.Tag; // Assuming the button's Tag is set to the AccountId
            NavigationService.Navigate(new EmployeeDetailsPage(accountId));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagerPage(_accountId));
        }
    }
}
