   M S B A M L   `   `   `  ����R  NHotel_Management_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Hotel_Management_SystemHotel_Management_System  5      :    4Hotel_Management_System.View.AccountView.AccountView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Hotel_Management_System     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fHfash=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f4660fawpf$http://schemas.fontawesome.io/icons/  5	      g cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac	 _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks  	 5
      _
 [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 
 5      -   5        $��userControlAccount��5         	AccountVM  � DataContext#  [  5      .��5      � .+�5   
   �� ���#200F53 �� CornerRadius$ 10��5       �� Padding$ 10q�5      ._�5      � .+�5      � $��
50,10,50,0q�6   $	��Top=�6+    � ColumnDefinitions 5      �� 5      $	��150 �6+   �� 5      $��* �6+    � RowDefinitions 5      �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5       $
��auto �6(   �� 5!      $
��auto �6(   �� 5"      $
��auto �6(   �� 5#      $
��auto �6(   �� 5$      $
��auto �6(   �� 5%      $
��auto �6(   �� 5&      $
��auto �6(   �� 5'      $
��auto �6(   �� 5(      $
��auto �6(   .+�5+      �� 
�������$��0��63   $��Mã nhân viên��6@     text#��[ 6T   �� 5,      
�������$��1��63   $��Tên nhân viên��6@   #��[ 6U   �� 5-      
�������$��2��63   $
��CCCD��6@   #��[ 6L   �� 5.      
�������$��3��63   $��Số điện thoại��6@   #��[ 6U   �� 5/      
�������$��4��63   $��Bộ phận��6@   #��[ 6O   �� 50      
�������$��5��63   $��Chức vụ��6@   #��[ 6O   �� 51      
�������$��6��63   $��
Ngày sinh��6@   #��[ 6Q   �� 52      
�������$��7��63   $��Giới tính��6@   #��[ 6Q   �� 53      
�������$��8��63   $��Tên tài khoản��6@   #��[ 6U   �� 54      
�������$��9��63   $��Mật khẩu��6@   #��[ 6P   �� 56      -   5        $��txtMNV��56   �   $��1��6   $��0��6.   $��30��6;   $
��0 10q�6G   $��Center=�6U   ���#868686 �� 
IsReadOnly . 
�������  textBox1#��[ 6�   $��NV10000��6�   �� 57      -   5        $��1��57      $��1��6.   $��30��6;   $
��0 10q�6G   $��Center=�6U   ���#868686#��[ 6�   $��Huỳnh Tiến Phát��6�   �� 58      -   5        $��1��58      $��2��6.   $��30��6;   $
��0 10q�6G   $��Center=�6U   ���#868686#��[ 6�   $��030802016299��6�   �� 59      -   5        $��1��59      $��3��6.   $��30��6;   $
��0 10q�6G   $��Center=�6U   ���#868686#��[ 6�   $��
0362309724��6�   �� 5:      $��1��6   $��4��6.   $��30��6;   $
��0 10q�6G   $��Center=�6U   ���#868686#��[ 6�   $��	Lễ tân��6�   �� 5;      $��1��6   $��5��6.   $��30��6;   $
��0 10q�6G   $��Center=�6U   ���#868686#��[ 6�   $��
Quản lý��6�   �� 5<       �� Orientation$ 
Horizontal=�6!   $��1��6:   $��7��6J   $	��0 5q�6W   .+�5=      �� $ 
Horizontal=�6%   $��0 0 30 0q�6>   .+�5>      d� -   5        $��toggleButtonMale��5>   +    
 button#��[ 6C    d� 	IsChecked$
 TrueY�6c   ��5?   '   �� *ClickGenderMaleCommand+��6R   ��  �� ElementName$ toggleButtonFemale��.��5@   "   "  FontAwesome.WPF.ImageAwesome  	   Icon$
	 Male=�65   $��15��6A   $��15��6L   
   
Foreground

 �����6X   5A      �� 5B      $	��Nam��6(   
�������$��Center=�6F   $��	10 0 20 0q�6a   $��SemiBold"�6t   5C      �� 5E      $ 
Horizontal=�6%   .+�5F      d� -   5        $��toggleButtonFemale��5F   +   #��[ 6E   $ FalseY�6e   ��5G   '   �� *ClickGenderFemaleCommand+��6T   �� $ toggleButtonMale��.��5H   "     $	 Female=�65   $��15��6C   $��15��6N   

 �����6Z   5I      �� 5J      $
��Nữ��6(   
�������$��Center=�6E   $��	10 0 20 0q�6`   $��SemiBold"�6s   5K      5L      (  "System.Windows.Controls.DatePicker  5M      $��1��6!   $��6��61   $��30��6>   $
��0 10q�6J   $��Center=�6X   $��0q�6z   ���#868686   SelectedDate$ 
2003-09-24X�6�   �� 5N      $��1��6   $��8��6.   $��30��6;   $
��0 10q�6G   $��Center=�6U   ���#868686 . 
�������#��[ 6�   $��NV10000��6�   �� 5O      $��1��6   $��9��6.   $��30��6;   $
��0 10q�6G   $��Center=�6U   ���#868686 . 
�������#��[ 6�   $��*****��6�   � 5Q      $��1��6   $��10��6+   $��
0,32,0,-82q�69    J� RenderTransformOrigin$ 0.473,-0.015&�6M    5R      �� 5S      $��* �6/   �� 5T      $��* �6/   .+�5W      �� $��1��6!     buttonMainGreen#��[ 61   $��10 0 0 0q�6Z   $��Cập nhật��6l   ��6   �� *EditStaffCommand+5X      5Y      5Z      5[      5\      5]      