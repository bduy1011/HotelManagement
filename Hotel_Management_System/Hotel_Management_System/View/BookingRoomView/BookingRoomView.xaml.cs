using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hotel_Management_System.View.BookingRoomView
{
    /// <summary>
    /// Interaction logic for BookingRoomView.xaml
    /// </summary>
    public partial class BookingRoomView : Window
    {
        public BookingRoomView()
        {
            InitializeComponent();
        }

        private void ngayDiDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? ngayDen = ngayDenDatePicker.SelectedDate;
            DateTime? ngayDi = ngayDiDatePicker.SelectedDate;

            if (ngayDen != null && ngayDi != null && ngayDi >= ngayDen)
            {
                gioDiTextBlock.Text = "12:00";
                int countDay = (ngayDi.Value - ngayDen.Value).Days;
                countDayTextBox.Text = string.Format("{0} đêm", ++countDay);
            }
            else
            {
                countDayTextBox.Text = "#";
            }
        }
    }
}
