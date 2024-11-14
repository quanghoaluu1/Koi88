
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using Koi88_BusinessObject;
using Koi88_Service;

namespace Koi88_WPF
{
    public partial class KoiFarmManageWindow : Window
    {
        private KoiFarmService _koiFarmService = new();

        public KoiFarmManageWindow()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckValidate())
            {
                return;
            }

            KoiFarm farm = new()
            {
                FarmName = FarmNameTextBox.Text,
                Location = LocationTextBox.Text,
                ContactInfo = ContactInfoTextBox.Text,
                ImageUrl = ImageUrlTextBox.Text
            };
            if (!string.IsNullOrEmpty(FarmIdTextBox.Text))
            {
                if (!string.IsNullOrEmpty(FarmIdTextBox.Text))
                {
                    if (_koiFarmService.GetById(int.Parse(FarmIdTextBox.Text)) != null)
                    {
                        MessageBox.Show("Duplicate ID !", "Falled!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;

                    }
                }
            }

            if (_koiFarmService.Create(farm))
            {
                MessageBox.Show("Create successfully!", "Successfully!", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckValidate())
            {
                return;
            }

            KoiFarm farm = new()
            {
                FarmId = int.Parse(FarmIdTextBox.Text),
                FarmName = FarmNameTextBox.Text,
                Location = LocationTextBox.Text,
                ContactInfo = ContactInfoTextBox.Text,
                ImageUrl = ImageUrlTextBox.Text
            };

            if (_koiFarmService.Update(farm))
            {
                MessageBox.Show("Update successfully!", "Successfully!", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            KoiFarm farm = new()
            {
                FarmId = int.Parse(FarmIdTextBox.Text),
                FarmName = FarmNameTextBox.Text,
                Location = LocationTextBox.Text,
                ContactInfo = ContactInfoTextBox.Text,
                ImageUrl = ImageUrlTextBox.Text
            };

            MessageBoxResult result = MessageBox.Show("Do you really want to delete this?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                return;
            }

            
            if (_koiFarmService.Delete(farm.FarmId))
            {
                MessageBox.Show("Delete successfully!", "Successfully!", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }

        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            KoiFarmGrid.ItemsSource = _koiFarmService.GetAll();
            FarmIdTextBox.Text = null;
            FarmNameTextBox.Text = null;
            LocationTextBox.Text = null;
            ContactInfoTextBox.Text = null;
            ImageUrlTextBox.Text = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void KoiFarmGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KoiFarm selected = KoiFarmGrid.SelectedItem as KoiFarm;
            if (selected != null)
            {
                FarmIdTextBox.Text = selected.FarmId.ToString();
                FarmNameTextBox.Text = selected.FarmName;
                LocationTextBox.Text = selected.Location;
                ContactInfoTextBox.Text = selected.ContactInfo;
                ImageUrlTextBox.Text = selected.ImageUrl;
            }
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrWhiteSpace(FarmNameTextBox.Text) || string.IsNullOrWhiteSpace(LocationTextBox.Text) || string.IsNullOrWhiteSpace(ContactInfoTextBox.Text) || string.IsNullOrWhiteSpace(ImageUrlTextBox.Text))
            {
                MessageBox.Show("All fields are required!", "Required!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            string name = FarmNameTextBox.Text.Trim();
            if (name.Length < 5 || name.Length > 90)
            {
                MessageBox.Show("Farm Name must be in the range of 5-90 characters!", "Length required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}