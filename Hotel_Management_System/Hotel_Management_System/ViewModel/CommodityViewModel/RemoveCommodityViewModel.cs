using Hotel_Management_System.Model;
using Hotel_Management_System.View.CommodityView;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel_Management_System.ViewModel.CommodityViewModel
{
    public class RemoveCommodityViewModel : BaseViewModel
    {
        public ICommand RemoveGoodsCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }

        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public Nullable<short> TonKho { get; set; }
        public string DonViTinh { get; set; }
        public Nullable<int> DonGiaNhap { get; set; }
        public Nullable<int> DonGiaBan { get; set; }

        public bool IsRemove = false;

        public RemoveCommodityViewModel()
        {
            RemoveGoodsCommand = new RelayCommand<object>((p) => { return true; }, (p) => { RemoveCommodity(); });

            BackCommand = new RelayCommand<RemoveCommodityView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<RemoveCommodityView>((p) => { return true; }, (p) => { Clear(); });
        }

        public RemoveCommodityViewModel(HANGHOA SelectedGoodsItem) : this()
        {
            MaHangHoa = SelectedGoodsItem.MaHangHoa;
            TenHangHoa = SelectedGoodsItem.TenHangHoa;
            TonKho = SelectedGoodsItem.TonKho;
            DonViTinh = SelectedGoodsItem.DonViTinh;
            DonGiaNhap = SelectedGoodsItem.DonGiaNhap;
            DonGiaBan = SelectedGoodsItem.DonGiaBan;
        }

        public void RemoveCommodity()
        {
            try
            {
                HANGHOA result = DataProvider.Ins.DB.HANGHOAs.Where(x => x.MaHangHoa == MaHangHoa).FirstOrDefault();
                result.TrangThai = "Ngừng kinh doanh";
                DataProvider.Ins.DB.HANGHOAs.AddOrUpdate(result);
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
            MaHangHoa = null;
            TenHangHoa = null;
            TonKho = null;
            DonViTinh = null;
            DonGiaNhap = null;
            DonGiaBan = null;
        }
    }
}
