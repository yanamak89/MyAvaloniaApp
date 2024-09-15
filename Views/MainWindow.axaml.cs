using Avalonia.Controls;
using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace MyAvaloniaApp
{
    public partial class MainWindow : Window
    {
        private const string fileName = "userData.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        // Метод для збереження даних
        private void SaveData_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            string dataToSave = InputTextBox.Text;

            if (!string.IsNullOrEmpty(dataToSave))
            {
                using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
                {
                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(fileName, FileMode.Create, isolatedStorage))
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            writer.WriteLine(dataToSave);
                        }
                    }
                }

                SavedDataTextBlock.Text = "Дані збережені успішно!";
            }
            else
            {
                SavedDataTextBlock.Text = "Будь ласка, введіть дані для збереження.";
            }
        }

        // Метод для завантаження даних
        private void LoadData_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (isolatedStorage.FileExists(fileName))
                {
                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(fileName, FileMode.Open, isolatedStorage))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string loadedData = reader.ReadToEnd();
                            SavedDataTextBlock.Text = $"Збережені дані: {loadedData}";
                        }
                    }
                }
                else
                {
                    SavedDataTextBlock.Text = "Немає збережених даних.";
                }
            }
        }
    }
}
