   M S B A M L   `   `   `  ????C  ?ZeppLife, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ZeppLifeZeppLife  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5   	   #clr-namespace:ZeppLifeZeppLife  5   	       ZeppLife.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ZeppLife     5   	   Bcol2clr-namespace:System.Collections;assembly=mscorlib     5   	   &appclr-namespace:ZeppLife     5   	   R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5	   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??880??6)   $	??450??65   $	??880??6E    ? 	Resources 5       ?? 
TargetType ?? Property ?? Value??%?   '??       '?? H     ?? 5   
   " ??6   .?5      ??  ? ??$ 14(?6)   5      ?? 5   
   " ??6   .?5      ??  ? ??$ 14(?6)   5      5       ? DataContext 5      '   !ZeppLife.ApplicationUserViewModel  5   
   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $
??1.2* ?6   .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   .+?5       ?? -   5         ??Name$ LoadJson??5       $??Load Tracker Data??5!      $??0??5#      $	??Top=?5$      $??30??5%      $??10q?5&      6$   ?? 5'      -   5        $ SaveData??5'      $??Save data to Json??5(      $??0??5*      $	??Top=?5+      $??30??5,      $??10q?5-      ${?False??6"   66   5.        OxyPlot.Wpf.Plot  53   
   $??1??6+   
???????  OxyPlot.Wpf.PlotBase	   	PanCursor$
	 Hand??6M   
   ZoomHorizontalCursor$
 SizeWE??6^      ZoomRectangleCursor$ SizeNWSE??6|      ZoomVerticalCursor$ SizeNS??6?      Title 6   ?? *Title+   Axes 54        OxyPlot.Wpf.LinearAxis  55        OxyPlot.Wpf.Axis   Position$ Bottom=?6!      Minimum$ 0Q?63      Maximum$ 31Q?6?     56      $
 Left=?6!   $ 0Q?61   $ 120000Q?6=      Series 58        OxyPlot.Wpf.LineSeries  59         
MarkerType$ Triangle=?6!     OxyPlot.Wpf.Series   Color$ 
Aquamarine??67   ??6J   ?? *Points+ ?? UpdateSourceTrigger$ PropertyChanged=?  5:      $ Triangle=?6!   $	 Red??68      StrokeThickness$ 0Q?6D   ??6X   ?? *
MaxPoint+$ PropertyChanged=?  5;      $ Triangle=?6!   $
 Blue??67   $ 0Q?6D   ??6X   ?? *
MinPoint+$ PropertyChanged=?5>      &   System.Windows.Controls.DataGrid  5@   
   -   5          Name$ 
phonesGrid??5@         AutoGenerateColumns$ False??6'      
IsReadOnly$
 True??5C      $??False??5D      $??Visible=?5E      $??0??5G      $??	0,49,10,0q?5H   8    ?? SelectedItem 5B      ?? *SelectedUser+   ColumnHeaderStyle 5I      ?? 5J      =	  7System.Windows.Controls.Primitives.DataGridColumnHeader" 	 6   .?5K      ??  ? ?? 5L      ?? 5M      .R?5N   "   ?? $
??Wrap=?6,   ??6@   ?? 6S   5O      5Q      5R         Columns 5T      0
  *System.Windows.Controls.DataGridTextColumn
  5U      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 160 62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   ??   ?? Path$
  User?
  5V      $* $Среднее число шагов??6%   $ 70 6B    6M   ?? $  AverageSteps?
  5W      $/ )Максимум шагов за день??6%   $ 70 6E    6P   ?? $  MaxSteps?
  5X      $- 'Минимум шагов за день??6%   $ 70 6D    6O   ?? $  MinSteps?5Z      5]      5^      