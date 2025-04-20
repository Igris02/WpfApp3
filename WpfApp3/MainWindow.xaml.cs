using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Studentss> Students;
        private bool isExpanded = false;

        public MainWindow()
        {
            InitializeComponent();
            Students = new List<Studentss>();
            StudentListBox.ItemsSource = Students;
            
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            string name = FullName.Text.Trim();
            string sex = Sex.Text.Trim();
            string age = Age.Text.Trim();
            string birthday = BirthDay.Text.Trim();
            string address = Address.Text.Trim();
            string email = Email.Text.Trim();
            string number = Number.Text.Trim();


            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(sex) || string.IsNullOrEmpty(age) || string.IsNullOrEmpty(birthday) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(number))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(age, out int ages))
            {
                MessageBox.Show("Age must be a number.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
           

            Students.Add(new Studentss
            {
                Name = name,
                Sex = sex,
                Age = ages,
                Bday = birthday,
                Address = address,
                Email = email,
                Number = number
            });

            RefreshListBox();

            FullName.Clear();
            Sex.Clear();
            Age.Clear();
            BirthDay.Clear();
            Address.Clear();
            Email.Clear();
            Number.Clear();
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (StudentListBox.SelectedItem is Studentss selectedStudent)
            {
                Students.Remove(selectedStudent);
                RefreshListBox();
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void RefreshListBox()
        {
            StudentListBox.ItemsSource = null;  
            StudentListBox.ItemsSource = Students;  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isExpanded)
            {
                this.Width = 900;
                ViewBtn.Content = "<<Hide";
                isExpanded = true;
            }
            else
            {
                this.Width = 470;
                ViewBtn.Content = "View>>";
                isExpanded = false;
            }
        }
    }
}
