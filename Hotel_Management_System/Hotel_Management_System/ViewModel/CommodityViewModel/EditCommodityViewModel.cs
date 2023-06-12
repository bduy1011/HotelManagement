using Hotel_Management_System.Model;
using Hotel_Management_System.View;
using Hotel_Management_System.View.CommodityView;
using Hotel_Management_System.View.StaffView;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel_Management_System.ViewModel.CommodityViewModel
{
    public class EditCommodityViewModel : BaseViewModel
    {
        public ICommand EditCommodityCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }

        public BrushConverter converter = new BrushConverter();
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public short? TonKho { get; set; }
        public string DonViTinh { get; set; }
        public int? DonGiaNhap { get; set; }
        public int? DonGiaBan { get; set; }

        private HANGHOA _selectedCommodityItem;
        public HANGHOA SelectedCommodityItem
        {
            get { return _selectedCommodityItem; }
            set
            {
                if (_selectedCommodityItem != value)
                {
                    _selectedCommodityItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public EditCommodityViewModel()
        {
            EditCommodityCommand = new RelayCommand<object>((p) => { return Check(); }, (p) => { EditCommodity(); });

            BackCommand = new RelayCommand<EditCommodityView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<EditCommodityView>((p) => { return true; }, (p) => { Clear(); });

        }

        public EditCommodityViewModel(HANGHOA SelectedCommodityItem) : this()
        {
            this.SelectedCommodityItem = SelectedCommodityItem;
            this.MaHangHoa = SelectedCommodityItem.MaHangHoa;
            this.TenHangHoa = SelectedCommodityItem.TenHangHoa;
            this.TonKho = SelectedCommodityItem.TonKho;
            this.DonViTinh = SelectedCommodityItem.DonViTinh;
            this.DonGiaNhap = SelectedCommodityItem.DonGiaNhap;
            this.DonGiaBan = SelectedCommodityItem.DonGiaBan;
        }

        public void EditCommodity()
        {
            try
            {
                var result = DataProvider.Ins.DB.HANGHOAs.Where(x => x.MaHangHoa == MaHangHoa).FirstOrDefault();

                result.TenHangHoa = this.TenHangHoa;
                result.TonKho = this.TonKho;
                result.DonViTinh = this.DonViTinh;
                result.DonGiaNhap = this.DonGiaNhap;
                result.DonGiaBan = this.DonGiaBan;

                DataProvider.Ins.DB.HANGHOAs.AddOrUpdate(result);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật thông tin không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool Check()
        {
            if (MaHangHoa != "" && TenHangHoa != "" && DonViTinh != "" && TonKho != null && DonGiaNhap != null && DonGiaBan != null)
                return true;
            else return false;
        }

        public void Clear()
        {
            MaHangHoa = null;
            TenHangHoa = null;
            TonKho = null;
            DonViTinh = null;
            DonGiaNhap = null;
            DonGiaBan = null;
        }
    }
}
