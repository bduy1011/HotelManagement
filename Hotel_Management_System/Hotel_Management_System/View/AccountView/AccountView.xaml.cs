using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hotel_Management_System.View.AccountView
{
    /// <summary>
    /// Interaction logic for AccountView.xaml
    /// </summary>
    public partial class AccountView : UserControl
    {
        public AccountView()
        {
            InitializeComponent();
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
