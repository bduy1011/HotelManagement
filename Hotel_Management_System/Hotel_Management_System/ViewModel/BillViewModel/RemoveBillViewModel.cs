using Hotel_Management_System.Model;
using Hotel_Management_System.View.BillView;
using Hotel_Management_System.View.BookingRoomView;
using Hotel_Management_System.View.CustomerView;
using Hotel_Management_System.View.StaffView;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
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
    public class RemoveBillViewModel : BaseViewModel
    {
        public const string TRONG = "Trống";
        public const string DUOC_THUE = "Được thuê";
        public const string DUOC_DAT = "Được đặt";
        public const string CHUA_THANH_TOAN = "Chưa thanh toán";
        public const string DA_THANH_TOAN = "Đã thanh toán";
        public const string DA_HUY = "Đã hủy";

        private ObservableCollection<PHIEUDATPHONG> _selectedPDPs;
        public ObservableCollection<PHIEUDATPHONG> SelectedPDPs
        {
            get { return _selectedPDPs; }
            set { _selectedPDPs = value; OnPropertyChanged(); }
        }

        private ObservableCollection<CT_PHIEUDICHVU> _showSselectedServices;
        public ObservableCollection<CT_PHIEUDICHVU> ShowSelectedServices
        {
            get { return _showSselectedServices; }
            set
            {
                _showSselectedServices = value;
                OnPropertyChanged();
            }
        }

        private string _sumFee;
        public string SumFee
        {
            get { return _sumFee; }
            set { _sumFee = value; OnPropertyChanged(); }
        }

        private string _servicesFee;
        public string ServicesFee
        {
            get { return _servicesFee; }
            set { _servicesFee = value; OnPropertyChanged(); }
        }

        private string _roomFee;
        public string RoomFee
        {
            get { return _roomFee; }
            set { _roomFee = value; OnPropertyChanged(); }
        }

        private string _remainingCosts;
        public string RemainingCosts
        {
            get { return _remainingCosts; }
            set
            {
                if (_remainingCosts != value)
                {
                    _remainingCosts = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _downPayment;
        public string DownPayment
        {
            get { return _downPayment; }
            set
            {
                if (_downPayment != value)
                {
                    _downPayment = value;
                    OnPropertyChanged();
                }
            }
        }

        private HOADON _bill;
        public HOADON Bill
        {
            get { return _bill; }
            set
            {
                if (_bill != value)
                {
                    _bill = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<KHACHHANG> _customerList;
        public ObservableCollection<KHACHHANG> CustomerList
        {
            get { return _customerList; }
            set
            {
                if (_customerList != value)
                {
                    _customerList = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand BackCommand { get; set; }
        public ICommand RemoveBillCommand { get; set; }

        public RemoveBillViewModel(HOADON hd) : this()
        {
            Bill = hd;
            Bill.KHACHHANG = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MaKhachHang == Bill.MaKhachHang).FirstOrDefault();
            SelectedPDPs = new ObservableCollection<PHIEUDATPHONG>();
            foreach(var item in DataProvider.Ins.DB.CT_HOADON.Where(x => x.MaHoaDon == Bill.MaHoaDon))
            {
                SelectedPDPs.Add(DataProvider.Ins.DB.PHIEUDATPHONGs.Where(x => x.MaPhieuDatPhong == item.MaPhieuDatPhong).FirstOrDefault());
            }
            Update();
        }

        public RemoveBillViewModel()
        {
            BackCommand = new RelayCommand<RemoveBillView>((p) => { return true; }, (p) => { p.Close(); });

            RemoveBillCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                try
                {
                    Bill.TrangThai = DA_HUY;
                    foreach (var item in SelectedPDPs)
                    {
                        item.TrangThai = CHUA_THANH_TOAN;
                        DataProvider.Ins.DB.PHIEUDATPHONGs.AddOrUpdate(item);
                    }
                    DataProvider.Ins.DB.HOADONs.AddOrUpdate(Bill);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Hủy thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    p.Close();
                }
                catch
                {
                    MessageBox.Show("Hủy không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        public void Update()
        {
            int j = 1;
            foreach (var item in SelectedPDPs)
            {
                item.STT = j++;
            }
            ShowSelectedServices = new ObservableCollection<CT_PHIEUDICHVU>();
            CustomerList = new ObservableCollection<KHACHHANG>();
            int roomFee = 0;
            int servicesFee = 0;
            int sumFee = 0;
            int downPayment = 0;
            int remainingCosts = 0;
            int i = 1;
            foreach (var item in SelectedPDPs)
            {
                item.STT = i++;
                foreach (var kh in item.KHACHHANGs) { CustomerList.Add(kh); }
                foreach (var dv in item.PHIEUSUDUNG.CT_PHIEUDICHVU) { dv.tmpMaPDP = item.MaPhieuDatPhong; ShowSelectedServices.Add(dv); servicesFee += (int)dv.ThanhTien; };
                foreach (var hh in item.PHIEUSUDUNG.CT_PHIEUHANGHOA) { hh.tmpMaPDP = item.MaPhieuDatPhong; ShowSelectedServices.Add(ChangeToCT_PhieuDichVu(hh)); servicesFee += (int)hh.ThanhTien; }
                sumFee += (int)item.DonGia;
                downPayment += (int)item.TienCoc;
            }
            roomFee = sumFee - servicesFee;
            remainingCosts = sumFee - downPayment;

            int t = 1;
            foreach (var item in ShowSelectedServices)
            {
                item.STT = t++;
            }

            RoomFee = roomFee.ToString();
            ServicesFee = servicesFee.ToString();
            SumFee = sumFee.ToString();
            DownPayment = downPayment.ToString();
            RemainingCosts = remainingCosts.ToString();
        }

        public CT_PHIEUDICHVU ChangeToCT_PhieuDichVu(CT_PHIEUHANGHOA ctphh)
        {
            DICHVU dv = new DICHVU();
            dv.MaDichVu = ctphh.HANGHOA.MaHangHoa;
            dv.TenDichVu = ctphh.HANGHOA.TenHangHoa;
            dv.DonGia = ctphh.HANGHOA.DonGiaBan;
            dv.DonViTinh = ctphh.HANGHOA.DonViTinh;
            CT_PHIEUDICHVU ctpdv = new CT_PHIEUDICHVU(dv);
            ctpdv.SoLuong = ctphh.SoLuong;
            ctpdv.ThanhTien = ctphh.ThanhTien;
            ctpdv.tmpMaPDP = ctphh.tmpMaPDP;
            return ctpdv;
        }
    }
}
