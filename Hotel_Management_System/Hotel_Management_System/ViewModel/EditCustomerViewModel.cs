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
    public class EditCustomerViewModel : BaseViewModel
    {
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand EditCustomerCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }

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

        public EditCustomerViewModel()
        {
            LoadedWindowCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { LoadedWindow(p); });

            EditCustomerCommand = new RelayCommand<Button>((p) => { return Check(); }, (p) => { EditCustomer(); });

            BackCommand = new RelayCommand<AddCustomerView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<AddCustomerView>((p) => { return true; }, (p) => { Clear(); });
        }

        public void LoadedWindow(TextBox tb)
        {
            
        }

        public void EditCustomer()
        {
            var customer = new KHACHHANG()
            {
                MaKhachHang = MaKhachHang,
                TenKhachHang = TenKhachHang,
                Character = TenKhachHang.ToString().Substring(0, 1),
                //BgColor = "",
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

        public bool Check()
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
