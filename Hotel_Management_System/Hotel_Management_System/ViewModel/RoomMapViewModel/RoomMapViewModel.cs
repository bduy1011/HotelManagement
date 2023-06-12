using Hotel_Management_System.Model;
using Hotel_Management_System.View.BookingRoomView;
using Hotel_Management_System.ViewModel.Other;
using Hotel_Management_System.ViewModel.BookingRoomViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotel_Management_System.ViewModel.RoomMapViewModel
{
    public class RoomMapViewModel : BaseViewModel
    {
        static string TRONG = "Trống";
        static string DUOC_THUE = "Được thuê";
        static string DUOC_DAT = "Được đặt";
        static string CHUA_THANH_TOAN = "Chưa thanh toán";
        static string DA_THANH_TOAN = "Đã thanh toán";
        static string DA_HUY = "Đã hủy";

        private string _vacant;
        public string Vacant
        {
            get { return _vacant; }
            set
            {
                if (_vacant != value)
                {
                    _vacant = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _occupied;
        public string Occupied
        {
            get { return _occupied; }
            set
            {
                if (_occupied != value)
                {
                    _occupied = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _reserved;
        public string Reserved
        {
            get { return _reserved; }
            set
            {
                if (_reserved != value)
                {
                    _reserved = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _dirty;
        public string Dirty
        {
            get { return _dirty; }
            set
            {
                if (_dirty != value)
                {
                    _dirty = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _outOfOrderRoom;
        public string OutOfOrderRoom
        {
            get { return _outOfOrderRoom; }
            set
            {
                if (_outOfOrderRoom != value)
                {
                    _outOfOrderRoom = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _stateColor;
        public string StateColor
        {
            get { return _stateColor; }
            set
            {
                if (_stateColor != value)
                {
                    _stateColor = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _numberOfRoom;
        public string NumberOfRoom
        {
            get { return _numberOfRoom; }
            set
            {
                _numberOfRoom = value;
                OnPropertyChanged();
            }
        }

        private string _vacantNumber;
        public string VacantNumber
        {
            get { return _vacantNumber; }
            set
            {
                _vacantNumber = value;
                OnPropertyChanged();
            }
        }

        private string _occupiedNumber;
        public string OccupiedNumber
        {
            get { return _occupiedNumber; }
            set
            {
                _occupiedNumber = value;
                OnPropertyChanged();
            }
        }

        private string _reservedNumber;
        public string ReservedNumber
        {
            get { return _reservedNumber; }
            set
            {
                _reservedNumber = value;
                OnPropertyChanged();
            }
        }

        private string _dirtyNumber;
        public string DirtyNumber
        {
            get { return _dirtyNumber; }
            set
            {
                _dirtyNumber = value;
                OnPropertyChanged();
            }
        }

        private string _outOfOrderRoomNumber;
        public string OutOfOrderRoomNumber
        {
            get { return _outOfOrderRoomNumber; }
            set
            {
                _outOfOrderRoomNumber = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _selectedCheckDate = null;
        public DateTime? SelectedCheckDate
        {
            get { return _selectedCheckDate; }
            set
            {
                if (_selectedCheckDate != value)
                {
                    _selectedCheckDate = value;
                    DateTime dateTime;
                    if (_selectedCheckDate.Value.Date == DateTime.Now.Date)
                    {
                        dateTime = _selectedCheckDate.Value.Date + DateTime.Now.TimeOfDay;
                    }
                    else dateTime = _selectedCheckDate.Value.Date + new TimeSpan(14, 0, 0);
                    _selectedCheckDate = dateTime;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime? _dateOfCheckIn = null;
        public DateTime? DateOfCheckIn
        {
            get { return _dateOfCheckIn; }
            set
            {
                _dateOfCheckIn = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _dateOfCheckOut = null;
        public DateTime? DateOfCheckOut
        {
            get { return _dateOfCheckOut; }
            set
            {
                _dateOfCheckOut = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<PHONG> _rooms;
        public ObservableCollection<PHONG> Rooms
        {
            get { return _rooms; }
            set
            {
                _rooms = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<PHONG> _emptyRoomList;
        public ObservableCollection<PHONG> EmptyRoomList
        {
            get { return _emptyRoomList; }
            set
            {
                _emptyRoomList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<PHIEUDATPHONG> _reservedBills;
        public ObservableCollection<PHIEUDATPHONG> ReservedBills
        {
            get { return _reservedBills; }
            set
            {
                if (_reservedBills != value)
                {
                    _reservedBills = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<PHIEUDATPHONG> _tmpReservedBills;
        public ObservableCollection<PHIEUDATPHONG> tmpReservedBills
        {
            get { return _tmpReservedBills; }
            set
            {
                if (_tmpReservedBills != value)
                {
                    _tmpReservedBills = value;
                    OnPropertyChanged();
                }
            }
        }

        private PHIEUDATPHONG _selectedReservedBillItem;
        public PHIEUDATPHONG SelectedReservedBillItem
        {
            get { return _selectedReservedBillItem; }
            set
            {
                if (_selectedReservedBillItem != value)
                {
                    _selectedReservedBillItem = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<PHONG> _items;
        public ObservableCollection<PHONG> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand BookingRoomCommand { get; set; }
        public ICommand CheckDateSelectedDateChangedCommand { get; set; }
        public ICommand SearchDateSelectedDateChangedCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SearchReservedBillCommand { get; set; }
        public ICommand TraPhongCommand { get; set; }
        public ICommand HuyPhongCommand { get; set; }
        public ICommand NhanPhongCommand { get; set; }

        public int numberOfRoom;
        public int vacantNumber;
        public int occupiedNumber;
        public int reservedNumber;

        public RoomMapViewModel()
        {
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Vacant = "#00DD00";
                Occupied = "#FF3333";
                Reserved = "#00BFFF";
                Dirty = "#FFB347";
                OutOfOrderRoom = "#AF69EE"; 

                SelectedCheckDate = DateTime.Now;
                try
                {
                    Rooms = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
                }
                catch { }
                LoadReservedBill();
                EmptyRoomList = new ObservableCollection<PHONG>();

                UpdateRoomState();
            });
                
            BookingRoomCommand = new RelayCommand<PHONG>((p) => { return true; }, (p) => 
            {
                if (p.TrangThai == TRONG)
                {
                    try
                    {
                        BookingRoomView bookingRoomView = new BookingRoomView();
                        bookingRoomView.DataContext = new BookingRoomViewModel.BookingRoomViewModel(p, (DateTime)SelectedCheckDate);
                        bookingRoomView.ShowDialog();

                        if (bookingRoomView.DataContext == null) return;
                        var bookingRoomViewModel = bookingRoomView.DataContext as BookingRoomViewModel.BookingRoomViewModel;

                        p.TrangThai = bookingRoomViewModel.Room.TrangThai;
                    }
                    catch
                    {
                        MessageBox.Show("Đặt phòng không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                UpdateRoomState();
                LoadReservedBill();
            });

            RemoveCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    RemoveBookingRoomView removeBookingRoomView = new RemoveBookingRoomView();
                    removeBookingRoomView.DataContext = new RemoveBookingRoomViewModel(SelectedReservedBillItem);
                    removeBookingRoomView.ShowDialog();
                    UpdateRoomState();
                    LoadReservedBill();
                }
                catch
                {
                    MessageBox.Show("Hủy không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    DateTime ngayDen = SelectedReservedBillItem.NgayDen.Value;
                    DateTime ngayDi = SelectedReservedBillItem.NgayDi.Value;
                    List<KHACHHANG> tmpCustomers = new List<KHACHHANG>();
                    for (int i = 0; i < SelectedReservedBillItem.KHACHHANGs.Count; i++)
                    {
                        KHACHHANG customer = new KHACHHANG();
                        customer.STT = SelectedReservedBillItem.KHACHHANGs.ElementAt(i).STT;
                        customer.MaKhachHang = SelectedReservedBillItem.KHACHHANGs.ElementAt(i).MaKhachHang;
                        customer.CCCD = SelectedReservedBillItem.KHACHHANGs.ElementAt(i).CCCD;
                        customer.TenKhachHang = SelectedReservedBillItem.KHACHHANGs.ElementAt(i).TenKhachHang;
                        customer.GioiTinh = SelectedReservedBillItem.KHACHHANGs.ElementAt(i).GioiTinh;
                        customer.NgaySinh = SelectedReservedBillItem.KHACHHANGs.ElementAt(i).NgaySinh;
                        customer.SoDienThoai = SelectedReservedBillItem.KHACHHANGs.ElementAt(i).SoDienThoai;
                        customer.LoaiKhachHang = SelectedReservedBillItem.KHACHHANGs.ElementAt(i).LoaiKhachHang;
                        tmpCustomers.Add(customer);
                    }
                    List<short> tmpAmountServices = new List<short>();
                    for (int i = 0; i < SelectedReservedBillItem.PHIEUSUDUNG.CT_PHIEUDICHVU.Count; i++)
                    {
                        short? soLuong = SelectedReservedBillItem.PHIEUSUDUNG.CT_PHIEUDICHVU.ElementAt(i).SoLuong;
                        tmpAmountServices.Add((short)soLuong);
                    }
                    List<short> tmpAmountCommoditys = new List<short>();
                    for (int i = 0; i < SelectedReservedBillItem.PHIEUSUDUNG.CT_PHIEUHANGHOA.Count; i++)
                    {
                        short? soLuong = SelectedReservedBillItem.PHIEUSUDUNG.CT_PHIEUHANGHOA.ElementAt(i).SoLuong;
                        tmpAmountCommoditys.Add((short)soLuong);
                    }
                    EditBookingRoomView editBookingRoomView = new EditBookingRoomView();
                    editBookingRoomView.DataContext = new EditBookingRoomViewModel(SelectedReservedBillItem);
                    editBookingRoomView.ShowDialog();

                    if (editBookingRoomView.DataContext == null) return;
                    var editBookingRoomVM = editBookingRoomView.DataContext as EditBookingRoomViewModel;

                    if (!editBookingRoomVM.IsEditBookingRoom)
                    {
                        // Load lại ngày đến và ngày đi trước đó
                        SelectedReservedBillItem.NgayDen = ngayDen;
                        SelectedReservedBillItem.NgayDi = ngayDi;
                        // Load lại danh sách khách hàng trước đó
                        SelectedReservedBillItem.KHACHHANGs.Clear();
                        SelectedReservedBillItem.KHACHHANGs = new List<KHACHHANG>(tmpCustomers);
                        // Load lại số lượng hàng hóa/dịch vụ đã chọn trước đó
                        for (int i = 0; i < tmpAmountServices.Count; i++)
                        {
                            SelectedReservedBillItem.PHIEUSUDUNG.CT_PHIEUDICHVU.ElementAt(i).SoLuong = tmpAmountServices[i];
                        }
                        for (int i = 0; i < tmpAmountCommoditys.Count; i++)
                        {
                            SelectedReservedBillItem.PHIEUSUDUNG.CT_PHIEUHANGHOA.ElementAt(i).SoLuong = tmpAmountCommoditys[i];
                        }
                    }
                    else MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    UpdateRoomState();
                    LoadReservedBill();
                }
                catch
                {
                    MessageBox.Show("Cập nhật thông tin không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            SearchReservedBillCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(p.Text))
                {
                    LoadReservedBill();
                }
                else
                {
                    ObservableCollection<PHIEUDATPHONG> result = new ObservableCollection<PHIEUDATPHONG>();
                    foreach (PHIEUDATPHONG item in DataProvider.Ins.DB.PHIEUDATPHONGs)
                    {
                        string t1 = item.NgayDen.Value.ToString("dd/MM/yyyy");
                        string t2 = item.NgayDi.Value.ToString("dd/MM/yyyy");
                        if (item.MaPhieuDatPhong.Contains(p.Text) || item.MaPhong.Contains(p.Text) || t1.Contains(p.Text) || t2.Contains(p.Text) || item.TrangThai.Contains(p.Text))
                        {
                            result.Add(item);
                        }
                    }
                    
                    ReservedBills = new ObservableCollection<PHIEUDATPHONG>();
                    
                    if (result == null) return;
                    foreach (var item in result)
                    {
                        if (item != null) ReservedBills.Add(item);
                    }
                }
            });

            CheckDateSelectedDateChangedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                UpdateRoomState();
            });

            SearchDateSelectedDateChangedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (DateOfCheckOut >= DateOfCheckIn && DateOfCheckIn != null && DateOfCheckOut != null)
                {
                    DateOfCheckIn = DateOfCheckIn.Value.Date + new TimeSpan(14, 0, 0);
                    DateOfCheckOut = DateOfCheckOut.Value.Date + new TimeSpan(12, 0, 0);
                    var ListRoom = DataProvider.Ins.DB.PHIEUDATPHONGs.Where(
                        x => x.TrangThai != DA_HUY 
                          && x.TrangThai != CHUA_THANH_TOAN 
                          && x.TrangThai != DA_THANH_TOAN 
                          && ((x.NgayDen < DateOfCheckIn && DateOfCheckIn < x.NgayDi) 
                          || (x.NgayDen < DateOfCheckOut && DateOfCheckOut < x.NgayDi)
                          || (x.NgayDen >= DateOfCheckIn && DateOfCheckOut >= x.NgayDi)
                          || (x.NgayDen <= DateOfCheckIn && DateOfCheckOut <= x.NgayDi))).Select(x => x.MaPhong).Distinct();
                    
                    EmptyRoomList = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs
                        .Where(x => !ListRoom.Contains(x.MaPhong)));
                }
                else
                {
                    EmptyRoomList.Clear();
                }
            });

            TraPhongCommand = new RelayCommand<PHONG>((p) => { return true; }, (p) =>
            {
                try
                {
                    PHIEUDATPHONG pdp = p.PHIEUDATPHONGs.Where(x => x.TrangThai == DUOC_THUE && x.NgayDen.Value <= SelectedCheckDate.Value && SelectedCheckDate.Value <= x.NgayDi.Value).FirstOrDefault();
                    pdp.TrangThai = CHUA_THANH_TOAN;
                    pdp.PHIEUSUDUNG.TrangThai = CHUA_THANH_TOAN;
                    p.StateColor = "#00DD00";
                    p.TrangThai = TRONG;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Trả phòng thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch { MessageBox.Show("Trả phòng không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error); }
            });

            HuyPhongCommand = new RelayCommand<PHONG>((p) => { return true; }, (p) => 
            {
                try
                {
                    PHIEUDATPHONG pdp = p.PHIEUDATPHONGs.Where(x => x.TrangThai == DUOC_DAT && x.NgayDen.Value <= SelectedCheckDate.Value && SelectedCheckDate.Value <= x.NgayDi.Value).FirstOrDefault();
                    // Trả số lượng hàng hóa về kho
                    try
                    {
                        foreach (CT_PHIEUHANGHOA item in pdp.PHIEUSUDUNG.CT_PHIEUHANGHOA)
                        {
                            item.HANGHOA.TonKho += item.SoLuong;
                        }
                    } catch { }
                    
                    pdp.TrangThai = DA_HUY;
                    pdp.PHIEUSUDUNG.TrangThai = DA_HUY;
                    p.StateColor = "#00DD00";
                    p.TrangThai = TRONG;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Hủy đặt phòng thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch { MessageBox.Show("Hủy phòng không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error); }
            });

            NhanPhongCommand = new RelayCommand<PHONG>((p) => { return true; }, (p) => 
            { 
                try
                {
                    PHIEUDATPHONG pdp = p.PHIEUDATPHONGs.Where(x => x.TrangThai == DUOC_DAT && x.NgayDen.Value <= SelectedCheckDate.Value && SelectedCheckDate.Value <= x.NgayDi.Value).FirstOrDefault();
                    p.StateColor = "#FF3333";
                    pdp.TrangThai = DUOC_THUE;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Nhận phòng thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                } 
                catch { MessageBox.Show("Nhận phòng không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error); }
            });
        }

        public void UpdateRoomColor()
        {
            numberOfRoom = 0;
            vacantNumber = 0;
            occupiedNumber = 0;
            reservedNumber = 0;
            
            foreach (var room in Rooms)
            {
                switch (room.TrangThai)
                {
                    case "Trống":
                        room.StateColor = Vacant;
                        vacantNumber++;
                        break;
                    case "Được đặt":
                        room.StateColor = Reserved;
                        reservedNumber++;
                        break;
                    case "Được thuê":
                        room.StateColor = Occupied;
                        occupiedNumber++;
                        break;
                    default:
                        room.TrangThai = TRONG;
                        room.StateColor = Vacant;
                        vacantNumber++;
                        break;
                }
            }

            numberOfRoom = vacantNumber + reservedNumber + occupiedNumber;

            NumberOfRoom = string.Format("Tất cả ({0})", numberOfRoom);
            VacantNumber = string.Format("Trống ({0})", vacantNumber);
            OccupiedNumber = string.Format("Được thuê ({0})", occupiedNumber); 
            ReservedNumber = string.Format("Được đặt ({0})", reservedNumber);
        }

        public void UpdateRoomState()
        {
            if (SelectedCheckDate != null)
            {
                try
                {
                    var ListRoomHaveReservedBillInCheckDate = DataProvider.Ins.DB.PHIEUDATPHONGs
                        .Where(x => x.TrangThai != DA_HUY && x.TrangThai != CHUA_THANH_TOAN  && x.TrangThai != DA_THANH_TOAN && x.NgayDen.Value <= SelectedCheckDate.Value && SelectedCheckDate.Value <= x.NgayDi.Value)
                        .Select(x => new { x.MaPhong, x.TrangThai });
 
                    var RoomStatusList = DataProvider.Ins.DB.PHONGs
                        .Select(x => new
                        {
                            x.MaPhong,
                            TrangThai = ListRoomHaveReservedBillInCheckDate
                                .Any(y => y.MaPhong == x.MaPhong) ? ListRoomHaveReservedBillInCheckDate
                                .Where(y => y.MaPhong == x.MaPhong).FirstOrDefault().TrangThai : TRONG
                        })
                        .ToList();

                    Rooms = new ObservableCollection<PHONG>(RoomStatusList.Select(x =>
                    {
                        var room = DataProvider.Ins.DB.PHONGs.Where(y => y.MaPhong == x.MaPhong).FirstOrDefault();
                        room.TrangThai = x.TrangThai;
                        return room;
                    }));
                }
                catch { }
                UpdateRoomColor();
            }
        }

        public void LoadReservedBill()
        {
            if (ReservedBills != null) ReservedBills.Clear();
            ReservedBills = new ObservableCollection<PHIEUDATPHONG>(DataProvider.Ins.DB.PHIEUDATPHONGs.Where(x => x.TrangThai == DUOC_THUE || x.TrangThai == DUOC_DAT));
            foreach (PHIEUDATPHONG item in DataProvider.Ins.DB.PHIEUDATPHONGs.Where(x => x.TrangThai == CHUA_THANH_TOAN)) ReservedBills.Add(item);
            foreach (PHIEUDATPHONG item in DataProvider.Ins.DB.PHIEUDATPHONGs.Where(x => x.TrangThai == DA_THANH_TOAN)) ReservedBills.Add(item);
            foreach (PHIEUDATPHONG item in DataProvider.Ins.DB.PHIEUDATPHONGs.Where(x => x.TrangThai == DA_HUY)) ReservedBills.Add(item);
        }
    }
}
