   M S B A M L   `   `   `  ����B  >Absence, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AbsenceAbsence  5   	       Absence.AjouterAbsence   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   !localclr-namespace:Absence  5   	     � Title$  AjouterAbsence��5	   	   $��349.437��6    $��344.77��61    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ CanMinimize=�6    � WindowStartupLocation$ CenterScreen=�66   .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� $��Stretch=�6   ���#0078D7$��40��6K   .+�5      �� $��Right=�6    �� Orientation$ 
Horizontal=�66   .+�5      �� -   5         ��Name$ minimize��5      ��6-   Z� ��6C   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�6.   
�������6;   5      �� 5      -   5        $ close��5      $��Right=�6(   ��6E   Z� ��6[   Z� .��5        $ Close=�6.   
�������6;   5      5      5      �� 5   
   $��1��6   .+�5      �� -   5        $��	matricule��5      $
��40,0q�6'    �� CharacterCasing$ Upper=�65   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 	matricule��6M    %  !MaterialDesignFloatingHintTextBox#��[  6�   �� 5       -   5        $	��nom��5       $
��40,0q�6!   $ Upper=�6/   
 �� 
IsReadOnly
 . |�.  $		 Nom��6k   #��[  6�   �� 5!      -   5        $��affectation��5!      $ Upper=�6)   $
��40,0q�6A   
 . |�.  $	 Affectation��6s   #��[  6�   �� 5"      -   5        $��type_absence��5"       �� SelectedItem$ AO��6,   $
��40,2q�6?    �� 
IsEditable .  $	 Type d'absence��6a    & "MaterialDesignFloatingHintComboBox#��[ 6�   .@�5#      ��  �� 
IsSelected . .��61   AO65   �� 5$      .��6   A6"   �� 5%      .��6   AA6#   �� 5&      .��6   O6"   �� 5'      .��6   CM6#   �� 5(      .��6   CMLD6%   5)      (  "System.Windows.Controls.DatePicker  5*      -   5          Name$ 
date_debut��5*      $
��40,2q�6-   $	 date de debut��6<    ( $MaterialDesignFloatingHintDatePicker#��[ 6k   �� 5+      -   5        $��nbr_jour��5+      $��	40,2,40,5q�6&   $��2��6:   $y�Visible=�6C   $	 	nbr jours��6X   #��[  6�     5,      -	   5        $ date_fin��5,      $y�	Collapsed=�6+   $��	40,2,40,5q�6B   $	 date de fin��6V   #��[ 6�   �� 5-      -
   5        $
��80,2q�5-      .��63   	Ajouter6<   5.      50      51      