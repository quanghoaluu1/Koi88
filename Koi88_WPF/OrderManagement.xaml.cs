using Koi88_BusinessObject;
using Koi88_Service;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Koi88_WPF
{
    public partial class OrderManagement : Page
    {
        private IOrderManagementService _orderManagementService;
        private IAccountService _accountService;
        private Koi88Context _context;
        public OrderManagement()
        {
            InitializeComponent();
            _orderManagementService = new OrderManagementService();
            _accountService = new AccountService();
            _context = new Koi88Context();
            LoadBookings();
            LoadConsultants();

        }

        private void LoadBookings()
        {
            List<Booking> bookings = _orderManagementService.GetBookingWithConsultants(); // Call the updated method

            // Sort bookings by BookingDate in descending order
            bookings = bookings.OrderByDescending(b => b.BookingDate).ToList();

            DataGridOrderManagement.ItemsSource = bookings;

            // Disable buttons based on status
            foreach (var item in bookings)
            {
                var row = DataGridOrderManagement.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)
                {
                    var acceptButton = FindAcceptButton(row);
                    var rejectButton = FindRejectButton(row);

                    if (acceptButton != null && rejectButton != null)
                    {
                        bool isRequested = item.Status == "Requested";
                        acceptButton.IsEnabled = isRequested;
                        rejectButton.IsEnabled = isRequested;
                    }
                }
            }
        }

        private void LoadConsultants()
        {
            var consultants = _accountService.GetConsultantByRoleId(4); // Fetch accounts with RoleId = 4
            if (consultants != null && consultants.Count > 0)
            {
                foreach (var consultant in consultants)
                {
                    Console.WriteLine($"Consultant: {consultant.Username}"); // Debugging line to check if Username is populated
                }
            }
            else
            {
                Console.WriteLine("No consultants found.");
            }
            ComboBoxConsultants.ItemsSource = consultants; 
        }

        private void ComboBoxConsultants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxConsultants.SelectedItem is Account selectedAccount)
            {
                // Lấy booking hiện tại đã chọn từ DataGrid
                if (DataGridOrderManagement.SelectedItem is Booking selectedBooking)
                {
                    // Kiểm tra nếu booking đã có consultant được gán
                    if (selectedBooking.ConsultantId != null)
                    {
                        MessageBox.Show("Already assigned consultant!");
                        ComboBoxConsultants.SelectedItem = null; // Xóa lựa chọn hiện tại để tránh gán lại
                        return;
                    }

                    // Chỉ gán nếu booking có trạng thái "Confirmed"
                    if (selectedBooking.Status == "Confirmed")
                    {
                        // Thông báo xác nhận trước khi gán
                        MessageBoxResult result = MessageBox.Show(
                            $"Do you want to assign {selectedAccount.Username} to this booking {selectedBooking.BookingId}?",
                            "Confirmation",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question
                        );

                        if (result == MessageBoxResult.Yes)
                        {
                            selectedBooking.ConsultantId = selectedAccount.AccountId;
                            bool updateSuccess = _orderManagementService.UpdateBooking(selectedBooking);

                            if (updateSuccess)
                            {
                                MessageBox.Show($"Consultant {selectedAccount.Username} assigned to booking {selectedBooking.BookingId}.");
                                LoadBookings();
                                LoadConsultants();
                                ComboBoxConsultants.SelectedItem = null;
                            }
                            else
                            {
                                MessageBox.Show("Failed to update the booking. Please try again.");
                            }
                        }
                        else
                        {
                            // Hủy bỏ nếu người dùng chọn "No"
                            ComboBoxConsultants.SelectedItem = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Consultant can only be assigned to bookings with status 'Confirmed'.");
                        LoadBookings();
                        LoadConsultants();
                        ComboBoxConsultants.SelectedItem = null;
                    }
                }
            }
            else
            {
                ComboBoxConsultants.SelectedItem = null;
            }
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int bookingId = (int)button.Tag;

            var booking = _orderManagementService.GetBookingById(bookingId);
            if (booking != null && booking.Status == "Requested")
            {
                MessageBoxResult result = MessageBox.Show("Do you want to update status to Accepted?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    booking.Status = "Accepted";
                    _context.Update(booking);
                    _context.SaveChanges();
                    // Update the booking in the database
                    // _orderManagementService.UpdateBooking(booking); // Uncomment this line if you have an update method
                    LoadBookings(); // Refresh the DataGrid
                }
            }
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int bookingId = (int)button.Tag;

            var booking = _orderManagementService.GetBookingById(bookingId);
            if (booking != null && booking.Status == "Requested")
            {
                MessageBoxResult result = MessageBox.Show("Do you want to update status to Rejected?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    booking.Status = "Rejected";
                    // Update the booking in the database
                    // _orderManagementService.UpdateBooking(booking); // Uncomment this line if you have an update method
                    LoadBookings(); // Refresh the DataGrid
                }
            }
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int bookingId = (int)button.Tag;

            // Navigate to the BookingDetails page, passing the bookingId
            NavigationService.Navigate(new BookingDetailsPage(bookingId, _orderManagementService));
        }

        private Button FindAcceptButton(DataGridRow row)
        {
            return FindChildButton(row, "AcceptButton");
        }

        private Button FindRejectButton(DataGridRow row)
        {
            return FindChildButton(row, "RejectButton");
        }

        private Button FindChildButton(DataGridRow row, string buttonName)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(row); i++)
            {
                var child = VisualTreeHelper.GetChild(row, i);
                if (child is Button button && button.Name == buttonName)
                {
                    return button;
                }
            }
            return null;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}