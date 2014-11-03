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
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
        }

        private void chkbxEmail_Checked(object sender, RoutedEventArgs e)
        {
            txtbxRequestEmail.IsEnabled = true;
        }

        private void chkbxEmail_Unchecked(object sender, RoutedEventArgs e)
        {
            txtbxRequestEmail.IsEnabled = false;
            txtbxRequestEmail.Background = Brushes.White;
        }

        private void chkbxSms_Checked(object sender, RoutedEventArgs e)
        {
            txtbxRequestSms.IsEnabled = true;
        }

        private void chkbxSms_Unchecked(object sender, RoutedEventArgs e)
        {
            txtbxRequestSms.IsEnabled = false;
            txtbxRequestSms.Background = Brushes.White;
        }

        private void chkbxPhonecall_Checked(object sender, RoutedEventArgs e)
        {
            txtbxRequestPhonecall.IsEnabled = true;
        }

        private void chkbxPhonecall_Unchecked(object sender, RoutedEventArgs e)
        {
            txtbxRequestPhonecall.IsEnabled = false;
            txtbxRequestPhonecall.Background = Brushes.White;
        }


    }
}
