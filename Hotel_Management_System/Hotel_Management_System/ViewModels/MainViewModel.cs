using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using FontAwesome.Sharp;
using Hotel_Management_System.Models;
using Hotel_Management_System.Repositories;

namespace Hotel_Management_System.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }
        }

        public ViewModelBase CurrentChildView 
        {
            get => _currentChildView; 
            set
            {
                _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView));
            } 
        }
        public string Caption
        {
            get => _caption;
            set
            {
                _caption=value; OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get => _icon;
            set
            {
                _icon = value; OnPropertyChanged(nameof(Icon));
            }
        }

        //Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }
      

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount=new UserAccountModel();
            //Command
            ShowHomeViewCommand = new RelayCommand(ExcuteShowHomeViewCommand);
            ShowCustomerViewCommand = new RelayCommand(ExcuteShowCustomerViewCommand);
            //Suze
            ExcuteShowHomeViewCommand(null);
            LoadCurrentUserData();

        }
        private void ExcuteShowCustomerViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Caption = "Customers";
            Icon = IconChar.UserGroup;
        }

        private void ExcuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if(user!=null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"{user.Name} {user.Lastname}";
                CurrentUserAccount.ProfilePicture = null;     
            }
            else
            {
                CurrentUserAccount.DisplayName="Nguoi dung khong hop le! Khong dang nhap duoc";
               
            }
        }
    }
}
