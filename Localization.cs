using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//My
using System.Windows.Controls;
using System.Windows;


namespace ByteArithmetic
{
    class LocalizationClass
    {
        //Элементы UI
        public TextBox ExTBox = new TextBox();
        public Label ExLBox = new Label();

        public TextBlock ExBlock = new TextBlock();
        public Label ExLBlock = new Label();

        public Grid ExGridF = new Grid();

        //Элементы в консоли управления
        public Button ButtonClean = new Button();
        public Button ButtonProcess = new Button();
        public Button ButtonExample = new Button();
        public Label ConsoleLabel = new Label();

        //Логи
        public Grid GridLogText = new Grid();
        public Label LabelLogText = new Label();
        public TextBlock ConsoleLabelText = new TextBlock();

        public Button ButtonCleanCosnole = new Button();

        public Button Info = new Button();

        public void Hide()
        {
            ExTBox.Visibility = Visibility.Hidden;
            ExLBox.Visibility = Visibility.Hidden;
            ExBlock.Visibility = Visibility.Hidden;
            ExLBlock.Visibility = Visibility.Hidden;
            ExGridF.Visibility = Visibility.Hidden;
            GridLogText.Visibility = Visibility.Hidden;
            Info.Visibility = Visibility.Hidden;
        }

        public void Show()
        {
            ExTBox.Visibility = Visibility.Visible;
            ExLBox.Visibility = Visibility.Visible;
            ExBlock.Visibility = Visibility.Visible;
            ExLBlock.Visibility = Visibility.Visible;
            ExGridF.Visibility = Visibility.Visible;
            GridLogText.Visibility = Visibility.Visible;
            Info.Visibility = Visibility.Visible;
        }

        public void ChangeOnRu()
        {
            //ExTB.Text = "Hi!";
            ExTBox.Text = "Последовательность байт";
            ExLBox.Content = "Исходные данные:";
            ExBlock.Text = "Результаты анализа";
            ExLBlock.Content = "Полученная статистика:";

            ButtonClean.Content = "Очистить Всё";
            ButtonProcess.Content = "Обработать";
            ButtonExample.Content = "Пример";
            ConsoleLabel.Content = "Консоль управления:";

            LabelLogText.Content = "Логи:";
            ConsoleLabelText.Text = "Консоль логирования";

            ButtonCleanCosnole.Content = "Убрать (без лог)";
        }

        public void ChangeOnEn()
        {
            ExTBox.Text = "Byte sequence";
            ExLBox.Content = "Initial data:";
            ExBlock.Text = "Analysis results";
            ExLBlock.Content = "Statistics received:";

            ButtonClean.Content = "Clear All";
            ButtonProcess.Content = "Process";
            ButtonExample.Content = "Example";
            ConsoleLabel.Content = "Management console:";

            LabelLogText.Content = "Logs:";
            ConsoleLabelText.Text = "Log console";

            ButtonCleanCosnole.Content = "Clear except log";
        }
    }
}
