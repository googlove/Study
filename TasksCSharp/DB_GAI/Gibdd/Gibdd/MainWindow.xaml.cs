using Gibdd.DBO;
using Gibdd.Pages;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Gibdd.Model
{
    /// <summary>
    /// Логика взаимодействия для InsertAuto.xaml
    /// </summary>
    public partial class InsertAuto : Window
    {
        DAO dao;
        public InsertAuto()
        {
            InitializeComponent();
            dao = new DAO(); 
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
            if (entityRadioButton.IsChecked == true)
            {
                methodSearchComboBox.Items.Clear();
                ComboBoxItem comboBoxItem1 = new ComboBoxItem
                {
                    Content = "ФИО владельца"
                };
                methodSearchComboBox.Items.Add(comboBoxItem1);
                ComboBoxItem comboBoxItem2 = new ComboBoxItem
                {
                    Content = "Номеру телефона"
                };
                methodSearchComboBox.Items.Add(comboBoxItem2);
                ComboBoxItem comboBoxItem3 = new ComboBoxItem
                {
                    Content = "Местонахождению"
                };
                methodSearchComboBox.Items.Add(comboBoxItem3);
                ComboBoxItem comboBoxItem4 = new ComboBoxItem
                {
                    Content = "Району"
                };
                methodSearchComboBox.Items.Add(comboBoxItem4);
                ComboBoxItem comboBoxItem5 = new ComboBoxItem
                {
                    Content = "Организации"
                };
                methodSearchComboBox.Items.Add(comboBoxItem5);
                ComboBoxItem comboBoxItem6 = new ComboBoxItem
                {
                    Content = "ИНН"
                };
                methodSearchComboBox.Items.Add(comboBoxItem6);
                methodSearchComboBox.SelectedItem = methodSearchComboBox.Items[0];
            }
            if (IndOwnerRadioButton.IsChecked == true)
            {

                methodSearchComboBox.Items.Clear();
                ComboBoxItem comboBoxItem1 = new ComboBoxItem
                {
                    Content = "ФИО владельца"
                };
                methodSearchComboBox.Items.Add(comboBoxItem1);
                ComboBoxItem comboBoxItem2 = new ComboBoxItem
                {
                    Content = "Номеру телефона"
                };
                methodSearchComboBox.Items.Add(comboBoxItem2);
                ComboBoxItem comboBoxItem3 = new ComboBoxItem
                {
                    Content = "Местонахождению"
                };
                methodSearchComboBox.Items.Add(comboBoxItem3);
                ComboBoxItem comboBoxItem4 = new ComboBoxItem
                {
                    Content = "Району"
                };
                methodSearchComboBox.Items.Add(comboBoxItem4);
                methodSearchComboBox.SelectedItem = methodSearchComboBox.Items[0];
            } 
            methodSearchComboBox.UpdateLayout();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            dataGridView.ItemsSource = null;
            ComboBoxItem comboBoxItem = (ComboBoxItem)methodSearchComboBox.SelectedItem;
            if(IndOwnerRadioButton.IsChecked == true)
            {
                List<OwnerForSearch> resultIndv = 
                    dao.GetResultOfSearchIndvidual(wordTextBox.Text, comboBoxItem.Content.ToString());
                if(resultIndv.Count() < 1)
                {
                    MessageBox.Show("Ничего не найдено");
                    return;
                }
                dataGridView.ItemsSource = resultIndv;
                dataGridView.Columns[0].Header = "ID";
                dataGridView.Columns[1].Header = "ФИО";
                dataGridView.Columns[2].Header = "Телефонный номер";
                dataGridView.Columns[3].Header = "Адрес";
                dataGridView.Columns[4].Header = "Район";
                dataGridView.Columns[5].Visibility = Visibility.Collapsed;
                dataGridView.Columns[6].Visibility = Visibility.Collapsed;
                dataGridView.Columns[7].Visibility = Visibility.Collapsed;
            }
            if(entityRadioButton.IsChecked == true)
            {

                List<OwnerForSearch> resultIndv =
                    dao.GetResultOfSearchEntities(wordTextBox.Text, comboBoxItem.Content.ToString());
                if (resultIndv.Count() < 1)
                {
                    MessageBox.Show("Ничего не найдено");
                    return;
                }
                dataGridView.ItemsSource = dao.GetResultOfSearchEntities(wordTextBox.Text, comboBoxItem.Content.ToString());
                dataGridView.Columns[0].Header = "ID";
                dataGridView.Columns[1].Visibility = Visibility.Collapsed;
                dataGridView.Columns[2].Header = "Телефонный номер";
                dataGridView.Columns[3].Header = "Адрес";
                dataGridView.Columns[4].Header = "Район";
                dataGridView.Columns[5].Header = "Название компании";
                dataGridView.Columns[6].Header = "ФИО деректора";
                dataGridView.Columns[7].Header = "ИНН";   
            }
        }

        private void WordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (wordTextBox.Text.Length >= 2)
            {
                searchButton.IsEnabled = true;
            }
            else
            {
                searchButton.IsEnabled = false;
            }
        }

        private void WordAutoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (wordAutoTextBox.Text.Length >= 2)
            {
                searchAutoButton.IsEnabled = true;
            }
            else
            {
                searchAutoButton.IsEnabled = false;
            }
        }


        private void Window_ContentRendered(object sender, EventArgs e)
        {
            RadioButton_Checked(IndOwnerRadioButton, new RoutedEventArgs());
        }

        private void SearchAutoButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (methodSearchAutoComboBox.SelectedItem != null)
            {
               
                dataGridView.ItemsSource = null;
                ComboBoxItem comboBoxItem = (ComboBoxItem)methodSearchAutoComboBox.SelectedItem;
                dataGridView.ItemsSource = dao.GetResultOfSearchAutos(wordAutoTextBox.Text, comboBoxItem.Content.ToString());
                dataGridView.Columns[0].Header = "ID";
                dataGridView.Columns[1].Header = "Гос. номер";
                dataGridView.Columns[2].Header = "Бренд";
                dataGridView.Columns[3].Header = "Модель";
                dataGridView.Columns[4].Header = "В угоне";
                dataGridView.Columns[5].Header = "Номер двигателя";
                dataGridView.Columns[6].Header = "Номер кузова";
                dataGridView.Columns[7].Header = "Год выпуска";
                dataGridView.Columns[8].Visibility = Visibility.Collapsed;
                
            }
        }

        private void OpenCardOfAutoButton_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void DeleteCardOfAutoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddCardOfauto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddCardOfOwner_Click(object sender, RoutedEventArgs e)
        {
            AddOwner addOwner = new AddOwner();
            addOwner.Show();
        }

        private void OpenCardOfOwnerButton_Click(object sender, RoutedEventArgs e)
        {

                if (dataGridView.SelectedItem != null)
                {
                    OwnerForSearch dataRow = (OwnerForSearch)dataGridView.SelectedItem;
                    int idOwner = dataRow.IndOwnerID;
                    Data.IdOwner = idOwner;
                    CardOfOwner ownerCardWindow = new CardOfOwner
                    {
                        Owner = this
                    };
                    ownerCardWindow.Show();
                }
            

        }

        private void DataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void DataGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenCardOfOwnerButton_Click(sender, e);
        }
    }
}
