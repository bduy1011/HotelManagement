using Hotel_Management_System.Model;
using Hotel_Management_System.View;
using Hotel_Management_System.View.RoomView;
using Hotel_Management_System.View.StaffView;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel_Management_System.ViewModel.RoomViewModel
{
    public class EditRoomViewModel : BaseViewModel
    {
        public ICommand EditRoomCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }



        public string MaPhong { get; set; }
        public string MaLoaiPhong { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }



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

        public EditRoomViewModel()
        {
            EditRoomCommand = new RelayCommand<object>((p) => { return Check(); }, (p) => { EditRoom(); });

            BackCommand = new RelayCommand<EditRoomView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<EditRoomView>((p) => { return true; }, (p) => { Clear(); });

        }

        public EditRoomViewModel(PHONG SelectedRoomItem) : this()
        {
            this.SelectedRoomItem = SelectedRoomItem;
            this.MaPhong = SelectedRoomItem.MaPhong;
            this.MaLoaiPhong = SelectedRoomItem.MaLoaiPhong;
            this.TrangThai = SelectedRoomItem.TrangThai;
            this.GhiChu = SelectedRoomItem.GhiChu;
        }

        public void EditRoom()
        {
            var result = DataProvider.Ins.DB.PHONGs.Where(x => x.MaPhong.CompareTo(this.MaPhong) == 0).Single();

            result.MaLoaiPhong = this.MaLoaiPhong;
            result.TrangThai = this.TrangThai;
            result.GhiChu = this.GhiChu;


            DataProvider.Ins.DB.PHONGs.AddOrUpdate(result);
            DataProvider.Ins.DB.SaveChanges();

            RoomView roomView = new RoomView();
            if (roomView.DataContext == null) return;
            var roomVM = roomView.DataContext as RoomViewModel;
            roomVM.UpdateRoom(result);
        }


        public bool Check()
        {
            if (MaLoaiPhong != "" && TrangThai != "" && GhiChu != "")
                return true;
            else return false;
        }

        public void Clear()
        {
            this.MaLoaiPhong = null;
            this.TrangThai = null;
            this.GhiChu = null;

        }
    }
}
