   M S B A M L   `   `   `  ����C  ?DA-Lab-4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DA_Lab_4DA_Lab_4  5   	   $    DA_Lab_4.IndependentDataWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:DA_Lab_4     5   	     � Title$  IndependentDataWindow��5   	   $	��265��6'   $	��800��64    � 
ResizeMode$ NoResize=�6@   .��5	      � $	��800��6   .+�5
   
   �� -   5         ��Name$ ShowXDatasWindowButton��5
      $;��5Інформація про першу вибірку��61   $��Right=�6X   $��
0,12,589,0q�6t   $	��Top=�6�   $��36��6�   $	��201��6�   6�   �� 5   
   -   5        $ ShowYDatasWindowButton��5      $;��5Інформація про другу вибірку��61   $��Right=�6X   $��
0,53,589,0q�6t   $	��Top=�6�   $��36��6�   $	��201��6�   6�   �� 5   
   -   5         ��Name$! MeanVariancePanelBackground��5      $
��Left=�69   $	��119��6T   $��	10,94,0,0q�6a   $	��Top=�6t   $	��376��6�   #��� ��6�   #��� ��6�   �� 5   
   -   5         ��Name$ MeansEqualityCheckbox��5      $8��2Критерій рівності середніх��62   $
��Left=�6W   $��
24,168,0,0q�6r   $	��Top=�6�   �� 5   
   -   5        $ VDVPanelBackground��5      $
��Left=�60   $��
393,94,0,0q�6K   $	��376��6_   #��� ��6k   #��� ��6�   $	��119��6  $	��Top=�6  �� 5   
   -   5        $ VariancesEqualityCheckbox��5      $:��4Критерій рівності дисперсій��66   $
��Left=�6\   $��
24,117,0,0q�6w   $	��Top=�6�   �� 5   
   -   5        $! VariancesEqualityBackground��5      $
��Left=�69   $��32��6T   $��210,109,0,0q�6`   $	��Top=�6u   $	��167��6�   #��� ��6�   #��� ��6�   �� 5   
   -   5         ��Name$! VariancesEqualityValuesText��5      $
��Left=�69   $��217,117,0,0q�6T   $
��Wrap=�6i   $��|-1.135432| < 16.189932 ��6}   $	��Top=�6�    �� TextAlignment$ Center=�6�   �� 5   
   $
��Left=�6   $��77��6/   $��
217,12,0,0q�6;   $	��Top=�6O   $	��552��6g   #��� ��6s   #��� ��6�   �� 5   
   -	   5        $ VDVCriteriaCheckbox��5      $3��-Критерій Ван дер Вардена��60   $
��Left=�6S   $��	509,0,0,0q�6n   $��Center=�6�   �� 5   
   -
   5        $ VDVCriteriaBackground��5      $
��Left=�63   $��28��6N   $��409,162,0,0q�6Z   $	��Top=�6o   $	��344��6�   #��� ��6�   #��� ��6�   �� 5   
   -   5        $ MeansEqualityBackground��5      $
��Left=�65   $��54��6P   $��210,149,0,0q�6\   $	��Top=�6q   $	��167��6�   #��� ��6�   #��� ��6�   �� 5   
   -   5        $ MeansEqualityValuesText��5      $
��Left=�65   $��217,158,0,0q�6P   $
��Wrap=�6e   $��|-1.135432| < 16.189932 ��6y   $	��Top=�6�   $ Center=�6�   �� 5   
   -   5        $ WelchCorrectionCheckbox��5      $$��З поправою Уелча��64   $
��Left=�6O   $��217,180,0,0q�6j   $	��Top=�6   �� 5   
   -   5         ��Name$ EqualityTypeText��5      $
��Left=�6,   $��
318,12,0,0q�6G    �� TextWrapping$
 Wrap=�6[   $����Вибірки розподілені нормально, тому застосовано критерій перевірки середніх і дисперсій��6o   $	��Top=�6�   $	��350��6�   $��77��6  $��Center=�6+  $��Center=�6O  $|�False��6q  	 J� IsHitTestVisible$	 False��6�  ��6�   Z� ��6  Z� 6�  �� 5   
   -   5        $ VDVCriteriaValuesText��5      $
��Left=�61   $��409,162,0,0q�6L   $
 Wrap=�6a   $��|-1.135432| < 16.189932 ��6u   $	��Top=�6�   $	��344��6�   $��28��6�   $��Center=�6�   $��Center=�6  $	 False��6;  $|�False��6T  ��6�   Z� ��6�   Z� 6T  5      5      