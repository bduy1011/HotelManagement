   M S B A M L   `   `   `  ����  Hotel_Management_System:    4Hotel_Management_System.View.StaffView.EditStaffView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fHfash=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f4660fawpf$http://schemas.fontawesome.io/icons/  5	   	   -   5        $��editStaffWindow��5   	      EditStaffVM  � DataContext#  [  5
   	   $	��665��5   	   $	��650��6   
������  � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�6    � AllowsTransparency . .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closed��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *ClosedWindowCommand+   CommandParameter 6L   �� 	 �� ElementName$	 editStaffWindow��5      .��5      �� 
 �� CornerRadius$
 20��6   $��3q�5      ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #6D2FFF��6    � Offset$ 0Q�6/   � 5      $ #FB539B��6   $
 0.75Q�6/   � 5      $ #836EFB��6   $ 1Q�6/   5      ��5    
   �� 5!      $	 0,1&�6"   $	 1,0&�63   .��5"      � $ White��6   $ 0Q�6.   � 5#      $ White��6   $ 1Q�6-   5$      ._�5'   
   �  � RowDefinitions 5(      �� 5*      $��35 �6    �� 5,      $��* �6    .+�50      �� -   5         ��Name$ pnlControlBar��50      $��0��51   !    �� Orientation$ 
Horizontal=�52   !   $��RightToLeft=�53   !   
������ $��0,0,5,0q�55   !   .+�59      �� -   5         ��Name$ btnClose��59        controlButton1#��[ 5:   !   
 � Tag$ #FB539B��5;   !   .��5=      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Xmark=�6%     controlButtonIcon1#��[ 62   5>      �� 5@      -   5        $ btnMinimize��5@      #��[ 5A   !   $ #78A3FC��5B   !   .��5D        $ WindowMinimize=�6%   $��12��6;   #��[ 6F   5E      5F      � 5I      $��1��6   $��
50,10,50,0q�6    $	��Top=�64    � ColumnDefinitions 5J      �� 5K      $	��150 �6'   �� 5L      $��* �6'    5O      �� 5P      $
��auto �6$   �� 5Q      $
��auto �6$   �� 5R      $
��auto �6$   �� 5S      $
��auto �6$   �� 5T      $
��auto �6$   �� 5U      $
��auto �6$   �� 5V      $
��auto �6$   �� 5W      $
��auto �6$   �� 5X      $
��auto �6$   �� 5Y      $
��auto �6$   �� 5Z      $
��auto �6$   .+�5]      �� $��0��6   $��Mã nhân viên��6)     text#��[ 6=   �� 5^      $��1��6   $��Tên nhân viên��6)   #��[ 6>   �� 5_      $��2��6   $
��CCCD��6)   #��[ 65   �� 5`      $��3��6   $��Số điện thoại��6)   #��[ 6>   �� 5a      $��4��6   $��Bộ phận��6)   #��[ 68   �� 5b      $��5��6   $��Chức vụ��6)   #��[ 68   �� 5c      $��6��6   $��
Ngày sinh��6)   #��[ 6:   �� 5d      $��7��6   $��Giới tính��6)   #��[ 6:   �� 5e      $��8��6   $��Tên tài khoản��6)   #��[ 6>   �� 5f      $��9��6   $��Mật khẩu��6)   #��[ 69   �� 5h      -   5        $��txtMNV��5h   �   $��1��6   $��0��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686 �� 
IsReadOnly . 
�������  textBox1#��[ 6�   ��6�   �� *
MaNhanVien+�� 5i      -   5        $��1��5i      $��1��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686#��[ 6�   ��6�   �� *TenNhanVien+�� 5j      -   5        $��1��5j      $��2��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686#��[ 6�   ��6�   �� *CCCD+�� 5k      -   5        $��1��5k      $��3��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686#��[ 6�   ��6�   �� *SoDienThoai+�� 5l      $��1��6   $��4��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686#��[ 6�   ��6�   �� *BoPhan+�� 5m      $��1��6   $��5��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686#��[ 6�   ��6�   �� *ChucVu+�� 5n      $ 
Horizontal=�6   $��1��66   $��7��6F   $	��0 5q�6S   .+�5o      �� $ 
Horizontal=�6!   $��0 0 30 0q�6:   .+�5p      d� -	   5        $��toggleButtonMale��5p   '    
 button#��[ 6?    d� 	IsChecked 6_   �� *IsCheckedMale+��5q   '   �� *ClickGenderMaleCommand+��6R   �� $	 toggleButtonFemale��.��5r      "  FontAwesome.WPF.ImageAwesome     Icon$
 Male=�61   $��15��6=   $��15��6H      
Foreground
 �����6T   5s      �� 5t      $	��Nam��6$   ���#363636$��Center=�6D   $��	10 0 20 0q�6_   $��SemiBold"�6r   5u      �� 5w      $ 
Horizontal=�6!   .+�5x      d� -
   5        $��toggleButtonFemale��5x   '   #��[ 6A    6a   �� *IsCheckedFemale+��5y   '   �� *ClickGenderFemaleCommand+��6T   �� $	 toggleButtonMale��.��5z        $ Female=�61   $��15��6?   $��15��6J   
 �����6V   5{      �� 5|      $
��Nữ��6$   ���#363636$��Center=�6C   $��	10 0 20 0q�6^   $��SemiBold"�6q   5}      5~      (  "System.Windows.Controls.DatePicker  5      $��1��6   $��6��6-   $��30��6:   $
��0 10q�6F   $��Center=�6T   $��0q�6v   ���#868686   SelectedDate 6�   �� *
NgaySinh+�� 5�      $��1��6   $��8��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686 . 
�������#��[ 6�   ��6�   �� *TenTaiKhoan+�� 5�      $��1��6   $��9��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686 . 
�������#��[ 6�   ��6�   �� *
Password+� 5�      $��1��6   $��10��6'   $��
0,32,0,-82q�65    J� RenderTransformOrigin$ 0.473,-0.015&�6I    5�      �� 5�      $��* �6+   �� 5�      $��* �6+   .+�5�      ��   
buttonMain#��[ 6   $��0 0 10 0q�6A   $��Hủy��6S   ��6a   �� *BackCommand+��6�   �� $	 editStaffWindow���� 5�      $��1��6     buttonMainGreen#��[ 6-   $��10 0 0 0q�6V   $��Cập nhật��6h   ��6{   �� *EditStaffCommand+��6�   �� $	 txtMNV��5�      5�      5�      5�      5�      