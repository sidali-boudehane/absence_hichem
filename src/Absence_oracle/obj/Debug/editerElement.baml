   M S B A M L   `   `   `  ����B  >Absence, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AbsenceAbsence  5   	       Absence.editerElement   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   !localclr-namespace:Absence  5   	     � Title$  editerElement��5	   	   $��488.278��6   $��344.77��60    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ CanMinimize=�6    � WindowStartupLocation$ CenterScreen=�66   .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� $��Stretch=�6   ���#0078D7$��40��6K   .+�5      �� $��Right=�6    �� Orientation$ 
Horizontal=�66   .+�5      �� -   5         ��Name$ minimize��5      ��6-   Z� ��6C   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�6.   
�������6;   5      �� 5      -   5        $ close��5      $��Right=�6(   ��6E   Z� ��6[   Z� .��5        $ Close=�6.   
�������6;   5      5      5      �� 5   
   $��1��6   .+�5      �� -   5        $��	matricule��5       �� CharacterCasing$ Upper=�6'   $��
40,30,40,2q�6?   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 	matricule��6S    %  !MaterialDesignFloatingHintTextBox#��[  6~   �� 5      -   5        $	��nom��5      $ Upper=�6!   $
��40,2q�69   $		 nom��6G   #��[  6l   �� 5       -   5        $��code_affect��5       $ Upper=�6)   $
��40,2q�6A   $	 code affectation��6O   #��[  6�   �� 5!      -   5        $��affectation��5!      $
��40,2q�6)   
 �� 
IsReadOnly
 . |�.  $	 affectation��6[   #��[  6�   �� 5"      -   5        $��
code_fonct��5"      $ Upper=�6(   $
��40,2q�6@   $	 code fonction��6N   #��[  6�   �� 5#      -   5        $��fonction��5#      $
��40,2q�6&   
 . |�.  $	 fonction��6X   #��[  6�   �� 5$      -	   5        $
��etat��5$       �� SelectedItem$ AO��6$   $
��40,2q�67    �� 
IsEditable .  $
	 etat��6Y    & "MaterialDesignFloatingHintComboBox#��[ 6   .@�5%      ��  �� 
IsSelected . .��61   ACTIF68   �� 5&      .��6   CMLD6%   �� 5'      .��6   RET6$   �� 5(      .��6   DEM6$   �� 5)      .��6   LIC6$   �� 5*      .��6   DECE6%   �� 5+      .��6   DISP6%   �� 5,      .��6   DEC6$   5-      �� 5.      -
   5        $��adresse��5.      $
��40,2q�6&   $	 Adresse��64   #��[  6]   �� 5/      -   5        $
��80,2q�5/      .��6;   Editer6C   50      52      53      