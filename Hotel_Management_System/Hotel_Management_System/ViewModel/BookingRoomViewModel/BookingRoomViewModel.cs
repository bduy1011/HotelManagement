using Hotel_Management_System.Model;
using Hotel_Management_System.View.BookingRoomView;
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
    public class BookingRoomViewModel : BaseViewModel
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

        private ObservableCollection<KHACHHANG> _addCustomers;
        public ObservableCollection<KHACHHANG> AddCustomers
        {
            get { return _addCustomers; }
            set
            {
                _addCustomers = value;
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
        public ICommand BookingRoomCommand { get; set; }

        public BookingRoomViewModel(PHONG room, DateTime dateTime) : this()
        {
            ReservationBill = new PHIEUDATPHONG();
            UsageBill = new PHIEUSUDUNG();

            Room = room;
            ReservationBill.NgayDen = dateTime;

            RoomFee = "0";
            SumFee = RoomFee;
            RemainingCosts = RoomFee;
            ServicesFee = "0";
            DownPayment = "";
            CompletelyPayment = "0";
            TotalDayReservation = "#";
            CountDay = 0;
        }

        public BookingRoomViewModel()
        {
            LoadedWindowCommand = new RelayCommand<MainWindow>((p) => { return true; }, (p) =>
            {
                if (DataProvider.Ins.DB.PHIEUDATPHONGs.Count() > 0)
                {
                    string t = DataProvider.Ins.DB.PHIEUDATPHONGs.OrderByDescending(x => x.MaPhieuDatPhong).FirstOrDefault().MaPhieuDatPhong;

                    ReservationBill.MaPhieuDatPhong = "PDP" + (int.Parse(t.Substring(3)) + 1);
                }
                else ReservationBill.MaPhieuDatPhong = "PDP10001";

                if (DataProvider.Ins.DB.PHIEUSUDUNGs.Count() > 0)
                {
                    string t = DataProvider.Ins.DB.PHIEUSUDUNGs.OrderByDescending(x => x.MaPhieuSuDung).FirstOrDefault().MaPhieuSuDung;

                    UsageBill.MaPhieuSuDung = "PSD" + (int.Parse(t.Substring(3)) + 1);
                }
                else UsageBill.MaPhieuSuDung = "PSD10001";

                // Thiết lập thông tin phiếu đặt phòng
                ReservationBill.MaPhieuSuDung = UsageBill.MaPhieuSuDung;
                ReservationBill.MaPhong = Room.MaPhong;
                ReservationBill.NgayLap = DateTime.Now;
                TimeReserved = ReservationBill.NgayDen.Value.ToString("HH:mm");

                // Thiết lập thông tin phiếu sử dụng
                UsageBill.NgayLap = ReservationBill.NgayLap;

                SelectedServices = new ObservableCollection<CT_PHIEUDICHVU>();

                SelectedCommoditys = new ObservableCollection<CT_PHIEUHANGHOA>();

                ShowSelectedServices = new ObservableCollection<CT_PHIEUDICHVU>();

                tmpServices = new ObservableCollection<DICHVU>();

                tmpCommoditys = new ObservableCollection<HANGHOA>();

                AddCustomers = new ObservableCollection<KHACHHANG>();

                KHACHHANG kh = new KHACHHANG();
                kh.STT = 1;
                AddCustomers.Add(kh);

                AddCustomers.CollectionChanged += AddCustomers_CollectionChanged;
            });

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
                for (int i = 0; i < AddCustomers.Count; i++)
                {
                    var item = AddCustomers[i];
                    var propertyInfo = item.GetType().GetProperty("IsLastRow");
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(item, i == AddCustomers.Count - 1);
                    }
                }
            });

            AddCustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                // Giới hạn số người trong 1 phòng tối đa là 8
                if(AddCustomers.Count < 8)
                {
                    KHACHHANG kh = new KHACHHANG();
                    AddCustomers.Add(kh);
                    int t = 1;
                    foreach (var item in AddCustomers)
                    {
                        item.STT = t++;
                    }
                }
            });

            RemoveCustomerCommand = new RelayCommand<KHACHHANG>((p) => { return AddCustomers.Count > 1; }, (p) =>
            {
                foreach (var item in AddCustomers)
                { 
                    if (item.STT == p.STT)
                    {
                        AddCustomers.Remove(item);
                        break;
                    }
                }
          
                for (int i = 0; i < AddCustomers.Count; i++)
                {
                    var item = AddCustomers[i];
                    item.IsLastRow = (i == AddCustomers.Count - 1);
                }

                int t = 1;
                foreach (var item in AddCustomers)
                {
                    item.STT = t++;
                }
            });

            BackCommand = new RelayCommand<BookingRoomView>((p) => { return true; }, (p) => { p.Close(); });
            
            BookingRoomCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (CheckInformReservation())
                {
                    foreach (var item in AddCustomers)
                    {
                        // Nếu là khách hàng rỗng thì bỏ qua, không thêm vào CSDL
                        if (item.TrangThai == null) continue;
                        // Check khách hàng trùng lặp
                        if (!DataProvider.Ins.DB.KHACHHANGs.Select(x => x.CCCD).Contains(item.CCCD))
                        {
                            string temp;
                            try
                            {
                                temp = AddCustomers[AddCustomers.Count - 1].MaKhachHang;
                            }
                            catch
                            {
                                temp = "KH" + 10000.ToString();
                            }
                            item.MaKhachHang = "KH" + (int.Parse(temp.Substring(2)) + 1).ToString();
                            ReservationBill.KHACHHANGs.Add(item);
                        }
                        else ReservationBill.KHACHHANGs.Add(DataProvider.Ins.DB.KHACHHANGs.Where(x => x.CCCD == item.CCCD).SingleOrDefault());
                    }

                    UsageBill.TriGia = int.Parse(ServicesFee);
                    UsageBill.TrangThai = "Chưa giao";

                    ReservationBill.DonGia = int.Parse(SumFee);

                    if (DownPayment == "") ReservationBill.TienCoc = 0;
                    else ReservationBill.TienCoc = int.Parse(DownPayment);

                    ReservationBill.SoNguoi = (short)ReservationBill.KHACHHANGs.Count();

                    if (ReservationBill.NgayDen.Value.Date == DateTime.Now.Date) ReservationBill.TrangThai = "Được thuê";
                    else ReservationBill.TrangThai = "Được đặt";

                    Room.TrangThai = ReservationBill.TrangThai;

                    DataProvider.Ins.DB.PHIEUSUDUNGs.Add(UsageBill);
                    DataProvider.Ins.DB.SaveChanges();

                    DataProvider.Ins.DB.CT_PHIEUDICHVU.AddRange(SelectedServices);
                    DataProvider.Ins.DB.CT_PHIEUHANGHOA.AddRange(SelectedCommoditys);
                    foreach (CT_PHIEUHANGHOA item in SelectedCommoditys)
                    {
                        item.HANGHOA.TonKho -= item.SoLuong;
                    }

                    DataProvider.Ins.DB.PHIEUDATPHONGs.Add(ReservationBill);
                    DataProvider.Ins.DB.SaveChanges();

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
                for (int i = 0; i < AddCustomers.Count; i++)
                {
                    var item = AddCustomers[i];
                    item.IsLastRow = (i == AddCustomers.Count - 1);
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
            foreach (var item in AddCustomers)
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
    }
}
