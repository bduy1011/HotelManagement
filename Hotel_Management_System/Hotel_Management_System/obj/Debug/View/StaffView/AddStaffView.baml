   M S B A M L   `   `   `  ����  Hotel_Management_System9    3Hotel_Management_System.View.StaffView.AddStaffView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fHfash=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f4660fawpf$http://schemas.fontawesome.io/icons/  5	   	   -   5        $��addStaffWindow��5   	      
AddStaffVM  � DataContext#  [  5
   	   $	��665��5   	   $	��650��6   
������  � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�6    � AllowsTransparency . .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedWindowCommand+   CommandParameter 6L   �� 	 �� ElementName$	 txtMNV��5        5   
   $ Closed��6   . 5         6$   �� *ClosedWindowCommand+ 6L   �� $	 addStaffWindow��5      .��5      �� 
 �� CornerRadius$
 20��6   $��3q�5      ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #6D2FFF��6    � Offset$ 0Q�6/   � 5      $ #FB539B��6   $
 0.75Q�6/   � 5       $ #836EFB��6   $ 1Q�6/   5!      ��5$   
   �� 5%      $	 0,1&�6"   $	 1,0&�63   .��5&      � $ White��6   $ 0Q�6.   � 5'      $ White��6   $ 1Q�6-   5(      ._�5+   
   � $��0,0,0,-3q�6    � ColumnDefinitions 5,      �� 5-      �� 5.      $��0* �6#    � RowDefinitions 50      �� 52      $��35 �6    �� 54      $��* �6    .+�58      �� -   5         ��Name$ pnlControlBar��58      $��0��59   !    �� Orientation$ 
Horizontal=�5:   !   $��RightToLeft=�5;   !   
������ $��0,0,5,0q�5=   !   .+�5A      �� -   5         ��Name$ btnClose��5A        controlButton1#��[ 5B   !   
 � Tag$ #FB539B��5C   !   .��5E      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Xmark=�6%     controlButtonIcon1#��[ 62   5F      �� 5H      -   5        $ btnMinimize��5H      #��[ 5I   !   $ #78A3FC��5J   !   .��5L        $ WindowMinimize=�6%   $��12��6;   #��[ 6F   5M      5N      � 5Q      $��1��6   $��
50,10,50,0q�6    $	��Top=�64    5R      �� 5S      $	��150 �6'   �� 5T      $��* �6'    5W      �� 5X      $
��auto �6$   �� 5Y      $
��auto �6$   �� 5Z      $
��auto �6$   �� 5[      $
��auto �6$   �� 5\      $
��auto �6$   �� 5]      $
��auto �6$   �� 5^      $
��auto �6$   �� 5_      $
��auto �6$   �� 5`      $
��auto �6$   �� 5a      $
��auto �6$   �� 5b      $
��auto �6$   .+�5e      �� $��0��6   $��Mã nhân viên��6)     text#��[ 6=   �� 5f      $��1��6   $��Tên nhân viên��6)   #��[ 6>   �� 5g      $��2��6   $
��CCCD��6)   #��[ 65   �� 5h      $��3��6   $��Số điện thoại��6)   #��[ 6>   �� 5i      $��4��6   $��Bộ phận��6)   #��[ 68   �� 5j      $��5��6   $��Chức vụ��6)   #��[ 68   �� 5k      $��6��6   $��
Ngày sinh��6)   #��[ 6:   �� 5l      $��7��6   $��Giới tính��6)   #��[ 6:   �� 5m      $��8��6   $��Tên tài khoản��6)   #��[ 6>   �� 5n      $��9��6   $��Mật khẩu��6)   #��[ 69   �� 5p      -   5        $��txtMNV��5p   �   $��1��6   $��0��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686 �� 
IsReadOnly . 
�������  textBox1#��[ 6�   ��6�   �� *
MaNhanVien+�� 5q      -   5        $��1��5q      $��1��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686#��[ 6�   ��6�   �� *TenNhanVien+�� 5r      -   5        $��1��5r      $��2��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686#��[ 6�   ��6�   �� *CCCD+�� 5s      -   5        $��1��5s      $��3��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686#��[ 6�   ��6�   �� *SoDienThoai+�� 5t      $��1��6   $��4��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686#��[ 6�   ��6�   �� *BoPhan+�� 5u      $��1��6   $��5��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686#��[ 6�   ��6�   �� *ChucVu+�� 5v      $ 
Horizontal=�6   $��1��66   $��7��6F   $	��0 5q�6S   .+�5w      �� $ 
Horizontal=�6!   $��0 0 30 0q�6:   .+�5x      d� -	   5        $��toggleButtonMale��5x   '    
 button#��[ 6?    d� 	IsChecked 6_   �� *IsCheckedMale+��5y   '   �� *ClickGenderMaleCommand+��6R   �� $	 toggleButtonFemale��.��5z      "  FontAwesome.WPF.ImageAwesome     Icon$
 Male=�61   $��15��6=   $��15��6H      
Foreground
 �����6T   5{      �� 5|      $	��Nam��6$   ���#363636$��Center=�6D   $��	10 0 20 0q�6_   $��SemiBold"�6r   5}      �� 5      $ 
Horizontal=�6!   .+�5�      d� -
   5        $��toggleButtonFemale��5�   '   #��[ 6A    6a   �� *IsCheckedFemale+��5�   '   �� *ClickGenderFemaleCommand+��6T   �� $	 toggleButtonMale��.��5�        $ Female=�61   $��15��6?   $��15��6J   
 �����6V   5�      �� 5�      $
��Nữ��6$   ���#363636$��Center=�6C   $��	10 0 20 0q�6^   $��SemiBold"�6q   5�      5�      (  "System.Windows.Controls.DatePicker  5�      $��1��6   $��6��6-   $��30��6:   $
��0 10q�6F   $��Center=�6T   $��0q�6v   ���#868686   SelectedDate 6�   �� *
NgaySinh+�� 5�      $��1��6   $��8��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686 . 
�������#��[ 6�   ��6�   �� *TenTaiKhoan+�� 5�      $��1��6   $��9��6*   $��30��67   $
��0 10q�6C   $��Center=�6Q   ���#868686 . 
�������#��[ 6�   ��6�   �� *
Password+� 5�      $��0��6   $��10��6'   $��0,40,0,0q�65    5�      �� 5�      $��40 �6+   �� 5�      $��* �6+   .+�5�      �� -   5        $��CheckBoxCreateAccount��5�   =   $��0��6   $��10��6/   $
��Left=�6Z   ��6u   �� *CreateAccountCommand+ 6�   �� *IsCheckCreateAccount+ � LayoutTransform 5�      �� 5�       �� ScaleX$ 2Q�6-    �� ScaleY$ 2Q�68   5�      �� 5�      $��1��6    $
��Left=�60   $��Center=�6K   
����  �$��Tạo tài khoản��6|   #��[ 6�   5�      � 5�      $��1��6   $��10��6'   $��0,40,0,0q�65    5�      �� 5�      $��* �6+   �� 5�      $��* �6+   .+�5�      ��   
buttonMain#��[ 6   $��0 0 10 0q�6A   $��Hủy��6S   ��6a   �� *BackCommand+��6�   �� $	 addStaffWindow���� 5�      $��1��6     buttonMainGreen#��[ 6-   $��10 0 0 0q�6V   $��Thêm mới��6h   ��6{   �� *AddStaffCommand+��6�   �� $	 txtMNV��5�      5�      5�      5�      5�      