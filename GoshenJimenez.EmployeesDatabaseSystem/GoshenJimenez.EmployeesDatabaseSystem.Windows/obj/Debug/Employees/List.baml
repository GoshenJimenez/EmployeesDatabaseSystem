   M S B A M L   `   `   `  ����h  dGoshenJimenez.EmployeesDatabaseSystem.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Eclr-namespace:GoshenJimenez.EmployeesDatabaseSystem.Windows.Employees7GoshenJimenez.EmployeesDatabaseSystem.Windows.Employees  5   	   B    <GoshenJimenez.EmployeesDatabaseSystem.Windows.Employees.List   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   WlocalEclr-namespace:GoshenJimenez.EmployeesDatabaseSystem.Windows.Employees     5   	     � Title$
  List��5   	   $��412.667��6   $	��800��6'   .��5	      � $��0,0,-0.4,-2q�6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgEmployees��5
      $
��Left=�6(   $	��214��6C   $��	35,78,0,0q�6P   $	��Top=�6c   $	��704��6{      AutoGenerateColumns .     CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5   5   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6   �� *	FirstName+65     5      $ 	Last Name��6%   $ * 5   4    6   �� *
LastName+64     5      $ Email Address��6%   $ * 5   8    6   �� *EmailAddress+68     5      $ Status��6%   $ * 5   2    6   �� *Status+62     5      $ Gross Salary��6%   $ * 5   2    6   �� *Salary+62     5      $ 
Deductions��6%   $ * 5   6    6   �� *
Deductions+66     5      $ 
Net Salary��6%   $ * 5   5    6   �� *	NetSalary+65     5      $ 
Assignment��6%   $ * 5   6    6   �� *
Assignment+66   4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5      �� 	 ��Name$	 	btnUpdate��6%   -   5        .��5   P   Update6X   5       5"        5#       5$      �� 5%      .R�5&      �� $	 	btnDelete��6%   -   5        .��5&   P   Delete6X   5'      5)        5*       5+      �� 5,      .R�5-      �� $	 btnDeactivate��6%   -   5        .��5-   X   
Deactivate6d   5.      50        51       52      �� 53      .R�54      �� $	 btnDeductions��6%   -   5        .��54   X   Show Deductions6i   55      57      59      �� 5:   
   -   5        
 ��Name$
 cboSortOrder��5:      $
��Left=�6)   $��
618,10,0,0q�6D   $	��Top=�6X   $	��120��6p   6|   �� 5;   
   -   5         ��Name$ lblSortOrder��5;      $��
Sort Order��6&   $
��Left=�6;   $��29��6V   $��
526,10,0,0q�6b   $	��Top=�6v   $��87��6�    J� RenderTransformOrigin$ 0.783,0.576&�6�   �� 5<   
   -   5        $
 	cboSortBy��5<      $
��Left=�6&   $��
396,10,0,0q�6A   $	��Top=�6U   $	��120��6m   6y   �� 5=   
   -	   5        $ 	lblSortBy��5=      $��Sort By��6#   $
��Left=�65   $��29��6P   $��
304,10,0,0q�6\   $	��Top=�6p   $��87��6�   $ 0.783,0.576&�6�   �� 5>   
   -
   5        $	 btnFirst��5>      $��First��6#   $
��Left=�63   $	��Top=�6N   $��75��6f   $��18��6q   $��
35,316,0,0q�6}   6�   �� 5?   
   -   5        $	 btnLast��5?      $
��Last��6"   $
��Left=�61   $	��Top=�6L   $��75��6d   $��18��6o   $��275,316,0,0q�6{   6�   �� 5@   
   -   5        $	 btnNext��5@      $
��Next��6"   $
��Left=�61   $	��Top=�6L   $��75��6d   $��18��6o   $��195,316,0,0q�6{   $ 0.615,2.311&�6�   6�   �� 5A   
   -   5        $	 btnPrevious��5A      $��Previous��6&   $
��Left=�69   $	��Top=�6T   $��75��6l   $��18��6w   $��115,316,0,0q�6�   6�   �� 5B   
   -   5         ��Name$ txtPageSize��5B      $��5��6'   $
��Left=�60   $��23��6K    �� TextWrapping$
 Wrap=�6W   $	��Top=�6k   $��75��6�   $��115,339,0,0q�6�   6�   �� 5C   
   -   5        $ lblPageSize��5C      $��	Page Size��6%   $
��Left=�69   $	��Top=�6T   $��
35,339,0,0q�6l   �� 5D   
   -   5        $
 cboFilterAssignment��5D      $
��Left=�60   $��
473,44,0,0q�6K   $	��Top=�6_   $	��120��6w   6�   �� 5E   
   -   5        $ 
lblFilters��5E      $��Filters��6$   $
��Left=�66   $��29��6Q   $��	35,44,0,0q�6]   $	��Top=�6p   $��87��6�   $ 0.783,0.576&�6�   �� 5F   
   -   5        $
 cboFilterStatus��5F      $
��Left=�6,   $��
617,44,0,0q�6G   $	��Top=�6[   $	��120��6s   6   �� 5G   
   -   5        $ 
txtKeyword��5G      $
��Left=�6&   $��23��6A   $��	89,43,0,0q�6M   $
 Wrap=�6`   $	��Top=�6t   $	��363��6�   6�   �� 5H   
   -   5        $	 btnAdd��5H      $��Add New��6!   $
��Left=�63   $	��Top=�6N   $��75��6f   $��18��6q   $��662,316,0,0q�6}   6�   5J      5K      