using Hotel_Management_System.Model;
using Hotel_Management_System.View;
using Hotel_Management_System.View.CommodityView;
using Hotel_Management_System.View.StaffView;
using Hotel_Management_System.ViewModel.Other;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel_Management_System.ViewModel.CommodityViewModel
{
    public class AddCommodityViewModel : BaseViewModel
    {

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand AddCommodityCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }

        public BrushConverter converter = new BrushConverter();
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public short? TonKho { get; set; }
        public string DonViTinh { get; set; }
        public int? DonGiaNhap { get; set; }
        public int? DonGiaBan { get; set; }

        public AddCommodityViewModel()
        {
            LoadedWindowCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { LoadedWindow(p); });

            AddCommodityCommand = new RelayCommand<TextBox>((p) => { return CheckAdd(); }, (p) => { AddCommodity(); });

            BackCommand = new RelayCommand<AddCommodityView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<AddCommodityView>((p) => { return true; }, (p) => { Clear(); });
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
                temp = DataProvider.Ins.DB.HANGHOAs.OrderByDescending(cus => cus.MaHangHoa).FirstOrDefault().MaHangHoa;
            }
            catch
            {
                temp = "HH" + 10000.ToString();
            }
            MaHangHoa = "HH" + (int.Parse(temp.Substring(2)) + 1).ToString();
            tb.Text = MaHangHoa;
        }

        public void AddCommodity()
        {
            try
            {
                var commodity = new HANGHOA()
                {
                    MaHangHoa = this.MaHangHoa,
                    TenHangHoa = this.TenHangHoa,
                    TonKho = this.TonKho,
                    DonViTinh = this.DonViTinh,
                    DonGiaNhap = this.DonGiaNhap,
                    DonGiaBan = this.DonGiaBan,
                };

                DataProvider.Ins.DB.HANGHOAs.Add(commodity);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool CheckAdd()
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
