using Hotel_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using Hotel_Management_System.View;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Windows.Controls;
using System.Windows.Data;
using Hotel_Management_System.ViewModel.Other;
using Hotel_Management_System.View.StaffView;
using Hotel_Management_System.View.RoomView;

namespace Hotel_Management_System.ViewModel.RoomViewModel
{
    public class RoomViewModel : BaseViewModel
    {
        private ObservableCollection<PHONG> _rooms;
        public ObservableCollection<PHONG> rooms
        {
            get { return _rooms; }
            set
            {
                if (_rooms != value)
                {
                    _rooms = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<PHONG> _tmpRooms;
        public ObservableCollection<PHONG> tmpRooms
        {
            get { return _tmpRooms; }
            set
            {
                if (_tmpRooms != value)
                {
                    _tmpRooms = value;
                    OnPropertyChanged();
                }
            }
        }

        private PHONG _selectedRoomItem;
        public PHONG SelectedRoomItem
        {
            get { return _selectedRoomItem; }
            set
            {
                if (_selectedRoomItem != value)
                {
                    _selectedRoomItem = value;
                    // Thực hiện các xử lý liên quan đến dòng đã chọn ở đây
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoadedUserControlCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public RemoveRoomView removeroomView;
        public EditRoomView editroomView;
        public AddRoomView addroomWindow;

        public RoomViewModel()
        {
            LoadedUserControlCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                try
                {
                    rooms = new ObservableCollection<PHONG>();
                    tmpRooms = new ObservableCollection<PHONG>();

                    var roomList = DataProvider.Ins.DB.PHONGs;

                    foreach (PHONG item in roomList)
                    {
                        rooms.Add(new PHONG
                        {
                            MaPhong = item.MaPhong,
                            MaLoaiPhong = item.MaLoaiPhong,
                            TrangThai = item.TrangThai,
                            GhiChu = item.GhiChu,
                        });
                    }
                    tmpRooms = rooms;
                }
                catch { return; }
            });

            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                addroomWindow = new AddRoomView();
                addroomWindow.ShowDialog();
            });

            SearchCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(p.Text))
                {
                    // Hiển thị lại tất cả dữ liệu nếu không có từ khóa tìm kiếm
                    rooms = tmpRooms;
                }
                else
                {
                    var result = tmpRooms.Where(x =>
                        x.MaPhong.ToString().Contains(p.Text)
                        || x.MaLoaiPhong.Contains(p.Text)
                        || x.TrangThai.Contains(p.Text)
                        || x.GhiChu.Contains(p.Text)
                    );

                    rooms = new ObservableCollection<PHONG>();

                    foreach (var item in result)
                    {
                        rooms.Add(new PHONG
                        {
                            MaPhong = item.MaPhong,
                            MaLoaiPhong = item.MaLoaiPhong,
                            TrangThai = item.TrangThai,
                            GhiChu = item.GhiChu,

                        });
                    }
                }
            });

            RemoveCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                removeroomView = new RemoveRoomView();
                removeroomView.DataContext = new RemoveRoomViewModel(SelectedRoomItem);
                removeroomView.ShowDialog();
            });

            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                editroomView = new EditRoomView();
                editroomView.DataContext = new EditRoomViewModel(SelectedRoomItem);
                editroomView.ShowDialog();
            });
        }

        public void AddRoom(PHONG room)
        {
            rooms.Add(room);
            MessageBox.Show("Thêm mới thông tin thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            addroomWindow.Close();
        }

        public void UpdateRoom(PHONG room)
        {
            PHONG RoomToFind = rooms.FirstOrDefault(c => c.MaPhong == room.MaPhong);
            if (RoomToFind != null)
            {
                RoomToFind.MaPhong = room.MaPhong;
                RoomToFind.MaLoaiPhong = room.MaLoaiPhong;
                RoomToFind.TrangThai = room.TrangThai;
                RoomToFind.GhiChu = room.GhiChu;

                MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void RemoveRoom(PHONG room)
        {
            rooms.Remove(room);
            rooms = new ObservableCollection<PHONG>();
            var roomList = DataProvider.Ins.DB.PHONGs;
            foreach (var item in roomList)
            {
                rooms.Add(new PHONG
                {
                    MaPhong = item.MaPhong,
                    MaLoaiPhong = item.MaLoaiPhong,
                    TrangThai = item.TrangThai,
                    GhiChu = item.GhiChu,

                });
            }
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            removeroomView.Close();
        }
    }
}
