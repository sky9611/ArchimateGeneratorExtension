   M S B A M L   `   `   `  ����V  RArchimateGeneratorExtension, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ArchimateGeneratorExtensionArchimateGeneratorExtension  5      2    ,ArchimateGeneratorExtension.GenerationWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:ArchimateGeneratorExtension     5      X TXceed.Wpf.Toolkit, Version=3.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44wpfx)http://schemas.xceed.com/wpf/xaml/toolkit  5      $��663.041��5   *   $��580.18��6;   .��5	      � $��0,0,2,7q�6     � ColumnDefinitions  5
   
   �� 5      �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ Element_type��5      $
��Left=�6*   $��	20,19,0,0q�6E   $
��Wrap=�6X   $��Element type��6l   $	��Top=�6�   $��45��6�   $	��155��6�   $��18(�6�   �� 5   
   $
��Left=�6   $��	20,88,0,0q�6/   $
��Wrap=�6B   $	��Top=�6V   $��45                    ��6n   $	��155��6�   $��18(�6�   �� 6�   $�Group��6�   6�   1   +ArchimateGeneratorExtension.MyCheckComboBox  5   
   -   5          Name$ Group��5       1   +ArchimateGeneratorExtension.MyCheckComboBox   ItemSelectionChanged$  Group_ItemSelectionChanged��5   s   $%��45                             ��5   E   $��228,116,0,0q�5      $	��Top=�64   $
��Left=�6L   $	��322��6g   ��5      �� +  %Xceed.Wpf.Toolkit.Primitives.Selector   SelectedValue 5      �� *SelectedValue+5   s   �� 5   
   -   5         ��Name$ Generate��5      $��Generate Elements��6#   $��392,553,0,0q�6?   $��16(�6T   $��32��6y   $	��Top=�6�   $
��Left=�6�   $	��158��6�    J� RenderTransformOrigin$ -0.005,2.078&�6�   �� 5   
   $
��Left=�6   $��
20,183,0,0q�6/   $
��Wrap=�6C   $
��View��6W   $	��Top=�6c   $��45                    ��6{   $	��155��5      $��18(�6"     5   
   -   5        $
 View��5       $ View_ItemSelectionChanged��5   s   $%��45                             ��5   E   $��228,211,0,0q�5      $	��Top=�64   $
��Left=�6L   $	��322��6g   ��5      ��  5      �� *SelectedValue+5        5   
   -   5        $ ElementType��5       $&  ElementType_ItemSelectionChanged��5   �   $��
228,19,0,0q�6E   $	��Top=�6Y   $��45��6q   $
��Left=�6}   $	��322��6�   ��5   5   ��  5      �� *SelectedValue+6�   �� 5   
   -   5         ��Name$ 
ViewSearch��5      $
��Left=�6&   $��23��6A   $��228,183,0,0q�6M    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��322��6�   6�   �� 5   
   -   5        $ GroupSearch��5      $
 Wrap=�6'   $��
228,88,0,0q�6W   $	��Top=�6k   $
��Left=�6�   $	��322��6�   $��23��6�   �� 5    
   $
��Left=�6   $��
20,479,0,0q�6/   $
��Wrap=�6C   $��Default namespace prefix��6W   $	��Top=�6w   $��46��6�   $	��155��6�   $��16(�6�   �� 5!   
   -   5        $ 	NameSpace��5!      $
��Left=�6%   $��46��6@   $��228,479,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��322��6�   $��16(�6�   �� 5"   
   $
��Left=�6   $��
20,385,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��74��6o   $	��156��6{   $��18(�6�   �� 6�   $�Element��6�   �� 6�   �� 6�   $ �(Group ou View) et Project��6�   6�     5#   
   -	   5        $ Element��5#       $" Element_ItemSelectionChanged��5%   �   $��46��65   $��228,413,0,0q�6A   $	��Top=�6V   $
��Left=�6n   $	��322��6�   ��5$      ��  5%      �� *SelectedValue+6�   �� 5&   
   -
   5        $ ElementSearch��5&      $
��Left=�6)   $��24��6D   $��228,385,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��322��6�   6�   �� 5'   
   $
��Left=�6   $��
20,286,0,0q�6/   $
��Wrap=�6C   $��Project��6W   $	��Top=�6f   $��46��6~   $	��155��6�   $��18(�6�     5(   
   -   5        $ Project��5(       $" Project_ItemSelectionChanged��5*   �   $��45��65   $��228,314,0,0q�6A   $	��Top=�6V   $
��Left=�6n   $	��322��6�   ��5)      ��  5*      �� *SelectedValue+6�   �� 5+   
   -   5        $ ProjectSearch��5+      $
��Left=�6)   $��23��6D   $��228,286,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��322��6�   6�   5,      5-      