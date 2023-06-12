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
using Hotel_Management_System.View.ServiceView;
using System.Data.Entity.Migrations;
using System.Windows;

namespace Hotel_Management_System.ViewModel.ServiceViewModel
{
    public class RemoveServiceViewModel : BaseViewModel
    {
        public ICommand RemoveServiceCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }

        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string DonViTinh { get; set; }
        public Nullable<double> DonGia { get; set; }

        public bool IsRemove = false;

        private DICHVU _selectedServiceItem;
        public DICHVU SelectedServiceItem
        {
            get { return _selectedServiceItem; }
            set
            {
                if (_selectedServiceItem != value)
                {
                    _selectedServiceItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public RemoveServiceViewModel()
        {
            RemoveServiceCommand = new RelayCommand<object>((p) => { return true; }, (p) => { RemoveService(); });

            BackCommand = new RelayCommand<RemoveServiceView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<RemoveServiceView>((p) => { return true; }, (p) => { Clear(); });
        }

        public RemoveServiceViewModel(DICHVU SelectedServiceItem) : this()
        {
            this.SelectedServiceItem = SelectedServiceItem;
            this.MaDichVu = SelectedServiceItem.MaDichVu;
            this.TenDichVu = SelectedServiceItem.TenDichVu;
            this.DonViTinh = SelectedServiceItem.DonViTinh;
            this.DonGia = SelectedServiceItem.DonGia;
        }

        public void RemoveService()
        {
            try
            {
                DICHVU result = DataProvider.Ins.DB.DICHVUs.Where(x => x.MaDichVu == MaDichVu).FirstOrDefault();
                result.TrangThai = "Ngừng kinh doanh";
                DataProvider.Ins.DB.DICHVUs.AddOrUpdate(result);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("Hủy thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Hủy không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Clear()
        {
            this.TenDichVu = null;
            this.DonViTinh = null;
            this.DonGia = null;
        }
    }
}
