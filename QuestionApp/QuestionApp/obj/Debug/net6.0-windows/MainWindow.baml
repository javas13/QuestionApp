   M S B A M L   `   `   `  ����F  BQuestionApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:QuestionAppQuestionApp  5   	       QuestionApp.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:QuestionApp     5   	   -   5          � WindowStyle$
  None=�5   	    � AllowsTransparency$
 True��5	   	   
������  � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
MainWindow��5   	   $	��320��6   $	��530��6)   .��5      � $	��286��6   $	��496��6    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6      
BlurRadius$ 25Q�6,      	Direction$	 -25Q�6<      RenderingBias$ Quality=�6L   	   ShadowDepth$	 4Q�6e   
   Opacity$	
 0.2Q�6u   .+�5   
   ��  �� CornerRadius$ 12��6    �� Padding$ 25q�6$   ���#E9EFF0._�5      � .+�5      �� $��Know your talent��6   ���#22CC22   
CustomFont#��[  6I   $��22(�6n   6~   �� 5      $��Enter registration code��6   
���   �#��[  6N   $��0,30,0,0q�6r   $��36(�6�   6�   �� 5      -   5         ��Name$ registrTokenTxt��5   @   $��56��6   $	��432��6&   $��20(�62   $
��Left=�6Y   
���   �$��0,0,0,0q�6�     textbxstyle#��[ 6�   6�   �� 5      -   5          buttonstyle1#��[ 5      $
��Left=�6?   $��56��6\   $��Continue��6h   
�������$��20(�6�   $	��118��6�   $��	0,150,0,0q�6�   6�   �� 5      -   5         ��Name$ errorTxt��5   2   $��Code incorrect��6   $y�Hidden=�6D   $��20(�6X   #��[  6f   ���#C50000$��288,182,-288,-182q�6�   6�   5      5      5      5      