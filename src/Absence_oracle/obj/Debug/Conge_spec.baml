   M S B A M L   `   `   `  ����B  >Absence, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AbsenceAbsence  5   	       Absence.Conge_spec   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Absence     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	     � Title$  
Conge_spec��5   	    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ CanMinimize=�6    � WindowStartupLocation$ CenterScreen=�66   $��425.962��5   	   $��695.397��6   .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��* �6   .+�5   
   �� $��Stretch=�6   ���#0078D7$��70��6K   .+�5      �� $��Right=�6    �� Orientation$ 
Horizontal=�66   .+�5      �� -   5         ��Name$ minimize��5      ��6-   Z� ��6C   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�6.   
�������6;   5      �� 5      -   5        $ close��5      $��Right=�6(   ��6E   Z� ��6[   Z� .��5        $ Close=�6.   
�������6;   5      5      �� 5      -   5        $	��nom��5      $��22(�6&   
�������$��-��6G   $��Center=�6P    �� TextAlignment$ Center=�6k   5      �� 5   
   $��1��6   .+�5!      �� -   5        $
��form��5!      {�. $	��350��67   .+�5#      �� -   5        $��type_absence��5#      	 �� SelectedItem$	 AO��60   $
��40,2q�6C   
 �� 
IsEditable
 .  )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Type d'absence��6e    &  "MaterialDesignFloatingHintComboBox#��[  6�   .@�5$      �� .��6#   CM6'   �� 5%      .��6   CMLD6%   5&      (  "System.Windows.Controls.DatePicker  5'      -   5          Name$ 
date_debut��5'      $
��40,2q�6-   $ date de debut��6<    ( $MaterialDesignFloatingHintDatePicker#��[ 6k     5(      -   5        $ date_fin��5(      $��	40,2,40,5q�6,   $ date de fin��6@   #��[ 6m   �� 5)      -   5        $
��80,2q�5)      .��62   editer6:   5*      &   System.Windows.Controls.DataGrid  5+      -	   5          Name$ absenceTable��5+      $��2��6-   $	��800��6;   $��0,5,0,0q�6K   $��center=�6\   $��Stretch=�6z   $��0q�6�      
IsReadOnly .    AutoGenerateColumns .  ��. $
��Auto=�6+  $��Visible=�6]   � 	Resources 5-      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�  '        �� 5.      "  6    .�5/      ��  � ��
 �   �6;   �� 50       � ��
 ���� 6;   �� 51       � ��$ Stretch=�6D   �� 52       � ��$ 28��67   �� 53       � ��$ Center=�6K   �� 54       � ��$ Center=�6I   �� 55       � ��$	 6,0q�68   �� 56       � ��
 �����6<   �� 57       � ��$ 0,0,0,1q�6@   58      59       � ContextMenu 5:      �� 5;      .@�5<      m� -
   5        $��	supprimer��5<   #   66   5=         Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6*      
Visibility$ 	Collapsed=�66      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6j   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6N   ��  �� Path$ ID�6j     5A      $ type absence��6*   $
 auto 6_    6A   �� $
 TYPE�6_     5B      $ 
date debut��6)   $
 auto 6h    6D   �� $ 
DATE_DEBUT�6h     5C      $ date fin��6)   $
 auto 6d    6B   �� $ DATE_FIN�6d   5E      5F      5H      5I      