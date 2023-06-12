using Hotel_Management_System.Model;
using Hotel_Management_System.View;
using Hotel_Management_System.View.ServiceView;
using Hotel_Management_System.ViewModel.Other;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel_Management_System.ViewModel.ServiceViewModel
{
    public class AddServiceViewModel : BaseViewModel
    {

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand AddServiceCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }

        public BrushConverter converter = new BrushConverter();
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string DonViTinh { get; set; }
        public Nullable<int> DonGia { get; set; }

        public AddServiceViewModel()
        {
            LoadedWindowCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { LoadedWindow(p); });

            AddServiceCommand = new RelayCommand<TextBox>((p) => { return CheckAdd(); }, (p) => { AddService(p); });

            BackCommand = new RelayCommand<AddServiceView>((p) => { return true; }, (p) => { p.Close(); });

            ClosedWindowCommand = new RelayCommand<AddServiceView>((p) => { return true; }, (p) => { Clear(); });

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
                temp = DataProvider.Ins.DB.DICHVUs.OrderByDescending(cus => cus.MaDichVu).FirstOrDefault().MaDichVu;
            }
            catch
            {
                temp = "DV" + 10000.ToString();
            }
            MaDichVu = "DV" + (int.Parse(temp.Split('V')[1]) + 1).ToString();
            tb.Text = MaDichVu;
        }

        public void AddService(TextBox tb)
        {
            var service = new DICHVU()
            {
                MaDichVu = this.MaDichVu,
                TenDichVu = this.TenDichVu,
                DonViTinh = this.DonViTinh,
                DonGia = this.DonGia,
            };

            DataProvider.Ins.DB.DICHVUs.Add(service);
            DataProvider.Ins.DB.SaveChanges();

            ServiceView serviceView = new ServiceView();
            if (serviceView.DataContext == null) return;
            var serviceVM = serviceView.DataContext as ServiceViewModel;
            serviceVM.Addservice(service);
        }

        public bool CheckAdd()
        {
            if (MaDichVu != "" && TenDichVu != "" && DonViTinh != "" && DonGia != null)
                return true;
            else return false;
        }

        public void Clear()
        {
            TenDichVu = null;
            DonViTinh = null;
            DonGia = null;
        }
    }
}
