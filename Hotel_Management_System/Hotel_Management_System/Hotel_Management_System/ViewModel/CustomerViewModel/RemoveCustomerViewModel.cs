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

namespace Hotel_Management_System.ViewModel.CustomerViewModel
{
    public class RemoveCustomerViewModel : BaseViewModel
    {
        public ICommand RemoveCustomerCommand { get; set; }
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
        public string SoDienThoai { get; set; }
        public string LoaiKhachHang { get; set; }

        public bool IsCheckedMale { get => _isCheckedMale; set { _isCheckedMale = value; OnPropertyChanged(); } }
        public bool IsCheckedFemale { get => _isCheckedFemale; set { _isCheckedFemale = value; OnPropertyChanged(); } }

        public bool IsRemove = false;

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

        public RemoveCustomerViewModel()
        {
            RemoveCustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) => { RemoveCustomer(); });

            BackCommand = new RelayCommand<RemoveCustomerView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<RemoveCustomerView>((p) => { return true; }, (p) => { Clear(); });

            ClickGenderMaleCommand = new RelayCommand<ToggleButton>((p) => { return true; }, (p) => { p.IsChecked = IsCheckedFemale = false; GioiTinh = "Nam"; });

            ClickGenderFemaleCommand = new RelayCommand<ToggleButton>((p) => { return true; }, (p) => { p.IsChecked = IsCheckedMale = false; GioiTinh = "Nữ"; });
        }

        public RemoveCustomerViewModel(KHACHHANG SelectedCustomerItem) : this()
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
            this.SoDienThoai = SelectedCustomerItem.SoDienThoai;
        }

        public void RemoveCustomer()
        {
            var result = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MaKhachHang.CompareTo(this.MaKhachHang) == 0).Single();
            DataProvider.Ins.DB.KHACHHANGs.Remove(result);
            DataProvider.Ins.DB.SaveChanges();

            CustomerView customerView = new CustomerView();
            if (customerView.DataContext == null) return;
            var customerVM = customerView.DataContext as CustomerViewModel;
            customerVM.RemoveCustomer(result);
            IsRemove = true;
        }

        public void Clear()
        {
            this.TenKhachHang = null;
            this.CCCD = null;
            this.NgaySinh = null;
            this.GioiTinh = null;
            this.LoaiKhachHang = null;
            this.SoDienThoai = null;
        }
    }
}
