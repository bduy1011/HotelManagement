   M S B A M L   `   `   `  ����R  NHotel_Management_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Hotel_Management_SystemHotel_Management_System  5      >    8Hotel_Management_System.View.CommodityView.CommodityView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Hotel_Management_System     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      g cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5	      _	 [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5
      -   5        $��userControlGoods��5         CommodityVM  � DataContext#  [  5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedUserControlCommand+   CommandParameter 5   $   ��  �� ElementName$ membersDataGrid��5        5   
   $ KeyUp��6   . 5         6$   �� *SearchCommand+ 5   $   �� $ textBoxSearch��5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      .+�5!   
   � $��0��6    � ColumnDefinitions 5"      �� 5#      $��* �6#   �� 5$      $	��120 �6#   �� 5%      $	��120 �6#   .+�5'      �� 	 �� Orientation$	 
Horizontal=�6   $	��Top=�5(      $��0��5)      .+�5*      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]
   Icon$
 Search=�6   $��20��6-   $��20��69      
Foreground �#7376BD6D   �� 5+      -   5         ��Name$ textBoxSearch��5+      $��13(�5,      $��24��5-      $	��300��5.      $��5,5,0,0q�5/      
������ $��Medium"�51      $��
Montserrat)�52      ���#7376BD �� 
CaretBrush �#7376BD���#7376BD$��0,0,0,2q�56      $��Center=�57      ) 	 #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Search...��58      59      �� 5:      $��1��6   $��Thêm hàng hóa��5;      $��12(�5<      $��
Montserrat)�5=       � Cursor$
 Hand��5>      $��0q�5?      
�������$	��Top=�5A      $��0 0 10 0q�5B      ��5C      �� *
AddCommand+��5D      �� 5E       �� 
TargetType" ��6   .�5F      ��  �� Property � �� �� Value �#773DFF67   �� 5G       � �� 5H      �� 5I   "    �� 
TargetType" ��62   .R�5J   &   �� $��30��6-    �� CornerRadius$ 15��5K   5   #��z��5L   5   ._�5M   *   �� $��Center=�6;   $��Center=�5N   G   5O   '   5P   #   5R       �� Triggers 5S      P� 5T       P� Property �@J�IsMouseOver P� Value . . �5U   "   ��  � �� �#836EFB6?   5V      5X      5Z      �� 5\      $��2��6   $��Nhập hàng��5]      $��12(�5^      $��
Montserrat)�5_      $
 Hand��5`      $��0q�5a      
�������$	��Top=�5c      $��10 0 0 0q�5d      ��5e      �� *ImportCommodityCommand+��5f      �� 5g      " ��6   .�5h      ��  � ��
 � � �67   �� 5i       � �� 5j      �� 5k   "   " ��62   .R�5l   &   �� $��30��6-   $ 15��5m   5   #��z��5n   5   ._�5o   *   �� $��Center=�6;   $��Center=�5p   G   5q   '   5r   #   5t       5u      P� 5v       �@J�IsMouseOver . . �5w   "   ��  � ��
 �"�"�6?   5x      5z      5|      5}      �� 5�   
   $��1��6   ���#200F53$ 10��5�       �� Padding$ 10q�5�      ._�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ membersDataGrid��5�        DataGridRowStyle1   RowStyle# �  5�        DataGridColumnHeaderStyle1   ColumnHeaderStyle# �  5�        DataGridCellStyle1   	CellStyle# �  5�        DataGridStyle1#���  5�         ColumnWidth5	  /System.Windows.Controls.DataGridLengthConverter$ *	 5�      ���#200F53$��0q�5�         AutoGenerateColumns .  ��5�      �� *	commodity+ �� SelectedItem 5�      �� *SelectedCommodityItem+  �� Mode$  TwoWay=�!   Columns! 5�      0
  *System.Windows.Controls.DataGridTextColumn
  5�      ,  &System.Windows.Controls.DataGridColumn"   Header$" #��6)   #   
IsReadOnly# . $   Width$
$ auto	 6F   1  +System.Windows.Controls.DataGridBoundColumn%   Binding% 6S   �� *	MaHangHoa+
  5�      $" Tên hàng hóa��6)   # . $$ *	 6Q   % 6[   �� *
TenHangHoa+
  5�      $" 	Tồn kho��6)   # . $$ *	 6g   % 6:   �� *TonKho+6g   
  5�      $" Đơn vị tính��6)   # . $$ *	 6n   % 6>   �� *	DonViTinh+6n   
  5�      $" Đơn giá nhập��6)   # . $$ *	 6p   % 6?   �� *
DonGiaNhap+6p   
  5�      $" Đơn giá bán��6)   # . $$ *	 6n   % 6>   �� *	DonGiaBan+6n   4  .System.Windows.Controls.DataGridTemplateColumn  5�      # . $
$ auto	 6?   &   CellTemplate& 5�      �� 5�      .R�5�   "   �� $	 
Horizontal=�6-   .+�5�   &   �� ��5�   *   �� 5�   .   " ��64   .�5�   2   ��  � y�$ 	Collapsed=�6O    5�   2   ^� 5�   6   ' ^� 
Conditions' 5�   :   �� 5�   >   ( �� Binding( 6H   �� *
Visibility+$ removeButton��) �� Value) 	Collapsed6�   �� 5�   >   ( 6H   �� *Tag+$ removeButton��) Ngừng kinh doanh6z   .0�5�   :   ��  � y�$ Visible=�6W   �� 5�   :    � ��$ Ngừng kinh doanh��6Q   �� 5�   :    � ��
 � ���6W   5�   7   5�   /   5�   '   �� 5�   &   * ��Name$* 
editButton��6-     gridEditButton#��[ 6A   ��5�   -   �� *DataContext.EditCommand++ �� RelativeSource+ �� , �� AncestorType",  ��5�   -   �� .��5�   *   .  (MahApps.Metro.IconPacks.PackIconMaterial  $��icon1��6U   -   Kind$- PencilOutline=�6@     gridButtonIcon#��[ 6b   5�   '   �� 5�   &   $* removeButton��6-   $��5 0 0 0q�6C     gridRemoveButton#��[ 6T   ��5�   *   �� *DataContext.RemoveCommand++ �� ",  ��5�   *   �� .��5�   *     $��icon2��6U   $- DeleteOutline=�6@   #��[ 6b   5�   '   5�   #   . �� Triggers. 5�   "   �� 5�   &   / �� Value$/ Ngừng kinh doanh��6P   0 �� Binding0 62   �� *	TrangThai+.a�5�   *   �� 1 �� 
TargetName$1 removeButton��61    � y�$ 	Collapsed=�6a   �� 5�   *   $1 
editButton��61    � y�$ 	Collapsed=�6_   �� 5�   *   $1 removeButton��61    �@�Tag$ Ngừng kinh doanh��6Z   5�   '   5�      5�      5�      5�      5�      5�      