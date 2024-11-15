using Koi88_BusinessObject;
using Koi88_DAO;
using Koi88_Repository;
using Koi88_Service;
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
    /// Interaction logic for AddFishPage.xaml
    /// </summary>
    public partial class AddFishPage : Page
    {
        private int poId;
        private IFarmService farmService;
        private IPodetailsService podetailsService;

        public AddFishPage(int poId)
        {
            InitializeComponent();
            this.poId = poId;
            farmService = new FarmService();
            podetailsService = new PodetailsService();
            loadInit();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public void loadInit()
        {
            cbFarm.ItemsSource = farmService.GetFarms();
            cbFarm.DisplayMemberPath = "FarmName";
            cbFarm.SelectedValuePath = "FarmId";

            cbFish.ItemsSource = KoiDAO.Instance.GetFish();
            cbFish.DisplayMemberPath = "KoiName";
            cbFish.SelectedValuePath = "KoiId";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Podetail podetail = new Podetail();
            podetail.PoId = poId;
            podetail.KoiId = int.Parse(cbFish.SelectedValue.ToString());
            podetail.FarmId = int.Parse(cbFarm.SelectedValue.ToString());
            podetail.Deposit = decimal.Parse(txtDeposit.Text);
            podetail.TotalKoiPrice = decimal.Parse(txtTotalPrice.Text);
            podetail.Quantity = int.Parse(txtQuantity.Text);
            podetail.Note = txtNote.Text;

            podetailsService.AddDodetail(podetail);
            MessageBox.Show("Add successfully!");
            NavigationService.GoBack();
        }
    }
}
