using Hotel_Management_System.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Resources.ResXFileRef;


namespace Hotel_Management_System.View
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {

        public BrushConverter converter = new BrushConverter();

        public CustomerView()
        {
            InitializeComponent();
            ObservableCollection<KHACHHANG> members = new ObservableCollection<KHACHHANG>();

            var khList = DataProvider.Ins.DB.KHACHHANGs;

            int i = 1;
            foreach (var item in khList)
            {
                members.Add(new KHACHHANG
                {
                    MaKhachHang = i,
                    Character = item.TenKhachHang.ToString().Substring(0, 1),
                    BgColor = listBrush(i),
                    TenKhachHang = item.TenKhachHang,
                    CCCD = item.CCCD,
                    Email = item.Email,
                    SDT = item.SDT
                });
                i++;
            }
            membersDataGrid.ItemsSource = members;
        }

        public Brush listBrush(int i)
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
    }
}
