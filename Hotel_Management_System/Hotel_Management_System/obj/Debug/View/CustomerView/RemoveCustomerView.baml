   M S B A M L   `   `   `  ����R  NHotel_Management_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Hotel_Management_System.View.CustomerView)Hotel_Management_System.View.CustomerView  5   	   B    <Hotel_Management_System.View.CustomerView.RemoveCustomerView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Ilocal7clr-namespace:Hotel_Management_System.View.CustomerView     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fHfash=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5	   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f4660fawpf$http://schemas.fontawesome.io/icons/  5
   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��removeCustomerWindow��5   	      RemoveCustomerVM  � DataContext#  [  5   	   $	��530��5   	   $	��650��6   
������  � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�6    � AllowsTransparency . .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closed��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *ClosedWindowCommand+   CommandParameter 6L   �� 	 �� ElementName$	 removeCustomerWindow��5      .��5      �� 
 �� CornerRadius$
 20��6   $��3q�5      ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #6D2FFF��6    � Offset$ 0Q�6/   � 5      $ #FB539B��6   $
 0.75Q�6/   � 5      $ #836EFB��6   $ 1Q�6/   5      ��5"   
   �� 5#      $	 0,1&�6"   $	 1,0&�63   .��5$      � $ White��6   $ 0Q�6.   � 5%      $ White��6   $ 1Q�6-   5&      ._�5)   
   �  � RowDefinitions 5*      �� 5,      $��35 �6    �� 5.      $��* �6    .+�52      �� -   5         ��Name$ pnlControlBar��52      $��0��53   !    �� Orientation$ 
Horizontal=�54   !   $��RightToLeft=�55   !   
������ $��0,0,5,0q�57   !   .+�5;      �� -   5         ��Name$ btnClose��5;        controlButton1#��[ 5<   !   
 � Tag$ #FB539B��5=   !   .��5?      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Xmark=�6%     controlButtonIcon1#��[ 62   5@      �� 5B      -   5        $ btnMinimize��5B      #��[ 5C   !   $ #78A3FC��5D   !   .��5F        $ WindowMinimize=�6%   $��12��6;   #��[ 6F   5G      5H      � 5K      $��1��6   $��
50,10,50,0q�6    $	��Top=�64    � ColumnDefinitions 5L      �� 5M      $	��150 �6'   �� 5N      $��* �6'    5Q      �� 5R      $
��auto �6$   �� 5S      $
��auto �6$   �� 5T      $
��auto �6$   �� 5U      $
��auto �6$   �� 5V      $
��auto �6$   �� 5W      $
��auto �6$   �� 5X      $
��auto �6$   �� 5Y      $
��auto �6$   .+�5\      �� $��0��6   $��Mã khách hàng��6)     text#��[ 6>   �� 5]      $��1��6   $��Tên khách hàng��6)   #��[ 6?   �� 5^      $��2��6   $
��CCCD��6)   #��[ 65   �� 5_      $��3��6   $��Giới tính��6)   #��[ 6:   �� 5`      $��4��6   $��
Ngày sinh��6)   #��[ 6:   �� 5a      $��5��6   $��Số điện thoại��6)   #��[ 6>   �� 5b      $��6��6   $��Loại khách hàng��6)   #��[ 6@   �� 5d      $��1��6   $��0��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686 �� 
IsReadOnly . 
�������  textBox1#��[ 6�   ��6�   �� *MaKhachHang+�� 5e      $��1��6   $��1��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686 . 
�������#��[ 6�   ��6�   �� *TenKhachHang+�� 5f      $��1��6   $��2��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686 . 
�������#��[ 6�   ��6�   �� *CCCD+�� 5g      $ 
Horizontal=�6   $��1��66   $��3��6F   $	��0 5q�6S   .+�5h      �� $ 
Horizontal=�6!   $��0 0 30 0q�6:   .+�5i      d� -   5        $��toggleButtonMale��5i   '    
 button#��[ 6?   {�.   d� 	IsChecked 6_   �� *IsCheckedMale+��5j   '   �� *ClickGenderMaleCommand+��6R   �� $	 toggleButtonFemale��.��5k      "  FontAwesome.WPF.ImageAwesome     Icon$
 Male=�61   $��15��6=   $��15��6H      
Foreground
 �����6T   5l      �� 5m      $	��Nam��6$   ���#363636$��Center=�6D   $��	10 0 20 0q�6_   $��SemiBold"�6r   5n      �� 5p      $ 
Horizontal=�6!   .+�5q      d� -   5        $��toggleButtonFemale��5q   '   #��[ 6A   {�.   6a   �� *IsCheckedFemale+��5r   '   �� *ClickGenderFemaleCommand+��6T   �� $	 toggleButtonMale��.��5s        $ Female=�61   $��15��6?   $��15��6J   
 �����6V   5t      �� 5u      $
��Nữ��6$   ���#363636$��Center=�6C   $��	10 0 20 0q�6^   $��SemiBold"�6q   5v      5w      (  "System.Windows.Controls.DatePicker  5x      $��1��6   $��4��6-   $��30��6:   $
��0 10q�6F   $��Center=�6T   $��0q�6v   ���#868686{�.     SelectedDate 6�   �� *
NgaySinh+�� 5y      $��1��6   $��5��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686 . 
�������#��[ 6�   ��6�   �� *SoDienThoai+�� 5z      $��1��6   $��6��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686 . 
�������#��[ 6�   ��6�   �� *LoaiKhachHang+ �� Mode$ TwoWay=�� 5|      $��1��6   $��7��6'   $��0 30 0 0q�64    5}      �� 5~      $��* �6+   �� 5      $��* �6+   .+�5�      ��   
buttonMain#��[ 6   $��0 0 10 0q�6A   $��Hủy��6S   ��6a   �� *BackCommand+��6�   �� $	 removeCustomerWindow���� 5�      $��1��6     buttonMainGreen#��[ 6-   $��10 0 0 0q�6V   $��Xác nhận xóa��6h   ��6   �� *RemoveCustomerCommand+5�      5�      5�      5�      5�      