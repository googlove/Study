using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace DataBase
{

    public partial class MainWindow : Window
    {
        SqlConnection Connection;                //объявляем как поле класса
        static Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        enum Region
        {
            AK, AB, AC, AE, AH, AM, AO, AP, AT, AI, BA, BB, BC, BE, BH, BI, BK,
            CH, BM, BO, AX, BT, BX, CA, CB, CE
        };
        enum MarkType { Lexus, Toyota, Lada, Volga, FIAT, SIAT, Renault };
        enum Colors { Зелёный, Красный, Чёрный, Бежевый, Синий, Серый, Лиловый };
        enum LastNames { Сидоров, Петров, Чернов, Мирнов, Винин, Мариной, Иванов };
        enum FirstNames { Р, С, В, Я, Е, Н, И };
        enum Padrons { Р, С, В, А, Е, Н, И };
        enum Streets { Ясеневая, Мировая, Трудовая, Большая, Кабельная, Строительная, Питерская };

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Study\VII семестр\.NET\DataBase\DataBase\GAI.mdf;Integrated Security=True";

            Connection = new SqlConnection(connectionstring);

            await Connection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Table]", Connection);

            for (int i = 0; i < 800; i++)
            {

                Region Reg = (Region)random.Next(26);
                Region letr = (Region)random.Next(26);
                string Number = Reg.ToString() + random.Next(9) + random.Next(9)
                                + random.Next(9) + random.Next(9) + letr.ToString();
                MarkType Mark = (MarkType)random.Next(7);
                int Year = random.Next(1976, 2018);
                Colors Color = (Colors)random.Next(7);
                LastNames lastname = (LastNames)random.Next(7);
                FirstNames firstname = (FirstNames)random.Next(7);
                Padrons padron = (Padrons)random.Next(7);
                string FIO = lastname.ToString() + " " + firstname.ToString() + ". " + padron.ToString() + ".";
                Streets street = (Streets)random.Next(7);
                string Address = street.ToString() + ", " + random.Next(120).ToString(); ;
                try
                {

                    SqlCommand commandadd = new SqlCommand("INSERT INTO [Table] (Number, Mark, Year, Color, " +
                                                        "FIO, Address) VALUES(@Number, @Mark, @Year, " +
                                                        "@Color, @FIO, @Address)", Connection);
                    commandadd.Parameters.AddWithValue("Number", Number);
                    commandadd.Parameters.AddWithValue("Mark", Mark.ToString());
                    commandadd.Parameters.AddWithValue("Year", Year.ToString());
                    commandadd.Parameters.AddWithValue("Color", Color.ToString());
                    commandadd.Parameters.AddWithValue("FIO", FIO);
                    commandadd.Parameters.AddWithValue("Address", Address);

                    await commandadd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListBox1.Items.Add(Convert.ToString(sqlReader["Number"]) + "   \t"
                                        + Convert.ToString(sqlReader["Mark"]) + "   \t" 
                                        + Convert.ToString(sqlReader["Year"]) + "   \t"
                                        + Convert.ToString(sqlReader["Color"]) + "    \t"
                                        + Convert.ToString(sqlReader["FIO"]) + "  \t"
                                        + Convert.ToString(sqlReader["Address"]));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Connection != null && Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            }
        }


        private async void Add(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Add_color.Text) && !string.IsNullOrWhiteSpace(Add_color.Text) &&
                    !string.IsNullOrEmpty(Add_number.Text) && !string.IsNullOrWhiteSpace(Add_number.Text) &&
                    !string.IsNullOrEmpty(Add_FIO.Text) && !string.IsNullOrWhiteSpace(Add_FIO.Text) &&
                    !string.IsNullOrEmpty(Add_address.Text) && !string.IsNullOrWhiteSpace(Add_address.Text) &&
                    !string.IsNullOrEmpty(Add_mark.Text) && !string.IsNullOrWhiteSpace(Add_mark.Text) &&
                    !string.IsNullOrEmpty(Add_year.Text) && !string.IsNullOrWhiteSpace(Add_year.Text))
                {

                    SqlCommand command = new SqlCommand("INSERT INTO [Table] (Number, Mark, Year, Color," +
                                                        " FIO, Address) VALUES(@Number, @Mark, @Year, " +
                                                        "@Color, @FIO, @Address)", Connection);
                    command.Parameters.AddWithValue("Number", Add_number.Text);
                    command.Parameters.AddWithValue("Mark", Add_mark.Text);
                    command.Parameters.AddWithValue("Year", Add_year.Text);
                    command.Parameters.AddWithValue("Color", Add_color.Text);
                    command.Parameters.AddWithValue("FIO", Add_FIO.Text);
                    command.Parameters.AddWithValue("Address", Add_address.Text);

                    await command.ExecuteNonQueryAsync();

                    Add_number.Text = "";
                    Add_mark.Text = "";
                    Add_year.Text = "";
                    Add_color.Text = "";
                    Add_FIO.Text = "";
                    Add_address.Text = "";
                }
                else
                {
                    MessageBox.Show("Все поля должны быть заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

      
        private async void Delete(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Delete_number.Text) && !string.IsNullOrWhiteSpace(Delete_number.Text))
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить это?", "Это точно?", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand("DELETE FROM [Table] WHERE[Number]=@Number", Connection);
                        command.Parameters.AddWithValue("Number", Delete_number.Text);

                        await command.ExecuteNonQueryAsync();

                        Delete_number.Text = "";
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        MessageBox.Show("Неверный формат номера", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else Delete_number.Text = "";
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void Change(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Change_number.Text) && !string.IsNullOrWhiteSpace(Change_number.Text) &&
               !string.IsNullOrEmpty(Change_mark.Text) && !string.IsNullOrWhiteSpace(Change_mark.Text) &&
               !string.IsNullOrEmpty(Change_year.Text) && !string.IsNullOrWhiteSpace(Change_year.Text) &&
               !string.IsNullOrEmpty(Change_color.Text) && !string.IsNullOrWhiteSpace(Change_color.Text) &&
               !string.IsNullOrEmpty(Change_FIO.Text) && !string.IsNullOrWhiteSpace(Change_FIO.Text) &&
               !string.IsNullOrEmpty(Change_address.Text) && !string.IsNullOrWhiteSpace(Change_address.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Table] SET [Mark]=@Mark, [Year]=@Year, " +
                    "                               [Color]=@Color, [FIO]=@FIO, [Address]=@Address " +
                    "                               WHERE [Number]=@Number", Connection);
                command.Parameters.AddWithValue("Number", Change_number.Text);
                command.Parameters.AddWithValue("Mark", Change_mark.Text);
                command.Parameters.AddWithValue("Year", Change_year.Text);
                command.Parameters.AddWithValue("Color", Change_color.Text);
                command.Parameters.AddWithValue("FIO", Change_FIO.Text);
                command.Parameters.AddWithValue("Address", Change_address.Text);

                await command.ExecuteNonQueryAsync();

                Change_number.Text = "";
                Change_mark.Text = "";
                Change_year.Text = "";
                Change_color.Text = "";
                Change_FIO.Text = "";
                Change_address.Text = "";

                Change_mark.IsEnabled = false;
                Change_year.IsEnabled = false;
                Change_color.IsEnabled = false;
                Change_FIO.IsEnabled = false;
                Change_address.IsEnabled = false;
                Button2.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Change_number_TextChanged(object sender, TextChangedEventArgs e)
        {
            Change_mark.Text = "";
            Change_year.Text = "";
            Change_color.Text = "";
            Change_FIO.Text = "";
            Change_address.Text = "";

            Change_mark.IsEnabled = false;
            Change_year.IsEnabled = false;
            Change_color.IsEnabled = false;
            Change_FIO.IsEnabled = false;
            Change_address.IsEnabled = false;
            Button2.IsEnabled = false;
        }

        private async void Search(object sender, RoutedEventArgs e)
        {
            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Table] WHERE [Number]=@Number", Connection);
            command.Parameters.AddWithValue("Number", Change_number.Text);

            Change_mark.IsEnabled = true;
            Change_year.IsEnabled = true;
            Change_color.IsEnabled = true;
            Change_FIO.IsEnabled = true;
            Change_address.IsEnabled = true;
            Button2.IsEnabled = true;

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    Change_mark.Text = Convert.ToString(sqlReader["Mark"]);
                    Change_year.Text = Convert.ToString(sqlReader["Year"]);
                    Change_color.Text = Convert.ToString(sqlReader["Color"]);
                    Change_FIO.Text = Convert.ToString(sqlReader["FIO"]);
                    Change_address.Text = Convert.ToString(sqlReader["Address"]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                }
            }
        }

        private async void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Table]", Connection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                ListBox1.Items.Clear();

                while (await sqlReader.ReadAsync())
                {
                    ListBox1.Items.Add(Convert.ToString(sqlReader["Number"]) + "   \t"
                                        + Convert.ToString(sqlReader["Mark"]) + "  \t"
                                        + Convert.ToString(sqlReader["Year"]) + "   \t"
                                        + Convert.ToString(sqlReader["Color"]) + "     \t"
                                        + Convert.ToString(sqlReader["FIO"]) + "  \t"
                                        + Convert.ToString(sqlReader["Address"]));
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                }
            }
        }
    }
}
