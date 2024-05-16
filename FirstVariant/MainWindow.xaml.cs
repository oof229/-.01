using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Reflection;

namespace FirstVariant
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Panels();
            LoadData();
            this.ResizeMode = ResizeMode.NoResize; //запрет на растягивание окна

            //добавление элементов в навигацию
            navigationBox.Items.Add("Тела и вещества");
            navigationBox.Items.Add("Физические и химические процессы");
            navigationBox.Items.Add("Химические элементы");
        }

        private void Panels() //скрытие окон и элементов
        {
            ThemeOneGrid.Visibility = Visibility.Hidden;
            ThemeTwoGrid.Visibility = Visibility.Hidden;
            ThemeThreeGrid.Visibility = Visibility.Hidden;
            ExitButton.Visibility = Visibility.Hidden;
            AddThemeGrid.Visibility = Visibility.Hidden;
            AddTheme.Visibility = Visibility.Hidden;
            navigationBox.Visibility = Visibility.Hidden;
        }

        private void LoadData() //загрузка тем
        {
            DataConnect.FirstThemeData();
            ThemeListView.ItemsSource = DataConnect.oneView;

            DataConnect.TwoThemeData();
            ThemeListBox.ItemsSource = DataConnect.twoView;

            DataConnect.ThridThemeData();
            ThemeList.ItemsSource = DataConnect.threeView;
        }

        private void OneThemeButton_Click(object sender, RoutedEventArgs e)
        {
            ThemeOneGrid.Visibility = Visibility.Visible;
            ExitButton.Visibility = Visibility.Visible;
            AddTheme.Visibility = Visibility.Visible;
            navigationBox.Visibility = Visibility.Visible;
        }
        private void TwoThemeButton_Click(object sender, RoutedEventArgs e)
        {
            ThemeTwoGrid.Visibility = Visibility.Visible;
            ExitButton.Visibility = Visibility.Visible;
            AddTheme.Visibility = Visibility.Visible;
            navigationBox.Visibility = Visibility.Visible;
        }
        private void ThreeThemeButton_Click(object sender, RoutedEventArgs e)
        {
            ThemeThreeGrid.Visibility = Visibility.Visible;
            ExitButton.Visibility = Visibility.Visible;
            AddTheme.Visibility = Visibility.Visible;
            navigationBox.Visibility = Visibility.Visible;
        }
        //открытие тем по нажатию кнопок

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Panels();
            ExitButton.Visibility = Visibility.Hidden;
        }
        //выход в главное меню

        private void AddTheme_Click(object sender, RoutedEventArgs e) //отображение UI записи тем
        {
            AddThemeGrid.Visibility = Visibility.Visible;
            AddTheme.Visibility = Visibility.Hidden;
            navigationBox.Visibility = Visibility.Hidden;
        }

        private void SaveDataButton_Click(object sender, RoutedEventArgs e) //сохранение темы
        {
            DataConnect.AddThemeData(NameTextBox.Text, ThemeTextBox.Text);
            //перезапуск приложения
            string appName = Assembly.GetEntryAssembly().Location;
            Process.Start(appName);
            Application.Current.Shutdown();
        }

        private void navigationBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (navigationBox.SelectedItem == null) return; // проверка на пустой выбор

            string selectedItem = navigationBox.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "Тела и вещества":
                    ThemeOneGrid.Visibility = Visibility.Visible;
                    ThemeTwoGrid.Visibility = Visibility.Hidden;
                    ThemeThreeGrid.Visibility = Visibility.Hidden;
                    break;

                case "Физические и химические процессы":
                    ThemeOneGrid.Visibility = Visibility.Hidden;
                    ThemeTwoGrid.Visibility = Visibility.Visible;
                    ThemeThreeGrid.Visibility = Visibility.Hidden;
                    break;

                case "Химические элементы":
                    ThemeOneGrid.Visibility = Visibility.Hidden;
                    ThemeTwoGrid.Visibility = Visibility.Hidden;
                    ThemeThreeGrid.Visibility = Visibility.Visible;
                    break;
            }
        }
        //навигация по темам

        private void SereachElement_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = SereachElement.Text;
            ThemeList.ItemsSource = DataConnect.searchResults;
            DataConnect.SearchElement(searchTerm);
        }
        //поиск элементов в таблице
    }

    public class DataConnect //класс подключения к базе данных
    {
        public static List<string> oneView = new List<string>(); //коллекции для БД
        public static List<string> twoView = new List<string>();
        public static List<string> threeView = new List<string>();
        public static List<string> searchResults = new List<string>();

        static string connect = "Data Source=GK216_7\\SQLEXPRESS;Initial Catalog=DimaCool;Integrated Security=True";
        //строка подключения
        public static void FirstThemeData()//отображение первой темы
        {
            string query = "SELECT name, theme FROM dbo.DataThemes WHERE name LIKE '%Тела и вещества%'"; //sql запрос

            using (SqlConnection connection = new SqlConnection(connect)) //подключение
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection); //запрос
                SqlDataReader reader = command.ExecuteReader(); //чтение

                while (reader.Read()) //запись
                {
                    oneView.Add(reader["name"].ToString());//добавляем название темы в список
                    oneView.Add(reader["theme"].ToString());// добавляем тему в список
                }

                connection.Close();
            }
        }

        public static void TwoThemeData() //отображение второй темы
        {
            string query = "SELECT name, theme FROM dbo.DataThemes WHERE name LIKE '%Физические и химические процессы%'"; //sql запрос

            using (SqlConnection connection = new SqlConnection(connect)) //подключение
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection); //запрос
                SqlDataReader reader = command.ExecuteReader(); //чтение

                while (reader.Read()) //запись
                {
                    twoView.Add(reader["name"].ToString());//добавляем название темы в список
                    twoView.Add(reader["theme"].ToString());// добавляем тему в список
                }

                connection.Close();
            }
        }

        public static void ThridThemeData() //отображение третьей темы
        {
            string query = "SELECT name, theme FROM dbo.DataThemes WHERE name LIKE '%Химические элементы%'"; //sql запрос

            using (SqlConnection connection = new SqlConnection(connect)) //подключение
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection); //запрос
                SqlDataReader reader = command.ExecuteReader(); //чтение

                while (reader.Read()) //запись
                {
                    threeView.Add(reader["name"].ToString());//добавляем название темы в список
                    threeView.Add(reader["theme"].ToString());// добавляем тему в список
                }

                connection.Close();
            }
        }

        public static void AddThemeData(string name, string theme)
        {
            string query = "INSERT INTO dbo.DataThemes (name, theme) VALUES (@name, @theme)";

            using (SqlConnection connection = new SqlConnection(connect))
            {
                SqlCommand command = new SqlCommand(query, connection);

                //параметры записи
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@theme", theme);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void SearchElement(string searchTerm)
        {
            searchResults.Clear();

            string query = "SELECT theme FROM dbo.DataThemes WHERE theme LIKE @searchTerm";

            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            searchResults.Add(reader["theme"].ToString());
                        }
                    }
                }
            }
        }
    }
}
