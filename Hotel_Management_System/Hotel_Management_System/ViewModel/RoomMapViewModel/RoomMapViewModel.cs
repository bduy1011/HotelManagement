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

        private DateTime? _selectedCheckDate = null;
        public DateTime? SelectedCheckDate
        {
            get { return _selectedCheckDate; }
            set
            {
                _selectedCheckDate = value;
                OnPropertyChanged();
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


        public ICommand LoadedWindowCommand { get; set; }
        public ICommand BookingRoomCommand { get; set; }
        public ICommand CheckDateSelectedDateChangedCommand { get; set; }
        public ICommand SearchDateSelectedDateChangedCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }
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

                Rooms = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
                ReservedBills = new ObservableCollection<PHIEUDATPHONG>(DataProvider.Ins.DB.PHIEUDATPHONGs);
                
                EmptyRoomList = new ObservableCollection<PHONG>();

                UpdateRoomState();
            });
                
            BookingRoomCommand = new RelayCommand<PHONG>((p) => { return true; }, (p) => 
            {
                switch (p.TrangThai)
                {
                    case "Trống":
                        DateTime dateTime = DateTime.Now;
                        if (SelectedCheckDate.Value.Date == DateTime.Now.Date)
                        {
                            dateTime = SelectedCheckDate.Value.Date + DateTime.Now.TimeOfDay;
                        }
                        else dateTime = SelectedCheckDate.Value.Date + new TimeSpan(14, 0, 0);
                        BookingRoomView bookingRoomView = new BookingRoomView();
                        bookingRoomView.DataContext = new BookingRoomViewModel.BookingRoomViewModel(p, dateTime);
                        bookingRoomView.ShowDialog();

                        if (bookingRoomView.DataContext == null) return;
                        var bookingRoomViewModel = bookingRoomView.DataContext as BookingRoomViewModel.BookingRoomViewModel;

                        p.TrangThai = bookingRoomViewModel.Room.TrangThai;
                        
                        break;
                    case "Được đặt":

                        break;
                    case "Được thuê":

                        break;
                }
                UpdateRoomState();
            });

            RemoveCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RemoveBookingRoomView removeBookingRoomView = new RemoveBookingRoomView();
                removeBookingRoomView.DataContext = new RemoveBookingRoomViewModel(SelectedReservedBillItem);
                removeBookingRoomView.ShowDialog();
                LoadReservedBill();
            });

            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //editCustomerView = new EditCustomerView();
                //editCustomerView.DataContext = new EditCustomerViewModel(SelectedCustomerItem);
                //editCustomerView.ShowDialog();
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
                        x => x.TrangThai != "Đã hủy"
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

            TraPhongCommand = new RelayCommand<object>((p) => { return true; }, (p) => { MessageBox.Show("1"); });
            HuyPhongCommand = new RelayCommand<object>((p) => { return true; }, (p) => { MessageBox.Show("2"); });
            NhanPhongCommand = new RelayCommand<object>((p) => { return true; }, (p) => { MessageBox.Show("3"); });
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
                DateTime dateTime= DateTime.Now;
                if (SelectedCheckDate.Value.Date == DateTime.Now.Date)
                {
                    dateTime = SelectedCheckDate.Value.Date + DateTime.Now.TimeOfDay;
                }
                else dateTime = SelectedCheckDate.Value.Date + new TimeSpan(14,0,0);
                try
                {
                    var ListRoomHaveReservedBillInCheckDate = DataProvider.Ins.DB.PHIEUDATPHONGs
                        .Where(x => x.NgayDen <= dateTime && dateTime <= x.NgayDi)
                        .Select(x => new { x.MaPhong, x.TrangThai });
 
                    var RoomStatusList = DataProvider.Ins.DB.PHONGs
                        .Select(x => new
                        {
                            x.MaPhong,
                            TrangThai = ListRoomHaveReservedBillInCheckDate
                                .Any(y => y.MaPhong == x.MaPhong) ? ListRoomHaveReservedBillInCheckDate
                                .Where(y => y.MaPhong == x.MaPhong).FirstOrDefault().TrangThai : "Trống"
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
            ReservedBills.Clear();
            ReservedBills = new ObservableCollection<PHIEUDATPHONG>(DataProvider.Ins.DB.PHIEUDATPHONGs);
        }
    }
}
