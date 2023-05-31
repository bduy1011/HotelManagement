using Hotel_Management_System.Model;
using Hotel_Management_System.View.StaffView;
using Hotel_Management_System.ViewModel.Other;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel_Management_System.ViewModel.StaffViewModel
{
    public class StaffViewModel : BaseViewModel
    {
        private ObservableCollection<NHANVIEN> _staffs;
        public ObservableCollection<NHANVIEN> staffs
        {
            get { return _staffs; }
            set
            {
                if (_staffs != value)
                {
                    _staffs = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<NHANVIEN> _tmpStaffs;
        public ObservableCollection<NHANVIEN> tmpStaffs
        {
            get { return _tmpStaffs; }
            set
            {
                if (_tmpStaffs != value)
                {
                    _tmpStaffs = value;
                    OnPropertyChanged();
                }
            }
        }

        private NHANVIEN _selectedStaffItem;
        public NHANVIEN SelectedStaffItem
        {
            get { return _selectedStaffItem; }
            set
            {
                if (_selectedStaffItem != value)
                {
                    _selectedStaffItem = value;
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

        public RemoveStaffView removestaffView;
        public EditStaffView editStaffView;
        public AddStaffView addStaffWindow;

        public StaffViewModel()
        {
            LoadedUserControlCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            { 
                try
                {
                    staffs = new ObservableCollection<NHANVIEN>();
                    tmpStaffs = new ObservableCollection<NHANVIEN>();

                    var staffList = DataProvider.Ins.DB.NHANVIENs;

                    foreach (NHANVIEN item in staffList)
                    {
                        staffs.Add(new NHANVIEN
                        {
                            MaNhanVien = item.MaNhanVien,
                            Character = item.TenNhanVien.ToString().Substring(0, 1),
                            BgColor = brushList((int.Parse(item.MaNhanVien.Substring(2)))),
                            TenNhanVien = item.TenNhanVien,
                            CCCD = item.CCCD,
                            SoDienThoai = item.SoDienThoai,
                            BoPhan = item.BoPhan,
                            ChucVu = item.ChucVu,
                            NgaySinh = item.NgaySinh,
                            GioiTinh = item.GioiTinh,
                            TenTaiKhoan = item.TenTaiKhoan,
                            MatKhau = item.MatKhau
                        });
                    }
                    tmpStaffs = staffs;
                }
                catch { }
            });

            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                addStaffWindow = new AddStaffView();
                addStaffWindow.ShowDialog();
            });

            SearchCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(p.Text))
                {
                    // Hiển thị lại tất cả dữ liệu nếu không có từ khóa tìm kiếm
                    staffs = tmpStaffs;
                }
                else
                {
                    var result = tmpStaffs.Where(x =>
                        x.MaNhanVien.ToString().Contains(p.Text)
                        || x.TenNhanVien.Contains(p.Text)
                        || x.CCCD.Contains(p.Text)
                        || x.BoPhan.Contains(p.Text)
                        || x.SoDienThoai.Contains(p.Text)
                        || x.ChucVu.Contains(p.Text)
                    );

                    staffs = new ObservableCollection<NHANVIEN>();

                    foreach (var item in result)
                    {
                        staffs.Add(new NHANVIEN
                        {
                            MaNhanVien = item.MaNhanVien,
                            Character = item.TenNhanVien.ToString().Substring(0, 1),
                            BgColor = brushList((int.Parse(item.MaNhanVien.Substring(2)))),
                            TenNhanVien = item.TenNhanVien,
                            CCCD = item.CCCD,
                            SoDienThoai = item.SoDienThoai,
                            BoPhan = item.BoPhan,
                            ChucVu = item.ChucVu,
                            NgaySinh = item.NgaySinh,
                            GioiTinh = item.GioiTinh,
                            TenTaiKhoan = item.TenTaiKhoan,
                            MatKhau = item.MatKhau
                        });
                    }
                }
            });

            RemoveCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                removestaffView = new RemoveStaffView();
                removestaffView.DataContext = new RemoveStaffViewModel(SelectedStaffItem);
                removestaffView.ShowDialog();
            });

            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                editStaffView = new EditStaffView();
                editStaffView.DataContext = new EditStaffViewModel(SelectedStaffItem);
                editStaffView.ShowDialog();
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

        public void Addstaff(NHANVIEN staff)
        {
            staffs.Add(staff);
            MessageBox.Show("Thêm mới thông tin thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            addStaffWindow.Close();
        }

        public void UpdateStaff(NHANVIEN staff)
        {
            NHANVIEN StaffToFind = staffs.FirstOrDefault(c => c.MaNhanVien == staff.MaNhanVien);
            if (StaffToFind != null)
            {
                StaffToFind.TenNhanVien = staff.TenNhanVien;
                StaffToFind.CCCD = staff.CCCD;
                StaffToFind.GioiTinh = staff.GioiTinh;
                StaffToFind.NgaySinh = staff.NgaySinh;
                StaffToFind.SoDienThoai = staff.SoDienThoai;
                StaffToFind.ChucVu = staff.ChucVu;
                StaffToFind.BoPhan = staff.BoPhan;
                StaffToFind.TenTaiKhoan = staff.TenTaiKhoan;
                StaffToFind.MatKhau = staff.MatKhau;
                MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void RemoveStaff(NHANVIEN staff)
        {
            staffs.Remove(staff);
            staffs = new ObservableCollection<NHANVIEN>();
            var staffList = DataProvider.Ins.DB.NHANVIENs;
            foreach (var item in staffList)
            {
                staffs.Add(new NHANVIEN
                {
                    MaNhanVien = item.MaNhanVien,
                    TenNhanVien = item.TenNhanVien,
                    GioiTinh = item.GioiTinh,
                    NgaySinh = item.NgaySinh,
                    CCCD = item.CCCD,
                    SoDienThoai = item.SoDienThoai,
                    BoPhan = item.BoPhan,
                    ChucVu = item.ChucVu,
                    TenTaiKhoan = item.TenTaiKhoan,
                    MatKhau = item.MatKhau
                });
            }
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            removestaffView.Close();
        }
    }
}
