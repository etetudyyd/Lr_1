using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;


namespace Lr_2
{
    /// <summary>
    /// Interaction logic for TaskWindow2.xaml
    /// </summary>
    public partial class TaskWindow2 : Window
    {
        public TaskWindow2()
        {
            InitializeComponent();

            CommandBinding saveCommand = new CommandBinding(ApplicationCommands.Save, ExecuteSave, CanExecuteSave);
            CommandBinding cutCommand = new CommandBinding(ApplicationCommands.Cut, ExecuteCut, CanExecuteCut);
            CommandBinding openCommand = new CommandBinding(ApplicationCommands.Open, ExecuteOpen, CanExecuteOpen);
            CommandBinding copyCommand = new CommandBinding(ApplicationCommands.Copy, ExecuteCopy, CanExecuteCopy);
            CommandBinding pasteCommand = new CommandBinding(ApplicationCommands.Paste, ExecutePaste, CanExecutePaste);

            // Add the CommandBindings to the window
            CommandBindings.Add(saveCommand);
            CommandBindings.Add(cutCommand);
            CommandBindings.Add(openCommand);
            CommandBindings.Add(pasteCommand);
            CommandBindings.Add(copyCommand);
        }      

        //Save Command
        private void CanExecuteSave(object sender, CanExecuteRoutedEventArgs e)
        {
            if (inputTextBox.Text.Trim().Length > 0) e.CanExecute = true; else e.CanExecute = false;
        }

        private void ExecuteSave(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                File.WriteAllText("d:\\myFile.txt", inputTextBox.Text);
                MessageBox.Show("The file was saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Open Command
        private void CanExecuteOpen(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExecuteOpen(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string content = File.ReadAllText(filePath);
                    inputTextBox.Text = content;
                    MessageBox.Show("File opened successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while opening the file: {ex.Message}");
                }
            }
        }

        // Cut Command
        private void CanExecuteCut(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = inputTextBox.SelectedText.Length > 0;
        }

        private void ExecuteCut(object sender, ExecutedRoutedEventArgs e)
        {
            inputTextBox.Cut();
        }

        //Copy Command
        private void CanExecuteCopy(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = inputTextBox.SelectedText.Length > 0;
        }

        private void ExecuteCopy(object sender, ExecutedRoutedEventArgs e)
        {
            Clipboard.SetText(inputTextBox.SelectedText);
        }

        // Paste Command
        private void CanExecutePaste(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
        }

        private void ExecutePaste(object sender, ExecutedRoutedEventArgs e)
        {
            inputTextBox.Paste();
        }

    }
}
