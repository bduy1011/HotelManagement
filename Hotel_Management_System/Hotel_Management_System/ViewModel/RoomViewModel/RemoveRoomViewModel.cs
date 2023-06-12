using Hotel_Management_System.Model;
using Hotel_Management_System.View;
using Hotel_Management_System.ViewModel.Other;
using Hotel_Management_System.View.CustomerView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Hotel_Management_System.View.StaffView;
using Hotel_Management_System.View.RoomView;

namespace Hotel_Management_System.ViewModel.RoomViewModel
{
    public class RemoveRoomViewModel : BaseViewModel
    {
        public ICommand RemoveRoomCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }


        public string MaPhong { get; set; }
        public string MaLoaiPhong { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }


        public bool IsRemove = false;

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

        public RemoveRoomViewModel()
        {
            RemoveRoomCommand = new RelayCommand<object>((p) => { return true; }, (p) => { RemoveRoom(); });

            BackCommand = new RelayCommand<RemoveRoomView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<RemoveRoomView>((p) => { return true; }, (p) => { Clear(); });

        }

        public RemoveRoomViewModel(PHONG SelectedRoomItem) : this()
        {
            this.SelectedRoomItem = SelectedRoomItem;
            this.MaPhong = SelectedRoomItem.MaPhong;
            this.MaLoaiPhong = SelectedRoomItem.MaLoaiPhong;
            this.TrangThai = SelectedRoomItem.TrangThai;
            this.GhiChu = SelectedRoomItem.GhiChu;

        }

        public void RemoveRoom()
        {
            var result = DataProvider.Ins.DB.PHONGs.Where(x => x.MaPhong.CompareTo(this.MaPhong) == 0).Single();
            DataProvider.Ins.DB.PHONGs.Remove(result);
            DataProvider.Ins.DB.SaveChanges();

            RoomView roomView = new RoomView();
            if (roomView.DataContext == null) return;
            var roomVM = roomView.DataContext as RoomViewModel;
            roomVM.RemoveRoom(result);
            IsRemove = true;
        }

        public void Clear()
        {
            this.MaLoaiPhong = null;
            this.TrangThai = null;
            this.GhiChu = null;
        }

    }
}
