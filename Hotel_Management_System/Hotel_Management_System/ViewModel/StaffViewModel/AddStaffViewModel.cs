using Hotel_Management_System.Model;
using Hotel_Management_System.View;
using Hotel_Management_System.View.StaffView;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel_Management_System.ViewModel.StaffViewModel
{
    public class AddStaffViewModel : BaseViewModel
    {
        private bool _isCheckedMale;
        private bool _isCheckedFemale;
        private bool _isCheckCreateAccount;
        private string _matKhau;
        private string _tenTaiKhoan;
        private string _password;

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand AddStaffCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }
        public ICommand ClickGenderMaleCommand { get; set; }
        public ICommand ClickGenderFemaleCommand { get; set; }
        public ICommand CreateAccountCommand { get; set; }

        public BrushConverter converter = new BrushConverter();
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string CCCD { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public string ChucVu { get; set; }
        public string BoPhan { get; set; }

        public bool IsCheckedMale { get => _isCheckedMale; set { _isCheckedMale = value; OnPropertyChanged(); } }
        public bool IsCheckedFemale { get => _isCheckedFemale; set { _isCheckedFemale = value; OnPropertyChanged(); } }
        public bool IsCheckCreateAccount { get => _isCheckCreateAccount; set { _isCheckCreateAccount = value; OnPropertyChanged(); } }
        public string TenTaiKhoan { get => _tenTaiKhoan; set { _tenTaiKhoan = value; OnPropertyChanged(); } }
        public string MatKhau { get => _matKhau; set { _matKhau = value; OnPropertyChanged(); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }

        public AddStaffViewModel()
        {
            LoadedWindowCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { LoadedWindow(p); });

            AddStaffCommand = new RelayCommand<TextBox>((p) => { return CheckAdd(); }, (p) => { AddStaff(); });

            BackCommand = new RelayCommand<AddStaffView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<AddStaffView>((p) => { return true; }, (p) => { Clear(); });

            ClickGenderMaleCommand = new RelayCommand<ToggleButton>((p) => { return true; }, (p) => { p.IsChecked = IsCheckedFemale = false; GioiTinh = "Nam"; });

            ClickGenderFemaleCommand = new RelayCommand<ToggleButton>((p) => { return true; }, (p) => { p.IsChecked = IsCheckedMale = false; GioiTinh = "Nữ"; });

            CreateAccountCommand = new RelayCommand<object>((p) => { return true; }, (p) => 
            { 
                if(IsCheckCreateAccount == true)
                {
                    TenTaiKhoan = MaNhanVien;
                    MatKhau = MaNhanVien;
                }
                else TenTaiKhoan = MatKhau = "";
            });
        }

        public Brush BrushList(int i)
        {
            switch (i % 10)
            {
                case 0:
                    return (Brush)converter.ConvertFromString("#1098AD");
                case 1:
                    return (Brush)converter.ConvertFromString("#1E88E5");
                case 2:
                    return (Brush)converter.ConvertFromString("#FF8F00");
                case 3:
                    return (Brush)converter.ConvertFromString("#0CA678");
                case 4:
                    return (Brush)converter.ConvertFromString("#6741D9");
                case 5:
                    return (Brush)converter.ConvertFromString("#FF6D00");
                case 6:
                    return (Brush)converter.ConvertFromString("#FF5252");
                case 7:
                    return (Brush)converter.ConvertFromString("#1E88E5");
                case 8:
                    return (Brush)converter.ConvertFromString("#0CA678");
                default:
                    return (Brush)converter.ConvertFromString("#FF5252");
            }
        }

        public void LoadedWindow(TextBox tb)
        {
            string temp;
            try
            {
                temp = DataProvider.Ins.DB.NHANVIENs.OrderByDescending(cus => cus.MaNhanVien).FirstOrDefault().MaNhanVien;
            }
            catch
            {
                temp = "NV" + 10000.ToString();
            }
            MaNhanVien = "NV" + (int.Parse(temp.Substring(2)) + 1).ToString();
            tb.Text = MaNhanVien;
        }

        public void AddStaff()
        {
            var staff = new NHANVIEN()
            {
                MaNhanVien = this.MaNhanVien,
                TenNhanVien = this.TenNhanVien,
                Character = this.TenNhanVien.ToString().Substring(0, 1),
                BgColor = BrushList((int.Parse(MaNhanVien.Substring(2)))),
                CCCD = this.CCCD,
                GioiTinh = this.GioiTinh,
                NgaySinh = this.NgaySinh,
                BoPhan = this.BoPhan,
                ChucVu = this.ChucVu,
                SoDienThoai = this.SoDienThoai,
                TenTaiKhoan = this.TenTaiKhoan,
                MatKhau = this.MatKhau
            };

            DataProvider.Ins.DB.NHANVIENs.Add(staff);
            DataProvider.Ins.DB.SaveChanges();

            StaffView staffView = new StaffView();
            if (staffView.DataContext == null) return;
            var staffVM = staffView.DataContext as StaffViewModel;
            staffVM.Addstaff(staff);
        }

        public bool CheckAdd()
        {
            if (MaNhanVien != "" && TenNhanVien != "" && CCCD != "" && GioiTinh != "" && NgaySinh != null && SoDienThoai != "" && BoPhan != "" &&
                ChucVu != "" && TenTaiKhoan != "" && MatKhau != "")
                return true;
            else return false;
        }

        public void Clear()
        {
            TenNhanVien = null;
            CCCD = null;
            NgaySinh = null;
            GioiTinh = null;
            IsCheckedFemale = false;
            IsCheckedMale = false;
            BoPhan = null;
            ChucVu = null;
            SoDienThoai = null;
            TenTaiKhoan = null;
            MatKhau = null;
        }
    }
}
