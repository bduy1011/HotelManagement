using Hotel_Management_System.Model;
using Hotel_Management_System.View.BookingRoomView;
using Hotel_Management_System.View.CustomerView;
using Hotel_Management_System.ViewModel.Other; 
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotel_Management_System.ViewModel.BookingRoomViewModel
{
    public class BookingRoomViewModel : BaseViewModel
    {
        private ObservableCollection<DICHVU> _services;
        public ObservableCollection<DICHVU> Services
        {
            get { return _services; }
            set
            {
                _services = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<HANGHOA> _commoditys;
        public ObservableCollection<HANGHOA> Commoditys
        {
            get { return _commoditys; }
            set
            {
                _commoditys = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<CT_PHIEUDICHVU> _selectedServices;
        public ObservableCollection<CT_PHIEUDICHVU> SelectedServices
        {
            get { return _selectedServices; }
            protected set
            {
                _selectedServices = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<CT_PHIEUHANGHOA> _selectedCommoditys;
        public ObservableCollection<CT_PHIEUHANGHOA> SelectedCommoditys
        {
            get { return _selectedCommoditys; }
            set
            {
                _selectedCommoditys = value;
                OnPropertyChanged();
            }
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

        private PHONG _room;
        public PHONG Room
        {
            get { return _room; }
            set
            {
                _room = value;
                OnPropertyChanged();
            }
        }

        private PHIEUSUDUNG _usageBill;
        public PHIEUSUDUNG UsageBill
        {
            get { return _usageBill; }
            set
            {
                _usageBill = value;
                OnPropertyChanged();
            }
        }

        private PHIEUDATPHONG _reservationBill;
        public PHIEUDATPHONG ReservationBill
        {
            get { return _reservationBill; }
            set
            {
                _reservationBill = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<DICHVU> _tmpServices;
        public ObservableCollection<DICHVU> tmpServices
        {
            get { return _tmpServices; }
            set
            {
                if (_tmpServices != value)
                {
                    _tmpServices = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<HANGHOA> _tmpCommoditys;
        public ObservableCollection<HANGHOA> tmpCommoditys
        {
            get { return _tmpCommoditys; }
            set
            {
                if (_tmpCommoditys != value)
                {
                    _tmpCommoditys = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<KHACHHANG> _addCustomers;
        public ObservableCollection<KHACHHANG> AddCustomers
        {
            get { return _addCustomers; }
            set
            {
                _addCustomers = value;
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
        private string _completelyPayment;
        private string _downPayment;
        private string _discount;

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

        public string CompletelyPayment
        {
            get { return _completelyPayment; }
            set
            {
                if (_completelyPayment != value)
                {
                    _completelyPayment = value;
                    OnPropertyChanged();
                }
            }
        }

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

        public string Discount
        {
            get { return _discount; }
            set
            {
                if (_discount != value)
                {
                    _discount = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isLastRow;
        public bool IsLastRow
        {
            get { return _isLastRow; }
            set
            {
                if (_isLastRow != value)
                {
                    _isLastRow = value;
                    OnPropertyChanged();
                }
            }
        }


        public ICommand LoadedWindowCommand { get; set; }
        public ICommand LoadedServicesCommand { get; set; }
        public ICommand LoadedCommoditysCommand { get; set; }
        public ICommand LoadedAddCustomerCommand { get; set; }
        public ICommand AddServiceCommand { get; set; }
        public ICommand AddCommodityCommand { get; set; }
        public ICommand AddCustomerCommand { get; set; }
        public ICommand RemoveSelectedServiceCommand { get; set; }
        public ICommand RemoveCustomerCommand { get; set; }
        public ICommand TextChangedCommand { get; set; }
        public ICommand SearchServicesCommand { get; set; }
        public ICommand SearchCommoditysCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand BookingRoomCommand { get; set; }
        

        public BookingRoomViewModel(PHONG room) : this()
        {
            Room = room;
            //RoomFee = Room.LOAIPHONG.DonGia.ToString();
            RoomFee = "500000";
            SumFee = RoomFee;
            RemainingCosts = RoomFee;
            ServicesFee = "0";
            Discount = "";
            DownPayment = "";
            CompletelyPayment = "0";
        }

        public BookingRoomViewModel()
        {
            LoadedWindowCommand = new RelayCommand<MainWindow>((p) => { return true; }, (p) =>
            {
                UsageBill = new PHIEUSUDUNG();
                UsageBill.MaPhieuSuDung = "SD1";

                ReservationBill = new PHIEUDATPHONG();
                ReservationBill.MaPhieuDatPhong = "DP123";
                ReservationBill.NgayLap = DateTime.Now;
                ReservationBill.NgayDen = DateTime.UtcNow;
                ReservationBill.MaPhieuSuDung = UsageBill.MaPhieuSuDung;

                SelectedServices = new ObservableCollection<CT_PHIEUDICHVU>();

                SelectedCommoditys = new ObservableCollection<CT_PHIEUHANGHOA>();

                ShowSelectedServices = new ObservableCollection<CT_PHIEUDICHVU>();

                tmpServices = new ObservableCollection<DICHVU>();

                tmpCommoditys = new ObservableCollection<HANGHOA>();

                AddCustomers = new ObservableCollection<KHACHHANG>();
                
                KHACHHANG kh = new KHACHHANG();

                string temp = "";
                try
                {
                    temp = DataProvider.Ins.DB.KHACHHANGs.OrderByDescending(cus => cus.MaKhachHang).FirstOrDefault().MaKhachHang;
                }
                catch
                {
                    temp = "KH" + (10000 - 1).ToString();
                }
                kh.MaKhachHang = "KH" + (int.Parse(temp.Split('H')[1]) + 1).ToString();

                AddCustomers.Add(kh);

                AddCustomers.CollectionChanged += AddCustomers_CollectionChanged;
            });

            LoadedServicesCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                try
                {
                    Services = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs);
                }
                catch
                {
                    Services = new ObservableCollection<DICHVU>();
                }

                int i = 1;
                foreach (var item in Services)
                {
                    item.STT = i++;
                }
                tmpServices = Services;
            });

            LoadedCommoditysCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                try
                {
                    Commoditys = new ObservableCollection<HANGHOA>(DataProvider.Ins.DB.HANGHOAs);
                }
                catch
                {
                    Commoditys = new ObservableCollection<HANGHOA>();
                }

                int i = 1;
                foreach (var item in Commoditys)
                {
                    item.STT = i++;
                }
                tmpCommoditys = Commoditys;
            });

            AddServiceCommand = new RelayCommand<DICHVU>((p) => { return true; }, (p) =>
            {
                foreach (var item in SelectedServices)
                {
                    if (item.MaDichVu == p.MaDichVu)
                    {
                        item.SoLuong++;
                        item.ThanhTien = item.SoLuong * p.DonGia;
                        UpdateFee(SelectedServices, SelectedCommoditys);
                        return;
                    }
                }

                CT_PHIEUDICHVU ctpdv = new CT_PHIEUDICHVU(p);
                ctpdv.MaPhieuSuDung = UsageBill.MaPhieuSuDung;
                int tmp = ShowSelectedServices.Count;
                ctpdv.STT = ++tmp;
                ctpdv.SoLuong = 1;
                ctpdv.ThanhTien = ctpdv.SoLuong * p.DonGia;
                SelectedServices.Add(ctpdv);
                ShowSelectedServices.Add(ctpdv);
                UpdateFee(SelectedServices, SelectedCommoditys);
            });

            AddCommodityCommand = new RelayCommand<HANGHOA>((p) => { return true; }, (p) =>
            {
                foreach (var item in SelectedCommoditys)
                {
                    if (item.MaHangHoa == p.MaHangHoa)
                    {
                        item.SoLuong++;
                        item.ThanhTien = item.SoLuong * p.DonGiaBan;
                    }
                }

                foreach (var item in ShowSelectedServices)
                {
                    if (item.MaDichVu == p.MaHangHoa)
                    {
                        item.SoLuong++;
                        item.ThanhTien = item.SoLuong * p.DonGiaBan;
                        UpdateFee(SelectedServices, SelectedCommoditys);
                        return;
                    }
                }

                CT_PHIEUHANGHOA ctphh = new CT_PHIEUHANGHOA(p);
                ctphh.MaPhieuSuDung = UsageBill.MaPhieuSuDung;
                int tmp = ShowSelectedServices.Count;
                ctphh.STT = ++tmp;
                ctphh.SoLuong = 1;
                ctphh.ThanhTien = ctphh.SoLuong * p.DonGiaBan;
                SelectedCommoditys.Add(ctphh);
                ShowSelectedServices.Add(ChangeToCT_PhieuDichVu(ctphh));
                UpdateFee(SelectedServices, SelectedCommoditys);
            });

            RemoveSelectedServiceCommand = new RelayCommand<CT_PHIEUDICHVU>((p) => { return true; }, (p) =>
            {
                if (p.MaDichVu.Contains("DV"))
                {
                    SelectedServices.Remove(p);
                }
                else if (p.MaDichVu.Contains("HH"))
                {
                    foreach(var item in SelectedCommoditys)
                    {
                        if (item.MaHangHoa == p.MaDichVu)
                        {
                            SelectedCommoditys.Remove(item);
                            break;
                        }
                    }
                }
                ShowSelectedServices.Remove(p);
                int t = 1;
                foreach (var item in ShowSelectedServices)
                {
                    item.STT = t++;
                }
                UpdateFee(SelectedServices, SelectedCommoditys);
            });

            TextChangedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                int sumFee = int.Parse(SumFee);
                int discount;
                int downPayment;
                try { discount = int.Parse(Discount); } catch { discount = 0; };
                try { downPayment = int.Parse(DownPayment); } catch { downPayment = 0; };
                int completelyPayment = discount + downPayment;
                CompletelyPayment = completelyPayment.ToString();
                int remainingCosts = sumFee - completelyPayment;
                RemainingCosts = remainingCosts.ToString();
            });

            SearchServicesCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(p.Text))
                {
                    Services = tmpServices;
                }
                else
                {
                    var result = tmpServices.Where(x =>
                        x.MaDichVu.Contains(p.Text) ||
                        x.TenDichVu.Contains(p.Text) ||
                        x.DonGia.ToString().Contains(p.Text)
                    );

                    Services = new ObservableCollection<DICHVU>();

                    foreach (var item in result)
                    {
                        Services.Add(item);
                    }
                }
            });

            SearchCommoditysCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(p.Text))
                {
                    Commoditys = tmpCommoditys;
                }
                else
                {
                    var result = tmpCommoditys.Where(x =>
                        x.MaHangHoa.Contains(p.Text) ||
                        x.TenHangHoa.Contains(p.Text) ||
                        x.DonGiaBan.ToString().Contains(p.Text)
                    );

                    Commoditys = new ObservableCollection<HANGHOA>();

                    foreach (var item in result)
                    {
                        Commoditys.Add(item);
                    }
                }
            });

            BackCommand = new RelayCommand<BookingRoomView>((p) => { return true; }, (p) => { p.Close(); });

            BookingRoomCommand = new RelayCommand<BookingRoomView>((p) => { return true; }, (p) => { p.Close(); });

            LoadedAddCustomerCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => 
            {
                for (int i = 0; i < AddCustomers.Count; i++)
                {
                    var item = AddCustomers[i];
                    var propertyInfo = item.GetType().GetProperty("IsLastRow");
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(item, i == AddCustomers.Count - 1);
                    }
                }
            });

            AddCustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                KHACHHANG kh = new KHACHHANG();
                
                string temp = "";
                try
                {
                    temp = AddCustomers[AddCustomers.Count - 1].MaKhachHang;
                }
                catch
                {
                    temp = "KH" + (23410000 - 1).ToString();
                }
                kh.MaKhachHang = "KH" + (int.Parse(temp.Split('H')[1]) + 1).ToString();

                AddCustomers.Add(kh);
            });

            RemoveCustomerCommand = new RelayCommand<KHACHHANG>((p) => { return AddCustomers.Count > 1; }, (p) =>
            {
                foreach (var item in AddCustomers)
                {
                    if (item.MaKhachHang == p.MaKhachHang)
                    {
                        AddCustomers.Remove(item);
                        break;
                    }
                }
                string temp = DataProvider.Ins.DB.KHACHHANGs.OrderByDescending(cus => cus.MaKhachHang).FirstOrDefault().MaKhachHang;
                AddCustomers[0].MaKhachHang = "KH" + (int.Parse(temp.Split('H')[1]) + 1).ToString();
                for (int i = 0; i < AddCustomers.Count; i++)
                {
                    var item = AddCustomers[i];
                    item.IsLastRow = (i == AddCustomers.Count - 1);
                    if(i != 0)
                        item.MaKhachHang = "KH" + (int.Parse(AddCustomers[i-1].MaKhachHang.Split('H')[1]) + 1).ToString();
                    
                }

            });

            BookingRoomCommand = new RelayCommand<KHACHHANG>((p) => { return true; }, (p) => 
            {
                //DataProvider.Ins.DB.CT_PHIEUDICHVU.AddRange(SelectedServices);
                //DataProvider.Ins.DB.CT_PHIEUHANGHOA.AddRange(SelectedCommoditys);
                //DataProvider.Ins.DB..AddRange(SelectedCommoditys);
                //DataProvider.Ins.DB.SaveChanges();
            });
        }

        public void UpdateFee(ObservableCollection<CT_PHIEUDICHVU> ct_PHIEUDICHVUs, ObservableCollection<CT_PHIEUHANGHOA> ct_PHIEUHANGHOAs)
        {
            int servicesFee = 0;
            foreach (var item in ct_PHIEUDICHVUs) { servicesFee += (int)item.ThanhTien; }
            foreach (var item in ct_PHIEUHANGHOAs) { servicesFee += (int)item.ThanhTien; }
            ServicesFee = servicesFee.ToString();

            int sumFee = servicesFee + int.Parse(RoomFee);
            SumFee = sumFee.ToString();

           int discount;
           int downPayment;
            try { discount = int.Parse(Discount); } catch { discount = 0; };
            try { downPayment = int.Parse(DownPayment); } catch { downPayment = 0; };

            int completelyPayment = discount + downPayment;
            CompletelyPayment = completelyPayment.ToString();
            int remainingCosts = sumFee - completelyPayment;
            RemainingCosts = remainingCosts.ToString();
        }

        public CT_PHIEUDICHVU ChangeToCT_PhieuDichVu(CT_PHIEUHANGHOA ctphh)
        {
            DICHVU dv = new DICHVU();
            dv.MaDichVu = ctphh.HANGHOA.MaHangHoa;
            dv.TenDichVu = ctphh.HANGHOA.TenHangHoa;
            dv.DonGia = ctphh.HANGHOA.DonGiaBan;
            CT_PHIEUDICHVU ctpdv = new CT_PHIEUDICHVU(dv);
            ctpdv.STT = ctphh.STT;
            ctpdv.SoLuong = ctphh.SoLuong;
            ctpdv.ThanhTien = ctphh.ThanhTien;
            return ctpdv;
        }

        private void AddCustomers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // Update the IsLastRow property for each item in the AddCustomers collection
                for (int i = 0; i < AddCustomers.Count; i++)
                {
                    var item = AddCustomers[i];
                    item.IsLastRow = (i == AddCustomers.Count - 1);
                }
            }
        }
    }  
}
