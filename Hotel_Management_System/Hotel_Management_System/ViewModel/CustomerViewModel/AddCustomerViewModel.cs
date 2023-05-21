using Hotel_Management_System.Model;
using Hotel_Management_System.View;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Hotel_Management_System.ViewModel
{
    public class AddCustomerViewModel : BaseViewModel
    {
        private bool _isCheckedMale;
        private bool _isCheckedFemale;

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand AddCustomerCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }
        public ICommand ClickGenderMaleCommand { get; set; }
        public ICommand ClickGenderFemaleCommand { get; set; }

        public BrushConverter converter = new BrushConverter();
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string CCCD { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }

        public bool IsCheckedMale { get => _isCheckedMale; set { _isCheckedMale = value; OnPropertyChanged(); } }
        public bool IsCheckedFemale { get => _isCheckedFemale; set { _isCheckedFemale = value; OnPropertyChanged(); } }

        public AddCustomerViewModel()
        {
            LoadedWindowCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { LoadedWindow(p); });

            AddCustomerCommand = new RelayCommand<TextBox>((p) => { return CheckAdd(); }, (p) => { AddCustomer(p); });

            BackCommand = new RelayCommand<AddCustomerView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<AddCustomerView>((p) => { return true; }, (p) => { Clear(); });

            ClickGenderMaleCommand = new RelayCommand<ToggleButton>((p) => { return true; }, (p) => { p.IsChecked = IsCheckedFemale = false; GioiTinh = "Nam"; });

            ClickGenderFemaleCommand = new RelayCommand<ToggleButton>((p) => { return true; }, (p) => { p.IsChecked = IsCheckedMale = false; GioiTinh = "Nữ"; });
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
                temp = DataProvider.Ins.DB.KHACHHANGs.OrderByDescending(cus => cus.MaKhachHang).FirstOrDefault().MaKhachHang;
            }
            catch
            {
                temp = "KH" + (23410000 - 1).ToString();
            }
            MaKhachHang = "KH" + (int.Parse(temp.Split('H')[1]) + 1).ToString();
            tb.Text = MaKhachHang;
        }

        public void AddCustomer(TextBox tb)
        {
            var customer = new KHACHHANG()
            {
                MaKhachHang = this.MaKhachHang,
                TenKhachHang = this.TenKhachHang,
                Character = this.TenKhachHang.ToString().Substring(0, 1),
                BgColor = BrushList((int.Parse(MaKhachHang.Split('H')[1]))),
                CCCD = this.CCCD,
                GioiTinh = this.GioiTinh,
                NgaySinh = this.NgaySinh,
                Email = this.Email,
                SDT = this.SDT
            };

            DataProvider.Ins.DB.KHACHHANGs.Add(customer);
            DataProvider.Ins.DB.SaveChanges();

            CustomerView customerView = new CustomerView();
            if (customerView.DataContext == null) return;
            var customerVM = customerView.DataContext as CustomerViewModel;
            customerVM.AddCustomer(customer);
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckAdd()
        {
            if (TenKhachHang != "" && CCCD != "" && GioiTinh != "" && NgaySinh != null && SDT != "" && Email != "" && IsValidEmail(Email))
                return true;
            else return false;
        }

        public void Clear()
        {
            TenKhachHang = null;
            CCCD = null;
            NgaySinh = null;
            GioiTinh = null;
            IsCheckedFemale = false;
            IsCheckedMale = false;
            Email = null;
            SDT = null;
        }
    }
}
