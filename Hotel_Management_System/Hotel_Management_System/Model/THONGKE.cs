//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel_Management_System.Model
{
    using Hotel_Management_System.ViewModel.Other;
    using System;

    public partial class THONGKE : BaseViewModel
    {
        private string _maThongKe;
        public string MaThongKe
        {
            get { return _maThongKe; }
            set { _maThongKe = value; OnPropertyChanged(); }
        }

        private string _maLoaiPhong;
        public string MaLoaiPhong
        {
            get { return _maLoaiPhong; }
            set { _maLoaiPhong = value; OnPropertyChanged(); }
        }

        private DateTime? _ngayLap;
        public DateTime? NgayLap
        {
            get { return _ngayLap; }
            set { _ngayLap = value; OnPropertyChanged(); }
        }

        private double? _doanhThu;
        public double? DoanhThu
        {
            get { return _doanhThu; }
            set { _doanhThu = value; OnPropertyChanged(); }
        }

        private double? _tiLe;
        public double? TiLe
        {
            get { return _tiLe; }
            set { _tiLe = value; OnPropertyChanged(); }
        }

        public virtual LOAIPHONG LOAIPHONG { get; set; }
    }
}
