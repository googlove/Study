using Gibdd.Model;
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
using System.Windows.Shapes;

namespace Gibdd
{
    /// <summary>
    /// Логика взаимодействия для AddOwner.xaml
    /// </summary>
    public partial class AddOwner : Window
    {
        public AddOwner()
        {
            InitializeComponent();
        }

        private void AddOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            if (indOwnerRadioButton.IsChecked==true)
            {
                if(fioOwnerTextBox.Text.Count() >1 &&
                    addressTextBox.Text.Count()>1 &&
                    districtTextBox.Text.Count()>1 &&
                    phoneNumberTextBox.Text.Count() > 4)
                {
                    new DAO().AddIndvidualOwner(new Owners
                    {
                        Address = addressTextBox.Text,
                        District = districtTextBox.Text,
                        Phone = phoneNumberTextBox.Text,
                        OwnerType = false

                    },
                    new IndividualOwners
                    {
                        OwnerFio = fioOwnerTextBox.Text
                    });
                }
            }
            if (entityOwnerRadioButton.IsChecked == true)
            {
                if (fioOwnerTextBox.Text.Count() > 1 &&
                    addressTextBox.Text.Count() > 1 &&
                    districtTextBox.Text.Count() > 1 &&
                    phoneNumberTextBox.Text.Count() > 4)
                {
                    new DAO().AddEntity(new Owners
                    {
                        Address = addressTextBox.Text,
                        District = districtTextBox.Text,
                        Phone = phoneNumberTextBox.Text,
                        OwnerType = true

                    },
                    new Entities
                    {
                        Chief = fioOwnerTextBox.Text,
                        EntityInn = innTextBox.Text,
                        EntityName = nameCompanyTextBox.Text
                    });
                }
            }

            this.Close();
        }
    }
}
