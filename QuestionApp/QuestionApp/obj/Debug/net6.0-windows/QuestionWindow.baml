   M S B A M L   `   `   `  ����F  BQuestionApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:QuestionAppQuestionApp  5   	        QuestionApp.QuestionWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:QuestionApp     5   	   -   5          � WindowStyle$
  None=�5   	    � AllowsTransparency$
 True��5   	   
������  � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ QuestionWindow��5   	   $
��1000��6    $	��520��6.   .��5      � $	��980��6   $	��496��6    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6      
BlurRadius$ 25Q�6,      	Direction$	 -25Q�6<      RenderingBias$ Quality=�6L   	   ShadowDepth$	 4Q�6e   
   Opacity$	
 0.2Q�6u   .+�5   
   ��  �� CornerRadius$ 12��6    �� Padding$ 25q�6$   ���#E9EFF0._�5      � .+�5      �� -   5         ��Name$
 nado��5      .+�5      �� $��0,0,0,5q�6    $��Know your talent��61   ���#22CC22   
CustomFont#��[  6^   $��22(�6�   6�   �� 5      -   5         ��Name$ questTxt��5   R   $/��)How happy are you with your current boss?��6!   $
��Wrap=�6d    �� 
LineHeight$ 38��6x   
���   �#��[  6�   $��0,0,0,30q�6�   $��36(�6�   6�   �� 5      -   5         ��Name$ questLst��5   �     buttonstyle12#��[ 6   
������ $��0q�6l   $��False��6�   $��Disabled=�6�   ��5      �� 5      .R�5   &   � $	��100��6,   ��6:   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" �� �� Path$ ActualWidth� �� Mode$ OneWay=�.+�5   *   �� $��Center=�65   .+�5    .   ��  �� Padding$ 	20,0,20,0q�68   $��Center=�6L   $��20(�6g   $��/Fonts/#Inter)�6u   ��6�   �� *
Question+6�   5!   +   5"   '   5$      5&      5'      5)      5+      5,      5-      