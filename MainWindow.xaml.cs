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

namespace ByteArithmetic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InterfaceClass UIElements = new InterfaceClass();
        LocalizationClass LocalePRJ = new LocalizationClass();
        public MainWindow()
        {
            InitializeComponent();

            //Присовение UI
            LocalePRJ.ExTBox = TextBoxInput;
            LocalePRJ.ExLBox = InputText;
            LocalePRJ.ExBlock = TextBlockStat;
            LocalePRJ.ExLBlock = OutputText;
            LocalePRJ.ExGridF = GridFunc;

            LocalePRJ.ButtonClean = BClean;
            LocalePRJ.ButtonProcess = BProcess;
            LocalePRJ.ButtonExample = BExample;
            LocalePRJ.ConsoleLabel = ConsoleL;

            LocalePRJ.GridLogText = GridLog;
            LocalePRJ.LabelLogText = LogLabel;
            LocalePRJ.ConsoleLabelText = LogBox;

            LocalePRJ.ButtonCleanCosnole = BCClean;

            LocalePRJ.Info = Information;

            //Скрытие элементов
            LocalePRJ.Hide();
            CurLang.Visibility = Visibility.Hidden;

            //Выравнивание GRID
            UIElements.ExG = GridLang;
            UIElements.MarginLag(300, 0, 0, 120);
        }

        private void CheckBox_Checked_RU(object sender, RoutedEventArgs e)
        {
            if (CB_Ru.IsChecked == false)
            {
                CurLang.Content = "";
                //Выравнивание GRID
                UIElements.ExG = GridLang;
                UIElements.MarginLag(300, 0, 0, 120);
                //Скрытие
                LocalePRJ.Hide();

            } else
            {
                CurLang.Content = "Вы выбрали Русский.";
                CurLang.Visibility = Visibility.Visible;
                //Выравнивание GRID
                UIElements.ExG = GridLang;
                UIElements.MarginLag(569, 0, 0, 10);
                //Первод и отображение
                LocalePRJ.ChangeOnRu();
                LocalePRJ.Show();
            }
            
            if (CB_En.IsChecked == true)
            {
                CB_En.IsChecked = false;
                CurLang.Content = "Вы выбрали Русский.";
                CurLang.Visibility = Visibility.Visible;
                //Выравнивание GRID
                UIElements.ExG = GridLang;
                UIElements.MarginLag(569, 0, 0, 10);
                //Первод и отображение
                LocalePRJ.ChangeOnRu();
                LocalePRJ.Show();
            }
        }
        private void CheckBox_Checked_EN(object sender, RoutedEventArgs e)
        {
            if (CB_En.IsChecked == false)
            {
                CurLang.Content = "";
                //Выравнивание GRID
                UIElements.ExG = GridLang;
                UIElements.MarginLag(300, 0, 0, 120);
                //Скрытие
                LocalePRJ.Hide();
            }
            else
            {
                CurLang.Content = "You have chosen English.";
                CurLang.Visibility = Visibility.Visible;
                //Выравнивание GRID
                UIElements.ExG = GridLang;
                UIElements.MarginLag(569, 0, 0, 10);
                //Первод и отображение
                LocalePRJ.ChangeOnEn();
                LocalePRJ.Show();
            }

            if (CB_Ru.IsChecked == true)
            {
                CB_Ru.IsChecked = false;
                CurLang.Content = "You have chosen English.";
                CurLang.Visibility = Visibility.Visible;
                //Выравнивание GRID
                UIElements.ExG = GridLang;
                UIElements.MarginLag(569, 0, 0, 10);
                //Первод и отображение
                LocalePRJ.ChangeOnEn();
                LocalePRJ.Show();
            }
        }
        private void BClean_Click(object sender, RoutedEventArgs e)
        {
            TextBoxInput.Clear();
            LogBox.Text = null;
            TextBlockStat.Text = null;

            if (CB_Ru.IsChecked == true)
            {
                LogBox.Text = ">> Произведена очистка всех блоков.";
            }
            else
            {
                LogBox.Text = ">> All blocks are cleared.";
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBoxInput.Clear();
            TextBlockStat.Text = null;

            string NotNull = LogBox.Text;
            if (CB_Ru.IsChecked == true)
            {
                if (NotNull.Length > 0)
                {
                    LogBox.Text = string.Concat(NotNull, "\n>> Произведена очистка блоков кроме логов.");
                }
                else
                {
                    LogBox.Text = ">> Произведена очистка блоков кроме логов.";
                }
            }
            else
            {
                if (NotNull.Length > 0)
                {
                    LogBox.Text = string.Concat(NotNull, "\n>> Cleared blocks except logs.");
                }
                else
                {
                    LogBox.Text = ">> Cleared blocks except logs.";
                }
            }
        }
        private void BProcess_Click(object sender, RoutedEventArgs e)
        {
            ExecutionProcessing();
        }

        private void ExecutionProcessing()
        {
            int Warning = 0;

            string AllText = TextBoxInput.Text;
            if (AllText != "")
            {
                string[] AllTextOnBlocks = AllText.Split(new Char[] { ' ' });
                int NumOfBlocks = AllTextOnBlocks.Length;

                //Проверка, что текст это действительно байт последовательность
                for (int i = 0; i< AllTextOnBlocks.Length; i ++)
                {
                    if (AllTextOnBlocks[i].Length != 2)
                    {
                        Warning = 1;
                    }
                }
                //Конец проверки

                int NumOfSpace = AllText.Length - 2 * NumOfBlocks;
                int NumOfSymbols = AllText.Length;

                SetStatistics(NumOfBlocks, NumOfSpace, NumOfSymbols, Warning);
            }
            else
            {
                TextBlockStat.Text = null;
                if (CB_Ru.IsChecked == true)
                {
                    TextBlockStat.Text = "Ошибка ввода данных!";
                }
                else
                {
                    TextBlockStat.Text = "Data entry error!";
                }
            }
        }

        private void SetStatistics(int NumberOfBlocks, int NumberOfSpace, int NumberOfSymbols, int WarningNotByte)
        {
            TextBlockStat.Text = null;
            if (CB_Ru.IsChecked == true)
            { 
                TextBlockStat.Text = 
                    "Блоков: " + NumberOfBlocks + "\n" + 
                    "Пробелов: " + NumberOfSpace + "\n" + 
                    "Символов: " + NumberOfSymbols + "\n";

                if (WarningNotByte == 1)
                {
                    string Temp = TextBlockStat.Text;
                    Temp += "\n\nОбратите внимание: введённые данные не представляют байт последовательности";
                    TextBlockStat.Text = Temp;
                }

                string NotNull = LogBox.Text;
                if (NotNull.Length > 0)
                { LogBox.Text = string.Concat(NotNull, "\nБлоков: " + 
                    NumberOfBlocks + ", пробелов: " +
                    NumberOfSpace + ", символов: " + 
                    NumberOfSymbols); }
                else
                { LogBox.Text = "Блоков: " + NumberOfBlocks + ", пробелов: " + NumberOfSpace + ", символов: " + NumberOfSymbols; }
            }
            else
            {
                TextBlockStat.Text =
                    "Blocks: " + NumberOfBlocks + "\n" +
                    "Spaces: " + NumberOfSpace + "\n" +
                    "Characters: " + NumberOfSymbols + "\n";

                if (WarningNotByte == 1)
                {
                    string Temp = TextBlockStat.Text;
                    Temp += "\n\nNote: the data entered does not represent a byte of the sequence";
                    TextBlockStat.Text = Temp;
                }

                string NotNull = LogBox.Text;
                if (NotNull.Length > 0)
                { LogBox.Text = string.Concat(NotNull, "\nBlocks: " + 
                    NumberOfBlocks + ", spaces: " + 
                    NumberOfSpace + ", characters: " + 
                    NumberOfSymbols); }
                else
                { LogBox.Text = "Blocks: " + NumberOfBlocks + ", spaces: " + NumberOfSpace + ", characters: " + NumberOfSymbols; }
            }
        }

        private void BExample_Click(object sender, RoutedEventArgs e)
        {
            TextBoxInput.Clear();
            TextBoxInput.Text = "d0 9f d1 80 d0 b8 d0 bc d0 b5 d1 80 20 45 78 61 6d 70 6c 65";
            ExecutionProcessing();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = 
                MessageBox.Show(
                "Автор данного ПО - Бородин Дмитрий; \n" +
                "Адрес VK - http://vk.com/id60202849; \n" +
                "Среда разработки - IDE Microsoft Visual Studio 2019 Enterprise; \n" +
                "Язык разработки - C#, графический интерфейс - WPF \n", 
                
                "Сведения об авторе и среде разработки", 
                MessageBoxButton.OK, 
                MessageBoxImage.None);
        }
    }
}
