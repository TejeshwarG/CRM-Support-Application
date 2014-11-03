using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

using CRM_Application.ViewModels;
using System;   //String
using System.Windows.Media;

namespace CRM_Application.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainViewModel;   
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
            mainViewModel = (MainWindowViewModel)DataContext;
        }

        private void chkbxEmail_Checked(object sender, RoutedEventArgs e)
        {
            txtbxRequestEmail.IsEnabled = true;
        }

        private void chkbxEmail_Unchecked(object sender, RoutedEventArgs e)
        {
            txtbxRequestEmail.IsEnabled = false;
            txtbxRequestEmail.Background = Brushes.White;
            txtbxRequestEmail.Text = String.Empty;
            mainViewModel.RequestEmailProperty = String.Empty;
        }

        private void chkbxSms_Checked(object sender, RoutedEventArgs e)
        {
            txtbxRequestSms.IsEnabled = true;
        }

        private void chkbxSms_Unchecked(object sender, RoutedEventArgs e)
        {
            txtbxRequestSms.IsEnabled = false;
            txtbxRequestSms.Background = Brushes.White;
            txtbxRequestSms.Text = String.Empty;
            mainViewModel.RequestSmsProperty = String.Empty;
        }

        private void chkbxPhonecall_Checked(object sender, RoutedEventArgs e)
        {
            txtbxRequestPhonecall.IsEnabled = true;
        }

        private void chkbxPhonecall_Unchecked(object sender, RoutedEventArgs e)
        {
            txtbxRequestPhonecall.IsEnabled = false;
            txtbxRequestPhonecall.Background = Brushes.White;
            txtbxRequestPhonecall.Text = String.Empty;
            mainViewModel.RequestPhonecallProperty = String.Empty;
        }


    }
}

