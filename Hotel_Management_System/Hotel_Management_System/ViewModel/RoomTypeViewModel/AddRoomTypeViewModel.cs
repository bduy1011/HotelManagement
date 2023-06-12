using Hotel_Management_System.Model;
using Hotel_Management_System.View.RoomTypeView;
using Hotel_Management_System.View.RoomView;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel_Management_System.ViewModel.RoomTypeViewModel
{
    public class AddRoomTypeViewModel : BaseViewModel
    {

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand AddRoomTypeCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }


        public BrushConverter converter = new BrushConverter();
        public string MaLoaiPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public int DonGia { get; set; }


        public AddRoomTypeViewModel()
        {
            LoadedWindowCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { LoadedWindow(p); });

            AddRoomTypeCommand = new RelayCommand<TextBox>((p) => { return CheckAdd(); }, (p) => { AddRoomType(p); });

            BackCommand = new RelayCommand<AddRoomTypeView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<AddRoomTypeView>((p) => { return true; }, (p) => { Clear(); });

        }

        public void LoadedWindow(TextBox tb)
        {
            string temp;
            try
            {
                temp = DataProvider.Ins.DB.LOAIPHONGs.OrderByDescending(cus => cus.MaLoaiPhong).FirstOrDefault().MaLoaiPhong;
            }
            catch
            {
                temp = "LP" + (23410000 - 1).ToString();
            }
            MaLoaiPhong = "P" + (int.Parse(temp.Split('P')[1]) + 1).ToString();
            tb.Text = MaLoaiPhong;
        }

        public void AddRoomType(TextBox tb)
        {
            var roomtype = new LOAIPHONG()
            {
                MaLoaiPhong = this.MaLoaiPhong,
                TenLoaiPhong = this.TenLoaiPhong,
                DonGia = this.DonGia,
            };

            DataProvider.Ins.DB.LOAIPHONGs.Add(roomtype);
            DataProvider.Ins.DB.SaveChanges();

            RoomTypeView roomtypeView = new RoomTypeView();
            if (roomtypeView.DataContext == null) return;
            var roomtypeVM = roomtypeView.DataContext as RoomTypeViewModel;
            roomtypeVM.AddRoomType(roomtype);
        }

        public bool CheckAdd()
        {
            if (TenLoaiPhong != "" && DonGia != 0)
                return true;
            else return false;
        }

        public void Clear()
        {
            TenLoaiPhong = null;
            DonGia = 0;
        }
    }
}
