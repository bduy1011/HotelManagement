using Hotel_Management_System.Model;
using Hotel_Management_System.View;
using Hotel_Management_System.View.RoomTypeView;
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

namespace Hotel_Management_System.ViewModel.RoomTypeViewModel
{
    public class EditRoomTypeViewModel : BaseViewModel
    {
        public ICommand EditRoomTypeCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }



        public string MaLoaiPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public Nullable<double> DonGia { get; set; }



        private LOAIPHONG _selectedRoomTypeItem;
        public LOAIPHONG SelectedRoomTypeItem
        {
            get { return _selectedRoomTypeItem; }
            set
            {
                if (_selectedRoomTypeItem != value)
                {
                    _selectedRoomTypeItem = value;
                    // Thực hiện các xử lý liên quan đến dòng đã chọn ở đây
                    OnPropertyChanged();
                }
            }
        }

        public EditRoomTypeViewModel()
        {
            EditRoomTypeCommand = new RelayCommand<object>((p) => { return Check(); }, (p) => { EditRoomType(); });

            BackCommand = new RelayCommand<EditRoomTypeView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<EditRoomTypeView>((p) => { return true; }, (p) => { Clear(); });

        }

        public EditRoomTypeViewModel(LOAIPHONG SelectedRoomTypeItem) : this()
        {
            this.SelectedRoomTypeItem = SelectedRoomTypeItem;
            this.MaLoaiPhong = SelectedRoomTypeItem.MaLoaiPhong;
            this.TenLoaiPhong = SelectedRoomTypeItem.TenLoaiPhong;
            this.DonGia = SelectedRoomTypeItem.DonGia;
        }

        public void EditRoomType()
        {
            var result = DataProvider.Ins.DB.LOAIPHONGs.Where(x => x.MaLoaiPhong.CompareTo(this.MaLoaiPhong) == 0).Single();
            result.MaLoaiPhong = this.MaLoaiPhong;
            result.TenLoaiPhong = this.TenLoaiPhong;
            //result.DonGia = this.DonGia;


            DataProvider.Ins.DB.LOAIPHONGs.AddOrUpdate(result);
            DataProvider.Ins.DB.SaveChanges();

            RoomTypeView roomtypeView = new RoomTypeView();
            if (roomtypeView.DataContext == null) return;
            var roomtypeVM = roomtypeView.DataContext as RoomTypeViewModel;
            roomtypeVM.UpdateRoomType(result);
        }


        public bool Check()
        {
            if (TenLoaiPhong != "" && DonGia != null)
                return true;
            else return false;
        }

        public void Clear()
        {
            this.TenLoaiPhong = null;
            this.DonGia = null;
        }
    }
}
