   M S B A M L   `   `   `  ����@  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake  5   	       Snake.PreGame   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Snake     5   	     � Title$  PreGame��5   	   $
��1080��6   $
��1980��6'    � WindowState$ 	Maximized=�64    � WindowStyle$
 None=�6L    � 	Resources 5	         
play_hover �� ImageSource j� Stretch  FocusVisual �� Property �� Value J� SnapsToDevicePixels	 �� StrokeDashArray  Button.Static.Background
 �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background 	 Button.Disabled.Border 
 Button.Disabled.Foreground  play �� 
TargetType �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 K     &	 �     &	     &	 ;    &	 ^    &	 �    &	 �    &	 �    &		 �    &	
     &	 0    7  7  7  7   7  7  7  7  7 	 7 
 �� 5
   
   $' !/images/buttons/button1_press.png��6(   $
 Fill=�6X   �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $		 1 2R�6�   5      5      5      �� 5   
   $
 	#FFDDDDDD��6;   �� 5   
   $
 	#FF707070��67   �� 5   
   $
 	#FFBEE6FD��6>   �� 5   
   $
 	#FF3C7FB1��6:   �� 5   
   $
 	#FFC4E5F6��6<   �� 5   
   $
 	#FF2C628B��68   �� 5   
   $
 	#FFF4F4F4��6=   �� 5   
   $
 	#FFADB2B5��69   �� 5   
   $
 	#FF838383��6=   �� 5   
   " ��6   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5        � ��8  6,   �� 5!       � ��# � ��6+   �� 5"       � ��$ 1q�60   �� 5#       � ��$ Center=�6;   �� 5$       � ��$ Center=�69   �� 5%       � ��$ 1q�6(   �� 5&       � �� 5'      �� 5(      " ��6&   .R�5)      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5*      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5+       5,      P� 5-       �@��IsDefaulted . . �5.   "   �� $ border��6@   # � ��6T    � ��5/      P� 50       �@J�IsMouseOver . . �51   "   �� $ border��6?   8   � ��6S   �� 52   "   $ border��6@   8   � ��6T   53      P� 54       � �� . . �55   "   �� $ border��6?   8   � ��6S   �� 56   "   $ border��6@   8   � ��6T   57      P� 58       � {� .  . �59   "   �� $ border��6?   8   � ��6S   �� 5:   "   $ border��6@   8   � ��6T   �� 5;   "   $ contentPresenter��6K   8 	  � ��6i   5<      5>      5@      5A      5B      .��5C      � ��5D   
   �� 5E      $! /images/back/background.png��6   .+�5G   
   �� -   5        $
��Back��5G      $
��Left=�6    $��	74,62,0,0q�6;   $	��Top=�6N   $��84��6f   $��65��6q   6}   �� 5H   
   -   5        $�� ��5H      $
��Left=�6   $��812,470,0,0q�67   $	��Top=�6L   $	��280��6d   $	��118��6p   $��0q�6�   #���  6�   ��5I      �� 5J      $# /images/buttons/button1_1.png��6   5L      �� 5M   
   -   5         ��Name$ 
PlayerName��5M   �   $
��Left=�6   $��23��6-   $��902,421,0,0q�69   $��Player��6N   $	��Top=�6\   $	��102��6t   6�   5N      5O      