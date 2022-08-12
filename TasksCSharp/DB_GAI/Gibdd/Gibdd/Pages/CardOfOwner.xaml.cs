using Gibdd.DBO;
using Gibdd.Model;
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

namespace Gibdd.Pages
{
    /// <summary>
    /// Логика взаимодействия для CardOfOwner.xaml
    /// </summary>
    public partial class CardOfOwner : Window
    {
        OwnerFullInfo indOwnerFullInfo;
        public CardOfOwner()
        {
            InitializeComponent();
            indOwnerFullInfo = new DAO().GetFullInformationIndividualOwner(Data.IdOwner, Data.IsEntity);
            if (indOwnerFullInfo.IsEntity)
            {
                nameCompanyTextBox.IsEnabled = true;
                innTextBox.IsEnabled = true;
                fioOwnerTextBox.Text = indOwnerFullInfo.Fio;
                nameCompanyTextBox.Text = indOwnerFullInfo.NameCompany;
                innTextBox.Text = indOwnerFullInfo.Inn;
            }
            else
            {
                fioOwnerTextBox.Text = indOwnerFullInfo.Fio;
            }
            
            phoneNumberTextBox.Text = indOwnerFullInfo.Phone;
            addressTextBox.Text = indOwnerFullInfo.Address;
            districtTextBox.Text = indOwnerFullInfo.District;           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (indOwnerFullInfo.Autos.Count() != 0)
            {
                autosIndOwnerDataGrid.ItemsSource = indOwnerFullInfo.Autos;
                autosIndOwnerDataGrid.Columns[0].Header = "ID";
                autosIndOwnerDataGrid.Columns[1].Header = "Гос. номер";
                autosIndOwnerDataGrid.Columns[2].Header = "Бренд";
                autosIndOwnerDataGrid.Columns[3].Header = "Модель";
                autosIndOwnerDataGrid.Columns[4].Header = "Год выпуска";
                autosIndOwnerDataGrid.Columns[5].Header = "В угоне";
                autosIndOwnerDataGrid.Columns[6].Visibility = Visibility.Collapsed;
                GetFullInfoAuto(indOwnerFullInfo.Autos[0].AutoID);
            }
        }

        private void GetFullInfoAuto(int id)
        {
            Autos auto = new Autos();
            auto = new DAO().GetFullInfoAboutAuto(id);
            numberTextBox.Text = auto.Number;
            brandTextBox.Text = auto.Brand;
            modelTextBox.Text = auto.Model;
            volumeEngineTextBox.Text = auto.Volume.ToString();
            powerTextBox.Text = auto.Power.ToString();
            typeBodyTextBox.Text = auto.TypeBody;
            engineIdTexBox.Text = auto.EngineID;
            bodyIdTextBox.Text = auto.BodyID;
            Data.IdAuto = auto.AutoID;
            if(auto.Helm == true)
            {
                leftCheckBox.IsChecked = true;
                rightCheckBox.IsEnabled = false;
            }
            else
            {
                leftCheckBox.IsChecked = false;
                rightCheckBox.IsEnabled = true;
            }
       
            yearTaxTextBox.Text = auto.YearTax.ToString();
            yearLabel.Text = auto.Year.ToString();
            commentTextBox.Text = auto.Comment;

            if (auto.Stealings.Count() >= 0)
            {
                stealingsDataGrid.ItemsSource = auto.Stealings;
                stealingsDataGrid.Columns[0].Visibility = Visibility.Collapsed;
                stealingsDataGrid.Columns[1].Header = "Дата угона";
                stealingsDataGrid.Columns[2].Header = "Дата возврата";
                stealingsDataGrid.Columns[3].Visibility = Visibility.Collapsed;
                stealingsDataGrid.Columns[4].Visibility = Visibility.Collapsed;
            }

            if (auto.TechnicalInspections.Count >= 0)
            {
                techViewAutoDataGrid.ItemsSource = auto.TechnicalInspections;
                techViewAutoDataGrid.Columns[0].Visibility = Visibility.Collapsed;
                techViewAutoDataGrid.Columns[1].Header = "Дата";
                techViewAutoDataGrid.Columns[2].Header = "ФИО инспектора";
                techViewAutoDataGrid.Columns[3].Header = "Оплата за знак ТО";
                techViewAutoDataGrid.Columns[4].Header = "Оплата за ТО";
                techViewAutoDataGrid.Columns[5].Header = "Пробег";
                techViewAutoDataGrid.Columns[6].Header = "ТО пройден";
                techViewAutoDataGrid.Columns[7].Header = "Заметки";
                techViewAutoDataGrid.Columns[8].Visibility = Visibility.Collapsed;
                techViewAutoDataGrid.Columns[9].Visibility = Visibility.Collapsed;
            }
        }

