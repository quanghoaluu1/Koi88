using System.Windows;
using System.Windows.Controls;
using Koi88_BusinessObject;
using Koi88_Service; 

namespace Koi88_WPF
{
    public partial class VarietyManagePage : Window
    {
        private VarietyService _varietyService = new();

        public VarietyManagePage()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckValidate())
            {
                return;
            }

            Variety variety = new()
            {
                VarietyName = VarietyNameTextBox.Text,
                Description = DescriptionTextBox.Text,
                ImageUrl = ImageUrlTextBox.Text
            };
            if (_varietyService.GetById(int.Parse(VarietyIdTextBox.Text)) != null)
            {
                MessageBox.Show("Duplicate ID !", "Falled!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_varietyService.Create(variety))
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

            Variety variety = new()
            {
                VarietyId = int.Parse(VarietyIdTextBox.Text),
                VarietyName = VarietyNameTextBox.Text,
                Description = DescriptionTextBox.Text,
                ImageUrl = ImageUrlTextBox.Text
            };

            if (_varietyService.Update(variety))
            {
                MessageBox.Show("Update successfully!", "Successfully!", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Variety variety = new()
            {
                VarietyId = int.Parse(VarietyIdTextBox.Text)
            };

            MessageBoxResult result = MessageBox.Show("Do you really want to delete this?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                return;
            }

            if (_varietyService.Delete(variety.VarietyId))
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
            VarietyGrid.ItemsSource = _varietyService.GetAll();
            VarietyIdTextBox.Text = null;
            VarietyNameTextBox.Text = null;
            DescriptionTextBox.Text = null;
            ImageUrlTextBox.Text = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void VarietyGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Variety selected = VarietyGrid.SelectedItem as Variety;
            if (selected != null)
            {
                VarietyIdTextBox.Text = selected.VarietyId.ToString();
                VarietyNameTextBox.Text = selected.VarietyName;
                DescriptionTextBox.Text = selected.Description;
                ImageUrlTextBox.Text = selected.ImageUrl;
            }
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrWhiteSpace(VarietyNameTextBox.Text) || string.IsNullOrWhiteSpace(DescriptionTextBox.Text) || string.IsNullOrWhiteSpace(ImageUrlTextBox.Text))
            {
                MessageBox.Show("All fields are required!", "Required!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            string name = VarietyNameTextBox.Text.Trim();
            if (name.Length < 5 || name.Length > 90)
            {
                MessageBox.Show("Variety Name must be in the range of 5-90 characters!", "Length required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}