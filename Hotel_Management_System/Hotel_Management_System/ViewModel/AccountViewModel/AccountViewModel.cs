using Hotel_Management_System.Model;
using Hotel_Management_System.View.AccountView;
using Hotel_Management_System.View.StaffView;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Hotel_Management_System.ViewModel.AccountViewModel
{
    public class AccountViewModel : BaseViewModel
    {
        public ICommand EditStaffCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }
        public ICommand ClickGenderMaleCommand { get; set; }
        public ICommand ClickGenderFemaleCommand { get; set; }

        private bool _isCheckedMale;
        private bool _isCheckedFemale;

        private string _maNhanVien;
        public string MaNhanVien
        {
            get { return _maNhanVien; }
            set { _maNhanVien = value; OnPropertyChanged(); }
        }

        private string _tenNhanVien;
        public string TenNhanVien
        {
            get { return _tenNhanVien; }
            set { _tenNhanVien = value; OnPropertyChanged(); }
        }

        private string _cCCD;
        public string CCCD
        {
            get { return _cCCD; }
            set { _cCCD = value; OnPropertyChanged(); }
        }

        private string _gioiTinh;
        public string GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; OnPropertyChanged(); }
        }

        private Nullable<System.DateTime> _ngaySinh;
        public Nullable<System.DateTime> NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; OnPropertyChanged(); }
        }

        private string _soDienThoai;
        public string SoDienThoai
        {
            get { return _soDienThoai; }
            set { _soDienThoai = value; OnPropertyChanged(); }
        }

        private string _chucVu;
        public string ChucVu
        {
            get { return _chucVu; }
            set { _chucVu = value; OnPropertyChanged(); }
        }

        private string _boPhan;
        public string BoPhan
        {
            get { return _boPhan; }
            set { _boPhan = value; OnPropertyChanged(); }
        }

        private string _tenTaiKhoan;
        public string TenTaiKhoan
        {
            get { return _tenTaiKhoan; }
            set { _tenTaiKhoan = value; OnPropertyChanged(); }
        }

        private string _matKhau;
        public string MatKhau
        {
            get { return _matKhau; }
            set { _matKhau = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public bool IsCheckedMale { get => _isCheckedMale; set { _isCheckedMale = value; OnPropertyChanged(); } }
        public bool IsCheckedFemale { get => _isCheckedFemale; set { _isCheckedFemale = value; OnPropertyChanged(); } }

        private NHANVIEN _selectedStaffItem;
        public NHANVIEN SelectedStaffItem
        {
            get { return _selectedStaffItem; }
            set
            {
                if (_selectedStaffItem != value)
                {
                    _selectedStaffItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public AccountViewModel()
        {
            EditStaffCommand = new RelayCommand<object>((p) => { return true; }, (p) => { EditStaff(); });

            ClosedWindowCommand = new RelayCommand<AccountView>((p) => { return true; }, (p) => { Clear(); });

            ClickGenderMaleCommand = new RelayCommand<ToggleButton>((p) => { return true; }, (p) => { p.IsChecked = IsCheckedFemale = false; GioiTinh = "Nam"; });

            ClickGenderFemaleCommand = new RelayCommand<ToggleButton>((p) => { return true; }, (p) => { p.IsChecked = IsCheckedMale = false; GioiTinh = "Nữ"; });
        }

        public AccountViewModel(NHANVIEN SelectedStaffItem) : this()
        {
            Load(SelectedStaffItem);
        } 

        public void EditStaff()
        {
            //var result = DataProvider.Ins.DB.NHANVIENs.Where(x => x.MaNhanVien.CompareTo(this.MaNhanVien) == 0).FirstOrDefault();

            //result.TenNhanVien = this.TenNhanVien;
            //result.CCCD = this.CCCD;
            //result.GioiTinh = this.GioiTinh;
            //result.TenTaiKhoan = this.TenTaiKhoan;
            //result.NgaySinh = this.NgaySinh;
            //result.SoDienThoai = this.SoDienThoai;
            //result.BoPhan = this.BoPhan;
            //result.ChucVu = this.ChucVu;
            //result.MatKhau = this.MatKhau;

            //DataProvider.Ins.DB.NHANVIENs.AddOrUpdate(result);
            //DataProvider.Ins.DB.SaveChanges();
            MessageBox.Show("Cập nhật thành công", "Thông báo",MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void Clear()
        {
            this.TenNhanVien = null;
            this.CCCD = null;
            this.NgaySinh = null;
            this.GioiTinh = null;
            this.ChucVu = null;
            this.SoDienThoai = null;
            this.BoPhan = null;
            this.TenTaiKhoan = null;
            this.MatKhau = null;
        }

        public void Load(NHANVIEN SelectedStaffItem)
        {
            this.SelectedStaffItem = SelectedStaffItem;
            this.MaNhanVien = SelectedStaffItem.MaNhanVien;
            this.TenNhanVien = SelectedStaffItem.TenNhanVien;
            this.CCCD = SelectedStaffItem.CCCD;
            this.GioiTinh = SelectedStaffItem.GioiTinh;
            if (GioiTinh == "Nam")
            {
                IsCheckedMale = true;
                IsCheckedFemale = false;
            }
            else if (GioiTinh == "Nữ")
            {
                IsCheckedMale = false;
                IsCheckedFemale = true;
            }
            this.NgaySinh = SelectedStaffItem.NgaySinh;
            this.SoDienThoai = SelectedStaffItem.SoDienThoai;
            this.TenTaiKhoan = SelectedStaffItem.TenTaiKhoan;
            this.MatKhau = SelectedStaffItem.MatKhau;
            if (MatKhau != null) this.Password = new string('*', MatKhau.Length);
            this.BoPhan = SelectedStaffItem.BoPhan;
            this.ChucVu = SelectedStaffItem.ChucVu;
        }
    }
}
