using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hotel_Management_System.View.CommodityView
{
    /// <summary>
    /// Interaction logic for ImportCommodityView.xaml
    /// </summary>
    public partial class ImportCommodityView : Window
    {
        public ImportCommodityView()
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

        private void TextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back && ((TextBox)sender).Text.Length == 1)
            {
                ((TextBox)sender).Text = "0";
            }
            else if (((TextBox)sender).Text == "0" && e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                ((TextBox)sender).Text = "";
            }
        }
    }
}
