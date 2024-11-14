using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    /// Interaction logic for ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        private int _accountId;
        public ManagerPage(int accountId)
        {
            InitializeComponent();
            this._accountId = accountId;
        }

        private void OnOrderManagementClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderManagement());

        }

        private void ButtonEmployeeCard_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeCardPage(_accountId));
        }

        private void ButtonUserInformation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserInformationPage(_accountId));
        }

        private void ButtonKoiFarm_Click(object sender, RoutedEventArgs e)
        {
           KoiFarmManageWindow window = new KoiFarmManageWindow();
            window.Show();
        }

        private void ButtonVariety_Click(object sender, RoutedEventArgs e)
        {
           VarietyManagePage varietyManageWindow = new VarietyManagePage();
            varietyManageWindow.Show();
        }

        private void ButtonKoiFish_Click(object sender, RoutedEventArgs e)
        {
            KoiFishManagePage koiFishManagePage = new KoiFishManagePage();
            koiFishManagePage.Show();
        }
    }
}
