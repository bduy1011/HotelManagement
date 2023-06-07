using Hotel_Management_System.Model;
using Hotel_Management_System.View.BookingRoomView;
using Hotel_Management_System.View.CustomerView;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotel_Management_System.ViewModel.BookingRoomViewModel
{
    public class RemoveBookingRoomViewModel : BaseViewModel
    {
        private ObservableCollection<PHIEUDATPHONG> _selectedReservedBillItem;
        public ObservableCollection<PHIEUDATPHONG> SelectedReservedBillItem
        {
            get { return _selectedReservedBillItem; }
            set { _selectedReservedBillItem = value; OnPropertyChanged(); }
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

        private PHONG _room;
        public PHONG Room
        {
            get { return _room; }
            set
            {
                _room = value;
                OnPropertyChanged();
            }
        }

        private PHIEUSUDUNG _usageBill;
        public PHIEUSUDUNG UsageBill
        {
            get { return _usageBill; }
            set
            {
                _usageBill = value;
                OnPropertyChanged();
            }
        }

        private PHIEUDATPHONG _reservationBill;
        public PHIEUDATPHONG ReservationBill
        {
            get { return _reservationBill; }
            set
            {
                _reservationBill = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<KHACHHANG> _customers;
        public ObservableCollection<KHACHHANG> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
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
        private string _completelyPayment;
        private string _downPayment;
        private double _countDay;
        private string _totalDayReservation;
        private string _timeReserved;

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

        public string CompletelyPayment
        {
            get { return _completelyPayment; }
            set
            {
                if (_completelyPayment != value)
                {
                    _completelyPayment = value;
                    OnPropertyChanged();
                }
            }
        }

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

        public double CountDay
        {
            get { return _countDay; }
            set
            {
                if (_countDay != value)
                {
                    _countDay = value;
                    OnPropertyChanged();
                }
            }
        }

        public string TotalDayReservation
        {
            get { return _totalDayReservation; }
            set
            {
                if (_totalDayReservation != value)
                {
                    _totalDayReservation = value;
                    OnPropertyChanged();
                }
            }
        }

        public string TimeReserved
        {
            get { return _timeReserved; }
            set
            {
                if (_timeReserved != value)
                {
                    _timeReserved = value;
                    OnPropertyChanged();
                }
            }
        }

        ObservableCollection<CT_PHIEUDICHVU> ct_PHIEUDICHVU;
        ObservableCollection<CT_PHIEUHANGHOA> ct_PHIEUHANGHOA;

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand LoadedCustomerCommand { get; set; }
        public ICommand AddCustomerCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand RemoveBookingRoomCommand { get; set; }

        public RemoveBookingRoomViewModel(PHIEUDATPHONG ReservedBill) : this()
        {
            // Lấy thông tin phiếu đặt phòng
            this.ReservationBill = ReservedBill;
            // Lấy thông tin phiếu sử dụng
            UsageBill = ReservedBill.PHIEUSUDUNG;
            // Lấy thông tin phòng
            Room = ReservedBill.PHONG;
            // Lấy danh sách khách hàng
            Customers = new ObservableCollection<KHACHHANG>();
            foreach (KHACHHANG item in ReservedBill.KHACHHANGs) Customers.Add(item);

            ShowSelectedServices = new ObservableCollection<CT_PHIEUDICHVU>();
            ct_PHIEUDICHVU = new ObservableCollection<CT_PHIEUDICHVU>
                (DataProvider.Ins.DB.CT_PHIEUDICHVU.Where(x => x.MaPhieuSuDung == UsageBill.MaPhieuSuDung));
            ct_PHIEUHANGHOA = new ObservableCollection<CT_PHIEUHANGHOA>
                (DataProvider.Ins.DB.CT_PHIEUHANGHOA.Where(x => x.MaPhieuSuDung == UsageBill.MaPhieuSuDung));
            
            foreach (var item in ct_PHIEUDICHVU)
            {
                ShowSelectedServices.Add(item);
            }
            
            foreach (var item in ct_PHIEUHANGHOA)
            {
                ShowSelectedServices.Add(ChangeToCT_PhieuDichVu(item));
            }
            
            int i = 1;
            foreach (var item in ShowSelectedServices)
            {
                item.STT = i++;
            }
            
            // Tổng tiền dịch vụ/hàng hóa
            int servicesFee = 0;
            foreach (var item in ct_PHIEUDICHVU) { servicesFee += (int)item.ThanhTien; }
            foreach (var item in ct_PHIEUHANGHOA) { servicesFee += (int)item.ThanhTien; }
            ServicesFee = servicesFee.ToString();
            // Tính số đêm ở khách sạn
            TotalCountDay();
            // Lấy số liệu
            SumFee = (int.Parse(RoomFee) + int.Parse(ServicesFee)).ToString();
            DownPayment = ReservationBill.TienCoc.ToString();
            RemainingCosts = (int.Parse(SumFee) - int.Parse(DownPayment)).ToString();
        }

        public RemoveBookingRoomViewModel()
        {
            BackCommand = new RelayCommand<RemoveBookingRoomView>((p) => { return true; }, (p) => { p.Close(); });

            RemoveBookingRoomCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                // Trả số lượng hàng hóa về kho
                foreach(var item in ct_PHIEUHANGHOA) 
                {
                    item.HANGHOA.TonKho += item.SoLuong;
                }
                ReservationBill.TrangThai = "Đã hủy";
                ReservationBill.PHIEUSUDUNG.TrangThai = "Đã hủy";
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Hủy thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                p.Close();
            });
        }

        public CT_PHIEUDICHVU ChangeToCT_PhieuDichVu(CT_PHIEUHANGHOA ctphh)
        {
            DICHVU dv = new DICHVU();
            dv.MaDichVu = ctphh.HANGHOA.MaHangHoa;
            dv.TenDichVu = ctphh.HANGHOA.TenHangHoa;
            dv.DonGia = ctphh.HANGHOA.DonGiaBan;
            dv.DonViTinh = ctphh.HANGHOA.DonViTinh;
            CT_PHIEUDICHVU ctpdv = new CT_PHIEUDICHVU(dv);
            ctpdv.STT = ctphh.STT;
            ctpdv.SoLuong = ctphh.SoLuong;
            ctpdv.ThanhTien = ctphh.ThanhTien;
            return ctpdv;
        }

        public void TotalCountDay()
        {
            if (ReservationBill.NgayDi >= ReservationBill.NgayDen && ReservationBill.NgayDi != null && ReservationBill.NgayDen != null)
            {
                CountDay = (ReservationBill.NgayDi.Value.Date - ReservationBill.NgayDen.Value.Date).Days;
                if (ReservationBill.NgayDen.Value.Hour >= 0 && ReservationBill.NgayDen.Value.Hour < 7)
                {
                    // Thuê phòng khoảng từ 0 giờ - 7 giờ sáng và ở đến 12 giờ trưa cùng ngày được tính là 1 đêm
                    CountDay += 1;
                }
                else if (ReservationBill.NgayDen.Value.Hour >= 7 && ReservationBill.NgayDen.Value.Hour < 12)
                {
                    // Phụ thu thêm số tiền = 1/4 giá thuê phòng 1 đêm
                    CountDay += 0.25;
                }
                if (CountDay == Math.Floor(CountDay)) TotalDayReservation = String.Format("{0} đêm", CountDay);
                else TotalDayReservation = String.Format("{0} đêm có phụ thu", Math.Floor(CountDay));
                RoomFee = (CountDay * Room.LOAIPHONG.DonGia).ToString();
            }
        }
    }
}
