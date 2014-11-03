using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CRM_Application.Helpers;
using CRM_Application.Models;

using CRM_Application.Views;
using System.Windows.Forms;             //MessageBox
using System.Text.RegularExpressions;   //Regex
using System.Windows.Media;             //Brushes
using System.Threading;                 //Process

namespace CRM_Application.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private MainWindow mainView;
        private MainWindowModel mainModel;
        private string customerEmailId = String.Empty, customerPhoneNumber = String.Empty;
        private string customerEmailIdMsg = String.Empty, customerPhoneNumberMsg = String.Empty;
        private string requestEmail = String.Empty, requestSms = String.Empty, requestPhonecall = String.Empty;

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(MainWindow mainView)
        {
            this.mainView = mainView;
            mainModel = new MainWindowModel();
        }

        #region Properties
        public string CustomerEmailIdProperty
        {
            get
            {
                return customerEmailId;
            }
            set
            {
                customerEmailId = value;
                OnPropertyChanged("CustomerEmailIdProperty");
            }
        }
        public string CustomerEmailIdMessageProperty
        {
            get
            {
                return customerEmailIdMsg;
            }
            set
            {
                customerEmailIdMsg = value;
                OnPropertyChanged("CustomerEmailIdMessageProperty");
            }
        }

        public string CustomerPhoneNumberProperty
        {
            get
            {
                return customerPhoneNumber;
            }
            set
            {
                customerPhoneNumber = value;
                OnPropertyChanged("CustomerPhoneNumberProperty");
            }
        }
        public string CustomerPhoneNumberMessageProperty
        {
            get
            {
                return customerPhoneNumberMsg;
            }
            set
            {
                customerPhoneNumberMsg = value;
                OnPropertyChanged("CustomerPhoneNumberMessageProperty");
            }
        }

        public string RequestEmailProperty
        {
            get
            {
                return requestEmail;
            }
            set
            {
                requestEmail = value;
                OnPropertyChanged("RequestEmailProperty");
            }
        }
        public string RequestSmsProperty
        {
            get
            {
                return requestSms;
            }
            set
            {
                requestSms = value;
                OnPropertyChanged("RequestSmsProperty");
            }
        }
        public string RequestPhonecallProperty
        {
            get
            {
                return requestPhonecall;
            }
            set
            {
                requestPhonecall = value;
                OnPropertyChanged("RequestPhonecallProperty");
            }
        }
        #endregion

        #region Commands
        public ICommand submitCommand
        {
            get
            {
                return new DelegateCommand(submitMethod);
            }
            set { }
        }
        #endregion

        public void submitMethod()
        {
            int validationFlag = 0;
            Boolean flag = false;

            //Validate email ID
            Boolean isEmail = Regex.IsMatch(CustomerEmailIdProperty, @"^([a-zA-Z]([.]?[a-zA-Z0-9]+)+)(@[a-zA-Z]+.(com|org|edu))$");
            if (isEmail == false)
            {
                CustomerEmailIdMessageProperty = "*Invalid email Id!";
                flag = false;
            }
            else
            {
                CustomerEmailIdMessageProperty = String.Empty;
                ++validationFlag;
                flag = true;
            }


            //Validate phone number
            Boolean isPhoneNum = Regex.IsMatch(CustomerPhoneNumberProperty, @"^[0-9]{10}$");
            if (isPhoneNum == false)
            {
                CustomerPhoneNumberMessageProperty = "*Invalid phone number!";
            }
            else
            {
                ++validationFlag;
                CustomerPhoneNumberMessageProperty = String.Empty;
            }

            //Validate request modes
            if (mainView.chkbxEmail.IsChecked == false && mainView.chkbxSms.IsChecked == false && mainView.chkbxPhonecall.IsChecked == false)
                MessageBox.Show("Please tick atleast one request mode!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (mainView.chkbxEmail.IsChecked == true)
                {
                    Boolean reqEmail = Regex.IsMatch(RequestEmailProperty, @"^([a-zA-Z]([.]?[a-zA-Z0-9]+)+)(@[a-zA-Z]+.(com|org|edu))$");
                    if (reqEmail == false)
                        mainView.txtbxRequestEmail.Background = Brushes.Red;
                    else
                    {
                        ++validationFlag;
                        mainView.txtbxRequestEmail.Background = Brushes.White;
                    }
                }
                if (mainView.chkbxSms.IsChecked == true)
                {
                    Boolean reqSms = Regex.IsMatch(RequestSmsProperty, @"^[0-9]{10}$");
                    if (reqSms == false)
                        mainView.txtbxRequestSms.Background = Brushes.Red;
                    else
                    {
                        ++validationFlag;
                        mainView.txtbxRequestSms.Background = Brushes.White;
                    }
                }
                if (mainView.chkbxPhonecall.IsChecked == true)
                {
                    Boolean reqPhonecall = Regex.IsMatch(RequestPhonecallProperty, @"^[0-9]{10}$");
                    if (reqPhonecall == false)
                        mainView.txtbxRequestPhonecall.Background = Brushes.Red;
                    else
                    {
                        ++validationFlag;
                        mainView.txtbxRequestPhonecall.Background = Brushes.White;
                    }
                }
            }

            if (validationFlag >= 3)
            {
                RequestWindow mainReq = new RequestWindow(CustomerEmailIdProperty, CustomerPhoneNumberProperty, RequestEmailProperty, RequestSmsProperty, RequestPhonecallProperty);
                mainReq.Show();
            }
            
        }

    }
}
