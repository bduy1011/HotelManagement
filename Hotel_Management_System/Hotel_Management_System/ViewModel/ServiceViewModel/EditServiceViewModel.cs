using Hotel_Management_System.Model;
using Hotel_Management_System.View;
using Hotel_Management_System.View.ServiceView;
using Hotel_Management_System.View.StaffView;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel_Management_System.ViewModel.ServiceViewModel
{
    public class EditServiceViewModel : BaseViewModel
    {
        public ICommand EditServiceCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }


        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string DonViTinh { get; set; }
        public Nullable<int> DonGia { get; set; }


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

        public EditServiceViewModel()
        {
            EditServiceCommand = new RelayCommand<object>((p) => { return Check(); }, (p) => { EditService(); });

            BackCommand = new RelayCommand<EditServiceView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<EditServiceView>((p) => { return true; }, (p) => { Clear(); });
        }

        public EditServiceViewModel(DICHVU SelectedServiceItem) : this()
        {
            this.SelectedServiceItem = SelectedServiceItem;
            this.MaDichVu = SelectedServiceItem.MaDichVu;
            this.TenDichVu = SelectedServiceItem.TenDichVu;
            this.DonViTinh = SelectedServiceItem.DonViTinh;
            this.DonGia = SelectedServiceItem.DonGia;
        }

        public void EditService()
        {
            var result = DataProvider.Ins.DB.DICHVUs.Where(x => x.MaDichVu.CompareTo(this.MaDichVu) == 0).Single();

            result.TenDichVu = this.TenDichVu;
            result.DonViTinh = this.DonViTinh;
            result.DonGia = this.DonGia;

            DataProvider.Ins.DB.DICHVUs.AddOrUpdate(result);
            DataProvider.Ins.DB.SaveChanges();

            ServiceView serviceView = new ServiceView();
            if (serviceView.DataContext == null) return;
            var serviceVM = serviceView.DataContext as ServiceViewModel;
            serviceVM.UpdateService(result);
        }


        public bool Check()
        {
            if (TenDichVu != "" && DonViTinh != "" && DonGia != null)
                return true;
            else return false;
        }

        public void Clear()
        {
            this.TenDichVu = null;
            this.DonViTinh = null;
            this.DonGia = null;
        }
    }
}
