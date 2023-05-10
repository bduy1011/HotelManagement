using Hotel_Management_System.Model;
using Hotel_Management_System.View;
using System;
using System.Collections.Generic;
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

namespace Hotel_Management_System.ViewModel
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
        public ICommand ShowAddCustomerViewCommand { get; set; }
        public ICommand LoadedUserControlCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public CustomerViewModel()
        {
            SearchCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(p.Text))
                {
                    // Hiển thị lại tất cả dữ liệu nếu không có từ khóa tìm kiếm
                    customers = tmpCustomers;
                }
                else
                {
                    var result = tmpCustomers.Where(x => x.TenKhachHang.Contains(p.Text));

                    customers = new ObservableCollection<KHACHHANG>();

                    foreach (var item in result)
                    {
                        customers.Add(new KHACHHANG
                        {
                            MaKhachHang = item.MaKhachHang,
                            Character = item.TenKhachHang.ToString().Substring(0, 1),
                            BgColor = brushList(item.MaKhachHang),
                            TenKhachHang = item.TenKhachHang,
                            CCCD = item.CCCD,
                            Email = item.Email,
                            SDT = item.SDT
                        });
                    }
                }
            });

            ShowAddCustomerViewCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                AddCustomerView addCustomerWindow = new AddCustomerView();
                addCustomerWindow.ShowDialog();
            });

            LoadedUserControlCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                customers = new ObservableCollection<KHACHHANG>();
                tmpCustomers = new ObservableCollection<KHACHHANG>();

                var customerList = DataProvider.Ins.DB.KHACHHANGs;

                foreach (var item in customerList)
                {
                    customers.Add(new KHACHHANG
                    {
                        MaKhachHang = item.MaKhachHang,
                        Character = item.TenKhachHang.ToString().Substring(0, 1),
                        BgColor = brushList(item.MaKhachHang),
                        TenKhachHang = item.TenKhachHang,
                        CCCD = item.CCCD,
                        Email = item.Email,
                        SDT = item.SDT
                    });
                }
                tmpCustomers = customers;
            });
        }
        public BrushConverter converter = new BrushConverter();
        public Brush brushList(int i)
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

        public void AddCustomer(KHACHHANG customer)
        {
            customers.Add(customer);
        }
    }
}
