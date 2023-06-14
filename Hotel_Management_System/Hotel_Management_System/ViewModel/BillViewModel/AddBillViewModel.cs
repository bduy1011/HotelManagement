using Hotel_Management_System.Model;
using Hotel_Management_System.View.BillView;
using Hotel_Management_System.View.BookingRoomView;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hotel_Management_System.ViewModel.BillViewModel
{
    public class AddBillViewModel : BaseViewModel
    {
        public const string TRONG = "Trống";
        public const string DUOC_THUE = "Được thuê";
        public const string DUOC_DAT = "Được đặt";
        public const string CHUA_THANH_TOAN = "Chưa thanh toán";
        public const string DA_THANH_TOAN = "Đã thanh toán";
        public const string DA_HUY = "Đã hủy";

        private NHANVIEN _nhanvien;
        public NHANVIEN nhanvien
        {
            get { return _nhanvien; }
            set
            {
                if (_nhanvien != value)
                {
                    _nhanvien = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<PHIEUDATPHONG> _pdps;
        public ObservableCollection<PHIEUDATPHONG> PDPs
        {
            get { return _pdps; }
            set { _pdps = value; OnPropertyChanged(); }
        }

        private ObservableCollection<PHIEUDATPHONG> _selectedPDPs;
        public ObservableCollection<PHIEUDATPHONG> SelectedPDPs
        {
            get { return _selectedPDPs; }
            set { _selectedPDPs = value; OnPropertyChanged(); }
        }

        private ObservableCollection<CT_PHIEUDICHVU> _showSselectedServices;
        public ObservableCollection<CT_PHIEUDICHVU> ShowSelectedServices
        {
            get { return _showSselectedServices; }
            set
            {
                _showSselectedServices = value;
                OnPropertyChanged();
            }
        }

        private string _sumFee;
        public string SumFee
        {
            get { return _sumFee; }
            set { _sumFee = value; OnPropertyChanged(); }
        }

        private string _servicesFee;
        public string ServicesFee
        {
            get { return _servicesFee; }
            set { _servicesFee = value; OnPropertyChanged(); }
        }

        private string _roomFee;
        public string RoomFee
        {
            get { return _roomFee; }
            set { _roomFee = value; OnPropertyChanged(); }
        }

        private string _remainingCosts;
        public string RemainingCosts
        {
            get { return _remainingCosts; }
            set
            {
                if (_remainingCosts != value)
                {
                    _remainingCosts = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _downPayment;
        public string DownPayment
        {
            get { return _downPayment; }
            set
            {
                if (_downPayment != value)
                {
                    _downPayment = value;
                    OnPropertyChanged();
                }
            }
        }

        public int i = 0;

        private HOADON _bill;
        public HOADON Bill
        {
            get { return _bill; }
            set
            {
                if (_bill != value)
                {
                    _bill = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<KHACHHANG> _customerList;
        public ObservableCollection<KHACHHANG> CustomerList
        {
            get { return _customerList; }
            set
            {
                if (_customerList != value)
                {
                    _customerList = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand AddPDPCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand AddBillCommand { get; set; }

       
        public AddBillViewModel(NHANVIEN nv) : this()
        {
            nhanvien = nv;
        }

        public AddBillViewModel()
        {
          
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Bill = new HOADON();
                Bill.MaHoaDon = CreateIdBill();
                Bill.NHANVIEN = nhanvien;
                Bill.NgayLap = DateTime.Now;
                RoomFee = "0";
                ServicesFee = "0";
                SumFee = "0";
                DownPayment = "0";
                RemainingCosts = "0";
                SelectedPDPs = new ObservableCollection<PHIEUDATPHONG>();
                PDPs = new ObservableCollection<PHIEUDATPHONG>(DataProvider.Ins.DB.PHIEUDATPHONGs.Where(x => x.TrangThai == CHUA_THANH_TOAN));
            });

            AddPDPCommand = new RelayCommand<PHIEUDATPHONG>((p) => { return true; }, (p) => 
            {
                
                foreach (var item in SelectedPDPs)
                {
                    if (item.MaPhieuDatPhong == p.MaPhieuDatPhong)
                    {
                        SelectedPDPs.Remove(item);
                        Update();
                        return;
                    }
                }
                SelectedPDPs.Add(p);
                Update();
            });

            BackCommand = new RelayCommand<AddBillView>((p) => { return true; }, (p) => { p.Close(); Clear(); });

            AddBillCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                try
                {
                    if (SelectedPDPs.Count() > 0)
                    {
                        foreach (var item in SelectedPDPs)
                        {
                            CT_HOADON cthd = new CT_HOADON();
                            cthd.MaHoaDon = Bill.MaHoaDon;
                            cthd.MaPhieuDatPhong = item.MaPhieuDatPhong;
                            cthd.ThanhTien = item.DonGia;
                            Bill.CT_HOADON.Add(cthd);
                            item.TrangThai = DA_THANH_TOAN;
                        }
                        Bill.TrangThai = DA_THANH_TOAN;
                        Bill.TriGia = int.Parse(SumFee);
                        if (Bill.KHACHHANG.MaKhachHang == null) Bill.MaKhachHang = "";
                        else Bill.MaKhachHang = Bill.KHACHHANG.MaKhachHang;
                        DataProvider.Ins.DB.HOADONs.Add(Bill);
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        p.Close();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn phiếu đặt phòng cần thanh toán", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                } 
                catch
                {
                    MessageBox.Show("Thanh toán không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        public CT_PHIEUDICHVU ChangeToCT_PhieuDichVu(CT_PHIEUHANGHOA ctphh)
        {
            DICHVU dv = new DICHVU();
            dv.MaDichVu = ctphh.HANGHOA.MaHangHoa;
            dv.TenDichVu = ctphh.HANGHOA.TenHangHoa;
            dv.DonGia = ctphh.HANGHOA.DonGiaBan;
            dv.DonViTinh = ctphh.HANGHOA.DonViTinh;
            CT_PHIEUDICHVU ctpdv = new CT_PHIEUDICHVU(dv);
            ctpdv.SoLuong = ctphh.SoLuong;
            ctpdv.ThanhTien = ctphh.ThanhTien;
            ctpdv.tmpMaPDP = ctphh.tmpMaPDP;
            return ctpdv;
        }

        public string CreateIdBill()
        {
            string temp;
            try
            {
                temp = DataProvider.Ins.DB.HOADONs.OrderByDescending(x => x.MaHoaDon).FirstOrDefault().MaHoaDon;
            }
            catch
            {
                temp = "HD" + 10000.ToString();
            }
            return "HD" + (int.Parse(temp.Substring(2)) + 1).ToString();
        }

        public void Update()
        {
            int j = 1;
            foreach (var item in SelectedPDPs)
            {
                item.STT = j++;
            }
            ShowSelectedServices = new ObservableCollection<CT_PHIEUDICHVU>();
            CustomerList = new ObservableCollection<KHACHHANG>();
            int roomFee = 0;
            int servicesFee = 0;
            int sumFee = 0;
            int downPayment = 0;
            int remainingCosts = 0;
            int i = 1;
            foreach (var item in SelectedPDPs)
            {
                item.STT = i++;
                foreach (var kh in item.KHACHHANGs) { CustomerList.Add(kh); }
                foreach (var dv in item.PHIEUSUDUNG.CT_PHIEUDICHVU) { dv.tmpMaPDP = item.MaPhieuDatPhong; ShowSelectedServices.Add(dv); servicesFee += (int)dv.ThanhTien; };
                foreach (var hh in item.PHIEUSUDUNG.CT_PHIEUHANGHOA) { hh.tmpMaPDP = item.MaPhieuDatPhong; ShowSelectedServices.Add(ChangeToCT_PhieuDichVu(hh)); servicesFee += (int)hh.ThanhTien; }
                sumFee += (int)item.DonGia;
                downPayment += (int)item.TienCoc;
            }
            roomFee = sumFee - servicesFee;
            remainingCosts = sumFee - downPayment;

            int t = 1;
            foreach (var item in ShowSelectedServices)
            {
                item.STT = t++;
            }
            RoomFee = roomFee.ToString();
            ServicesFee = servicesFee.ToString();
            SumFee = sumFee.ToString();
            DownPayment = downPayment.ToString();
            RemainingCosts = remainingCosts.ToString();
        }

        public void Clear()
        {
            if (ShowSelectedServices != null)
                ShowSelectedServices.Clear();
            if (ShowSelectedServices != null) 
                CustomerList.Clear();
            nhanvien = null;
        }
    }
}
