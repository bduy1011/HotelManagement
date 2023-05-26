using FontAwesome.Sharp;
using Hotel_Management_System.Model;
using Hotel_Management_System.ViewModel.RoomMapViewModel;
using Hotel_Management_System.View.LoginView;
using Hotel_Management_System.ViewModel.Other;
using Hotel_Management_System.ViewModel.CustomerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotel_Management_System.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        private BaseViewModel _currentChildView;
        public BaseViewModel CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand ShowStaffViewCommand { get; set; }
        public ICommand ShowCustomerViewCommand { get; set; }
        public ICommand ShowRoomMapViewCommand { get; set; }

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;

                if (p == null) return;
                p.Hide();

                LoginView loginWindow = new LoginView();
                loginWindow.ShowDialog();

                if (loginWindow.DataContext == null) return;
                var loginVM = loginWindow.DataContext as LoginViewModel;

                if(loginVM.IsLogin)
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }
            });

            //Initialize commands
            ShowStaffViewCommand = new ViewModelCommand(ExecuteShowStaffViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowRoomMapViewCommand = new ViewModelCommand(ExecuteShowRoomMapViewCommand);

            //Default view
            ExecuteShowRoomMapViewCommand(null);
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel.CustomerViewModel();
        }
        private void ExecuteShowStaffViewCommand(object obj)
        {
            CurrentChildView = new StaffViewModel.StaffViewModel();
        }
        private void ExecuteShowRoomMapViewCommand(object obj)
        {
            CurrentChildView = new RoomMapViewModel.RoomMapViewModel();
        }
    }
}
