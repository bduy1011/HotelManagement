using Hotel_Management_System.Model;
using Hotel_Management_System.View.BillView;
using Hotel_Management_System.View.CustomerView;
using Hotel_Management_System.View.StaffView;
using Hotel_Management_System.ViewModel.CustomerViewModel;
using Hotel_Management_System.ViewModel.Other;
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

namespace Hotel_Management_System.ViewModel.BillViewModel
{
    public class BillViewModel : BaseViewModel
    {
        private NHANVIEN _nhanvien;
        public NHANVIEN nhanvien
        {
            get { return _nhanvien; }
            set
            {
                if (_nhanvien != value)
                {
                    _nhanvien = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<HOADON> _bills;
        public ObservableCollection<HOADON> bills
        {
            get { return _bills; }
            set
            {
                if (_bills != value)
                {
                    _bills = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<HOADON> _tmpBills;
        public ObservableCollection<HOADON> tmpBill
        {
            get { return _tmpBills; }
            set
            {
                if (_tmpBills != value)
                {
                    _tmpBills = value;
                    OnPropertyChanged();
                }
            }
        }

        private HOADON _selectedBillItem;
        public HOADON SelectedBillItem
        {
            get { return _selectedBillItem; }
            set
            {
                if (_selectedBillItem != value)
                {
                    _selectedBillItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoadedUserControlCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }

        public RemoveBillView removeBillView;
        public AddBillView addBillWindow;

        public BillViewModel(NHANVIEN nv) : this()
        {
            nhanvien = new NHANVIEN();
            nhanvien.MaNhanVien = nv.MaNhanVien;
            nhanvien.TenNhanVien = nv.TenNhanVien;
            nhanvien.ChucVu = nv.ChucVu;
            nhanvien.BoPhan = nv.BoPhan;
            nhanvien.NgaySinh = nv.NgaySinh;
            nhanvien.CCCD = nv.CCCD;
        } 

        public BillViewModel()
        {
            LoadedUserControlCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                try
                {
                    Load();
                }
                catch { return; }
            });

            SearchCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(p.Text))
                {
                    // Hiển thị lại tất cả dữ liệu nếu không có từ khóa tìm kiếm
                    bills = tmpBill;
                }
                else
                {
                    ObservableCollection<HOADON> result = new ObservableCollection<HOADON>();
                    foreach (HOADON item in DataProvider.Ins.DB.HOADONs)
                    {
                        string t = item.NgayLap.Value.ToString();
                        if (item.MaHoaDon.Contains(p.Text) || /*item.MaNhanVien.Contains(p.Text) ||*/ t.Contains(p.Text) || item.MaKhachHang.Contains(p.Text) || item.TriGia.ToString().Contains(p.Text))
                        {
                            result.Add(item);
                        }
                    }

                    bills = new ObservableCollection<HOADON>();

                    foreach (var item in result)
                    {
                        bills.Add(item);
                    }
                }
            });

            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                addBillWindow = new AddBillView();
                addBillWindow.DataContext = new AddBillViewModel(nhanvien);
                addBillWindow.ShowDialog();
                Load();
            });

            RemoveCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                removeBillView = new RemoveBillView();
                removeBillView.DataContext = new RemoveBillViewModel(SelectedBillItem);
                removeBillView.ShowDialog();
                Load();
            });
        }

        public void Load() 
        {
            bills = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADONs.Where(x => x.TrangThai != "Đã hủy"));
            foreach(var item in DataProvider.Ins.DB.HOADONs.Where(x => x.TrangThai == "Đã hủy")) bills.Add(item);
            tmpBill = bills;
        }
    }
}
