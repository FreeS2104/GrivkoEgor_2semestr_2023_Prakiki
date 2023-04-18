using Microsoft.Win32;
using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
namespace pz_10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string filePath;
        private bool isTextChanged;
        public MainWindow()
        {
            InitializeComponent();
            TextBox.Focus();

        }
        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontSizeComboBox.SelectedItem != null)
            {
                TextBox.FontSize = double.Parse((FontSizeComboBox.SelectedItem as ComboBoxItem).Content.ToString());
            }
        }
        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox.FontWeight = TextBox.FontWeight == FontWeights.Bold ? FontWeights.Normal : FontWeights.Bold;
        }
        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox.FontStyle = TextBox.FontStyle == FontStyles.Italic ? FontStyles.Normal : FontStyles.Italic;
        }
        private void UnderlineButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox.TextDecorations = TextBox.TextDecorations == null || TextBox.TextDecorations.Count == 0 ? TextDecorations.Underline : null;
        }
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
                TextBox.Text = File.ReadAllText(filePath);
                isTextChanged = false;

            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                if (saveFileDialog.ShowDialog() == true)
                {
                    filePath = saveFileDialog.FileName;
                }
            }
            File.WriteAllText(filePath, TextBox.Text);
            isTextChanged = false;

        }
        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Copy();
        }
        private void PasteButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Paste();
        }
        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.CanUndo)
            {
                TextBox.Undo();
            }
        }
        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.CanRedo)
            {
                TextBox.Redo();
            }
        }
    }
}
