﻿using System;
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
    /// Interaction logic for DeliveryStaffPage.xaml
    /// </summary>
    public partial class DeliveryStaffPage : Page
    {
        private int _accountId;
        public DeliveryStaffPage(int accountId)
        {
            InitializeComponent();
            this._accountId = accountId;
        }
    }
}