        private void SaveOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            if (Data.IsEntity)
            {
                if (fioOwnerTextBox.Text.Count() > 2 &&
                numberTextBox.Text.Count() > 5 &&
                addressTextBox.Text.Count() > 2 &&
                districtTextBox.Text.Count() > 2)
                {
                    new DAO().ChangeOwner(
                        Data.IdOwner, Data.IsEntity, 
                        new Owners
                        {
                            Address = addressTextBox.Text,
                            District = districtTextBox.Text,
                            Phone = numberTextBox.Text
                        },
                        new Entities
                        {
                            Chief = fioOwnerTextBox.Text,
                            EntityName = nameCompanyTextBox.Text,
                            EntityInn = innTextBox.Text
                        },
                        null);
                }
            }
            else
            {
                if (fioOwnerTextBox.Text.Count() > 2 &&
                numberTextBox.Text.Count() > 5 &&
                addressTextBox.Text.Count() > 2 &&
                districtTextBox.Text.Count() > 2)
                {
                    new DAO().ChangeOwner(
                        Data.IdOwner, Data.IsEntity,
                        new Owners
                        {
                            Address = addressTextBox.Text,
                            District = districtTextBox.Text,
                            Phone = numberTextBox.Text
                        },
                        null,
                        new IndividualOwners
                        {
                            OwnerFio = fioOwnerTextBox.Text
                        });
                }
            }

            
        }

        private void DeleteOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            new DAO().DeleteIndvidualOwner(Data.IdOwner);
            this.Close();
        }

        private void DeleteAutoButton_Click(object sender, RoutedEventArgs e)
        {
            new DAO().DeleteAuto(Data.IdAuto);
        }

        private void AutosIndOwnerDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (autosIndOwnerDataGrid.SelectedItem == null)
                return;

            AutoForCardIndOwner dr = (AutoForCardIndOwner)autosIndOwnerDataGrid.SelectedItem;
            GetFullInfoAuto(dr.AutoID);
            Data.IdAuto = dr.AutoID;
        }
        private void SaveChangeAutoButton_Click(object sender, RoutedEventArgs e)
        {
            if (deleteAutoButton.Visibility == Visibility.Collapsed)
            {
                new DAO().AddAuto(new Autos
                {
                    Number = numberTextBox.Text,
                    Brand = brandTextBox.Text,
                    Model = modelTextBox.Text,
                    BodyModel = "BBq",
                    Color = colorTextBox.Text,
                    Volume = Convert.ToDouble(volumeEngineTextBox.Text),
                    Power = Convert.ToInt32(powerTextBox.Text),
                    TypeBody = typeBodyTextBox.Text,
                    EngineID = engineIdTexBox.Text,
                    BodyID = bodyIdTextBox.Text,
                    AutoID = Data.IdAuto,
                    YearTax = Convert.ToDecimal(yearTaxTextBox.Text),
                    Comment = commentTextBox.Text,
                    DrivingAway = false,
                    OwnerID = Data.IdOwner,
                    Drive = (bool)rightCheckBox.IsChecked,
                    Helm = (bool)leftCheckBox.IsChecked,
                    Year = Convert.ToInt32(yearLabel.Text)       
                });
                deleteAutoButton.Visibility = Visibility.Visible;
                
            }
            else
            {
                Autos newAuto = new Autos
                {
                    Number = numberTextBox.Text,
                    Brand = brandTextBox.Text,
                    Model = modelTextBox.Text,
                    BodyModel = "BBq",
                    Color = colorTextBox.Text,
                    Volume = Convert.ToDouble(volumeEngineTextBox.Text),
                    Power = Convert.ToInt32(powerTextBox.Text),
                    TypeBody = typeBodyTextBox.Text,
                    EngineID = engineIdTexBox.Text,
                    BodyID = bodyIdTextBox.Text,
                    AutoID = Data.IdAuto,
                    YearTax = Convert.ToDecimal(yearTaxTextBox.Text),
                    Comment = commentTextBox.Text
                };
                new DAO().ChangeAuto(newAuto);
            }
            
        }

        private void AddAutoToOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            deleteAutoButton.Visibility = Visibility.Collapsed;
            numberTextBox.Text = "";
            brandTextBox.Text = "";
            modelTextBox.Text = "";
            volumeEngineTextBox.Text = "";
            powerTextBox.Text = "";
            typeBodyTextBox.Text = "";
            engineIdTexBox.Text = "";
            bodyIdTextBox.Text = "";
            leftCheckBox.IsChecked = false;
            rightCheckBox.IsEnabled = false;
            yearTaxTextBox.Text = "";
            yearLabel.Text = "";
            commentTextBox.Text = "";
            stealingsDataGrid.ItemsSource = null;
            techViewAutoDataGrid.ItemsSource = null;
        }

        private void TechViewAutoDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                TechnicalInspections newItem = e.Row.DataContext as TechnicalInspections;
                newItem.AutoID = Data.IdAuto;
                new DAO().AddTechnical(newItem);
            } 
        }

        private void StealingsDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                Stealings newItem = e.Row.DataContext as Stealings;
                newItem.AutoID = Data.IdAuto;
                new DAO().AddStealing(newItem);
            }
        }
    }
}
