using Hotel_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using Hotel_Management_System.View;
using System.ComponentModel;
using System.Data;
using System.Windows.Controls;
using Hotel_Management_System.ViewModel.Other;
using Hotel_Management_System.View.StaffView;
using Hotel_Management_System.View.ServiceView;

namespace Hotel_Management_System.ViewModel.ServiceViewModel
{
    public class ServiceViewModel : BaseViewModel
    {
        public const string NGUNG_KINH_DOANH = "Ngừng kinh doanh";

        private ObservableCollection<DICHVU> _services;
        public ObservableCollection<DICHVU> services
        {
            get { return _services; }
            set
            {
                if (_services != value)
                {
                    _services = value;
                    OnPropertyChanged();
                }
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

        private DICHVU _selectedServiceItem;
        public DICHVU SelectedServiceItem
        {
            get { return _selectedServiceItem; }
            set
            {
                if (_selectedServiceItem != value)
                {
                    _selectedServiceItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public BrushConverter converter;

        public ICommand LoadedUserControlCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public RemoveServiceView removeserviceView;
        public EditServiceView editserviceView;
        public AddServiceView addServiceWindow;



        public ServiceViewModel()
        {
            LoadedUserControlCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                try
                {
                    services = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs);
                    tmpServices = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs);
                }
                catch { return; }
            });

            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                addServiceWindow = new AddServiceView();
                addServiceWindow.ShowDialog();
            });

            SearchCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(p.Text))
                {
                    // Hiển thị lại tất cả dữ liệu nếu không có từ khóa tìm kiếm
                    services = tmpServices;
                }
                else
                {
                    var result = tmpServices.Where(x =>
                        x.MaDichVu.ToString().Contains(p.Text)
                        || x.TenDichVu.Contains(p.Text)
                        || x.DonViTinh.Contains(p.Text)
                        || x.DonGia.ToString().Contains(p.Text)
                    );

                    services = new ObservableCollection<DICHVU>();

                    foreach (var item in result)
                    {
                        services.Add(new DICHVU
                        {
                            MaDichVu = item.MaDichVu,
                            TenDichVu = item.TenDichVu,
                            DonViTinh = item.DonViTinh,
                            DonGia = item.DonGia,

                        });
                    }
                }
            });

            RemoveCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                removeserviceView = new RemoveServiceView();
                removeserviceView.DataContext = new RemoveServiceViewModel(SelectedServiceItem);
                removeserviceView.ShowDialog();
            });

            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                editserviceView = new EditServiceView();
                editserviceView.DataContext = new EditServiceViewModel(SelectedServiceItem);
                editserviceView.ShowDialog();
            });

        }

        public Brush brushList(int i)
        {
            converter = new BrushConverter();
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

        public void Addservice(DICHVU service)
        {
            services.Add(service);
            MessageBox.Show("Thêm mới thông tin thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            addServiceWindow.Close();
        }

        public void UpdateService(DICHVU service)
        {
            DICHVU ServiceToFind = services.FirstOrDefault(c => c.MaDichVu == service.MaDichVu);
            if (ServiceToFind != null)
            {
                ServiceToFind.TenDichVu = service.TenDichVu;
                ServiceToFind.DonViTinh = service.DonViTinh;
                ServiceToFind.DonGia = service.DonGia;

                MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void RemoveService(DICHVU service)
        {
            services.Remove(service);
            services = new ObservableCollection<DICHVU>();
            var serviceList = DataProvider.Ins.DB.DICHVUs;
            foreach (var item in serviceList)
            {
                services.Add(new DICHVU
                {
                    MaDichVu = item.MaDichVu,
                    TenDichVu = item.TenDichVu,
                    DonViTinh = item.DonViTinh,
                    DonGia = item.DonGia,
                });
            }
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            removeserviceView.Close();
        }

        public void LoadCommodity()
        {
            services = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs.Where(x => x.TrangThai != NGUNG_KINH_DOANH));
            foreach (var item in DataProvider.Ins.DB.DICHVUs.Where(x => x.TrangThai == NGUNG_KINH_DOANH)) services.Add(item);
        }
    }
}
