using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace Hotel_Management_System.View.CustomerView
{
    /// <summary>
    /// Interaction logic for AddCustomerView.xaml
    /// </summary>
    public partial class AddCustomerView : Window
    {
        public AddCustomerView()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TextBox_PreviewTextInput1(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsLetter(e.Text);
        }

        private bool IsLetter(string text)
        {
            // Kiểm tra xem chuỗi có chứa toàn chữ cái hay không
            return text.All(char.IsLetter);
        }

        private void TextBox_PreviewTextInput2(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNumeric2(e.Text);
        }

        private bool IsNumeric2(string text)
        {
            // Kiểm tra xem chuỗi có chứa toàn số hay không
            return text.All(char.IsDigit);
        }
    }
}
