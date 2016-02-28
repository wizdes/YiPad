using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Dragablz;

namespace PadTest1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DragablzWindow
    {
        private static bool _hackyIsFirstWindow = true;

        private static MainWindowViewModel context;

        public MainWindow()
        {
            InitializeComponent();

            if (_hackyIsFirstWindow)
            {
                context = MainWindowViewModel.CreateInitView();
                DataContext = context;   
            }

            _hackyIsFirstWindow = false;

        }

        public static void changeHeader(string s)
        {
            context.TabContents[0].Header = s;
        }

        public static Func<object> NewItemFactory
        {
            get { return MainWindowViewModel.NewItemFactory; }
        }
    }
}
