   M S B A M L   `   `   `  ����B  >Absence, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AbsenceAbsence  5   	       Absence.Archive   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   !localclr-namespace:Absence  5   	     � WindowStyle$
  None=�5	   	    � WindowState$ 	Maximized=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Archive��5   	   $��558.279��6   $��1071.234��6*    � 	Resources 5       �� 
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
��Left=�62   .+�5      �� -   5         ��Name$ close��5      $��Right=�6(   ��6E   Z� ��6[   Z� .��5       '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowBack=�6.   $��24��6?   $��24��6K   
�������6V   5!      5"      �� 5$      $��1��6   $��Right=�6)   $
 
Horizontal=�6E   .+�5%      �� -   5        ��5%      Z� ��62   Z� .��5&        $ Refresh=�6.   
�������6=   5'      5(      5)      �� 5+   
   $��0,50,0,0q�6   .+�5,      �� -   5        $��infoCard��5,       �� CornerRadius$ 5��6%   $��0,15,0,0q�67    �� Padding$
 0,10q�6I   
�������$��1q�6l   $
��auto��6�   $	��700��6�   $
��auto��6�   ._�5-      � 	 5.      �� 5/      $	��190 �6+   �� 50      $��* �6,   .+�52      �� $��Center=�6!   .+�53      �� $
��0,10q�6!   $��Center=�6/   
������ 
������ $	��120��6   $	��120��6�    *  &MaterialDesignFloatingActionDarkButton#���   6�   .��54      �� -   5         ��Name$ photo��54   $   $
��Fill=�63   $��Center=�6B   $��Center=�6]   55      56      �� 58      $��1��6!   $��Center=�62   .+�59      �� -   5        $��	matricule��59   4   $��1��6$   $��14(�6E   $��Center=�6S   $
��Wrap=�6n   6�   �� 5:      -   5        $	��nom��5:   4   $��1��6$   $��14(�6?   $��Center=�6M   $
��Wrap=�6h   6~   �� 5;      -   5        $��code_affectation��5;   4   $��1��6$   $��14(�6L   $��Center=�6Z   $
��Wrap=�6u   6�   �� 5<      -   5        $��affectation��5<   4   $��1��6$   $��14(�6G   $��Center=�6U   $
��Wrap=�6p   6�   �� 5=      -	   5        $��code_fonction��5=   4   $��1��6$   $��14(�6I   $��Center=�6W   $
��Wrap=�6r   6�   �� 5>      -
   5        $��fonction��5>   4   $��1��6$   $��14(�6D   $��Center=�6R   $
��Wrap=�6m   6�   5?      5A      5B      �� 5D      -   5         ��Name$ filter��5D       �� CharacterCasing$ Upper=�6&   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ filtrer��6>   $��20(�6g   
�������
�������$
��20,5q�6�   $	��200��6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   &   System.Windows.Controls.DataGrid  5F      -   5          Name$ personTable��5F      $��2��6,   $	��800��6:   $��0,5,0,0q�6J   $��Stretch=�6[   ���	#a2ffffff J� Opacity$	 0.5Q�6�   $��Stretch=�6�   $��0q�6�      
IsReadOnly .    AutoGenerateColumns .  ��. $
��Auto=�6O  $��Visible=�6�   5G      =  7System.Windows.Controls.Primitives.DataGridColumnHeader)  #System.Windows.Controls.DataGridRow��%�  '        '  }    �� 5H      "  6   .�5I      ��  � ��
 �   �67   �� 5J       � ��
 ���� 67   �� 5K       � ��$ Stretch=�6D   �� 5L       � ��$ 28��63   �� 5M       � ��$ Center=�6G   �� 5N       � ��$ Center=�6E   �� 5O       � ��$	 6,0q�64   �� 5P       � ��
 �����68   �� 5Q       � ��$	 0,1q�6<   5R      �� 5S      "  6   .�5T      -   5        5U      5V       � ContextMenu 5W      �� 5X      .@�5Y      m� -   5        $��Conege spec��5Y   #   68   �� 5Z      m� 5[      -   5        $��Editer��5[   #   63   5\         Columns 5^      0  *System.Windows.Controls.DataGridTextColumn  5_      ,  &System.Windows.Controls.DataGridColumn   Header$ 	matricule��6*      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6a   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6>   ��  �� Path$ 	matricule�6a     5`      $	 nom��6)   $
 auto 6Z    6=   �� $	 nom�6Z     5a      $ Code Affect��6)   $
 auto 6j    6E   �� $ code_affect�6j     5b      $ affectation��6)   $
 auto 6j    6E   �� $ affectation�6j     5c      $ Code Fonction��6)   $
 auto 6k    6G   �� $ 
code_fonct�6k     5d      $ Adresse��6)   $
 auto 6b    6A   �� $ adresse�6b   5f      5g      5h      5i      