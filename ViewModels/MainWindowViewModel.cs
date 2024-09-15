using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO.IsolatedStorage;
using System.IO;

namespace MyAvaloniaApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _greeting;
        private const string FileName = "UserData.txt";

        public MainWindowViewModel()
        {
            LoadData();
        }

        public string Greeting
        {
            get => _greeting;
            set
            {
                _greeting = value;
                OnPropertyChanged();
            }
        }

        // Метод для збереження даних в ізольоване сховище
        public void SaveData()
        {
            using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(FileName, FileMode.Create, isolatedStorage))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.WriteLine(Greeting);
                    }
                }
            }
        }

        // Метод для завантаження даних з ізольованого сховища
        private void LoadData()
        {
            using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (isolatedStorage.FileExists(FileName))
                {
                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(FileName, FileMode.Open, isolatedStorage))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            Greeting = reader.ReadToEnd();
                        }
                    }
                }
                else
                {
                    Greeting = "Введіть дані для збереження!";
                }
            }
        }

        // Подія для оновлення інтерфейсу
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
