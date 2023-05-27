using Hotel_Management_System.Model;
using Hotel_Management_System.View.CustomerView;
using Hotel_Management_System.ViewModel.Other;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel_Management_System.ViewModel.CustomerViewModel
{
    public class CustomerViewModel : BaseViewModel
    {
        private ObservableCollection<KHACHHANG> _customers;
        public ObservableCollection<KHACHHANG> customers
        {
            get { return _customers; }
            set
            {
                if (_customers != value)
                {
                    _customers = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<KHACHHANG> _tmpCustomers;
        public ObservableCollection<KHACHHANG> tmpCustomers
        {
            get { return _tmpCustomers; }
            set
            {
                if (_tmpCustomers != value)
                {
                    _tmpCustomers = value;
                    OnPropertyChanged();
                }
            }
        }

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

        public BrushConverter converter;

        public ICommand LoadedUserControlCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public RemoveCustomerView removeCustomerView;
        public EditCustomerView editCustomerView;
        public AddCustomerView addCustomerWindow;

        public CustomerViewModel()
        {
            LoadedUserControlCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                //try
                //{
                    customers = new ObservableCollection<KHACHHANG>();
                    tmpCustomers = new ObservableCollection<KHACHHANG>();

                    var customerList = DataProvider.Ins.DB.KHACHHANGs;

                    foreach (KHACHHANG item in customerList)
                    {
                        customers.Add(new KHACHHANG
                        {
                            MaKhachHang = item.MaKhachHang,
                            Character = item.TenKhachHang.ToString().Substring(0, 1),
                            BgColor = brushList((int.Parse(item.MaKhachHang.Split('H')[1]))),
                            TenKhachHang = item.TenKhachHang,
                            GioiTinh = item.GioiTinh,
                            NgaySinh = item.NgaySinh,
                            CCCD = item.CCCD,
                            LoaiKhachHang = item.LoaiKhachHang,
                            SoDienThoai = item.SoDienThoai
                        });
                    }
                    tmpCustomers = customers;
                //}
                //catch { return; }
            });

            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                addCustomerWindow = new AddCustomerView();
                addCustomerWindow.ShowDialog();
            });

            SearchCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(p.Text))
                {
                    customers = tmpCustomers;
                }
                else
                {
                    var result = tmpCustomers.Where(x =>
                        x.MaKhachHang.ToString().Contains(p.Text) ||
                        x.TenKhachHang.Contains(p.Text) ||
                        x.CCCD.Contains(p.Text) ||
                        x.LoaiKhachHang.Contains(p.Text) ||
                        x.SoDienThoai.Contains(p.Text)
                    );

                    customers = new ObservableCollection<KHACHHANG>();

                    foreach (var item in result)
                    {
                        customers.Add(new KHACHHANG
                        {
                            MaKhachHang = item.MaKhachHang,
                            Character = item.TenKhachHang.ToString().Substring(0, 1),
                            BgColor = brushList((int.Parse(item.MaKhachHang.Split('H')[1]))),
                            TenKhachHang = item.TenKhachHang,
                            GioiTinh = item.GioiTinh,
                            NgaySinh = item.NgaySinh,
                            CCCD = item.CCCD,
                            LoaiKhachHang = item.LoaiKhachHang,
                            SoDienThoai = item.SoDienThoai
                        });
                    }
                }
            });

            RemoveCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                removeCustomerView = new RemoveCustomerView();
                removeCustomerView.DataContext = new RemoveCustomerViewModel(SelectedCustomerItem);
                removeCustomerView.ShowDialog();
            });

            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                editCustomerView = new EditCustomerView();
                editCustomerView.DataContext = new EditCustomerViewModel(SelectedCustomerItem);
                editCustomerView.ShowDialog();
            });
        }

        public Brush brushList(int i)
        {
            converter = new BrushConverter();
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

        public void AddCustomer(KHACHHANG customer)
        {
            customers.Add(customer);
            MessageBox.Show("Thêm mới thông tin thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            addCustomerWindow.Close();
        }

        public void UpdateCustomer(KHACHHANG customer)
        {
            KHACHHANG customerToFind = customers.FirstOrDefault(c => c.MaKhachHang == customer.MaKhachHang);
            if (customerToFind != null)
            {
                // Sử dụng KHACHHANG customerToFind tìm thấy được
                customerToFind.TenKhachHang = customer.TenKhachHang;
                customerToFind.CCCD = customer.CCCD;
                customerToFind.GioiTinh = customer.GioiTinh;
                customerToFind.NgaySinh = customer.NgaySinh;
                customerToFind.SoDienThoai = customer.SoDienThoai;
                customerToFind.LoaiKhachHang = customer.LoaiKhachHang;
                MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // Không tìm thấy KHACHHANG trong danh sách
            }
        }

        public void RemoveCustomer(KHACHHANG customer)
        {
            customers.Remove(customer);
            customers = new ObservableCollection<KHACHHANG>();
            var customerList = DataProvider.Ins.DB.KHACHHANGs;
            foreach (var item in customerList)
            {
                customers.Add(new KHACHHANG
                {
                    MaKhachHang = item.MaKhachHang,
                    Character = item.TenKhachHang.ToString().Substring(0, 1),
                    BgColor = brushList((int.Parse(item.MaKhachHang.Split('H')[1]))),
                    TenKhachHang = item.TenKhachHang,
                    GioiTinh = item.GioiTinh,
                    NgaySinh = item.NgaySinh,
                    CCCD = item.CCCD,
                    LoaiKhachHang = item.LoaiKhachHang,
                    SoDienThoai = item.SoDienThoai
                });
            }
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            removeCustomerView.Close();
        }
    }
}
