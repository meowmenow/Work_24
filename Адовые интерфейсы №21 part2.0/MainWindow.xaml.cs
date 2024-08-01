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
using System.Data;

static class VissualArray
{
    public static DataTable ToDataTable<T>(this T[,] matrix)
    {
        var res = new DataTable();
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            res.Columns.Add("Столбец " + (i + 1), typeof(T));
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            var row = res.NewRow();

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                row[j] = matrix[i, j];
            }
            res.Rows.Add(row);
        }
        return res;
    }
}
namespace Адовые_интерфейсы__21_part2._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void exit_Click(object sender, RoutedEventArgs e)
        {
            // Добавляем данные для MessageBox
            // t1 - Текст MessageBox'а
            string t1 = "Уверены, что хотите выйти?";
            // t2 - Заголовок MessageBox'a
            string t2 = "Предупреждение";
            // Параметры кнопок MessageBox'a
            // В данном случае Да\Нет
            MessageBoxButton bt = MessageBoxButton.YesNo;
            // Подставляем иконку вопроса к тексту
            MessageBoxImage icon = MessageBoxImage.Question;
            // Создаем переменную для присваивания всех данных и присваиваем данные
            MessageBoxResult result;
            result = MessageBox.Show(t1, t2, bt, icon, MessageBoxResult.Yes);
            // Оператор switch помогает нам сменить окно, в случае положительного ответа в MessageBox
            switch (result)
            {
                // Описан только случай с положительным ответом, так как при отрицательном ничего не происходит
                case MessageBoxResult.Yes:
                    // Закрытие рабочего окна
                    this.Close();
                    break;
            }
        }

        int[,] matrix;

        private void create2_Click(object sender, RoutedEventArgs e)
        {
            ras2.IsEnabled = true;
            int k, s = 2, d;
            bool f1 = Int32.TryParse(kolk.Text, out k);
            bool f3 = Int32.TryParse(n.Text, out d);
            if (f1 == true && f3 == true)
            {
                if (k > 0)
                {
                    matrix = new int[s, k];
                    Random rnd = new Random();
                    for (int i = 0; i < s; i++)
                    {
                        for (int j = 0; j < k; j++)
                        {
                            matrix[i, j] = rnd.Next(-d, d); ;
                        }
                    }
                    dg2.ItemsSource = VissualArray.ToDataTable(matrix).DefaultView;
                }
                else
                {
                    // Очистка окна ввода
                    kolk.Clear();
                    // Предупреждение об ошибке при помощи MessageBox
                    // t1 - Текст MessageBox'a
                    string t1 = "Недопустимое значение!";
                    // t2 - Заголовок MessageBox'a
                    string t2 = "Ошибочка";
                    // Параметр кнопок MessageBox'a
                    // В данном случае единственный возможный ответ ОК
                    MessageBoxButton button = MessageBoxButton.OK;
                    // Добавление иконки ошибки к тексту
                    MessageBoxImage icon = MessageBoxImage.Error;
                    // Переменная для объединения данных
                    MessageBoxResult result;
                    result = MessageBox.Show(t1, t2, button, icon, MessageBoxResult.Yes);
                }
            }
            else
            {
                // Очистка окна ввода
                kolk.Clear();
                n.Clear();
                // Предупреждение об ошибке при помощи MessageBox
                // t1 - Текст MessageBox'a
                string t1 = "Недопустимое значение!";
                // t2 - Заголовок MessageBox'a
                string t2 = "Ошибочка";
                // Параметр кнопок MessageBox'a
                // В данном случае единственный возможный ответ ОК
                MessageBoxButton button = MessageBoxButton.OK;
                // Добавление иконки ошибки к тексту
                MessageBoxImage icon = MessageBoxImage.Error;
                // Переменная для объединения данных
                MessageBoxResult result;
                result = MessageBox.Show(t1, t2, button, icon, MessageBoxResult.Yes);
            }
        }

        private void ras2_Click(object sender, RoutedEventArgs e)
        {
            int x = 2;
            int y = Convert.ToInt32(kolk.Text);
            int a = 0;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i == 0)
                    {
                        if (matrix[i, j] > 0 && matrix[i + 1, j] < 0 || matrix[i + 1, j] > 0 && matrix[i, j] < 0)
                        {
                            a = j + 1;
                        }
                    }
                }
            }

            if (a != 0)
            {
                viv2.Text = Convert.ToString(a);
            }
            else
            {
                viv2.Text = Convert.ToString(0);
            }

        }

        private void clir_Click(object sender, RoutedEventArgs e)
        {
            dg2.ItemsSource = null;
            n.Clear();
            kolk.Clear();
            viv2.Clear();
        }

        private void clirus_Click(object sender, RoutedEventArgs e)
        {
            dg2.ItemsSource = null;
            kolk.Clear();
            n.Clear();
            viv2.Clear();
        }
        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Горе-дизайнер Бирюков Георгий, Гриша, Джордж, Жорик и тому подобные личности из ИСП-23. Ввести n целых чисел. Найти сумму чисел кратных 5. Результат вывести на экран");
        }


        private void anek_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Как называется главное место казни на Руси? Кол-центр"); //Выводим анекдот 
        }

        private void random_Click(object sender, RoutedEventArgs e)
        {
            ras2.IsEnabled = true;

            int k, s, d;
            Random rnd = new Random();
            d = rnd.Next(1, 1000);
            
                k = rnd.Next(1, 10); s = rnd.Next(1, 10);
                matrix = new int[s, k];
                for (int i = 0; i < s; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        matrix[i, j] = rnd.Next(-d, d); ;
                    }
                }
                dg2.ItemsSource = VissualArray.ToDataTable(matrix).DefaultView;
            
        }
    }
}
