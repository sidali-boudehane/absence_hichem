   M S B A M L   `   `   `  ����B  >Absence, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AbsenceAbsence  5   	       Absence.Fiche   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   !localclr-namespace:Absence  5   	     � WindowStyle$
  None=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � Title$ Fiche��5   	   $	��500��6   $��655.655��6'   $��704.849��69   .��5      � .+�5      �� $��Stretch=�6   $��Stretch=�6/   $��0q�6K   .+�5   
   �� $��Stretch=�6   ���#0078D7$��40��6K   .+�5      �� $��Right=�6    �� Orientation$ 
Horizontal=�66   .+�5      �� -   5         ��Name$ close��5      $��Right=�6(   ��6E   Z� ��6[   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6.   
�������6;   5      5      5      � 5      $	��5,0q�6   .+�5      �� -   5        $ open_container��5      $
��Left=�61   $��24��6L   $��24��6W   $��0q�6c   
������ 
������ .��5        $ ArrowCollapseRight=�6.   $��24��6H   $��24��6T   
����  �6_   5       �� 5!      $ 
Horizontal=�6   $��Center=�66   $��Right=�6Q   .+�5"      �� -   5         ��Name$ years��5"      $��80��6&   $��80��61   $��Center=�6?    �� 
IsEditable . 6c   �� 5#      -   5        $ 
updateDate��5#      
������ 
������ .��5$        $ Refresh=�62   $��24��6A   $��24��6M   
����  �6X   5%      5&      5'   
   � 5)   
   -   5        	 �Name$	 calender��5)      $��Stretch=�6!   $��Stretch=�6?   �� 5*   
   $ 
Horizontal=�6   $��Right=�6.   $	��0,5q�6J   .+�5+      �� $
��AO :��6   �� 5,      -   5        $��ao��5,      $��0��6   $��30��6*   �� 5.      $
��AA :��6   �� 5/      -   5        $��aa��5/      $��0��6   $��30��6*   �� 51      $
��CM :��6   �� 52      -   5        $��cm��52      $��0��6   $��30��6*   �� 54      -	   5        $ update��54      $	��5,0q�6:   .��6G   mise à jour6T   55      56      � 57   
   -
   5        $��shadow_container��57      $y�Hidden=�6'   
���   �
 J� Opacity$	
 0.7Q�6O   6_   �� 58   
   -   5        $��form_container��58      $y�Hidden=�6+   
�������$
 1Q�6R   $��Center=�6^   $
��Left=�6y   .+�59      �� -   5        $ 
close_form��59      $
��Left=�6)   $	��Top=�6D   $��50��6\   $��50��6g   ��6s   Z� ��6�   Z� .��5:        $ 	ArrowBack=�6*   
����  �6;   5;      �� 5<      -   5        $��matricule_form��5<      $
��40,0q�6,    �� CharacterCasing$ Upper=�6:   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	matricule��6R    %  !MaterialDesignFloatingHintTextBox#��[  6�   �� 5=      -   5        $	��nom��5=      $
��40,0q�6!   $ Upper=�6/    �� 
IsReadOnly . |�.  $	 Nom��6k   #��[  6�   �� 5>      -   5        $��affectation��5>      $ Upper=�6)   $
��40,0q�6A    . |�.  $ Affectation��6s   #��[  6�   �� 5?      -   5        $��type_absence��5?       �� SelectedItem$ AO��6,   $
��40,2q�6?    .  $ Type d'absence��6a    & "MaterialDesignFloatingHintComboBox#��[ 6�   .@�5@      ��  �� 
IsSelected . .��61   AO65   �� 5A      .��6   A6"   �� 5B      .��6   AA6#   �� 5C      .��6   O6"   �� 5D      .��6   CM6#   �� 5E      .��6   CMLD6%   5F      (  "System.Windows.Controls.DatePicker  5G      -   5          Name$ date_debut_form��5G      $
��40,2q�62   $ date de debut��6A    ( $MaterialDesignFloatingHintDatePicker#��[ 6p   �� 5H      -   5        $��nbr_jour��5H      $��	40,2,40,5q�6&   $��2��6:   $y�Visible=�6C   $ 	nbr jours��6X   #��[  6�     5I      -   5        $ date_fin_form��5I      $y�	Collapsed=�60   $��	40,2,40,5q�6G   $ date de fin��6[   #��[ 6�   �� 5J      -   5        $
��80,2q�5J      .��6;   	Ajouter6D   5K      5L      5M      