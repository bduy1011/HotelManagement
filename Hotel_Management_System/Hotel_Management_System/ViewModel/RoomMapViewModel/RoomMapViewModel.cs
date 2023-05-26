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

namespace Hotel_Management_System.ViewModel.RoomMapViewModel
{
    public class RoomMapViewModel : BaseViewModel
    {
        public string Vacant {get; set;}
        public string Occupied {get; set;}
        public string Reserved {get; set;}
        public string Dirty {get; set;}
        public string OutOfOrderRoom { get; set;}
        public string StateColor { get; set;}

        private string _numberOfRoom;
        public string NumberOfRoom
        {
            get { return _numberOfRoom; }
            protected set
            {
                _numberOfRoom = value;
                OnPropertyChanged();
            }
        }

        private string _vacantNumber;
        public string VacantNumber
        {
            get { return _vacantNumber; }
            protected set
            {
                _vacantNumber = value;
                OnPropertyChanged();
            }
        }

        private string _occupiedNumber;
        public string OccupiedNumber
        {
            get { return _occupiedNumber; }
            protected set
            {
                _occupiedNumber = value;
                OnPropertyChanged();
            }
        }

        private string _reservedNumber;
        public string ReservedNumber
        {
            get { return _reservedNumber; }
            protected set
            {
                _reservedNumber = value;
                OnPropertyChanged();
            }
        }

        private string _dirtyNumber;
        public string DirtyNumber
        {
            get { return _dirtyNumber; }
            protected set
            {
                _dirtyNumber = value;
                OnPropertyChanged();
            }
        }

        private string _outOfOrderRoomNumber;
        public string OutOfOrderRoomNumber
        {
            get { return _outOfOrderRoomNumber; }
            protected set
            {
                _outOfOrderRoomNumber = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PHONG> Rooms { get; set; }
        public ICommand BookingRoomCommand { get; set; }

        public RoomMapViewModel()
        {
            Vacant = "#00DD00";
            Occupied = "#FF3333";
            Reserved = "#00BFFF";
            Dirty = "#FFB347";
            OutOfOrderRoom = "#AF69EE";

            int numberOfRoom = 0;
            int vacantNumber = 0;
            int occupiedNumber = 0;
            int reservedNumber = 0;
            int dirtyNumber = 0;
            int outOfOrderRoomNumber = 0;

            Rooms = new ObservableCollection<PHONG>()
            {
                new PHONG("100", "Standard room", "Trống", null, null, null),
                new PHONG("101", "Standard room", "Trống", null, null, null),
                new PHONG("102", "Standard room", "Trống", null, null, null),
                new PHONG("103", "Standard room", "Cần dọn phòng", null, null, null),
                new PHONG("104", "Standard room", "Được thuê", null, null, null),
                new PHONG("105", "Standard room", "Được thuê", null, null, null),
                new PHONG("106", "Standard room", "Được thuê", null, null, null),
                new PHONG("107", "Standard room", "Được thuê", null, null, null),
                new PHONG("108", "Deluxe room", "Trống", null, null, null),
                new PHONG("109", "Deluxe room", "Trống", null, null, null),
                new PHONG("110", "Deluxe room", "Trống", null, null, null),
                new PHONG("111", "Deluxe room", "Ngưng hoạt động", null, null, null),
                new PHONG("112", "Deluxe room", "Cần dọn phòng", null, null, null),
                new PHONG("113", "Deluxe room", "Được đặt", null, null, null),
                new PHONG("114", "Deluxe room", "Được đặt", null, null, null),
                new PHONG("115", "Deluxe room", "Được đặt", null, null, null),
                new PHONG("201", "Suite room", "Ngưng hoạt động", null, null, null),
                new PHONG("202", "Suite room", "Được thuê", null, null, null),
                new PHONG("203", "Suite room", "Được thuê", null, null, null),
                new PHONG("204", "Suite room", "Trống", null, null, null),
                new PHONG("205", "Executive room", "Được thuê", null, null, null),
                new PHONG("206", "Executive room", "Được thuê", null, null, null),
                new PHONG("207", "Executive room", "Được thuê", null, null, null),
                new PHONG("208", "Executive room", "Được thuê", null, null, null),
                new PHONG("301", "View room", "Được thuê", null, null, null),
                new PHONG("302", "View room", "Được thuê", null, null, null),
                new PHONG("303", "View room", "Được thuê", null, null, null),
                new PHONG("304", "View room", "Được thuê", null, null, null),
                new PHONG("305", "Family room", "Được đặt", null, null, null),
                new PHONG("306", "Family room", "Được đặt", null, null, null),
                new PHONG("307", "Family room", "Cần dọn phòng", null, null, null),
                new PHONG("308", "Family room", "Cần dọn phòng", null, null, null)
            };

            foreach (var room in Rooms)
            {
                switch(room.TrangThai) {
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
            }

            BookingRoomCommand = new RelayCommand<PHONG>((p) => { return true; }, (p) => 
            { 
                BookingRoomView bookingRoomView = new BookingRoomView();
                bookingRoomView.DataContext = new BookingRoomViewModel.BookingRoomViewModel(p);
                bookingRoomView.ShowDialog(); 
            });
        }
    }
}
