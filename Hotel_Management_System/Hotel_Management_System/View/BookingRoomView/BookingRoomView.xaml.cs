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

        private void TextBox_PreviewTextInput2(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNumeric2(e.Text);
        }

        private bool IsNumeric2(string text)
        {
            // Kiểm tra xem chuỗi có chứa toàn số hay không
            return int.TryParse(text, out int result);
        }

        private void TextBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Back && ((System.Windows.Controls.TextBox)sender).Text.Length == 1)
            {
                ((System.Windows.Controls.TextBox)sender).Text = "0";
            }
            else if (((System.Windows.Controls.TextBox)sender).Text == "0" && e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                ((System.Windows.Controls.TextBox)sender).Text = "";
            }
        }
    }
}
