using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.ComponentModel;    //INotifyPropertyChanged
using CRM_Application.ViewModels;

namespace CRM_Application.Views
{
    /// <summary>
    /// Interaction logic for RequestWindow.xaml
    /// </summary>
    public partial class RequestWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public RequestWindow(string emailId, string phoneNum, string reqEmail, string reqSms, string reqPhoneCall)
        {
            InitializeComponent();

            labelCustomerRequestNoValue.Content = "44876";
            labelCustomerEmailIdValue.Content = emailId;
            labelCustomerPhoneNumberValue.Content = phoneNum;
            
            if(reqEmail == String.Empty)
                labelCustomerReqEmailIdValue.Content = "NA";
            else
                labelCustomerReqEmailIdValue.Content = reqEmail;

            if(reqSms == String.Empty)
                labelCustomerReqSmsValue.Content = "NA";
            else
                labelCustomerReqSmsValue.Content = reqSms;

            if(reqPhoneCall == String.Empty)
                labelCustomerReqphonecallValue.Content = "NA";
            else
                labelCustomerReqphonecallValue.Content = reqPhoneCall;
        }


    }
}
