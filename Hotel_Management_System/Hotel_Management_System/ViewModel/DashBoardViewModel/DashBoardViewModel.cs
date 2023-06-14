using Hotel_Management_System.Model;
using Hotel_Management_System.ViewModel.Other;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel_Management_System.ViewModel.DashBoardViewModel
{
    public class DashBoardViewModel : BaseViewModel
    {
        private ChartValues<double> charttol;
        private ChartValues<double> chartser;
        public ChartValues<double> ChartTol
        {
            get { return charttol; }
            set { charttol = value; OnPropertyChanged(); }
        }

        public ChartValues<double> ChartSer
        {
            get { return chartser; }
            set { chartser = value; OnPropertyChanged(); }
        }
        private double revenue;
        public double Revenue
        {
            get { return revenue; }
            set { revenue = value; OnPropertyChanged(); }
        }
        private int numPeo;
        public int NumPeo
        {
            get { return numPeo; }
            set { numPeo = value; OnPropertyChanged(); }
        }
        private int numBill;
        public int NumBill
        {
            get { return numBill; }
            set { numBill = value; OnPropertyChanged(); }
        }

        public ICommand LoadedUserControlCommand { get; set; }

        public DashBoardViewModel()
        {
            LoadedUserControlCommand = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                ChartTol = new ChartValues<double>();
                ChartSer = new ChartValues<double>();
                LoadDB(DateTime.Now.Month);
                LoadChart();
            });
        }
        private void LoadChart()
        {
            for (int i = 1; i <= 12; i++)
            {
                double TotalMoney = 0;
                double TotalService = 0;
                foreach(var item in DataProvider.Ins.DB.HOADONs)
                {
                    if(item.NgayLap.Value.Month == i && item.TrangThai == "Đã thanh toán")
                    {
                        TotalMoney += (int)item.TriGia;
                        if (item.CT_HOADON != null && item.CT_HOADON.Count != 0)
                        {
                            foreach (var item1 in item.CT_HOADON)
                            {
                                foreach (var ctdv in DataProvider.Ins.DB.CT_PHIEUDICHVU)
                                {
                                    if (ctdv.MaPhieuSuDung == item1.PHIEUDATPHONG.MaPhieuSuDung)
                                        TotalService += (int)ctdv.ThanhTien;
                                };
                                foreach (var cthh in DataProvider.Ins.DB.CT_PHIEUHANGHOA)
                                {
                                    if (cthh.MaPhieuSuDung == item1.PHIEUDATPHONG.MaPhieuSuDung)
                                        TotalService += (int)cthh.ThanhTien;
                                };
                            }
                        }
                    }
                }

                TotalMoney /= 1000000;
                TotalService /= 1000000;
                
                ChartTol.Add(TotalMoney);
                ChartSer.Add(TotalService);
            }
        }
        private void LoadDB(int Month)
        {
            Revenue = 0;
            NumPeo = 0;
            NumBill = 0;
            foreach (var item in DataProvider.Ins.DB.HOADONs)
            {
                if (item.NgayLap.Value.Month == Month && item.TrangThai == "Đã thanh toán")
                {
                    if (item.CT_HOADON != null && item.CT_HOADON.Count != 0)
                    {
                        foreach(var item1 in item.CT_HOADON)
                        {
                            NumPeo += (int)item1.PHIEUDATPHONG.SoNguoi;
                        }
                    }
                    NumBill++;
                    Revenue += (int)item.TriGia;
                }
            }
            Revenue /= 1000000;
        }
    }
}
