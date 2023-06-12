using Hotel_Management_System.Model;
using Hotel_Management_System.View.RoomView;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel_Management_System.ViewModel.RoomViewModel
{
    public class AddRoomViewModel : BaseViewModel
    {

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand AddRoomCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }


        public BrushConverter converter = new BrushConverter();
        public string MaPhong { get; set; }
        public string MaLoaiPhong { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }


        public AddRoomViewModel()
        {
            LoadedWindowCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { LoadedWindow(p); });

            AddRoomCommand = new RelayCommand<TextBox>((p) => { return CheckAdd(); }, (p) => { AddRoom(p); });

            BackCommand = new RelayCommand<AddRoomView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<AddRoomView>((p) => { return true; }, (p) => { Clear(); });

        }

        public Brush BrushList(int i)
        {
            switch (i % 10)
            {
                case 0:
                    return (Brush)converter.ConvertFromString("#1098AD");
                case 1:
                    return (Brush)converter.ConvertFromString("#1E88E5");
                case 2:
                    return (Brush)converter.ConvertFromString("#FF8F00");
                case 3:
                    return (Brush)converter.ConvertFromString("#0CA678");
                case 4:
                    return (Brush)converter.ConvertFromString("#6741D9");
                case 5:
                    return (Brush)converter.ConvertFromString("#FF6D00");
                case 6:
                    return (Brush)converter.ConvertFromString("#FF5252");
                case 7:
                    return (Brush)converter.ConvertFromString("#1E88E5");
                case 8:
                    return (Brush)converter.ConvertFromString("#0CA678");
                default:
                    return (Brush)converter.ConvertFromString("#FF5252");
            }
        }

        public void LoadedWindow(TextBox tb)
        {
            string temp;
            try
            {
                temp = DataProvider.Ins.DB.PHONGs.OrderByDescending(cus => cus.MaPhong).FirstOrDefault().MaPhong;
            }
            catch
            {
                temp = "P" + (23410000 - 1).ToString();
            }
            MaPhong = "P" + (int.Parse(temp.Split('P')[1]) + 1).ToString();
            tb.Text = MaPhong;
        }

        public void AddRoom(TextBox tb)
        {
            var room = new PHONG()
            {
                MaPhong = this.MaPhong,
                MaLoaiPhong = this.MaLoaiPhong,
                TrangThai = this.MaLoaiPhong,
                GhiChu = this.GhiChu,
            };

            DataProvider.Ins.DB.PHONGs.Add(room);
            DataProvider.Ins.DB.SaveChanges();

            RoomView roomView = new RoomView();
            if (roomView.DataContext == null) return;
            var roomVM = roomView.DataContext as RoomViewModel;
            roomVM.AddRoom(room);
        }

        public bool CheckAdd()
        {
            if (MaPhong != "" && MaLoaiPhong != "" && GhiChu != "" && TrangThai != "")
                return true;
            else return false;
        }

        public void Clear()
        {
            MaLoaiPhong = null;
            GhiChu = null;
            MaPhong = null;
            TrangThai = null;
        }
    }
}
