using Hotel_Management_System.Model;
using Hotel_Management_System.View.BookingRoomView;
using Hotel_Management_System.ViewModel.Other;
using Hotel_Management_System.ViewModel.BookingRoomViewModel;
using MaterialDesignColors.ColorManipulation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Hotel_Management_System.View.CustomerView;
using Hotel_Management_System.ViewModel.CustomerViewModel;
using System.Net.NetworkInformation;

namespace Hotel_Management_System.ViewModel.RoomMapViewModel
{
    public class RoomMapViewModel : BaseViewModel
    {
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

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
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

        private KHACHHANG _selectedReservedBillItem;
        public KHACHHANG SelectedReservedBillItem
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

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand BookingRoomCommand { get; set; }
        public ICommand ReservedRoomCommand { get; set; }
        public ICommand CheckDateSelectedDateChangedCommand { get; set; }
        public ICommand DateOfCheckOutSelectedDateChangedCommand { get; set; }
        public ICommand DateOfCheckInSelectedDateChangedCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public int numberOfRoom = 0;
        public int vacantNumber = 0;
        public int occupiedNumber = 0;
        public int reservedNumber = 0;
        public int dirtyNumber = 0;
        public int outOfOrderRoomNumber = 0;

        public RoomMapViewModel()
        {

            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Vacant = "#00DD00";
                Occupied = "#FF3333";
                Reserved = "#00BFFF";
                Dirty = "#FFB347";
                OutOfOrderRoom = "#AF69EE";

                Rooms = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);

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
                        case "Cần dọn phòng":
                            room.StateColor = Dirty;
                            dirtyNumber++;
                            break;
                        case "Ngưng hoạt động":
                            room.StateColor = OutOfOrderRoom;
                            outOfOrderRoomNumber++;
                            break;
                    }

                    numberOfRoom = vacantNumber + reservedNumber + occupiedNumber + dirtyNumber + outOfOrderRoomNumber;

                    NumberOfRoom = string.Format("Tất cả ({0})", numberOfRoom);
                    VacantNumber = string.Format("Trống ({0})", vacantNumber);
                    OccupiedNumber = string.Format("Được thuê ({0})", reservedNumber);
                    ReservedNumber = string.Format("Được đặt ({0})", occupiedNumber);
                    DirtyNumber = string.Format("Phòng bẩn ({0})", dirtyNumber);
                    OutOfOrderRoomNumber = string.Format("Đang sửa ({0})", outOfOrderRoomNumber);
                    AddDataReseredBills();

