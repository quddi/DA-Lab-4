   M S B A M L   `   `   `  ����C  ?DA-Lab-4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DA_Lab_4DA_Lab_4  5   	       DA_Lab_4.DatasWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:DA_Lab_4     5   	     � Title$  DatasWindow��5   	   $	��392��6   $
��1101��6*    � 
ResizeMode$ NoResize=�67   .��5	      � $��Center=�6   $
��1100��6(   $	��376��65   $��Center=�6B   .+�5
   
   �� $��	250,4,0,0q�6   $@��:/Widows/Concrete/DatasWindow/CharacteristicsBackground.png��6#   $
��Fill=�6g   $	��238��6v   $	��Top=�6�   $
��Left=�6�   $	��840��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ValuesDataGrid��5      $��10,10,855,30q�6V      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5         
Foreground
 �   �,  &System.Windows.Controls.DataGridColumn   Header$ Значення��68      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6J   5      �� 5   
   -   5         ��Name$ MeanTextBox��5      $
��Left=�6'   $��
681,72,0,0q�6B    �� TextWrapping$
 Wrap=�6V   $��TextBox��6j   $	��Top=�6y   $	��109��6�   $��34��6�   	 �� TextAlignment$	 Center=�6�   $��Center=�6�   �� 5   
   -   5        $ MeanIntervalTextBox��5      $
��Left=�6/   $��
789,72,0,0q�6J   $
 Wrap=�6^   $��TextBox��6r   $	��Top=�6�   $	��298��6�   $��34��6�   $	 Center=�6�   $��Center=�6�   �� 5   
   -   5        $ MedianTextBox��5      $
��Left=�6)   $��681,105,0,0q�6D   $
 Wrap=�6Y   $��TextBox��6m   $	��Top=�6|   $	��109��6�   $��34��6�   $	 Center=�6�   $��Center=�6�   �� 5   
   -   5        $ MedianIntervalTextBox��5      $
��Left=�61   $��789,105,0,0q�6L   $
 Wrap=�6a   $��TextBox��6u   $	��Top=�6�   $	��298��6�   $��34��6�   $	 Center=�6�   $��Center=�6�   �� 5   
   -   5        $ StandardDeviationTextBox��5      $
��Left=�64   $��681,138,0,0q�6O   $
 Wrap=�6d   $��TextBox��6x   $	��Top=�6�   $	��109��6�   $��35��6�   $	 Center=�6�   $��Center=�6�   �� 5   
   -   5        $&  StandardDeviationIntervalTextBox��5      $
��Left=�6<   $��789,138,0,0q�6W   $
 Wrap=�6l   $��TextBox��6�   $	��Top=�6�   $	��298��6�   $��35��6�   $	 Center=�6�   $��Center=�6�   �� 5   
   -   5        $  SkewnessCoefficientTextBox��5      $
��Left=�66   $��681,172,0,0q�6Q   $
 Wrap=�6f   $��TextBox��6z   $	��Top=�6�   $	��109��6�   $��34��6�   $	 Center=�6�   $��Center=�6�   �� 5   
   -	   5        $( "SkewnessCoefficientIntervalTextBox��5      $
��Left=�6>   $��789,172,0,0q�6Y   $
 Wrap=�6n   $��TextBox��6�   $	��Top=�6�   $	��298��6�   $��34��6�   $	 Center=�6�   $��Center=�6�   �� 5   
   -
   5        $  KurtosisCoefficientTextBox��5      $
��Left=�66   $��681,205,0,0q�6Q   $
 Wrap=�6f   $��TextBox��6z   $	��Top=�6�   $	��109��6�   $��33��6�   $	 Center=�6�   $��Center=�6�   �� 5   
   -   5        $( "KurtosisCoefficientIntervalTextBox��5      $
��Left=�6>   $��789,205,0,0q�6Y   $
 Wrap=�6n   $��TextBox��6�   $	��Top=�6�   $	��298��6�   $��33��6�   $	 Center=�6�   $��Center=�6�   �� 5   
   $
��Left=�6   $��0��6-   $��432,280,0,0q�68   $
 Wrap=�6M   $��TextBox��6a   $	��Top=�6p   $	��120��6�   �� 5   
   -   5        
 ��Name$0
 *NormalDistributionIdentificationBackground��5      $
��Left=�6H   $	��103��6c   $��256,243,0,0q�6p   
���   �$	��Top=�6�   $	��831��6�   #��� /�6�   �� 5   
   -   5         ��Name$* $NormalDistributionIdentificationText��5      $j��dІдентифікація нормального розподілу: ідентифікується��6>   $
��Left=�6}   $��264,249,0,0q�6�   $	��Top=�6�   $��18(�6�   $��Center=�6�   $��Center=�6�   $��43��6  $	��520��6%  �� 5   
   $
��Left=�6   $��40��6/   $��264,299,0,0q�6;   $	��Top=�6P   $	��406��6h   #��� ��6t   �� 5   
   -   5         ��Name$* $NormalDistributionBySkewnessCheckbox��5      $2��,За коефіцієнтом ексцесу��6A   $
��Left=�6c   $��273,305,0,0q�6~   $	��Top=�6�   $��18(�6�   $��28��6�   $	��397��6�   $��Center=�6�   �� 5   
   $
��Left=�6   $��40��6/   $��675,299,0,0q�6;   $	��Top=�6P   $	��403��6h   #��� ��6t   �� 5    
   -   5        $* $NormalDistributionByKurtosisCheckbox��5       $6��0За коефіцієнтом асиметрії��6A   $
��Left=�6e   $��682,305,0,0q�6�   $	��Top=�6�   $��18(�6�   $��28��6�   $	��396��6�   $��Center=�6�   �� 5!   
   -   5        $ StudentQuantileText��5!      $
��Left=�6/   $��789,254,0,0q�6J   $
 Wrap=�6_   $��u=3.123125441432342342��6s   $	��Top=�6�   $	��289��6�   $��35��6�   ���	#FFFFFFE1$��Center=�6�   $��Center=�6  $��18(�65   J� IsHitTestVisible$ False��6C  $|�False��6\  ��6�   Z� 6\  5#      5$      