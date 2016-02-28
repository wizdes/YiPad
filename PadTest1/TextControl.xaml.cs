using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PadTest1
{
    /// <summary>
    /// Interaction logic for TextControl.xaml
    /// </summary>
    public partial class TextControl : UserControl
    {
        private static Dictionary<int, string> windowToFilenameDictionary = new Dictionary<int, string>();

        public TextControl()
        {
            InitializeComponent();
            windowToFilenameDictionary[0] = "";
            string[] args = System.Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                string fileName = args[1];
                FileDetails f = FileOperations.OpenFileNoDialog(fileName);
                UISetFile(f);
            }
        }

        // TODO: May want to seperate the UI model into another class? 
        private void menuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            FileDetails details = FileOperations.OpenFile();
            UISetFile(details);
        }

        private void UISetFile(FileDetails details)
        {
            TextBox.Text = details.file;
            MainWindow.changeHeader(details.fileName);
            //this.Parent.Title = details.fileName;
            windowToFilenameDictionary[0] = details.fileName;
        }

        private void MenuItemNew_OnClick(object sender, RoutedEventArgs e)
        {
            NewFile();
        }

        private void NewFile()
        {
            TextBox.Text = "";
            windowToFilenameDictionary[0] = "";
            //App.Title = "YiPad";
        }

        private void MenuItemSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (windowToFilenameDictionary[0] == "")
            {
                string fileTitle = FileOperations.SaveFile(TextBox.Text);
                windowToFilenameDictionary[0] = fileTitle;
                MainWindow.changeHeader(fileTitle);
                //App.Title = fileTitle;
            }
            else
            {
                FileOperations.SaveFileNoDialog(windowToFilenameDictionary[0], TextBox.Text);
            }
        }

        private void TextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.S))
            {
                //App.Title =;
                MainWindow.changeHeader(FileOperations.SaveFile(TextBox.Text));
            }

            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.N))
            {
                NewFile();
            }

            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.O))
            {
                FileDetails details = FileOperations.OpenFile();
                TextBox.Text = details.file;
                MainWindow.changeHeader(details.fileName);
                //App.Title = details.fileName;
            }
        }

        private void TextBox_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            int caret = TextBox.CaretIndex;
            int row = TextBox.GetLineIndexFromCharacterIndex(caret);
            int column = caret - TextBox.GetCharacterIndexFromLineIndex(row);
            int displayedRow = row + 1;
            int displayColumn = column + 1;
            StatusBarLine.Text = "Line " + displayedRow + ":" + TextBox.LineCount + " Column " + displayColumn;
        }

        private void MenuItemSaveAs_OnClick(object sender, RoutedEventArgs e)
        {
            string fileTitle = FileOperations.SaveFile(TextBox.Text);
            windowToFilenameDictionary[0] = fileTitle;
            MainWindow.changeHeader(fileTitle);
            //App.Title = fileTitle;
        }

        private void TextBox_OnDrop(object sender, DragEventArgs e)
        {
            string[] data = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            FileDetails f = FileOperations.OpenFileNoDialog(data[0]);
            UISetFile(f);
        }

        private void TextBox_OnPreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }
    }
}
