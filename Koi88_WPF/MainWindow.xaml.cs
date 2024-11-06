using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Koi88_BusinessObject;
using Koi88_Repository;

namespace Koi88_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int _accountId;
        private IAccountRepository _accountRepository;
        public MainWindow(int accountId)
        {
            InitializeComponent();
            _accountRepository = new AccountRepository();
            this._accountId = accountId;
            Account account = _accountRepository.GetAccountByAccountId(_accountId);
            TextBlockWelcome.Text = "Welcome " + account.Lastname;
            int? role = account.RoleId;
            switch (role)
            {
                case 1:
                    MainFrame.Navigate(new CustomerPage(_accountId));
                    break;
                case 2:
                    MainFrame.Navigate(new ManagerPage(_accountId));
                    break;
                case 3:
                    MainFrame.Navigate(new SaleStaffPage(_accountId));
                    break;
                case 4:
                    MainFrame.Navigate(new ConsultingStaffPage(_accountId));
                    break;
                case 5:
                    MainFrame.Navigate(new DeliveryStaffPage(_accountId));
                    break;

            }
            
        }

        

        private void ButtonLogout_OnClick_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
    }
}