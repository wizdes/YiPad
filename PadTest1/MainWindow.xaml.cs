using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Microsoft.Win32;

namespace PadTest1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            FileDetails details = FileOperations.OpenFile();
            TextBox.Text = details.file;
            App.Title = details.fileName;
        }

        private void MenuItemNew_OnClick(object sender, RoutedEventArgs e)
        {
            NewFile();
        }

        private void NewFile()
        {
            TextBox.Text = "";
            App.Title = "YiPad";
        }

        private void MenuItemSave_OnClick(object sender, RoutedEventArgs e)
        {
            string fileTitle = FileOperations.SaveFile(TextBox.Text);
            App.Title = fileTitle;
        }

        private void TextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.S))
            {
                App.Title = FileOperations.SaveFile(TextBox.Text);
            }

            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.N))
            {
                NewFile();
            }

            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.O))
            {
                FileDetails details = FileOperations.OpenFile();
                TextBox.Text = details.file;
                App.Title = details.fileName;
            }
        }

        private void DescriptionTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox thisTextBox = sender as TextBox;
            if (thisTextBox != null)
            {
                // only check if we have passed the MaxLines 
                if (thisTextBox.LineCount > thisTextBox.MaxLines)
                {
                    // we are going to discard the last entered character
                    int numChars = thisTextBox.Text.Length;

                    // force the issue
                    thisTextBox.Text = thisTextBox.Text.Substring(0, numChars - 1);

                    // set the cursor back to the last allowable character
                    thisTextBox.SelectionStart = numChars - 1;

                    // disallow the key being passed in
                    e.Handled = true;
                }
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
    }
}
