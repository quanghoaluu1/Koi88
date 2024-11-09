using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Koi88_BusinessObject;
using Koi88_Service;

namespace Koi88_WPF
{
    /// <summary>
    /// Interaction logic for NewBookingPage.xaml
    /// </summary>
    public partial class NewBookingPage : Page
    {
        private readonly int _accountId;
        private IBookingService _bookingService;
        private IAccountService _accountService;
        public NewBookingPage(int accountId)
        {
            InitializeComponent();
            _bookingService = new BookingService();
            _accountService = new AccountService();
            this._accountId = accountId;

        }


        private void ButtonSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            string fullName = TextBoxFullName.Text;
            string email = TextBoxEmail.Text;
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format");
                return;
            }
            string phone = TextBoxPhoneNumber.Text;
            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Invalid phone number format");
                return;
            }
            string? gender = ComboBoxGender.Text;

            string favouriteFarm = TextBoxFavouriteFarm.Text;
            string favouriteBreed = TextBoxFavouriteBreed.Text;
            DateOnly startDate = DateOnly.FromDateTime(DatePickerStartDate.SelectedDate.Value);
            DateOnly endDate = DateOnly.FromDateTime(DatePickerEndDate.SelectedDate.Value);
            if (!IsValidDate(startDate, endDate))
            {
                MessageBox.Show("Invalid start date or end date");
                return;
            }
            decimal estimateCost = Decimal.Parse(TextBoxEstimateCost.Text);
            if (!IsNum(TextBoxEstimateCost.Text))
            {
                MessageBox.Show("Please input number");
                return;
            }
            string hotelAccommodation = TextBoxHotelAccommodation.Text;
            string additionInformation = TextBoxAdditionalInformation.Text;

            Booking booking = new Booking();
            booking.Fullname = fullName;
            booking.Email = email;
            booking.Phone = phone;
            booking.Gender = gender;
            booking.Favoritefarm = favouriteFarm;
            booking.FavoriteKoi = favouriteBreed;
            booking.StartDate = startDate;
            booking.EndDate = endDate;
            booking.EstimatedCost = estimateCost;
            booking.HotelAccommodation = hotelAccommodation;
            booking.Note = additionInformation;

            Account account = _accountService.GetAccountByAccountId(_accountId);

            booking.CustomerId = account.Customers.FirstOrDefault(c => c.AccountId.Equals(_accountId)).CustomerId;
            booking.BookingDate = DateOnly.FromDateTime(DateTime.Now);
            booking.Status = "Requested";
            booking.IsActive = true;

            if (_bookingService.CreateBooking(booking))
            {
                MessageBox.Show("Booking created successfully");
                NavigationService.Navigate(new YourBookingPage(_accountId));
            }
            else
            {
                MessageBox.Show("Booking creation failed");
            }
        }

        private void ComboBoxAvailableFarm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxAvailableFarm.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedFarm = selectedItem.Content.ToString();
                switch (selectedFarm)
                {
                    case "Dainichi Koi Farm":
                        TextBoxFavouriteFarm.Text = "Dainichi Koi Farm";
                        TextBoxFavouriteBreed.Text = "Asagi, Shiro Utsuri";
                        break;
                    case "Otsuka Koi Farm":
                        TextBoxFavouriteFarm.Text = "Otsuka Koi Farm";
                        TextBoxFavouriteBreed.Text = "Kohaku, Sanke";
                        break;
                    case "Fukasawa Koi Farm":
                        TextBoxFavouriteFarm.Text = "Fukasawa Koi Farm";
                        TextBoxFavouriteBreed.Text = "Showa, Goshiki";
                        break;
                    case "Hosoka Koi Farm":
                        TextBoxFavouriteFarm.Text = "Hosoka Koi Farm";
                        TextBoxFavouriteBreed.Text = "Hikari Muji, Utsurimono";
                        break;
                    case "Kansuke Koi Farm":
                        TextBoxFavouriteFarm.Text = "Kansuke Koi Farm";
                        TextBoxFavouriteBreed.Text = "Kohaku, Tancho";
                        break;
                    case "Mano Koi Farm":
                        TextBoxFavouriteFarm.Text = "Mano Koi Farm";
                        TextBoxFavouriteBreed.Text = "Bekko, Asagi";
                        break;
                    case "Hoshikin Koi Farm":
                        TextBoxFavouriteFarm.Text = "Hoshikin Koi Farm";
                        TextBoxFavouriteBreed.Text = "Kohaku, Showa";
                        break;
                    case "Izumiya Koi Farm":
                        TextBoxFavouriteFarm.Text = "Izumiya Koi Farm";
                        TextBoxFavouriteBreed.Text = "Goshiki, Sanke";
                        break;
                }
            }
        }

        private void DatePickerEndDate_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (!DatePickerEndDate.SelectedDate.HasValue) return;
            DateOnly endDate = DateOnly.FromDateTime(DatePickerEndDate.SelectedDate.Value);
            if (DatePickerStartDate.SelectedDate == null) return;
            DateOnly startDate = DateOnly.FromDateTime(DatePickerStartDate.SelectedDate.Value);
            if (endDate < startDate)
            {
                TextBlockErrorEnd.Text = "End date must be after start date";
                TextBlockErrorEnd.Visibility = Visibility.Visible;
            }
            else
            {
                var dayDifference = endDate.DayOfYear - startDate.DayOfYear;
                switch (dayDifference)
                {
                    case < 2:
                        TextBlockErrorEnd.Text = "The trip must be at least 2 days long.";
                        TextBlockErrorEnd.Visibility = Visibility.Visible;
                        break;
                    case > 14:
                        TextBlockErrorEnd.Text = "The trip duration must be within 14 days.";
                        TextBlockErrorEnd.Visibility = Visibility.Visible;
                        break;
                    default:
                        TextBlockErrorEnd.Visibility = Visibility.Hidden;
                        break;
                }
            }
        }

        private bool IsValidDate(DateOnly startDate, DateOnly endDate)
        {
            if (endDate < startDate)
            {
                return false;
            }
            else
            {
                var dayDifference = endDate.DayOfYear - startDate.DayOfYear;
                switch (dayDifference)
                {
                    case < 2:
                        return false;
                    case > 14:
                        return false;
                    default:
                        return true;
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$");
        }


        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"((^(\+84|84|0|0084){1})(3|5|7|8|9))+([0-9]{8})$");
        }

        private bool IsNum(string number)
        {
            return Regex.IsMatch(number, @"^\d*\.?\d*$");
        }
        private void DatePickerStartDate_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (DatePickerStartDate.SelectedDate.HasValue)
            {
                DateOnly startDate = DateOnly.FromDateTime(DatePickerStartDate.SelectedDate.Value);
                if (startDate < DateOnly.FromDateTime(DateTime.Now).AddDays(3))
                {
                    TextBlockErrorStart.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockErrorStart.Visibility = Visibility.Hidden;
                }
            }
        }

        private void TextBoxEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxEmail.Text.Length > 0)
            {
                if (!IsValidEmail(TextBoxEmail.Text))
                {
                    TextBlockErrorEmail.Visibility = Visibility.Visible;
                    TextBlockErrorEmail.Text = "Invalid email format";
                }
                else
                {
                    TextBlockErrorEmail.Visibility = Visibility.Hidden;
                }
            }
        }

        private void TextBoxPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxPhoneNumber.Text.Length > 0)
            {
                if (!IsValidPhoneNumber(TextBoxPhoneNumber.Text))
                {
                    TextBlockErrorPhoneNumber.Visibility = Visibility.Visible;
                    TextBlockErrorPhoneNumber.Text = "Invalid phone number format";
                }
                else
                {
                    TextBlockErrorPhoneNumber.Visibility = Visibility.Hidden;
                }
            }
        }

        private void TextBoxEstimateCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(TextBoxEstimateCost.Text.Length > 0)
            {
                if (!IsNum(TextBoxEstimateCost.Text))
                {
                    TextBlockErrorEstimateCost.Visibility = Visibility.Visible;
                    TextBlockErrorEstimateCost.Text = "Please input number";
                }
                else
                {
                    TextBlockErrorEstimateCost.Visibility = Visibility.Hidden;
                }
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

        
    
