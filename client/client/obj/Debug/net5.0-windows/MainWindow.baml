   M S B A M L   `   `   `  ����A  =client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:clientclient  5   	   +clr-namespace:client.Pagesclient.Pages  6,       client.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:client     5   	   ,pagesclr-namespace:client.Pages     6,   -   5          � Title$  Szolg. Prog. Beadandó��5	   	   $	��900��6'   $
��1600��64    � WindowStartupLocation$ CenterScreen=�6A    � WindowState$ 	Maximized=�6f   .��5
      �  � RowDefinitions 5   
   �� 5      $
��50px �6   �� 5      �� 5      $
��50px �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��
10 10 10 0q�6;   .+�5      �� -   5         ��Name$ 	btn_books��5   Q   $��Books��6   $
��70px��6%   6f   �� 5      -   5        $ btn_authors��5   U   $��Authors��6   $
��70px��6'   6l   �� 5      -   5        $ 	btn_users��5   c   $��Users��6   $
��70px��6%   ${�False��6Q   6x   5       � 5   
   -   5          �Name$ frm_content��5        � NavigationUIVisibility$ Hidden=�6%   $��1��6E   $��10q�6R     � Source$ Pages/Books.page.xaml?�6_   5      �� 5   
   $ 
Horizontal=�6   $��2��6.   $��	10 0 10 0q�6;   .+�5      �� -   5        	 ��Name$	 lbl_userName��5   =   $��Guest - Login��6   $
��30px(�6-   6�   5      5      5      