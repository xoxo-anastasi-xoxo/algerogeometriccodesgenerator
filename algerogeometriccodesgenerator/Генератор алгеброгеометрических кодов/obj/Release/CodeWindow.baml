   M S B A M L   `   `   `  ���� �  Генератор алгеброгеометрических кодов, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null�Vclr-namespace:Генератор_алгеброгеометрических_кодовHГенератор_алгеброгеометрических_кодов  Y    SГенератор_алгеброгеометрических_кодов.CodeWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     hlocalVclr-namespace:Генератор_алгеброгеометрических_кодов       � Title$N  HГенератор алгеброгеометрических кодов��$	��450��$	��625�� � 
ResizeMode$ CanMinimize=� � Icon$ Properties/mainIcon.png������  �� ImageSource$ Properties/fon.jpg�� j� TileMode$ FlipXY=� j� Stretch$ UniformToFill=�.���  � ColumnDefinitions �� $
��308* ��� $
��311* � � RowDefinitions �� $	��87* ��� $	��75* ��� $��0* ��� $	��28* ��� $	��80* ��� $	��79* ��� $	��72* �.+��� $��58��$��
45,3,61,14q�$��Center=�$��Visible=�$��Disabled=�$��Center=�$��Center=�$��1�� J� Opacity$
 0.85Q�.���� -   	 ��Name$	 first��
 �� TextWrapping$

 Wrap=�$��24(�
�������$��38��$ �� HorizontalScrollBarVisibility$ Visible=��� -    ��Name$ previousWindowButton��$�� ��$
��Left=�   GlassButton#��[  $��10,7,0,0q�$	��Top=�$��55��$��55��$��6����Z� ��Z� ���� $) #Properties/previousWindow-icone.png��$ Uniform=��� $��1��$��Center=�$��58��$��
62,3,47,14q�$��Center=�$	��202��$��Visible=�$��Disabled=�$��Center=�$��Center=�$��1��$
 0.85Q�.���� -   $	 second��$

 Wrap=�$��24(�
�������$��38�� �� 
IsReadOnly . �� -    ��Name$ СodeOrDecode��$��2��$��Center=�$��226,37,233,12q�$��Center=�$	��160��$��38��$��Center=�$��Center=�$��16(�$��Italic$�.@��� ���	#FF051A3E$��Кодирование��$��Center=�$��Center=�$��0q�$	��150��$��27��$��16(�$��Italic$� �� 
IsSelected . $��Center=�$��Center=��� ���	#FF051A3E$ ��Декодирование��$��Center=�$��Center=�$��0q�$	��150��$��27��$��16(�$��Italic$�$��Center=�$��Center=��� -   $ 
codeButton��$�� ��#��[  $
��Left=�$��	281,4,0,0q�$	��Top=�$��55��$��2��$��55��$��1������ $( "Properties/сodeOrDecode-icone.jpg���� -    ��Name$ error��$��Center=�$��0q�$��3��$
��Wrap=�$��Center=�$	��527�����	#FFF70505$��2��$��20��
�������$	 0.8Q�$y�Hidden=��� -   $ 
helpButton��$�� ��$
��Left=�#��[  $��83,7,0,0q�$	��Top=�$��56��$��55��$��6����Z� ��Z� ���� $ Properties/help-icon.png��$ Uniform=� � ToolTip$ .���� $
��Left=�$	��136��$��	45,13,0,0q�$��4��$	��Top=�$	��528��$��2��$��2��$
��Auto=�$��Disabled=�.���� -   $	 
usersNotes��$	��138��$

 Wrap=�$	��525�����	#FF051A3E$	 0.8Q� J� IsManipulationEnabled . " �� VerticalScrollBarVisibility$ Visible=� �� AcceptsReturn . ��Z� 