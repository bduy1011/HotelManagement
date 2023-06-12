using Hotel_Management_System.Model;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotel_Management_System.ViewModel.LoginViewModel
{
    public class LoginViewModel : BaseViewModel
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
        public bool IsLogin { get; set; }
        private string _username;
        private string _password;

        public string Username 
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        public LoginViewModel()
        {
            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }

        void Login(Window p)
        {
            if (p == null)
            {
                return;
            }
            nhanvien = new NHANVIEN();
            nhanvien = DataProvider.Ins.DB.NHANVIENs.Where(x => x.TenTaiKhoan != null && x.MatKhau != null && x.TenTaiKhoan == Username && x.MatKhau == Password).FirstOrDefault();
            if (nhanvien != null)
            {
                IsLogin = true;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
