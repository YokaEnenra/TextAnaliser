using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Application = Microsoft.Office.Interop.Word.Application;
using Document = Microsoft.Office.Interop.Word.Document;

namespace RGZ_Real
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private string[] _text;
        private bool _isFile;
        private string _information = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            TextOnScreen.Clear();
            _information = "";
            _isFile = false;
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter =
                    "Текстові файли (*.txt)|*.txt|Документи (*.docx;*.doc)|*.docx;*.doc|Всі файли (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            if (openFileDialog.ShowDialog() == true)
            {
                if (Path.GetExtension(openFileDialog.FileName) == ".txt")
                {
                    _isFile = true;
                    _text = File.ReadAllLines(openFileDialog.FileName);
                }
                else if (Path.GetExtension(openFileDialog.FileName) == ".docx" ||
                         Path.GetExtension(openFileDialog.FileName) == ".doc")
                {
                    _isFile = true;
                    object readOnly = true;
                    object addToRecentFiles = false;
                    Application ap = new Application { Visible = false };
                    Document document = ap.Documents.Open(openFileDialog.FileName, ReadOnly: readOnly,
                        AddToRecentFiles: ref addToRecentFiles);
                    object saveChanges = false;
                    _text = document.Content.Text.Split(new[] { "\r" }, StringSplitOptions.None);
                    ap.Quit(ref saveChanges);
                }
                else
                {
                    MessageBox.Show("Тип обраного файлу не підтримується", "Помилка!", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }

                if (_isFile)
                {
                    foreach (var paragraph in _text)
                    {
                        TextOnScreen.AppendText(paragraph + "\n");
                    }
                }
            }
        }

        private void ProcessFile_Click(object sender, RoutedEventArgs e)
        {
            if (_isFile)
            {
                Counter.Reset();
                TextOnScreen.Clear();
                Counter.CountParagraphs(_text);
                var checkers = new List<Checker>()
                {
                    new LetterChecker(),
                    new WordChecker(),
                    new CommaChecker(),
                    new DotChecker(),
                    new ExclamationChecker(),
                    new QuestionChecker()
                    
                };
                foreach (var paragraph in _text)
                {
                    foreach (var symbol in paragraph)
                    {
                        foreach (var checker in checkers)
                        {
                            if (checker.Check(symbol))
                            {
                                Checker.PrevSymbol = symbol;
                                break;
                            }

                        }
                    }
                }
                var output = Counter.GetAll();
                if (ParagraphsCheck.IsChecked == true)
                {
                    TextOnScreen.AppendText("Абзаців в тексті:" + output[0] + "\n");
                }

                if (SentencesCheck.IsChecked == true)
                {
                    TextOnScreen.AppendText("Речень в тексті:" + output[1] + "\n");
                }

                if (WordsCheck.IsChecked == true)
                {
                    TextOnScreen.AppendText("Слів в тексті:" + output[2] + "\n");
                }

                if (LettersCheck.IsChecked == true)
                {
                    TextOnScreen.AppendText("Літер в тексті:" + output[3] + "\n");
                }

                if (CommasCheck.IsChecked == true)
                {
                    TextOnScreen.AppendText("Ком в тексті:" + output[4] + "\n");
                }

                if (QuestionsCheck.IsChecked == true)
                {
                    TextOnScreen.AppendText("Знаків питання в тексті:" + output[5] + "\n");
                }

                if (ExclamationsCheck.IsChecked == true)
                {
                    TextOnScreen.AppendText("Знаків оклику в тексті:" + output[6] + "\n");
                }

                _information = TextOnScreen.Text;
            }
            else
            {
                MessageBox.Show("Спочатку оберіть файл", "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void DisplayText_Click(object sender, RoutedEventArgs e)
        {
            if (_isFile)
            {
                TextOnScreen.Clear();
                foreach (var paragraph in _text)
                {
                    TextOnScreen.AppendText(paragraph + "\n");
                }
            }
            else
            {
                MessageBox.Show("Спочатку оберіть файл", "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveInfo_Click(object sender, RoutedEventArgs e)
        {
            if (_information != "")
            {
                var saveFileDialog = new SaveFileDialog
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Filter =
                        "Текстові файли (*.txt)|*.txt|Всі файли (*.*)|*.*"
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, _information);
                    MessageBox.Show("Дані збережено у файл: " + saveFileDialog.FileName, "Збережено!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Спочатку опрацюйте текст", "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}