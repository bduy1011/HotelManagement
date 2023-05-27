using Hotel_Management_System.Model;
using Hotel_Management_System.View.CustomerView;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Hotel_Management_System.ViewModel.CustomerViewModel
{
    public class EditCustomerViewModel : BaseViewModel
    {
        public ICommand EditCustomerCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }
        public ICommand ClickGenderMaleCommand { get; set; }
        public ICommand ClickGenderFemaleCommand { get; set; }

        private bool _isCheckedMale;
        private bool _isCheckedFemale;

        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string CCCD { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string SDT { get; set; }
        public string LoaiKhachHang { get; set; }

        public bool IsCheckedMale { get => _isCheckedMale; set { _isCheckedMale = value; OnPropertyChanged(); } }
        public bool IsCheckedFemale { get => _isCheckedFemale; set { _isCheckedFemale = value; OnPropertyChanged(); } }

        private KHACHHANG _selectedCustomerItem;
        public KHACHHANG SelectedCustomerItem
        {
            get { return _selectedCustomerItem; }
            set
            {
                if (_selectedCustomerItem != value)
                {
                    _selectedCustomerItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public EditCustomerViewModel()
        {
            EditCustomerCommand = new RelayCommand<object>((p) => { return Check(); }, (p) => { EditCustomer(); });

            BackCommand = new RelayCommand<EditCustomerView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<EditCustomerView>((p) => { return true; }, (p) => { Clear(); });

            ClickGenderMaleCommand = new RelayCommand<ToggleButton>((p) => { return true; }, (p) => { p.IsChecked = IsCheckedFemale = false; GioiTinh = "Nam"; });

            ClickGenderFemaleCommand = new RelayCommand<ToggleButton>((p) => { return true; }, (p) => { p.IsChecked = IsCheckedMale = false; GioiTinh = "Nữ"; });
        }

        public EditCustomerViewModel(KHACHHANG SelectedCustomerItem) : this()
        {
            this.SelectedCustomerItem = SelectedCustomerItem;
            this.MaKhachHang = SelectedCustomerItem.MaKhachHang;
            this.TenKhachHang = SelectedCustomerItem.TenKhachHang;
            this.CCCD = SelectedCustomerItem.CCCD;
            this.GioiTinh = SelectedCustomerItem.GioiTinh;
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
            this.NgaySinh = SelectedCustomerItem.NgaySinh;
            this.LoaiKhachHang = SelectedCustomerItem.LoaiKhachHang;
            this.SDT = SelectedCustomerItem.SoDienThoai;
        }

        public void EditCustomer()
        {
            var result = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MaKhachHang.CompareTo(this.MaKhachHang) == 0).Single();

            result.TenKhachHang = this.TenKhachHang;
            result.CCCD = this.CCCD;
            result.GioiTinh = this.GioiTinh;
            result.TenKhachHang = this.TenKhachHang;
            result.NgaySinh = this.NgaySinh;
            result.SoDienThoai = this.SDT;
            result.LoaiKhachHang = this.LoaiKhachHang;

            DataProvider.Ins.DB.KHACHHANGs.AddOrUpdate(result);
            DataProvider.Ins.DB.SaveChanges();

            CustomerView customerView = new CustomerView();
            if (customerView.DataContext == null) return;
            var customerVM = customerView.DataContext as CustomerViewModel;
            customerVM.UpdateCustomer(result);
        }

        public bool Check()
        {
            if (TenKhachHang != "" && CCCD != "" && (IsCheckedFemale == true || IsCheckedMale == true) && NgaySinh != null && SDT != "" && LoaiKhachHang != "")
                return true;
            else return false;
        }

        public void Clear()
        {
            this.TenKhachHang = null;
            this.CCCD = null;
            this.NgaySinh = null;
            this.GioiTinh = null;
            this.LoaiKhachHang = null;
            this.SDT = null;
        }
    }
}
