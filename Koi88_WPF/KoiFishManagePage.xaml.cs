using System.Windows;
using System.Windows.Controls;
using Koi88_BusinessObject;
using Koi88_Service;

namespace Koi88_WPF
{
    public partial class KoiFishManagePage : Window
    {
        private KoiFishService _koiFishService = new();

        public KoiFishManagePage()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckValidate())
            {
                return;
            }

            KoiFish fish = new()
            {
                VarietyId = int.Parse(VarietyIdTextBox.Text),
                KoiName = KoiNameTextBox.Text,
                Description = DescriptionTextBox.Text,
                ImageUrl = ImageUrlTextBox.Text
            };
            if (!string.IsNullOrEmpty(KoiIdTextBox.Text))
            {
                if (_koiFishService.GetById(int.Parse(KoiIdTextBox.Text)) != null)
                {
                    MessageBox.Show("Duplicate ID !", "Falled!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }
            }


            if (_koiFishService.Create(fish))
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

            KoiFish fish = new()
            {
                KoiId = int.Parse(KoiIdTextBox.Text),
                VarietyId = int.Parse(VarietyIdTextBox.Text),
                KoiName = KoiNameTextBox.Text,
                Description = DescriptionTextBox.Text,
                ImageUrl = ImageUrlTextBox.Text
            };

            if (_koiFishService.Update(fish))
            {
                MessageBox.Show("Update successfully!", "Successfully!", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            KoiFish fish = new()
            {
                KoiId = int.Parse(KoiIdTextBox.Text)
            };

            MessageBoxResult result = MessageBox.Show("Do you really want to delete this?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                return;
            }

            if (_koiFishService.Delete(fish.KoiId))
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
            KoiFishGrid.ItemsSource = _koiFishService.GetAll();
            KoiIdTextBox.Text = null;
            VarietyIdTextBox.Text = null;
            KoiNameTextBox.Text = null;
            DescriptionTextBox.Text = null;
            ImageUrlTextBox.Text = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void KoiFishGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KoiFish selected = KoiFishGrid.SelectedItem as KoiFish;
            if (selected != null)
            {
                KoiIdTextBox.Text = selected.KoiId.ToString();
                VarietyIdTextBox.Text = selected.VarietyId.ToString();
                KoiNameTextBox.Text = selected.KoiName;
                DescriptionTextBox.Text = selected.Description;
                ImageUrlTextBox.Text = selected.ImageUrl;
            }
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrWhiteSpace(KoiNameTextBox.Text) || string.IsNullOrWhiteSpace(VarietyIdTextBox.Text) || string.IsNullOrWhiteSpace(DescriptionTextBox.Text) || string.IsNullOrWhiteSpace(ImageUrlTextBox.Text))
            {
                MessageBox.Show("All fields are required!", "Required!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            string name = KoiNameTextBox.Text.Trim();
            if (name.Length < 5 || name.Length > 90)
            {
                MessageBox.Show("Koi Name must be in the range of 5-90 characters!", "Length required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}