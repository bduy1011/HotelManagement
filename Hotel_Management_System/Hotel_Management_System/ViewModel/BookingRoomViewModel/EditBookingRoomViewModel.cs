using Hotel_Management_System.Model;
using Hotel_Management_System.View.BookingRoomView;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotel_Management_System.ViewModel.BookingRoomViewModel
{
    public class EditBookingRoomViewModel : BaseViewModel
    {
        private ObservableCollection<DICHVU> _services;
        public ObservableCollection<DICHVU> Services
        {
            get { return _services; }
            set { _services = value; OnPropertyChanged(); }
        }

        private ObservableCollection<HANGHOA> _commoditys;
        public ObservableCollection<HANGHOA> Commoditys
        {
            get { return _commoditys; }
            set { _commoditys = value; OnPropertyChanged(); }
        }

        private ObservableCollection<CT_PHIEUDICHVU> _selectedServices;
        public ObservableCollection<CT_PHIEUDICHVU> SelectedServices
        {
            get { return _selectedServices; }
            set { _selectedServices = value; OnPropertyChanged(); }
        }

        private ObservableCollection<CT_PHIEUHANGHOA> _selectedCommoditys;
        public ObservableCollection<CT_PHIEUHANGHOA> SelectedCommoditys
        {
            get { return _selectedCommoditys; }
            set
            {
                _selectedCommoditys = value;
                OnPropertyChanged();
            }
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

        private ObservableCollection<DICHVU> _tmpServices;
        public ObservableCollection<DICHVU> tmpServices
        {
            get { return _tmpServices; }
            set
            {
                if (_tmpServices != value)
                {
                    _tmpServices = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<HANGHOA> _tmpCommoditys;
        public ObservableCollection<HANGHOA> tmpCommoditys
        {
            get { return _tmpCommoditys; }
            set
            {
                if (_tmpCommoditys != value)
                {
                    _tmpCommoditys = value;
                    OnPropertyChanged();
                }
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

        private string _completelyPayment;
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

        private bool _isLastRow;
        public bool IsLastRow
        {
            get { return _isLastRow; }
            set
            {
                if (_isLastRow != value)
                {
                    _isLastRow = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _countDay;
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

        private string _totalDayReservation;
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

        private string _timeReserved;
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

        private bool _isCheckReserved;
        public bool IsCheckReserved
        {
            get { return _isCheckReserved; }
            set
            {
                if (_isCheckReserved != value)
                {
                    _isCheckReserved = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsEditBookingRoom { get; set; }

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand LoadedServicesCommand { get; set; }
        public ICommand LoadedCommoditysCommand { get; set; }
        public ICommand LoadedAddCustomerCommand { get; set; }
        public ICommand AddServiceCommand { get; set; }
        public ICommand AddCommodityCommand { get; set; }
        public ICommand AddCustomerCommand { get; set; }
        public ICommand RemoveSelectedServiceCommand { get; set; }
        public ICommand RemoveCustomerCommand { get; set; }
        public ICommand MoneyTextChangedCommand { get; set; }
        public ICommand AmountOfSelectedServicesTextChangedCommand { get; set; }
        public ICommand DateOfCheckOutSelectedDateChangedCommand { get; set; }
        public ICommand DateOfCheckInSelectedDateChangedCommand { get; set; }
        public ICommand SearchServicesCommand { get; set; }
        public ICommand SearchCommoditysCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand EditBookingRoomCommand { get; set; }

        public EditBookingRoomViewModel(PHIEUDATPHONG ReservedBill) : this()
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
            int t = 1;
            foreach (var item in Customers)
            {
                item.STT = t++;
            }

            ShowSelectedServices = new ObservableCollection<CT_PHIEUDICHVU>();
            SelectedServices = new ObservableCollection<CT_PHIEUDICHVU>
                (DataProvider.Ins.DB.CT_PHIEUDICHVU.Where(x => x.MaPhieuSuDung == UsageBill.MaPhieuSuDung));
            SelectedCommoditys = new ObservableCollection<CT_PHIEUHANGHOA>
                (DataProvider.Ins.DB.CT_PHIEUHANGHOA.Where(x => x.MaPhieuSuDung == UsageBill.MaPhieuSuDung));

            foreach (var item in SelectedServices)
            {
                ShowSelectedServices.Add(item);
            }

            foreach (var item in SelectedCommoditys)
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
            foreach (var item in SelectedServices) { servicesFee += (int)item.ThanhTien; }
            foreach (var item in SelectedCommoditys) { servicesFee += (int)item.ThanhTien; }
            ServicesFee = servicesFee.ToString();
            // Tính số đêm ở khách sạn
            TotalCountDay();
            // Lấy số liệu
            SumFee = (int.Parse(RoomFee) + int.Parse(ServicesFee)).ToString();
            DownPayment = ReservationBill.TienCoc.ToString();
            RemainingCosts = (int.Parse(SumFee) - int.Parse(DownPayment)).ToString();
            Customers.CollectionChanged += AddCustomers_CollectionChanged;

            IsEditBookingRoom = false;
        }

        public EditBookingRoomViewModel()
        {
            LoadedServicesCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                try
                {
                    Services = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs);
                }
                catch
                {
                    Services = new ObservableCollection<DICHVU>();
                }

                int i = 1;
                foreach (var item in Services)
                {
                    item.STT = i++;
                }
                tmpServices = Services;
            });

            LoadedCommoditysCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                try
                {
                    Commoditys = new ObservableCollection<HANGHOA>(DataProvider.Ins.DB.HANGHOAs);
                }
                catch
                {
                    Commoditys = new ObservableCollection<HANGHOA>();
                }

                int i = 1;
                foreach (var item in Commoditys)
                {
                    item.STT = i++;
                }
                tmpCommoditys = Commoditys;
            });

            AddServiceCommand = new RelayCommand<DICHVU>((p) => { return true; }, (p) =>
            {
                foreach (var item in SelectedServices)
                {
                    if (item.MaDichVu == p.MaDichVu)
                    {
                        return;
                    }
                }

                CT_PHIEUDICHVU ctpdv = new CT_PHIEUDICHVU(p);
                ctpdv.MaPhieuSuDung = UsageBill.MaPhieuSuDung;
                int tmp = ShowSelectedServices.Count;
                ctpdv.STT = ++tmp;
                ctpdv.SoLuong = 1;
                ctpdv.ThanhTien = ctpdv.SoLuong * p.DonGia;
                SelectedServices.Add(ctpdv);
                ShowSelectedServices.Add(ctpdv);
                UpdateFee(SelectedServices, SelectedCommoditys);
            });

            AddCommodityCommand = new RelayCommand<HANGHOA>((p) => { return true; }, (p) =>
            {
                foreach (var item in SelectedCommoditys)
                {
                    if (item.MaHangHoa == p.MaHangHoa)
                    {
                        return;
                    }
                }
                CT_PHIEUHANGHOA ctphh = new CT_PHIEUHANGHOA(p);
                ctphh.MaPhieuSuDung = UsageBill.MaPhieuSuDung;
                int tmp = ShowSelectedServices.Count;
                ctphh.STT = ++tmp;
                ctphh.SoLuong = 1;
                ctphh.ThanhTien = ctphh.SoLuong * p.DonGiaBan;
                SelectedCommoditys.Add(ctphh);
                ShowSelectedServices.Add(ChangeToCT_PhieuDichVu(ctphh));
                UpdateFee(SelectedServices, SelectedCommoditys);
            });

            RemoveSelectedServiceCommand = new RelayCommand<CT_PHIEUDICHVU>((p) => { return true; }, (p) =>
            {
                if (p.MaDichVu.Contains("DV"))
                {
                    SelectedServices.Remove(p);
                }
                else if (p.MaDichVu.Contains("HH"))
                {
                    foreach (var item in SelectedCommoditys)
                    {
                        if (item.MaHangHoa == p.MaDichVu)
                        {
                            SelectedCommoditys.Remove(item);
                            break;
                        }
                    }
                }
                ShowSelectedServices.Remove(p);
                int t = 1;
                foreach (var item in ShowSelectedServices)
                {
                    item.STT = t++;
                }
                UpdateFee(SelectedServices, SelectedCommoditys);
            });

            MoneyTextChangedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                UpdateFee(SelectedServices, SelectedCommoditys);
            });

            AmountOfSelectedServicesTextChangedCommand = new RelayCommand<CT_PHIEUDICHVU>((p) => { return true; }, (p) =>
            {
                if (p.MaDichVu.Contains("DV"))
                {
                    foreach (var item in SelectedServices)
                    {
                        if (item.MaDichVu == p.MaDichVu)
                        {
                            item.ThanhTien = item.SoLuong * item.DICHVU.DonGia;
                            p.ThanhTien = item.ThanhTien;
                        }
                    }
                }
                else if (p.MaDichVu.Contains("HH"))
                {
                    foreach (var item in SelectedCommoditys)
                    {
                        if (item.MaHangHoa == p.MaDichVu)
                        {
                            if (p.SoLuong > item.HANGHOA.TonKho)
                            {
                                MessageBox.Show(string.Format("Không đủ cung cấp! Số lượng tồn kho: {0} {1}", item.HANGHOA.TonKho, item.HANGHOA.DonViTinh), "Thông báo không đủ số lượng", MessageBoxButton.OK, MessageBoxImage.Information);
                                p.SoLuong = item.HANGHOA.TonKho;
                            }
                            item.SoLuong = p.SoLuong;
                            item.ThanhTien = item.SoLuong * item.HANGHOA.DonGiaBan;
                            p.ThanhTien = item.ThanhTien;
                        }
                    }
                }
                UpdateFee(SelectedServices, SelectedCommoditys);
            });

            DateOfCheckInSelectedDateChangedCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                // Thiết lập giờ cho ngày đến
                if (ReservationBill.NgayDen.Value.Date == DateTime.Now.Date)
                {
                    ReservationBill.NgayDen = ReservationBill.NgayDen.Value.Date + DateTime.Now.TimeOfDay;
                }
                else ReservationBill.NgayDen = ReservationBill.NgayDen.Value.Date + new TimeSpan(14, 0, 0);

                // Tính lại số đêm khách ở và tính tiền phòng
                TotalCountDay();
                UpdateFee(SelectedServices, SelectedCommoditys);
            });

            DateOfCheckOutSelectedDateChangedCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                // Thiết lập giờ cho ngày đi
                ReservationBill.NgayDi = ReservationBill.NgayDi.Value.Date + new TimeSpan(12, 0, 0);

                // Tính lại số đêm khách ở và tính tiền phòng
                TotalCountDay();
                UpdateFee(SelectedServices, SelectedCommoditys);
            });

            SearchServicesCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(p.Text))
                {
                    Services = tmpServices;
                }
                else
                {
                    var result = tmpServices.Where(x =>
                        x.MaDichVu.Contains(p.Text) ||
                        x.TenDichVu.Contains(p.Text) ||
                        x.DonGia.ToString().Contains(p.Text)
                    );

                    Services = new ObservableCollection<DICHVU>();

                    foreach (var item in result)
                    {
                        Services.Add(item);
                    }
                }
            });

            SearchCommoditysCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(p.Text))
                {
                    Commoditys = tmpCommoditys;
                }
                else
                {
                    var result = tmpCommoditys.Where(x =>
                        x.MaHangHoa.Contains(p.Text) ||
                        x.TenHangHoa.Contains(p.Text) ||
                        x.DonGiaBan.ToString().Contains(p.Text)
                    );

                    Commoditys = new ObservableCollection<HANGHOA>();

                    foreach (var item in result)
                    {
                        Commoditys.Add(item);
                    }
                }
            });

            LoadedAddCustomerCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                for (int i = 0; i < Customers.Count; i++)
                {
                    var item = Customers[i];
                    var propertyInfo = item.GetType().GetProperty("IsLastRow");
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(item, i == Customers.Count - 1);
                    }
                }
            });

            AddCustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                // Giới hạn số người trong 1 phòng tối đa là 8
                if (Customers.Count < 8)
                {
                    KHACHHANG kh = new KHACHHANG();
                    Customers.Add(kh);
                    int t = 1;
                    foreach (var item in Customers)
                    {
                        item.STT = t++;
                    }
                }
            });

            RemoveCustomerCommand = new RelayCommand<KHACHHANG>((p) => { return Customers.Count > 1; }, (p) =>
            {
                foreach (var item in Customers)
                {
                    if (item.STT == p.STT)
                    {
                        Customers.Remove(item);
                        break;
                    }
                }

                for (int i = 0; i < Customers.Count; i++)
                {
                    var item = Customers[i];
                    item.IsLastRow = (i == Customers.Count - 1);
                }

                int t = 1;
                foreach (var item in Customers)
                {
                    item.STT = t++;
                }
            });

            BackCommand = new RelayCommand<EditBookingRoomView>((p) => { return true; }, (p) => { p.Close(); });

            EditBookingRoomCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (CheckInformReservation())
                {
                    foreach (var item in Customers)
                    {
                        // Check khách hàng trùng lặp
                        if (item.MaKhachHang != null && item.MaKhachHang != "")
                        {
                            DataProvider.Ins.DB.KHACHHANGs.AddOrUpdate(item);
                        }
                        else
                        {
                            if (item.LoaiKhachHang == ">= 15 tuổi")
                            {
                                if (!DataProvider.Ins.DB.KHACHHANGs.Select(x => x.CCCD).Contains(item.CCCD))
                                {
                                    item.MaKhachHang = CreateIdCustomer();
                                    ReservationBill.KHACHHANGs.Add(item);
                                }
                                else
                                {
                                    ReservationBill.KHACHHANGs.Add(DataProvider.Ins.DB.KHACHHANGs.Where(x => x.CCCD == item.CCCD).SingleOrDefault());
                                }
                            }
                            else if (item.LoaiKhachHang == "< 15 tuổi")
                            {
                                if (!DataProvider.Ins.DB.KHACHHANGs.Where(x => x.TenKhachHang == item.TenKhachHang).Select(x => x.NgaySinh).Contains(item.NgaySinh))
                                {
                                    item.MaKhachHang = CreateIdCustomer();
                                    ReservationBill.KHACHHANGs.Add(item);
                                }
                                else ReservationBill.KHACHHANGs.Add(DataProvider.Ins.DB.KHACHHANGs.Where(x => x.TenKhachHang == item.TenKhachHang && x.NgaySinh == item.NgaySinh).SingleOrDefault());
                            }
                        }
                    }
                    DataProvider.Ins.DB.SaveChanges();

                    UsageBill.TriGia = int.Parse(ServicesFee);

                    ReservationBill.DonGia = int.Parse(SumFee);

                    if (DownPayment == "") ReservationBill.TienCoc = 0;
                    else ReservationBill.TienCoc = int.Parse(DownPayment);

                    ReservationBill.SoNguoi = (short)ReservationBill.KHACHHANGs.Count();

                    // Xác định trạng thái của PDP
                    if (ReservationBill.NgayDen.Value.Date == DateTime.Now.Date) ReservationBill.TrangThai = "Được thuê";
                    else ReservationBill.TrangThai = "Được đặt";

                    Room.TrangThai = ReservationBill.TrangThai;

                    // Trả hàng hóa lại trước khi xóa các phiếu hàng hóa
                    string maPSD = UsageBill.MaPhieuSuDung;
                    foreach (CT_PHIEUHANGHOA item in DataProvider.Ins.DB.CT_PHIEUHANGHOA.Where(x => x.PHIEUSUDUNG.MaPhieuSuDung == maPSD))
                    {
                        item.HANGHOA.TonKho += item.SoLuong;
                    }
                    // Xóa các hàng hóa/dịch vụ cũ
                    DataProvider.Ins.DB.CT_PHIEUDICHVU.RemoveRange(DataProvider.Ins.DB.CT_PHIEUDICHVU.Where(x => x.PHIEUSUDUNG.MaPhieuSuDung == maPSD));
                    DataProvider.Ins.DB.CT_PHIEUHANGHOA.RemoveRange(DataProvider.Ins.DB.CT_PHIEUHANGHOA.Where(x => x.PHIEUSUDUNG.MaPhieuSuDung == maPSD));
                    
                    // Sửa PSD
                    DataProvider.Ins.DB.PHIEUSUDUNGs.AddOrUpdate(UsageBill);
                    DataProvider.Ins.DB.SaveChanges();
                    // Thêm hàng hóa/dịch vụ mới cập nhật
                    DataProvider.Ins.DB.CT_PHIEUDICHVU.AddRange(SelectedServices);
                    DataProvider.Ins.DB.CT_PHIEUHANGHOA.AddRange(SelectedCommoditys);
                    foreach (CT_PHIEUHANGHOA item in SelectedCommoditys)
                    {
                        item.HANGHOA.TonKho -= item.SoLuong;
                    }

                    DataProvider.Ins.DB.PHIEUDATPHONGs.AddOrUpdate(ReservationBill);
                    DataProvider.Ins.DB.SaveChanges();

                    IsEditBookingRoom = true;
                    p.Close();
                }
            });
        }

        public void UpdateFee(ObservableCollection<CT_PHIEUDICHVU> ct_PHIEUDICHVUs, ObservableCollection<CT_PHIEUHANGHOA> ct_PHIEUHANGHOAs)
        {
            // Tổng tiền dịch vụ/hàng hóa
            int servicesFee = 0;
            foreach (var item in ct_PHIEUDICHVUs) { servicesFee += (int)item.ThanhTien; }
            foreach (var item in ct_PHIEUHANGHOAs) { servicesFee += (int)item.ThanhTien; }
            ServicesFee = servicesFee.ToString();

            // Tổng tiền phòng + dịch vụ
            int sumFee = servicesFee + int.Parse(RoomFee);
            SumFee = sumFee.ToString();

            int downPayment;
            try { downPayment = int.Parse(DownPayment); } catch { downPayment = 0; };

            // Tổng tiền còn lại phải thanh toán
            int remainingCosts = 0;
            if (sumFee > downPayment) remainingCosts = sumFee - downPayment;
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
            ctpdv.STT = ctphh.STT;
            ctpdv.SoLuong = ctphh.SoLuong;
            ctpdv.ThanhTien = ctphh.ThanhTien;
            return ctpdv;
        }

        public void AddCustomers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // Update the IsLastRow property for each item in the AddCustomers collection
                for (int i = 0; i < Customers.Count; i++)
                {
                    var item = Customers[i];
                    item.IsLastRow = (i == Customers.Count - 1);
                }
            }
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
            else
            {
                CountDay = 0;
                RoomFee = "0";
                TotalDayReservation = "#";
            }
        }

        public bool CheckInformReservation()
        {
            int countAdult = 0;
            if (ReservationBill.NgayDi == null || ReservationBill.NgayDen == null)
            {
                MessageBox.Show("Bạn chưa chọn ngày đến hoặc ngày đi!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            foreach (var item in Customers)
            {
                if (item.TenKhachHang == null || item.TenKhachHang.Trim(' ') == "")
                {
                    MessageBox.Show("Một số thông tin khách hàng chưa nhập tên", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (item.GioiTinh == null || item.GioiTinh == "")
                {
                    MessageBox.Show("Một số thông tin khách hàng chưa nhập giới tính", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (item.NgaySinh == null)
                {
                    MessageBox.Show("Một số thông tin khách hàng chưa nhập ngày sinh", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (item.LoaiKhachHang == null || item.LoaiKhachHang == "")
                {
                    MessageBox.Show("Một số thông tin khách hàng chưa có loại khách hàng", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (item.LoaiKhachHang == ">= 15 tuổi")
                {
                    if (item.CCCD == null || item.CCCD == "" || item.CCCD.Length != 12)
                    {
                        MessageBox.Show("Một số thông tin khách hàng chưa nhập hoặc nhập sai CCCD", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    if (item.SoDienThoai == null || item.SoDienThoai == "" || item.SoDienThoai.Length < 10 || item.SoDienThoai.Length > 11)
                    {
                        MessageBox.Show("Một số thông tin khách hàng chưa nhập hoặc nhập sai SĐT", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    countAdult++;
                }
            }
            if (countAdult < 1)
            {
                MessageBox.Show("Cần ít nhất có 1 khách hàng >= 15 tuổi", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public string CreateIdCustomer()
        {
            string temp;
            try
            {
                temp = DataProvider.Ins.DB.KHACHHANGs.OrderByDescending(cus => cus.MaKhachHang).FirstOrDefault().MaKhachHang;
            }
            catch
            {
                temp = "KH" + 10000.ToString();
            }
            return "KH" + (int.Parse(temp.Substring(2)) + 1).ToString();
        }
    }
}
