   M S B A M L   `   `   `  ����B  >Absence, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AbsenceAbsence  5   	       Absence.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   !localclr-namespace:Absence  5   	     � WindowStyle$
  None=�5	   	    � WindowState$ 	Maximized=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
MainWindow��5   	   $��558.279��6   $��1071.234��6-    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$ Arial Rounded MT Bold)�6+   �� 5       � ��
 �����6+   �� 5       � ��$	 0,5q�6'   5      5      ��5      �� 5   
    �� ImageSource$ 
img/bg.jpg��6   61   .��5      �� $��10q�6   .+�5   
   � $��Stretch=�6   
������ $��40��6H   	 � ColumnDefinitions	 5      �� 5      $��* �6#   �� 5      $	��150 �6#   .+�5      �� 
 �� Orientation$
 
Horizontal=�6   $
��Left=�62   .+�5      o�  o� 
IsMainMenu . .@�5       m� $��Element��6      Menu#��[  60   .@�5!      m� -   5        $��Ajouter Element��5!   #     SubMenu#��[ 6<   6`   m� 5"      -   5        $��Archive��5"   #   #��[ 64   6X   5#      m� 5$      $��Absence��6   #��[  60   .@�5%      m� -   5        $��Ajouter Absence��5%   #   #��[ 6<   6`   5&      5'      5(      �� 5*      $��1��6   $��Right=�6)   $
 
Horizontal=�6E   .+�5+      �� -   5        ��5+      Z� ��62   Z� .��5,      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Refresh=�6.   
�������6=   5-      �� 5.      -   5         ��Name$ minimize��5.      ��6-   Z� ��6C   Z� .��5/        $ Minus=�6.   
�������6;   50      �� 51      -   5        $ close��51      $��Right=�6(   ��6E   Z� ��6[   Z� .��52        $ Close=�6.   
�������6;   53      54      55      �� 57   
   $��0,50,0,0q�6   .+�58      �� -   5        $��infoCard��58       �� CornerRadius$ 5��6%   $��0,15,0,0q�67    �� Padding$
 0,10q�6I   
�������$��1q�6l   $
��auto��6�   $	��700��6�   $
��auto��6�   ._�59      � 	 5:      �� 5;      $	��190 �6+   �� 5<      $��* �6,   .+�5>      �� $��Center=�6!   .+�5?      �� $
��0,10q�6!   $��Center=�6/   
������ 
������ $	��120��6   $	��120��6�    * &MaterialDesignFloatingActionDarkButton#���  6�   .��5@      �� -   5         ��Name$ photo��5@   $   $
��Fill=�63   $��Center=�6B   $��Center=�6]   5A      5B      �� 5D      $��1��6!   $��Center=�62   .+�5E      �� -	   5        $��	matricule��5E   4   $��1��6$   $��14(�6E   $��Center=�6S   $
��Wrap=�6n   6�   �� 5F      -
   5        $	��nom��5F   4   $��1��6$   $��14(�6?   $��Center=�6M   $
��Wrap=�6h   6~   �� 5G      -   5        $��code_affectation��5G   4   $��1��6$   $��14(�6L   $��Center=�6Z   $
��Wrap=�6u   6�   �� 5H      -   5        $��affectation��5H   4   $��1��6$   $��14(�6G   $��Center=�6U   $
��Wrap=�6p   6�   �� 5I      -   5        $��code_fonction��5I   4   $��1��6$   $��14(�6I   $��Center=�6W   $
��Wrap=�6r   6�   �� 5J      -   5        $��fonction��5J   4   $��1��6$   $��14(�6D   $��Center=�6R   $
��Wrap=�6m   6�   5K      5M      5N      �� 5P      -   5         ��Name$ filter��5P       �� CharacterCasing$ Upper=�6&   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ filtrer��6>   $��20(�6g   
�������
�������$
��20,5q�6�   $	��200��6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   &   System.Windows.Controls.DataGrid  5R      -   5          Name$ personTable��5R      $��2��6,   $	��800��6:   $��0,5,0,0q�6J   $��Stretch=�6[   ���	#a2ffffff J� Opacity$	 0.5Q�6�   $��Stretch=�6�   $��0q�6�      
IsReadOnly .    AutoGenerateColumns .  ��. $
��Auto=�6P  $��Visible=�6�   5S      =  7System.Windows.Controls.Primitives.DataGridColumnHeader)  #System.Windows.Controls.DataGridRow��%�  '        '  }    �� 5T      "  6   .�5U      ��  � ��
 �   �67   �� 5V       � ��
 ���� 67   �� 5W       � ��$ Stretch=�6D   �� 5X       � ��$ 28��63   �� 5Y       � ��$ Center=�6G   �� 5Z       � ��$ Center=�6E   �� 5[       � ��$	 6,0q�64   �� 5\       � ��
 �����68   �� 5]       � ��$	 0,1q�6<   5^      �� 5_      "  6   .�5`      -   5        5a      5b       � ContextMenu 5c      �� 5d      .@�5e      m� -   5        $��Fiche��5e   #   62   �� 5f      m� 5g      -   5        $��Editer��5g   #   63   �� 5h      m� 5i      -   5        $��Conege spec��5i   #   68   5j         Columns 5l      0  *System.Windows.Controls.DataGridTextColumn  5m      ,  &System.Windows.Controls.DataGridColumn   Header$ 	matricule��6*      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6a   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6>   ��  �� Path$ 	matricule�6a     5n      $	 nom��6)   $
 auto 6Z    6=   �� $	 nom�6Z     5o      $ Code Affect��6)   $
 auto 6j    6E   �� $ code_affect�6j     5p      $ affectation��6)   $
 auto 6j    6E   �� $ affectation�6j     5q      $ Code Fonction��6)   $
 auto 6k    6G   �� $ 
code_fonct�6k     5r      $ Adresse��6)   $
 auto 6b    6A   �� $ adresse�6b   5t      5u      5v      5w      