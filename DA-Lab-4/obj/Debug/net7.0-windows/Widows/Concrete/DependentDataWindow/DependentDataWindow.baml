   M S B A M L   `   `   `  ����C  ?DA-Lab-4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DA_Lab_4DA_Lab_4  5   	   "    DA_Lab_4.DependentDataWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:DA_Lab_4     5   	     � Title$  DependentDataWindow��5   	   $	��313��6%   $	��800��62   .��5	      � .+�5
   
   �� -   5         ��Name$ ShowXDatasWindowButton��5
      $;��5Інформація про першу вибірку��61   $
��Left=�6X   $��	10,10,0,0q�6s   $	��Top=�6�   $��36��6�   $	��201��6�   6�   �� 5   
   -   5        $ ShowYDatasWindowButton��5      $;��5Інформація про другу вибірку��61   $
��Left=�6X   $��	10,51,0,0q�6s   $	��Top=�6�   $��36��6�   $	��201��6�   6�   �� 5   
   -   5        $&  ShowDifferencesDatasWindowButton��5      $?��9Інформація про різницю вибірок��6;   $
��Left=�6d   $��	10,92,0,0q�6   $	��Top=�6�   $��36��6�   $	��201��6�   6�   �� 5   
   -   5         ��Name$! MeanVariancePanelBackground��5      $
��Left=�69   $	��119��6T   $��
10,135,0,0q�6a   $	��Top=�6u   $	��376��6�   #��� ��6�   #��� ��6�   �� 5   
   -   5         ��Name$ MeansEqualityCheckbox��5      $8��2Критерій рівності середніх��62   $
��Left=�6W   $��
24,208,0,0q�6r   $	��Top=�6�   �� 5   
   -   5        $ VariancesEqualityCheckbox��5      $:��4Критерій рівності дисперсій��66   $
��Left=�6\   $��
24,158,0,0q�6w   $	��Top=�6�   �� 5   
   -   5        $! VariancesEqualityBackground��5      $
��Left=�69   $��32��6T   $��210,150,0,0q�6`   $	��Top=�6u   $	��167��6�   #��� ��6�   #��� ��6�   �� 5   
   -   5         ��Name$! VariancesEqualityValuesText��5      $
��Left=�69   $��217,158,0,0q�6T   $
��Wrap=�6i   $��|-1.135432| < 16.189932 ��6}   $	��Top=�6�    �� TextAlignment$ Center=�6�   �� 5   
   -	   5        $ MeansEqualityBackground��5      $
��Left=�65   $��32��6P   $��210,201,0,0q�6\   $	��Top=�6q   $	��167��6�   #��� ��6�   #��� ��6�   �� 5   
   -
   5        $ MeansEqualityValuesText��5      $
��Left=�65   $��217,209,0,0q�6P   $
��Wrap=�6e   $��|-1.135432| < 16.189932 ��6y   $	��Top=�6�   $ Center=�6�   �� 5   
   $
��Left=�6   $	��118��6/   $��
219,10,0,0q�6<   $	��Top=�6P   $	��552��6h   #��� ��6t   #��� ��6�   �� 5   
   -   5         ��Name$ EqualityTypeText��5      $
��Left=�6,   $��
320,10,0,0q�6G    �� TextWrapping$
 Wrap=�6[   $����Вибірки розподілені нормально, тому застосовано критерій перевірки середніх і дисперсій��6o   $	��Top=�6�   $	��350��6�   $	��118��6  $��Center=�6,  $��Center=�6P  $|�False��6r   J� IsHitTestVisible$ False��6�  ��6�   Z� ��6  Z� 6�  �� 5   
   -   5        $ VilcocsonPanelBackground��5      $
��Left=�66   $��395,135,0,0q�6Q   $	��376��6f   #��� ��6r   #��� ��6�   $	��119��6  $	��Top=�6  �� 5   
   -   5        $ VilcocsonCriteriaCheckbox��5      $I��CКритерій знакових рангів Вілкоксона��66   $
��Left=�6d   $��471,158,0,0q�6   $	��Top=�6�   �� 5   
   -   5        $! VilcocsonCriteriaValuesText��5      $
��Left=�67   $��411,193,0,0q�6R   $
 Wrap=�6g   $��|-1.135432| < 16.189932 ��6{   $	��Top=�6�   $	��344��6�   $��50��6�   $��Center=�6�   $��Center=�6  $ False��6A  $|�False��6Z  ��6�   Z� ��6�   Z� 6Z  5      5      