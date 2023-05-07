using Hotel_Management_System.Model;
using Hotel_Management_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel_Management_System.ViewModel
{
    public class AddCustomerViewModel : BaseViewModel
    {
        public ICommand AddCustomerCommand { get; set; } 

        public AddCustomerViewModel()
        {
            AddCustomerCommand = new RelayCommand<UserControl>((p) =>
            {
                return true;

            }, (p) =>
            {
                int i = DataProvider.Ins.DB.KHACHHANGs.Max(cus => cus.MaKhachHang);
                string name = "Test" + i.ToString();
                var customer = new KHACHHANG()
                {
                    MaKhachHang = i + 1,
                    TenKhachHang = name,
                    Character = name.ToString().Substring(0, 1),
                    BgColor = brushList(i),
                    CCCD = "00000000",
                    Email = "111111@gmail.com",
                    SDT = "99999999"
                };

                DataProvider.Ins.DB.KHACHHANGs.Add(customer);
                DataProvider.Ins.DB.SaveChanges();

                CustomerView customerView = new CustomerView();
                if (customerView.DataContext == null) return;
                var customerVM = customerView.DataContext as CustomerViewModel;
                customerVM.AddCustomer(customer);
            });
        }

        public BrushConverter converter = new BrushConverter();
        public Brush brushList(int i)
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
