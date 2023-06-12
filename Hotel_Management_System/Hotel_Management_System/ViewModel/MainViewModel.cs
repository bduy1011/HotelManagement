using FontAwesome.Sharp;
using Hotel_Management_System.Model;
using Hotel_Management_System.ViewModel.RoomMapViewModel;
using Hotel_Management_System.View.LoginView;
using Hotel_Management_System.ViewModel.Other;
using System.Windows;
using System.Windows.Input;

namespace Hotel_Management_System.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private NHANVIEN _nhanvien;
        public NHANVIEN nhanvien
        {
            get { return _nhanvien; }
            set
            {
                if (_nhanvien != value)
                {
                    _nhanvien = value;
                    OnPropertyChanged();
                }
            }
        }
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
                OnPropertyChanged();
            }
        }

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand ShowStaffViewCommand { get; set; }
        public ICommand ShowCustomerViewCommand { get; set; }
        public ICommand ShowRoomMapViewCommand { get; set; }
        public ICommand ShowCommodityViewCommand { get; set; }
        public ICommand ShowServiceViewCommand { get; set; }
        public ICommand ShowRoomViewCommand { get; set; }
        public ICommand ShowRoomTypeViewCommand { get; set; }
        public ICommand ShowBillViewCommand { get; set; }
        public ICommand ShowAccountViewCommand { get; set; }

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                nhanvien = new NHANVIEN();
                Isloaded = true;

                if (p == null) return;
                p.Hide();

                LoginView loginWindow = new LoginView();
                loginWindow.txtUser.Text = "";
                loginWindow.ShowDialog();

                if (loginWindow.DataContext == null) return;
                var loginVM = loginWindow.DataContext as LoginViewModel.LoginViewModel;

                if(loginVM.IsLogin)
                {
                    nhanvien = loginVM.nhanvien;
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
            ShowCommodityViewCommand = new ViewModelCommand(ExecuteShowCommodityViewCommand);
            ShowServiceViewCommand = new ViewModelCommand(ExecuteShowServiceViewCommand);
            ShowRoomViewCommand = new ViewModelCommand(ExecuteShowRoomViewCommand);
            ShowRoomTypeViewCommand = new ViewModelCommand(ExecuteShowRoomTypeViewCommand);
            ShowBillViewCommand = new ViewModelCommand(ExecuteShowBillViewCommand);
            ShowAccountViewCommand = new ViewModelCommand(ExecuteShowAccountViewCommand);

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
        private void ExecuteShowCommodityViewCommand(object obj)
        {
            CurrentChildView = new CommodityViewModel.CommodityViewModel();
        }
        private void ExecuteShowServiceViewCommand(object obj)
        {
            CurrentChildView = new ServiceViewModel.ServiceViewModel();
        }
        private void ExecuteShowRoomViewCommand(object obj)
        {
            CurrentChildView = new RoomViewModel.RoomViewModel();
        }
        private void ExecuteShowRoomTypeViewCommand(object obj)
        {
            CurrentChildView = new RoomTypeViewModel.RoomTypeViewModel();
        }
        private void ExecuteShowBillViewCommand(object obj)
        {
            CurrentChildView = new BillViewModel.BillViewModel(nhanvien);
        }
        private void ExecuteShowAccountViewCommand(object obj)
        {
            CurrentChildView = new AccountViewModel.AccountViewModel(nhanvien);
        }
    }
}
