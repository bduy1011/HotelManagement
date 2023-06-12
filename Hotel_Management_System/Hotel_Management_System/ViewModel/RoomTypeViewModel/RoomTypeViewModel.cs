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
using Hotel_Management_System.View.RoomTypeView;

namespace Hotel_Management_System.ViewModel.RoomTypeViewModel
{
    public class RoomTypeViewModel : BaseViewModel
    {
        private ObservableCollection<LOAIPHONG> _roomtypes;
        public ObservableCollection<LOAIPHONG> roomtypes
        {
            get { return _roomtypes; }
            set
            {
                if (_roomtypes != value)
                {
                    _roomtypes = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<LOAIPHONG> _tmpRoomTypes;
        public ObservableCollection<LOAIPHONG> tmpRoomTypes
        {
            get { return _tmpRoomTypes; }
            set
            {
                if (_tmpRoomTypes != value)
                {
                    _tmpRoomTypes = value;
                    OnPropertyChanged();
                }
            }
        }

        private LOAIPHONG _selectedRoomTypeItem;
        public LOAIPHONG SelectedRoomTypeItem
        {
            get { return _selectedRoomTypeItem; }
            set
            {
                if (_selectedRoomTypeItem != value)
                {
                    _selectedRoomTypeItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoadedUserControlCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public RemoveRoomTypeView removeroomtypeView;
        public EditRoomTypeView editroomtypeView;
        public AddRoomTypeView addroomtypeWindow;

        public RoomTypeViewModel()
        {
            LoadedUserControlCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                try
                {
                    roomtypes = new ObservableCollection<LOAIPHONG>();
                    tmpRoomTypes = new ObservableCollection<LOAIPHONG>();

                    var roomtypeList = DataProvider.Ins.DB.LOAIPHONGs;

                    foreach (LOAIPHONG item in roomtypeList)
                    {
                        roomtypes.Add(new LOAIPHONG
                        {
                            MaLoaiPhong = item.MaLoaiPhong,
                            TenLoaiPhong = item.TenLoaiPhong,
                            DonGia = item.DonGia,
                        });
                    }
                    tmpRoomTypes = roomtypes;
                }
                catch { return; }
            });

            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                addroomtypeWindow = new AddRoomTypeView();
                addroomtypeWindow.ShowDialog();
            });

            SearchCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(p.Text))
                {
                    // Hiển thị lại tất cả dữ liệu nếu không có từ khóa tìm kiếm
                    roomtypes = tmpRoomTypes;
                }
                else
                {
                    var result = tmpRoomTypes.Where(x =>
                        x.MaLoaiPhong.Contains(p.Text)
                        || x.TenLoaiPhong.Contains(p.Text)
                        || x.DonGia.ToString().Contains(p.Text)
                    );

                    roomtypes = new ObservableCollection<LOAIPHONG>();

                    foreach (var item in result)
                    {
                        roomtypes.Add(new LOAIPHONG
                        {
                            MaLoaiPhong = item.MaLoaiPhong,
                            TenLoaiPhong = item.TenLoaiPhong,
                            DonGia = item.DonGia,

                        });
                    }
                }
            });

            RemoveCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                removeroomtypeView = new RemoveRoomTypeView();
                removeroomtypeView.DataContext = new RemoveRoomTypeViewModel(SelectedRoomTypeItem);
                removeroomtypeView.ShowDialog();
            });

            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                editroomtypeView = new EditRoomTypeView();
                editroomtypeView.DataContext = new EditRoomTypeViewModel(SelectedRoomTypeItem);
                editroomtypeView.ShowDialog();
            });

        }

        public void AddRoomType(LOAIPHONG roomtype)
        {
            roomtypes.Add(roomtype);
            MessageBox.Show("Thêm mới thông tin thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            addroomtypeWindow.Close();
        }

        public void UpdateRoomType(LOAIPHONG roomtype)
        {
            LOAIPHONG RoomTypeToFind = roomtypes.FirstOrDefault(c => c.MaLoaiPhong == roomtype.MaLoaiPhong);
            if (RoomTypeToFind != null)
            {
                RoomTypeToFind.MaLoaiPhong = roomtype.MaLoaiPhong;
                RoomTypeToFind.TenLoaiPhong = roomtype.TenLoaiPhong;
                RoomTypeToFind.DonGia = roomtype.DonGia;

                MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void RemoveRoomType(LOAIPHONG roomtype)
        {
            roomtypes.Remove(roomtype);
            roomtypes = new ObservableCollection<LOAIPHONG>();
            var roomtypeList = DataProvider.Ins.DB.LOAIPHONGs;
            foreach (var item in roomtypeList)
            {
                roomtypes.Add(new LOAIPHONG
                {
                    MaLoaiPhong = item.MaLoaiPhong,
                    TenLoaiPhong = item.TenLoaiPhong,
                    DonGia = item.DonGia,

                });
            }
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            removeroomtypeView.Close();
        }
    }
}
