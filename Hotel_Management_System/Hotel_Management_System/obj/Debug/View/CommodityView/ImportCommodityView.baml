   M S B A M L   `   `   `  ����  Hotel_Management_SystemD    >Hotel_Management_System.View.CommodityView.ImportCommodityView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   g cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   _	 [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	 5	   	   -   5        $��importCommodityWindow��5   	     � Title$  Import Commodity��5   	   $	��750��6"   $
��1200��6/      ImportCommodityVM � DataContext# [  5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedWindowCommand+5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��80 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $	��690 �6#   �� 5      $��* �6#   .+�5!      � $��0��6   $��15 0 5 0q�6#   .+�5"      � $��0��6    5#      �� 5$      $��40 �6(   �� 5%      $��* �6(   .+�5(      �� $��0��6!   $'��!DANH SÁCH HÀNG HÓA NHẬP VÀO��6.   $
��Bold"�6Q   $��Center=�6c   $��Center=�6�   &   System.Windows.Controls.DataGrid  5*      $��1��6      AutoGenerateColumns .    DataGridStyle1#���  5,      
���������5+      �� *ShowSelectedCommoditys+	   Columns	 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn
   Header$
 #��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 45 6T      
IsReadOnly . 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6<   �� *STT+6_     50      $
 Mã hàng hóa��61   $ * 6d    .  6F   �� *	MaHangHoa+6n     51      $
 Tên hàng hóa��61   $ * 6f    .  6G   �� *
TenHangHoa+6p   4
  .System.Windows.Controls.DataGridTemplateColumn
  52      $
 Số lượng��65   $	 100 6G    
  CellTemplate 53   "   �� 54   &   .R�55   *   �� -   5        ��55   2   �� *SoLuongNhap+ �� UpdateSourceTrigger$ PropertyChanged=�.��57   X   58   +   59   '   5;        5<      $
 
Đơn vị��61   $ * 6_    .  6A   �� *	DonViTinh+6i   5>      5?      5@      � 5B      $��1��6   $��	10 0 15 0q�6#    5C      �� 5D      $��35 �6$   62   �� 5E      6&   .+�5H      �� $��0��6   $%��DANH SÁCH HÀNG HÓA TRONG KHO��6)   $��20 0 0 0q�6M   $
��Bold"�6_   $��Center=�6q   $��Center=�6�     5J      -   5          Name$ CommodityDatagrid��5J   (   $��1��6    .    DataGridRowStyle1   RowStyle# �  5L        DataGridCellStyle1   	CellStyle# �  5M      #���  5N      ��5K      �� *
Commoditys+	 5O        5P      $	
 Mã��6-   $	 100 6W    .  69   �� *	MaHangHoa+6c     5Q      $

 Tên��6-   $ 75 6Y    .  6:   �� *
TenHangHoa+6d     5R      $
 	Tồn kho��6-   $	 100 6Y    .  6>   �� *TonKho+6e     5S      $
 
Đơn vị��6-   $	 100 6[    .  6=   �� *	DonViTinh+6g   
  5T      $
 Chọn��61    . $ * 6Q    5U      �� 5V   "   .R�5W   &   ��  �� Orientation$ 
Horizontal=�61   .+�5X   *   �� $��5 0 0 0q�63   ��5Y   -   �� *!DataContext.AddCommodityCommand+ �� RelativeSource ��  �� AncestorType"  ��5[   -   �� 5\   +   5]   '   5^   #   5`      5b      5c      5d      � 5f   
   $��1��6    5g      �� 5h      $��* �6#   6/   �� 5i      $	��300 �6#   61   .+�5l      �� $��0��6   $	��200��6%   $��Right=�61     
buttonMain#��[ 6M   $��0 0 10 0q�6q   $��Hủy��6�   ��6�   �� *BackCommand+��6�   ��  �� ElementName$ importCommodityWindow���� 5n      $��1��6   $	��200��6%     buttonMainGreen#��[ 61   $��10 0 0 0q�6Z   $��Nhập hàng��6l   ��6�   �� *
AddCommand+��6�   �� $ importCommodityWindow��5o      5p      5q      