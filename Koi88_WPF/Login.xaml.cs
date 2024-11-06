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
using System.Windows.Shapes;
using Koi88_BusinessObject;
using Koi88_Repository;

namespace Koi88_WPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IAccountRepository _accountRepository;
        public Login()
        {
            InitializeComponent();
            _accountRepository = new AccountRepository();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = TextBoxUsername.Text;
            string password = PasswordBoxPassword.Password;
            Account account = _accountRepository.GetAccountByUsername(username);
            if (account != null && account.Password != null && account.Password.Equals(password))
            {
                int accountId = account.AccountId;
                MainWindow mainWindow = new MainWindow(accountId);
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
