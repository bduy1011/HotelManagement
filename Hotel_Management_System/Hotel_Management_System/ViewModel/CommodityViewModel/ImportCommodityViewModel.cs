using Hotel_Management_System.Model;
using Hotel_Management_System.View.BookingRoomView;
using Hotel_Management_System.View.CommodityView;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hotel_Management_System.ViewModel.CommodityViewModel
{
    public class ImportCommodityViewModel : BaseViewModel
    {
        public const string NGUNG_KINH_DOANH = "Ngừng kinh doanh";

        private ObservableCollection<HANGHOA> _commoditys;
        public ObservableCollection<HANGHOA> Commoditys
        {
            get { return _commoditys; }
            set
            {
                if (_commoditys != value)
                {
                    _commoditys = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<HANGHOA> _showSelectedCommoditys;
        public ObservableCollection<HANGHOA> ShowSelectedCommoditys
        {
            get { return _showSelectedCommoditys; }
            set
            {
                if (_showSelectedCommoditys != value)
                {
                    _showSelectedCommoditys = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand AddCommodityCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public ImportCommodityViewModel()
        {
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Commoditys = new ObservableCollection<HANGHOA>(DataProvider.Ins.DB.HANGHOAs.Where(x => x.TrangThai != NGUNG_KINH_DOANH));
                ShowSelectedCommoditys = new ObservableCollection<HANGHOA>();
            });

            AddCommodityCommand = new RelayCommand<HANGHOA>((p) => { return true; }, (p) =>
            {
                int i = 1;
                foreach (var item in ShowSelectedCommoditys)
                {
                    if (item.MaHangHoa == p.MaHangHoa)
                    {
                        ShowSelectedCommoditys.Remove(item);
                        foreach (HANGHOA item1 in ShowSelectedCommoditys) item1.STT = i++;
                        return;
                    }
                }
                int j = 1;
                ShowSelectedCommoditys.Add(p);
                foreach (var item in ShowSelectedCommoditys) item.STT = j++;
            });

            BackCommand = new RelayCommand<ImportCommodityView>((p) => { return true; }, (p) => { p.Close(); });

            AddCommand = new RelayCommand<ImportCommodityView>((p) => { return true; }, (p) => 
            { 
                try
                {
                    if(ShowSelectedCommoditys.Count > 0)
                    {
                        foreach(HANGHOA item in ShowSelectedCommoditys)
                        {
                            DataProvider.Ins.DB.HANGHOAs.Where(x => x.MaHangHoa == item.MaHangHoa).FirstOrDefault().TonKho += item.SoLuongNhap;
                        }
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Nhập hàng thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        p.Close();
                        ShowSelectedCommoditys.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Chưa có hàng hóa cần nhập", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch
                {
                    MessageBox.Show("Nhập hàng không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }
}
