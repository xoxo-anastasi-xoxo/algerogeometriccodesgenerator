   M S B A M L   `   `   `  �����  Генератор алгеброгеометрических кодов, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null�Vclr-namespace:Генератор_алгеброгеометрических_кодовHГенератор_алгеброгеометрических_кодов  5   	   d    ^Генератор_алгеброгеометрических_кодов.CodeDescriptionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   hlocalVclr-namespace:Генератор_алгеброгеометрических_кодов     5   	     � Title$N  HГенератор алгеброгеометрических кодов��5   
   $	��450��68   $	��625��6E    � 
ResizeMode$ CanMinimize=�6Q    � Icon$ Properties/mainIcon.png��6j   ��5	      �� 5
   
    �� ImageSource$ Properties/fon.jpg��6    j� TileMode$ FlipXY=�66    j� Stretch$ UniformToFill=�6H   .��5      �  � RowDefinitions 5   
   �� 5      $	��81* �6   �� 5      $
��274* �6   �� 5      $	��66* �6   .+�5   
   �� -   5         ��Name$ PreviousWindowButton��5      $�� ��6/   $
��Left=�6:      GlassButton#��[  6V   $��10,1,0,0q�6{   $	��Top=�5      $��55��6)   $��55��64   $��2��5   4   ��5   @   Z� ��6V   Z� ��5      �� 5      $) #Properties/previousWindow-icone.png��6   $ Uniform=�6O   5      �� 5   
   $B��<Характеристики полученного кода��6   $��Center=�6:   $��74,22,74,23q�6W   $��Center=�6l   $��Italic$�6�   $��20(�6�   ���	#FF051A3E$
��Bold"�6�   $��Center=�6�   $��Center=�6�   $��36��6  $	��471��6#  �� 5   
   $��Center=�6   $	��240��64   $��0q�6A   $��1��6L   $��Center=�6Y   $	��471��6t   $
��Auto=�6�   $��Disabled=�6�   $��Center=�6�   $��Center=�6�   .��5      �� -   5         ��Name$ infoTextBox��5      $	��232��6+   	 �� TextWrapping$
	 Wrap=�68   $	��464��6M   
 J� IsManipulationEnabled
 . 
������� �� SelectionBrush �	#FF74BEF9���	#FF051A3E$
��Left=�5   -   $	��Top=�5      $��Courier New)�6.   $	��464��6G   $	��232��5        J� Opacity$
 0.77Q�6&    �� 
IsReadOnly . ��5      Z� 5    5   5!      �� 5"   
   -   5        $ 
saveButton��5"      $�� ��6%   $
��Left=�60   #��[  5#      $��83,1,0,0q�66   $	��Top=�5$      $��55��6)   $��55��64   $��2��5%   ?   ��6   Z� ��6'   Z� ��5'      �� 5(      $ Properties/save-icon.png��6   $ Uniform=�6D   5*      �� 5+   
   -   5        $ nextWindowButton��5+      $�� ��6+   $
��Left=�66   #��[  6R   $��	157,1,0,0q�6w   $	��Top=�5,      $��55��6)   $��55��64   $��2��5-      ��5,   @   Z� ��6V   Z� ��5.      �� 5/      $% Properties/nextWindow-icone.png��6   $ Uniform=�6K   51      �� 52   
   -   5         ��Name$ littleTextBlock��52      $
��Left=�6-   $��
255,20,0,0q�6H   $��2��6\   $
��Wrap=�6i   $	��Top=�6~   $	��333��6�   ���	#FF03063C$
��Bold"�6�   $��Italic$�6�   53      54      