                    EmptyRoomList = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
                }
            });
                
            BookingRoomCommand = new RelayCommand<PHONG>((p) => { return true; }, (p) => 
            {
                switch (p.TrangThai)
                {
                    case "Trống":
                        BookingRoomView bookingRoomView = new BookingRoomView();
                        bookingRoomView.DataContext = new BookingRoomViewModel.BookingRoomViewModel(p);
                        bookingRoomView.ShowDialog();

                        if (bookingRoomView.DataContext == null) return;
                        var bookingRoomViewModel = bookingRoomView.DataContext as BookingRoomViewModel.BookingRoomViewModel;

                        p.TrangThai = bookingRoomViewModel.Room.TrangThai;
                        break;
                    case "Được đặt":

                        break;
                    case "Được thuê":

                        break;
                    case "Cần dọn phòng":

                        break;
                    case "Ngưng hoạt động":

                        break;
                }
            });

            RemoveCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //removeCustomerView = new RemoveCustomerView();
                //removeCustomerView.DataContext = new RemoveCustomerViewModel(SelectedCustomerItem);
                //removeCustomerView.ShowDialog();
            });

            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //editCustomerView = new EditCustomerView();
                //editCustomerView.DataContext = new EditCustomerViewModel(SelectedCustomerItem);
                //editCustomerView.ShowDialog();
            });
        }

        public void AddDataReseredBills()
        {
            ReservedBills = new ObservableCollection<PHIEUDATPHONG> {
            new PHIEUDATPHONG
            {
                MaPhieuDatPhong = "PDP0001",
                MaPhieuSuDung = "PSD0001",
                MaPhong = "P001",
                NgayDen = new DateTime(2023, 6, 10),
                NgayDi = new DateTime(2023, 6, 15),
                DonGia = 1000000,
                TienCoc = 500000,
                SoNguoi = 2,
                NgayLap = new DateTime(2023, 6, 1),
                TrangThai = "Đã đặt"
            },
            new PHIEUDATPHONG
            {
                MaPhieuDatPhong = "PDP0002",
                MaPhieuSuDung = "PSD0002",
                MaPhong = "P002",
                NgayDen = new DateTime(2023, 6, 10),
                NgayDi = new DateTime(2023, 6, 15),
                DonGia = 1200000,
                TienCoc = 600000,
                SoNguoi = 3,
                NgayLap = new DateTime(2023, 6, 1),
                TrangThai = "Đã đặt"
            },
            new PHIEUDATPHONG
            {
                MaPhieuDatPhong = "PDP0003",
                MaPhieuSuDung = "PSD0003",
                MaPhong = "P002",
                NgayDen = new DateTime(2023, 6, 16),
                NgayDi = new DateTime(2023, 6, 20),
                DonGia = 1500000,
                TienCoc = 750000,
                SoNguoi = 4,
                NgayLap = new DateTime(2023, 6, 1),
                TrangThai = "Đã đặt"
            },
            new PHIEUDATPHONG
            {
                MaPhieuDatPhong = "PDP0004",
                MaPhieuSuDung = "PSD0004",
                MaPhong = "P003",
                NgayDen = new DateTime(2023, 6, 10),
                NgayDi = new DateTime(2023, 6, 14),
                DonGia = 800000,
                TienCoc = 400000,
                SoNguoi = 2,
                NgayLap = new DateTime(2023, 6, 1),
                TrangThai = "Đã đặt"
            },
            new PHIEUDATPHONG
            {
                MaPhieuDatPhong = "PDP0005",
                MaPhieuSuDung = "PSD0005",
                MaPhong = "P004",
                NgayDen = new DateTime(2023, 6, 10),
                NgayDi = new DateTime(2023, 6, 13),
                DonGia = 900000,
                TienCoc = 450000,
                SoNguoi = 2,
                NgayLap = new DateTime(2023, 6, 1),
                TrangThai = "Đã đặt"
            },
            new PHIEUDATPHONG
            {
                MaPhieuDatPhong = "PDP0006",
                MaPhieuSuDung = "PSD0006",
                MaPhong = "P005",
                NgayDen = new DateTime(2023, 6, 10),
                NgayDi = new DateTime(2023, 6, 12),
                DonGia = 500000,
                TienCoc = 250000,
                SoNguoi = 1,
                NgayLap = new DateTime(2023, 6,1),
                TrangThai = "Đã đặt"
            },
            new PHIEUDATPHONG
            {
                MaPhieuDatPhong = "PDP0007",
                MaPhieuSuDung = "PSD0007",
                MaPhong = "P006",
                NgayDen = new DateTime(2023, 6, 10),
                NgayDi = new DateTime(2023, 6, 11),
                DonGia = 400000,
                TienCoc = 200000,
                SoNguoi = 1,
                NgayLap = new DateTime(2023, 6, 1),
                TrangThai = "Đã đặt"
            },
            new PHIEUDATPHONG
            {
                MaPhieuDatPhong = "PDP0008",
                MaPhieuSuDung = "PSD0008",
                MaPhong = "P007",
                NgayDen = new DateTime(2023, 6, 10),
                NgayDi = new DateTime(2023, 6, 11),
                DonGia = 500000,
                TienCoc = 250000,
                SoNguoi = 2,
                NgayLap = new DateTime(2023, 6, 1),
                TrangThai = "Đã đặt"
            },
new         PHIEUDATPHONG
            {
                MaPhieuDatPhong = "PDP0009",
                MaPhieuSuDung = "PSD0009",
                MaPhong = "P008",
                NgayDen = new DateTime(2023, 6, 10),
                NgayDi = new DateTime(2023, 6, 11),
                DonGia = 600000,
                TienCoc = 300000,
                SoNguoi = 2,
                NgayLap = new DateTime(2023, 6, 1),
                TrangThai = "Đã đặt"
            },
            new PHIEUDATPHONG
            {
                MaPhieuDatPhong = "PDP0010",
                MaPhieuSuDung = "PSD0010",
                MaPhong = "P009",
                NgayDen = new DateTime(2023, 6, 10),
                NgayDi = new DateTime(2023, 6, 11),
                DonGia = 700000,
                TienCoc = 350000,
                SoNguoi = 2,
                NgayLap = new DateTime(2023, 6, 1),
                TrangThai = "Đã đặt"
            }
            };
        }
    }
}
