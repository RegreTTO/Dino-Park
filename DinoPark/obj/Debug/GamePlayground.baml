   M S B A M L   `   `   `  ����H  DDino Park 2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Dino_Park_2._0Dino_Park_2._0  5   	   #    Dino_Park_2._0.GamePlayground   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Dino_Park_2._0     5   	   -   5          � Title$   ��5   	   $	��605��6   $	��689��6    � 
ResizeMode$ NoResize=�6�   ��5	      �� 5
   
    �� ImageSource$ Sandbox.png��6   .��5      � -   5         �Name$
 grid��5       � ColumnDefinitions 5   
   �� 5      .+�5   
      Dino_Park_2._0.Dino  -   5          Name$
 dino��5      $��140,127,362,262q�6#      Dino_Park_2._0.Octopus  5   
   -   5          Name$ octopus��5      $��415,349,192,159q�6)   �� 5   
   -   5         ��Name$ Score��5      $��518,0,0,496q�6#   $
��Auto��68   $
��Wrap=�6F   $��NO��6Z   $��48(�6d      Dino_Park_2._0.Seashell  5   
   -   5          Name$ 	seashell1��5      $
��Auto��6,   $��410,205,203,301q�6:   $
��Auto��6S     5   
   -   5        $ 	seashell2��5      $
��Auto��6,   $��560,320,53,186q�6:   $
��Auto��6R     5   
   -   5        $ 	seashell3��5      $
��Auto��6,   $��255,395,358,111q�6:   $
��Auto��6S   �� 5   
   -	   5        	 ��Name$	 hpBox��5      $��
140,79,0,0q�6    $��45��64   $	��Top=�6@   $
��Left=�6X   $	��181��6s   .+�5      �� $��HP��6   
 �� Left$
 84��6!   $��25��62   � 5      -
   5         �Name$ hpBar��5      $��17��6)   
 �� Top$ 25��65   $	��179��6E    � Value$	 100Q�6Q   $
 1��6]   �� 5      -   5         ��Name$ hpLabel��5      $	��100��6%   $��Center=�63   $	��Top=�6W   $
 70��6v   $��8(�6�   $��19��6�   $ 23��6�   $��50��6�   5      5      5      