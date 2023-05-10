using Hotel_Management_System.Model;
using Hotel_Management_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel_Management_System.ViewModel
{
    public class AddCustomerViewModel : BaseViewModel
    {
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand AddCustomerCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }
        public BrushConverter converter = new BrushConverter();

        private int _maKhachHang;
        private string _tenKhachHang;
        private string _CCCD;
        private string _gioiTinh;
        private Nullable<System.DateTime> _ngaySinh;
        private string _SDT;
        private string _email;

        public int MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string CCCD { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }

        public AddCustomerViewModel()
        {
            LoadedWindowCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { LoadedWindow(p); });

            AddCustomerCommand = new RelayCommand<Button>((p) => { return true; }, (p) => { AddCustomer(); });

            BackCommand = new RelayCommand<AddCustomerView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<AddCustomerView>((p) => { return true; }, (p) => { Clear(); });
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
            MaKhachHang = DataProvider.Ins.DB.KHACHHANGs.Max(cus => cus.MaKhachHang) + 1;
            tb.Text = MaKhachHang.ToString();
        }

        public void AddCustomer()
        {
            var customer = new KHACHHANG()
            {
                MaKhachHang = MaKhachHang,
                TenKhachHang = TenKhachHang,
                Character = TenKhachHang.ToString().Substring(0, 1),
                BgColor = BrushList(MaKhachHang),
                CCCD = CCCD,
                GioiTinh = GioiTinh,
                NgaySinh = NgaySinh,
                Email = Email,
                SDT = SDT
            };

            DataProvider.Ins.DB.KHACHHANGs.Add(customer);
            DataProvider.Ins.DB.SaveChanges();

            CustomerView customerView = new CustomerView();
            if (customerView.DataContext == null) return;
            var customerVM = customerView.DataContext as CustomerViewModel;
            customerVM.AddCustomer(customer);
        }

        public bool CheckAdd()
        {
            if (TenKhachHang != "" && CCCD != "" && GioiTinh != "" && NgaySinh != null && SDT != "" && Email != "")
                return true;
            else return false;
        }

        public void Clear()
        {
            TenKhachHang = null;
            CCCD = null;
            NgaySinh = null;
            GioiTinh = null;
            Email = null;
            SDT = null;
        }
    }
}
