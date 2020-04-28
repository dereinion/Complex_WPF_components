using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

namespace wpf_present
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

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TxtEditor.Text = "Новий документ";
        }
        private void mnuOpen_Click(object sender, RoutedEventArgs e)
        {
            TxtEditor.Text = "Sorry but this function is not available so far";
        }
        private void viewStsBar_Clicked(object sender, RoutedEventArgs e) {
            if (StsBar.IsChecked==true)
            {
                StsBar.IsChecked= false;
                StsBar.IsCheckable = false;
                StatusBar.Visibility = Visibility.Collapsed;
            }
            else 
            {
                StsBar.IsChecked = true;
                StsBar.IsCheckable = false;
                StatusBar.Visibility = Visibility.Visible;
            }
            //status bar disappears code
        }

        private void ToolbarOpenClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
                TxtEditor.Text = File.ReadAllText(openFileDialog.FileName);
        }
        public void StatusBarSample()
        {
            InitializeComponent();
        }

        private void TxtEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int row = TxtEditor.GetLineIndexFromCharacterIndex(TxtEditor.CaretIndex);
            int col = TxtEditor.CaretIndex - TxtEditor.GetCharacterIndexFromLineIndex(row);
            lblCursorPosition.Text = "Line " + (row + 1) + ", Char " + (col + 1);
        }
   
    }
}
