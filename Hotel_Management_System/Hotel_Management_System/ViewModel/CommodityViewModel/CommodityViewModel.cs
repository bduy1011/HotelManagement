using Hotel_Management_System.Model;
using Hotel_Management_System.View.CommodityView;
using Hotel_Management_System.View.StaffView;
using Hotel_Management_System.ViewModel.Other;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel_Management_System.ViewModel.CommodityViewModel
{
    public class CommodityViewModel : BaseViewModel
    {
        public const string NGUNG_KINH_DOANH = "Ngừng kinh doanh";
        public const string HET_HANG = "Hết hàng";
        public const string DA_HUY = "Đã hủy";

        private ObservableCollection<HANGHOA> _commodity;
        public ObservableCollection<HANGHOA> commodity
        {
            get { return _commodity; }
            set
            {
                if (_commodity != value)
                {
                    _commodity = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<HANGHOA> _tmpCommodity;
        public ObservableCollection<HANGHOA> tmpCommodity
        {
            get { return _tmpCommodity; }
            set
            {
                if (_tmpCommodity != value)
                {
                    _tmpCommodity = value;
                    OnPropertyChanged();
                }
            }
        }

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

        public ICommand LoadedUserControlCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand ImportCommodityCommand { get; set; }

        public RemoveCommodityView removecommodityView;
        public EditCommodityView editcommodityView;
        public AddCommodityView addcommodityView;
        public ImportCommodityView importCommodityView;

        public CommodityViewModel()
        {
            LoadedUserControlCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                try
                {
                    commodity = new ObservableCollection<HANGHOA>(DataProvider.Ins.DB.HANGHOAs);
                    tmpCommodity = new ObservableCollection<HANGHOA>(DataProvider.Ins.DB.HANGHOAs);
                }
                catch { return; }
            });

            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                addcommodityView = new AddCommodityView();
                addcommodityView.ShowDialog();
                LoadCommodity();
            });

            SearchCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(p.Text))
                {
                    // Hiển thị lại tất cả dữ liệu nếu không có từ khóa tìm kiếm
                    commodity = tmpCommodity;
                }
                else
                {
                    var result = tmpCommodity.Where(x =>
                        x.MaHangHoa.ToString().Contains(p.Text)
                        || x.TenHangHoa.Contains(p.Text)
                        || x.TonKho.ToString().Contains(p.Text)
                        || x.DonViTinh.Contains(p.Text)
                        || x.DonGiaNhap.ToString().Contains(p.Text)
                        || x.DonGiaBan.ToString().Contains(p.Text)
                    );

                    commodity = new ObservableCollection<HANGHOA>();

                    foreach (var item in result)
                    {
                        commodity.Add(new HANGHOA
                        {
                            MaHangHoa = item.MaHangHoa,
                            TenHangHoa = item.TenHangHoa,
                            TonKho = item.TonKho,
                            DonViTinh = item.DonViTinh,
                            DonGiaNhap = item.DonGiaNhap,
                            DonGiaBan = item.DonGiaBan,
                        });
                    }
                }
            });

            RemoveCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                removecommodityView = new RemoveCommodityView();
                removecommodityView.DataContext = new RemoveCommodityViewModel(SelectedCommodityItem);
                removecommodityView.ShowDialog();
                LoadCommodity();
            });

            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                editcommodityView = new EditCommodityView();
                editcommodityView.DataContext = new EditCommodityViewModel(SelectedCommodityItem);
                editcommodityView.ShowDialog();
                LoadCommodity();
            });

            ImportCommodityCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                importCommodityView = new ImportCommodityView();
                importCommodityView.DataContext = new ImportCommodityViewModel();
                importCommodityView.ShowDialog();
                LoadCommodity();
            });
        }

        public void LoadCommodity()
        {
            commodity = new ObservableCollection<HANGHOA>(DataProvider.Ins.DB.HANGHOAs.Where(x => x.TrangThai != NGUNG_KINH_DOANH));
            foreach (var item in DataProvider.Ins.DB.HANGHOAs.Where(x => x.TrangThai == NGUNG_KINH_DOANH)) commodity.Add(item);
        }
    }
}
