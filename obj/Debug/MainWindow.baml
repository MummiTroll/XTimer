   M S B A M L   `   `   `  ����A  =Timer2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Timer2Timer2  5   	       Timer2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Timer2     5   	   -   5        $	��350��5      $	��350��6'     � WindowStartupLocation$  Manual=�5   	   
 � Top$	 688��6(    � Left$ 0��62    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�6    � AllowsTransparency . .��5
      �� $��3q�6   
���"�"����#C0C0C0._�5   
   � -   5         �Name$ MainGrid��5       � RowDefinitions 5      �� 5      $��1* �6    �� 5      $
��0.8* �6    �� 5      $
��4.3* �6    �� 5      $��3* �6    �� 5      $
��0.8* �6    �� 5      $��3* �6    �� 5      $��1* �6     � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $
��1.6* �6#   �� 5      $��7* �6#   �� 5      $
��2.5* �6#   �� 5      $��1* �6#   ��5      �� 5      	 j� Stretch$
	 Fill=�6   
 �� ImageSource$K
 Epack://application:,,,/Timer2;component/Resources/TimerBackground.png��6,    j� 
AlignmentY$	 Top=�6�    j� 
AlignmentX$ Center=�6�   .+�5       �� $��XTimer��6   $��0��6%   $��2��62   $��2��6C   $��Center=�6S   $��	AR Blanca)�6p   $��24(�6�   
���"�"�5!      �� 5#      $��1��6   $��2��6#   $	��150��63   $��20��6?   $��0,7,0,0q�5$      $��Center=�6$   $��	Castellar)�6H   $��12(�6_   $
��Bold"�6m   
����iA�
�������$��0q�5%   *   ��5#   K   �� *	TimerName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5%   *   �� 5(      $��0��6   $
��Left=�6)   $
��Auto��6D   $
��Auto��6Q   $��8,6,4,6q�6_   .+�5)      �� $E��?pack://application:,,,/Timer2;component/Resources/Timer5_64.ico��6   5*      �� 5+      $��1��6   $��©ПК��6)   $��SegoeUI)�64   $��11(�6I   $
��Left=�5,      $��Center=�68   $��4,3,4,0q�6S   � 5.      -   5        $��TitleBar��5.      $��0��6$   $��3��61   $��2��6A   $��0,6,2,0q�6U   $��Right=�6f   $	��Top=�6�    5/      �� 50      $��15 �6'   �� 51      $��1* �6'   �� 52      $��35 �6'   �� 53      $��20 �6'   �� 54      $��30 �6'   .+�56      �� -   5        $��	Normalize��56   )   $��2��6   $��0q�6:   
������ $y�	Collapsed=�6�   $��Center=�57      ��56   g   �� *NormalizeIt+.��58      F�    	Normalize#��[  6   
���   �$
��0.75��6M   $��12��6e    �� Stretch$
 Fill=�6q   $��12��6�   59      �� 5:      -   5        $��Minimize��5:   )   $��3��6   $��0q�69   
������ $��Center=�6�   ��6f   �� *
MinimizeIt+.��5;      F�   Minimize#��[ 6   
���   �$
��0.75��6L   $��10��6d   $
 Fill=�6p   $��12��6   5<      �� 5=      -   5        $��Maximize��5=   )   $��2��6   $��0q�69   
������ $y�	Collapsed=�6�   $��Center=�6�   ��6f   �� *
MaximizeIt+.��5>      F�   Maximize#��[ 6   
���   �$
��0.75��6L   $��10��6d   $
 Fill=�6p   $��10��6   5?      �� 5@      -   5        $��Close��5@   )   $��4��6   $��0q�66   
������ $��Center=�6   ��6c   �� *	CloseIt+.��5A      F�  	 Close#��[ 6   
���   �$
��0.75��6I   $��10��6a   $
 Fill=�6m   $��10��6|   5B      5C      �� 5D      -   5         ��Name$	 RTB��5D      $��2��6(   $��1��65   $��3��6E   $��Calibri)�6Y   $��18(�6n   $	��280��6|   $	��100��6�   $��0,3,0,0q�5E      $��Center=�5F      $��Center=�6<   $��2,5,0,0q�6`    �� 
IsReadOnly . ��5E   +   �� *OverallBackColor+$ OneWay=�$ PropertyChanged=� �� FallbackValue$ White��. �5G      /�  /� 
PageHeight$
 Auto��6   .T�5H      J� .*�6    .*�5I      �� �6   �� *	textRange+$ TwoWay=�5J      5K       � 	Resources 5L       �� 
TargetType �� Property �� Value��%�   '��       �� 5M      " ��6   .�5N      ��  �@��CornerRadius$ 8��69   �� 5O       �@��Padding$ 5q�64   5P      5Q      5R      �� 5j      $��2��6   $��3��6$   $��15��64   $��15��6?   $��Bottom=�6K   $��9(�6f    . $��
40,0,0,-15q�5l   �   $��	2.5,0,0,0q�6�   ��5k      �� *TimerIndicator1+$ OneWay=�$ PropertyChanged=�$	 ↑����5l      �� *BackgroundTimerIndicator1+$ OneWay=�$ PropertyChanged=�$ White��.��6�    5m      ��%_   '��       �� 5n      " ��6   .�5o      ��  �@��CornerRadius$ 12��69   5p      5q      .��6%   5r      � 5t      -	   5        $ Buttons��5t      $��3��6$   $��2��61    5u      �� 5v      $��1* �6$   �� 5w      $��1* �6$   .+�5z      � -
   5        $ Buttons1��5z      $��0��6)   $��30��66   $��0,5,0,0q�6B    5{      �� 5|      $��1* �6+   �� 5}      $��1* �6+   �� 5~      $��1* �6+   .+�5�      �� -   5         ��Name$
 Hour��5�      $��H_��6L   $��0��6b   $��55��6r   $��22��6}   $
��HOUR��6�   $
��Left=�6�   ��6+   �� *SetTimeValue+6�   �� 5�      -   5        $	 Min��5�      $��M_��6K   $��1��6a   $��55��6q   $��22��6|   $	��MIN��6�   $��Center=�6�   ��6*   �� *SetTimeValue+6�   �� 5�      -   5        $	 Sec��5�      $��S_��6K   $��2��6a   $��55��6q   $��22��6|   $	��SEC��6�   $��Right=�6�   ��6*   �� *SetTimeValue+6�   5�      � 5�      -   5        $ Buttons2��5�      $��1��6)   $��30��66   $��0,-5,0,0q�6B    5�      �� 5�      $	��29* �6+   �� 5�      $	��64* �6+   �� 5�      $	��92* �6+   .+�5�      �� -   5        $ 	StartStop��5�      $	��St_��6O   $��0��6f   $��75��6v   $��22��6�   $��
Start/Stop��6�   $
��Left=�6�   $��2��6�   $	��0,4q�6�   ��60   �� *
StartTimer+6�   �� 5�      -   5        $ Clear��5�      $��2��6,   $��C_��6[   $��76��6q   $��22��6|   $��Clear��6�   $��Right=�6�   $��
0,4,-0.5,4q�6�   ��6<   �� *
ClearTimer+6�   5�      5�      	� 5�       	� 	GroupName$ A��6   $��Clock��6(   $��3��68   $��3��6E   $��0,-2,0,0q�6U   $��	7,13,0,40q�6h   $��Center=�6�    d� 	IsChecked 6{   �� *Clock+$ TwoWay=�$ PropertyChanged=�6�   	� 5�      $ A��6   $��Timer��6(   $��3��68   $��3��6E   $��0,-2,0,0q�6U   $��7,27,0,0q�6h   $��Center=�6�    6z   �� *Timer+$ TwoWay=�$ PropertyChanged=�6�   � 5�      -   5        $ 
TimeValues��5�      $��3��6'   $��1��64   $��Center=�6D    5�      �� 5�      $��1* �6$   �� 5�      $��1* �6$   �� 5�      $��1* �6$   .+�5�      �� -   5         ��Name$
 Box1��5�      $��0��6(   $��23��65   $��20��6@   $��Center=�6L   $��Center=�6n   $��10(�5�   i   $��0,0,0,0q�6w   $��0q�6�    � Cursor$ Arrow��5�      ��5�      �� *TimeValues1+$ TwoWay=�$ PropertyChanged=�.��5�   O    5�      ��%^   '��       �� 5�      " ��6    .�5�      ��  �@��CornerRadius$ 6��6=   5�      5�      .��6)   5�      �� 5�      -   5        $
 Box2��5�      $��1��6(   $��23��65   $��20��6@   $��Center=�6L   $��Center=�6n   $��10(�5�   i   $��0,2,0,0q�6w   $��0q�6�   $ Arrow��5�      ��5�      �� *TimeValues2+$ TwoWay=�$ PropertyChanged=�.��5�   O    5�      ��%^   '��       �� 5�      " ��6    .�5�      ��  �@��CornerRadius$ 6��6=   5�      5�      .��6)   5�      �� 5�      -   5        $
 Box3��5�      $��2��6(   $��23��65   $��20��6@   $��Center=�6L   $��Center=�6n   $��10(�5�   i   $��0,2,0,0q�6w   $��0q�6�   $ Arrow��5�      ��5�      �� *TimeValues3+$ TwoWay=�$ PropertyChanged=�.��5�   O    5�      ��%^   '��       �� 5�      " ��6    .�5�      ��  �@��CornerRadius$ 6��6=   5�      5�      .��6)   5�      5�      �� 5�      $��
Days count��6   $��4��6)   $��2��66   $��Center=�6F   $��SegoeUI)�6c   $��12(�6x   $��	10,-4,0,0q�5�      � 5�      -   5        $ 	TimerDays��5�      $��5��6&   $��1��63   $��3��6C    5�      �� 5�      $��1* �6$   �� 5�      $��1* �6$   �� 5�      $��1* �6$    5�      �� 5�      $��1* �6'   �� 5�      $��3* �6'   �� 5�      $��5* �6'   �� 5�      $��1* �6'   �� 5�      $��3* �6'   �� 5�      $��5* �6'   .+�5�      �� $��1��6   $��0��6'   $��15��67   $��15��6B   $��Center=�6N   $��9(�6i    . $��0,0,0,0q�5�   }   $��	2.5,0,0,0q�6�   ��6   �� *TimerIndicator2+$ OneWay=�$ PropertyChanged=�$	 ↑����5�      �� *BackgroundTimerIndicator2+$ OneWay=�$ PropertyChanged=�$ White��.��6�    5�      ��%_   '��       �� 5�      " ��6    .�5�      ��  �@��CornerRadius$ 12��6=   5�      5�      .��6)   5�      �� 5�      -   5        $
 Box4��5�      $��0��6(   $��1��65   $��3��6E   $��30��6W   $��30��6b   $��Center=�6o   $��Center=�6�   $��16(�5�   i   $��0,0,0,0q�6w   $��0q�6�   $ Arrow��5�      ��5�      �� *DaysValues1+$ TwoWay=�$ PropertyChanged=�.��5�   )    5�      ��%^   '��       �� 5�      " ��6    .�5�      ��  �@��CornerRadius$ 6��6=   5�      5�      .��6)   5�      �� 5�      $	��Set��6   $��0��6'   $��2��64   $��60��6D   $��19��6O   $��11(�6[   $��s1��5�   g   ��6   �� *	SetDays+$ TwoWay=�$ PropertyChanged=�6g   �� 5�      $��
Start/stop��6   $��1��6.   $��2��6;   $��60��6K   $��19��6V   $��11(�6b   $��b1��5�   i   ��6   �� *	StartStop+$ TwoWay=�$ PropertyChanged=�6i   �� 5�      $��Clear��6   $��2��6)   $��2��66   $��60��6F   $��19��6Q   $��11(�6]   $��d1��5�   f   ��6   �� *Delete+$ TwoWay=�$ PropertyChanged=�6f   �� 5�      $��1��6   $��3��6'   $��15��67   $��15��6B   $��Center=�6N   $��9(�6i    . $��0,0,0,0q�5�   }   $��	2.5,0,0,0q�6�   ��6   �� *TimerIndicator3+$ OneWay=�$ PropertyChanged=�$	 ↑����5�      �� *BackgroundTimerIndicator3+$ OneWay=�$ PropertyChanged=�$ White��.��6�    5�      ��%_   '��       �� 5�      " ��6    .�5�      ��  �@��CornerRadius$ 12��6=   5�      5�      .��6)   5�      �� 5�      -   5        $
 Box5��5�      $��0��6(   $��4��65   $��3��6E   $��30��6W   $��30��6b   $��Center=�6o   $��Center=�6�   $��18(�5�   i   $��0,0,0,0q�6w   $��0q�6�   $ Arrow��5�      ��5�      �� *DaysValues2+$ TwoWay=�$ PropertyChanged=�.��5�   )    5�      ��%^   '��       �� 5�      " ��6    .�5�      ��  �@��CornerRadius$ 6��6=   5�      5�      .��6)   5�      �� 5�      $	��Set��6   $��0��6'   $��5��64   $��60��6D   $��19��6O   $��11(�6[   $��s2��5�   g   ��6   �� *	SetDays+$ TwoWay=�$ PropertyChanged=�6g   �� 5�      $��
Start/stop��6   $��1��6.   $��5��6;   $��60��6K   $��19��6V   $��11(�6b   $��b2��5�   i   ��6   �� *	StartStop+$ TwoWay=�$ PropertyChanged=�6i   �� 5�      $��Clear��6   $��2��6)   $��5��66   $��60��6F   $��19��6Q   $��11(�6]   $��d2��5�   f   ��6   �� *Delete+$ TwoWay=�$ PropertyChanged=�6f   5�      �� 5�      -   5        $ OpenSettings��5�      $��6��6+   $��3��68   $��Center=�6e   $��Center=�6�   
������ $��1q�6�   $��	-15,0,0,0q�5�      $��17��6$   $��17��6/    � ToolTip$ Open settings��6;   ��5�   I   �� *	OpenSet+��5�      �� 5      $	 UniformToFill=�6!   $D
 >pack://application:,,,/Timer2;component/Resources/Gear4_64.png��69   $ Center=�6�   $ Center=�6�    5     ��%_   '��       �� 5     " ��6   .�5     ��  �@��CornerRadius$ 15��69   5     5     5     �� 5	     -   5        $
 Exit��5	     $�� ��6<   $��6��6Q   $��4��6^   $��Center=�6n   $��Center=�6�   
���   �$��1q�6�   $��0,0,0,0q�5
     $��15��6"   $��15��6-   ��5	  #   �� *Exit+��5     �� 5     $
	 Fill=�6!   $T
 Npack://application:,,,/Timer2;component/Resources/Button_Round_red_exit_64.jpg��60   $ Center=�6�   $ Center=�6�    5     ��%_   '��       �� 5     " ��6   .�5     ��  �@��CornerRadius$ 12��69   5     5     5     �� 5     $��6��6   $��2��6"   $��Center=�62   $��11(�6V   
�������$��10,0,0,0q�5     ��6(   �� *date+$ OneWay=�$ PropertyChanged=�$
 Date���� 5     $��0��6   $��1��6"   $��3��62   $��4��6F   $
��Left=�6W   $	��Top=�6r   $��
-20,10,0,0q�6�   $	��0.5q�6�   
���   �$	��300��5     $	��200��6%   y�62   �� *SettingsVis+$ OneWay=�$ PropertyChanged=�$ hidden��._�5     �� -   5        $��Settings��5     $	��300��6-   $	��200��69   ���#F8F8FF.+�5     �� $��Timer settings��6   $��12��65   $��0��6C   $��Center=�6S   $��SegoeUI)�6p   $��13(�5     $
��Bold"�6*   $��0,10,0,0q�6<   $��25��6N   $
��Auto��6Z   
���   �6g   � 5     -   5        $ 	AlarmTime��5     $
��Auto��6.   $
��Left=�6;   $��	40,10,0,0q�6V    5     �� 5      $��1* �6/   �� 5!     $��4* �6/   .+�5#     �� $��0��6"   $��20��62   $��20��6=   
�������$��0,0,0,0q�6`   $
��Left=�6q   $��10(�5$  o   $��Center=�5%  &   $��Center=�6H   ��5$  &   �� *Alarm+$ TwoWay=�$ PropertyChanged=�5%  H   �� 5&     $��1��6    $��Alarm time (s)��60   $��25��6I   $	��100��6U   $
��Left=�6a   $
��Left=�5'  $   $��Center=�6F   $��5,-2,0,0q�6h   
���   �6z   5(     � 5)     -   5        $ AlarmRingTones��5)     $
��Auto��63   $��25��6@   $
��Left=�6L   $��	40,10,0,0q�6g    5*     �� 5+     $��2* �6/   �� 5,     $��1* �6/   .+�5.     �� -   5        $��ComboAlarms��5.  #   $��0��66   $
��Left=�6G   $	��110��6b   $��23��6n   $��0,0,0,0q�6z   $
��Left=�5/  #   $��Center=�6E   $��12(�6g   $ Arrow��6v    �� Text 50  #   �� *Item+$ TwoWay=�$ PropertyChanged=�$ Alarm10.mp3�� �� SelectedItem 51  #   �� *Item+��52  #   �� *	RingTones+�� 53     $��1��6    $��
Ring tones��60   $��27��6E   $��70��6Q   $
��Left=�6\   $
��Left=�54  $   $��Center=�6F   $��5,-4,0,0q�6h   
���   �6z   55     � 56     -   5        $ WindowStartLocation��56     $
��Auto��68   $
��Auto��6E   $
��Left=�6S   $��	40,10,0,0q�6n    57     �� 58     $��1* �6/   �� 59     $��1* �6/    5;     �� 5<     $
��Auto �6,   �� 5=     $
��Auto �6,   .+�5@     �� $��0��6"   $��0��6/   $��30��6?   $��20��6J   
�������$��0,0,0,0q�6m   $
��Left=�6~   $��10(�5A  r   $��Center=�5B  &   $��Center=�6H   ��5A  &   �� *
TopValue+$ TwoWay=�$ PropertyChanged=�5B  H   �� 5C     $��0��6    $��1��6-   $��
Window top��6=   $��25��6R   $	��100��6^   $
��Left=�6j   $
��Left=�5D  $   $��Center=�6F   $��5,-2,0,0q�6h   
���   �6z   �� 5F     $��1��6"   $��0��6/   $��30��6?   $��20��6J   
�������$��0,0,0,0q�6m   $
��Left=�6~   $��10(�5G  s   $��Center=�5H  &   $��Center=�6H   ��5G  &   �� *	LeftValue+$ TwoWay=�$ PropertyChanged=�5H  H   �� 5I     $��1��6    $��1��6-   $��Window left��6=   $��25��6S   $	��100��6_   $
��Left=�6k   $
��Left=�5J  $   $��Center=�6F   $��5,-2,0,0q�6h   
���   �6z   5K     �� 5M     -   5        $ ListSettings��5M     $��3��63   $��1��6@   $��22��6P   $��90��6\   $�� ��6�   $��SegoeUI)�6�   $��12(�6�   $
��Left=�5N     $��Center=�61   $��34,5,0,0q�6L   
������ $��0q�6w   ��5M  g   �� *ListOfSettings+.��5O     �� $��	Underline{�6$   List of settings6R   5P     5R     5S     �� 5T     $��0��6   $��2��6"   $��12��62   $��3��6D   $
��Left=�6X   $��Center=�6s   $	��0.5q�6�   
���   �$��0,0,0,0q�5U     $	��120��6*   $
��Auto��66   y�6D   �� *SettingsListVis+$ OneWay=�$ PropertyChanged=�$ visible��._�5V     �� -    5        $��SettingsList��5V     $	��120��61   $
��Auto��6=   ���#F8F8FF6K   5W     5X     5Y     5Z     