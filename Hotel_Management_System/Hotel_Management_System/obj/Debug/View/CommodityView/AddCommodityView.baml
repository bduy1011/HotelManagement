   M S B A M L   `   `   `  ����  Hotel_Management_SystemA    ;Hotel_Management_System.View.CommodityView.AddCommodityView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fHfash=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f4660fawpf$http://schemas.fontawesome.io/icons/  5	   	   -   5        $��addGoodsWindow��5   	      AddCommodityVM  � DataContext#  [  5
   	   $	��470��5   	   $	��650��6   
������  � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�6    � AllowsTransparency . .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedWindowCommand+   CommandParameter 6L   �� 	 �� ElementName$	 txtMHH��5        5   
   $ Closed��6   . 5         6$   �� *ClosedWindowCommand+ 6L   �� $	 addGoodsWindow��5      .��5      �� 
 �� CornerRadius$
 20��6   $��3q�5      ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #6D2FFF��6    � Offset$ 0Q�6/   � 5      $ #FB539B��6   $
 0.75Q�6/   � 5       $ #836EFB��6   $ 1Q�6/   5!      ��5$   
   �� 5%      $	 0,1&�6"   $	 1,0&�63   .��5&      � $ White��6   $ 0Q�6.   � 5'      $ White��6   $ 1Q�6-   5(      ._�5+   
   �  � RowDefinitions 5,      �� 5.      $��35 �6    �� 50      $��* �6    .+�54      �� -   5         ��Name$ pnlControlBar��54      $��0��55   !    �� Orientation$ 
Horizontal=�56   !   $��RightToLeft=�57   !   
������ $��0,0,5,0q�59   !   .+�5=      �� -   5         ��Name$ btnClose��5=        controlButton1#��[ 5>   !   
 � Tag$ #FB539B��5?   !   .��5A      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Xmark=�6%     controlButtonIcon1#��[ 62   5B      �� 5D      -   5        $ btnMinimize��5D      #��[ 5E   !   $ #78A3FC��5F   !   .��5H        $ WindowMinimize=�6%   $��12��6;   #��[ 6F   5I      5J      � 5M      $��1��6   $��
50,10,50,0q�6    $	��Top=�64    � ColumnDefinitions 5N      �� 5O      $	��150 �6'   �� 5P      $��* �6'    5S      �� 5T      $
��auto �6$   �� 5U      $
��auto �6$   �� 5V      $
��auto �6$   �� 5W      $
��auto �6$   �� 5X      $
��auto �6$   �� 5Y      $
��auto �6$   �� 5Z      $
��auto �6$   .+�5]      �� $��0��6   $��Mã hàng hóa��6)     text#��[ 6<   �� 5^      $��1��6   $��Tên hàng hóa��6)   #��[ 6=   �� 5_      $��2��6   $��Số lượng ban đầu��6)   #��[ 6A   �� 5`      $��3��6   $��Đơn vị tính��6)   #��[ 6<   �� 5a      $��4��6   $��Đơn giá nhập��6)   #��[ 6=   �� 5b      $��5��6   $��Đơn giá bán��6)   #��[ 6<   �� 5d      -   5        $��txtMHH��5d   �   $��1��6   $��0��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686 �� 
IsReadOnly . 
�������  textBox1#��[ 6�   ��6�   �� *	MaHangHoa+�� 5e      $��1��6   $��1��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686#��[ 6�   ��6�   �� *
TenHangHoa+�� 5f      -   5        $��1��5f      $��2��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686#��[ 6�   ��6�   �� *TonKho+�� 5g      $��1��6   $��3��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686#��[ 6�   ��6�   �� *	DonViTinh+�� 5h      -   5        $��1��5h      $��4��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686#��[ 6�   ��6�   �� *
DonGiaNhap+�� 5i      -   5        $��1��5i      $��5��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686#��[ 6�   ��6�   �� *	DonGiaBan+� 5k      $��1��6   $��10��6'   $��0 30 0 0q�65    5l      �� 5m      $��* �6+   �� 5n      $��* �6+   .+�5q      ��   
buttonMain#��[ 6   $��0 0 10 0q�6A   $��Hủy��6S   ��6a   �� *BackCommand+��6�   �� $	 addGoodsWindow���� 5s      $��1��6     buttonMainGreen#��[ 6-   $��10 0 0 0q�6V   $��Thêm mới��6h   ��6{   �� *AddCommodityCommand+��6�   �� $	 txtMHH��5t      5u      5v      5w      5x      