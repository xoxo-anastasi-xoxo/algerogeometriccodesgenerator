   M S B A M L   `   `   `  ���� �  Генератор алгеброгеометрических кодов, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null�Vclr-namespace:Генератор_алгеброгеометрических_кодовHГенератор_алгеброгеометрических_кодов  _    YГенератор_алгеброгеометрических_кодов.SelectCodeWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     hlocalVclr-namespace:Генератор_алгеброгеометрических_кодов     -     �Name$
  win1�� � Title$N HГенератор алгеброгеометрических кодов��$	��450��$	��625�� � 
ResizeMode$ CanMinimize=� � Icon$ Properties/mainIcon.png������  �� ImageSource$ Properties/fon.jpg�� j� TileMode$ FlipXY=� j� Stretch$ UniformToFill=�.���  � RowDefinitions �� $	��89* ��� $	��45* ��� $	��60* ��� $
��225* � � ColumnDefinitions �� $
��145* ��� $
��299* ��� $
��145* �.+��� -   	 ��Name$	 	mainLabel��$��Выберите код:��$��1��$��Center=�$��0q�$��1��$��Center=�$��20(����	#FF051A3E$
��Bold"�$��Center=�$��Center=�$��36��$	��159��$��Italic$��� -   
 ��Name$
 codeSelector��$��1�����	#FF0C1A3E$��Italic$�$��13(�$��Center=�$��56,20,59,19q�$��2��$��Center=�$	��199��$��22��$��Center=�$��Center=�.@���  J� OpacityMask
 �   �$��22��$	��191�����	#FF0C1A3E$(��"Cоздать новый код...��$��Italic$�$��13(����	#FFFFFEFE$��0,0,6,0q���Z� �� -    ��Name$ previousWindowButton��$�� ��$
��Left=�   GlassButton#��[  $��
10,161,0,0q�$	��Top=�$��55��$��55��$��3����Z� ��Z� ���� $) #Properties/previousWindow-icone.png��$ Uniform=��� -   $ trashButton��$�� ��$
��Left=�#��[  $��
85,161,0,0q�$	��Top=�$��55��$��55��$��3����Z� ��Z� ���� $ Properties/trash-icon.png��$ Uniform=��� -   $ nextWindowButton��$�� ��$
��Left=�#��[  $��
12,161,0,0q�$	��Top=�$��55��$��55��$��3��$��1����Z� ��Z� ���� $% Properties/nextWindow-icone.png��$ Uniform=