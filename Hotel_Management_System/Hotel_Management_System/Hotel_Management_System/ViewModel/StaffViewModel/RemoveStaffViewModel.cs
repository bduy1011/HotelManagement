using Hotel_Management_System.Model;
using Hotel_Management_System.View;
using Hotel_Management_System.ViewModel.Other;
using Hotel_Management_System.View.CustomerView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Hotel_Management_System.View.StaffView;

namespace Hotel_Management_System.ViewModel.StaffViewModel
{
    public class RemoveStaffViewModel : BaseViewModel
    {
        public ICommand RemoveStaffCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }
        public ICommand ClickGenderMaleCommand { get; set; }
        public ICommand ClickGenderFemaleCommand { get; set; }

        private bool _isCheckedMale;
        private bool _isCheckedFemale;

        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string CCCD { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public string ChucVu { get; set; }
        public string BoPhan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }

        public bool IsCheckedMale { get => _isCheckedMale; set { _isCheckedMale = value; OnPropertyChanged(); } }
        public bool IsCheckedFemale { get => _isCheckedFemale; set { _isCheckedFemale = value; OnPropertyChanged(); } }

        public bool IsRemove = false;

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

        public RemoveStaffViewModel()
        {
            RemoveStaffCommand = new RelayCommand<object>((p) => { return true; }, (p) => { RemoveStaff(); });

            BackCommand = new RelayCommand<RemoveStaffView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<RemoveStaffView>((p) => { return true; }, (p) => { Clear(); });

            ClickGenderMaleCommand = new RelayCommand<ToggleButton>((p) => { return true; }, (p) => { p.IsChecked = IsCheckedFemale = false; GioiTinh = "Nam"; });

            ClickGenderFemaleCommand = new RelayCommand<ToggleButton>((p) => { return true; }, (p) => { p.IsChecked = IsCheckedMale = false; GioiTinh = "Nữ"; });
        }

        public RemoveStaffViewModel(NHANVIEN SelectedStaffItem) : this()
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

        public void RemoveStaff()
        {
            var result = DataProvider.Ins.DB.NHANVIENs.Where(x => x.MaNhanVien.CompareTo(this.MaNhanVien) == 0).Single();
            DataProvider.Ins.DB.NHANVIENs.Remove(result);
            DataProvider.Ins.DB.SaveChanges();

            StaffView staffView = new StaffView();
            if (staffView.DataContext == null) return;
            var staffVM = staffView.DataContext as StaffViewModel;
            staffVM.RemoveStaff(result);
            IsRemove = true;
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
    }
}
