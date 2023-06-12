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
using Hotel_Management_System.View.RoomTypeView;

namespace Hotel_Management_System.ViewModel.RoomTypeViewModel
{
    public class RemoveRoomTypeViewModel : BaseViewModel
    {
        public ICommand RemoveRoomTypeCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }


        public string MaLoaiPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public Nullable<double> DonGia { get; set; }


        public bool IsRemove = false;

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

        public RemoveRoomTypeViewModel()
        {
            RemoveRoomTypeCommand = new RelayCommand<object>((p) => { return true; }, (p) => { RemoveRoomType(); });

            BackCommand = new RelayCommand<RemoveRoomTypeView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<RemoveRoomTypeView>((p) => { return true; }, (p) => { Clear(); });

        }

        public RemoveRoomTypeViewModel(LOAIPHONG SelectedRoomTypeItem) : this()
        {
            this.SelectedRoomTypeItem = SelectedRoomTypeItem;
            this.MaLoaiPhong = SelectedRoomTypeItem.MaLoaiPhong;
            this.TenLoaiPhong = SelectedRoomTypeItem.TenLoaiPhong;
            this.DonGia = SelectedRoomTypeItem.DonGia;

        }

        public void RemoveRoomType()
        {
            var result = DataProvider.Ins.DB.LOAIPHONGs.Where(x => x.MaLoaiPhong.CompareTo(this.MaLoaiPhong) == 0).Single();
            DataProvider.Ins.DB.LOAIPHONGs.Remove(result);
            DataProvider.Ins.DB.SaveChanges();

            RoomTypeView roomtypeView = new RoomTypeView();
            if (roomtypeView.DataContext == null) return;
            var roomtypeVM = roomtypeView.DataContext as RoomTypeViewModel;
            roomtypeVM.RemoveRoomType(result);
            IsRemove = true;
        }

        public void Clear()
        {
            this.TenLoaiPhong = null;
            this.DonGia = null;
        }

    }
}
