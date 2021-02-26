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

namespace StudentManagment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> students = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine();
            if (gradL.SelectedIndex == 0)
            {
                Person u = new Undergrad(FirstNameTextBox.Text, LastNameTextBox.Text, int.Parse(AgeTextBox.Text), genderS.SelectedIndex , int.Parse(StudentIDTextBox.Text));
                students.Add(u);
            }
            else
            {
                Person g = new Grad(FirstNameTextBox.Text, LastNameTextBox.Text, int.Parse(AgeTextBox.Text), genderS.SelectedIndex , int.Parse(StudentIDTextBox.Text));
                students.Add(g);
            }
            Console.WriteLine(students.Count);
            StudentsListBox.Items.Add(LastNameTextBox.Text + " " + FirstNameTextBox.Text);
        }

        private void StudentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CoursessListBox.Items.Clear();
            FirstNameTextBox.Text = students[StudentsListBox.SelectedIndex].FirstName;
            LastNameTextBox.Text = students[StudentsListBox.SelectedIndex].LastName;
            AgeTextBox.Text = students[StudentsListBox.SelectedIndex].Age.ToString();
            StudentIDTextBox.Text = students[StudentsListBox.SelectedIndex].StuID.ToString();
            genderS.SelectedIndex = students[StudentsListBox.SelectedIndex].Gender;

            List<Course> l = students[StudentsListBox.SelectedIndex].getCourses();
            for(int i = 0; i < l.Count; i++)
            {
                CoursessListBox.Items.Add(l[i].getcourseNum());
            }
            

            if (students[StudentsListBox.SelectedIndex].GetType().Equals(typeof(Undergrad)))
               gradL.SelectedIndex = 0;
            else
               gradL.SelectedIndex = 1;

            

            TotalGPATextBox.Text = students[StudentsListBox.SelectedIndex].getGpa().ToString();

        }

        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsListBox.SelectedIndex != -1)
            {
                if (students[StudentsListBox.SelectedIndex].GetType().Equals(typeof(Undergrad)) && (int.Parse(CourseNumberTextBox.Text) < 5000))
                {
                    students[StudentsListBox.SelectedIndex].addCourse(new Course(CourseNameTextBox.Text, int.Parse(CourseNumberTextBox.Text), double.Parse(CreditHoursTextBox.Text), double.Parse(GPATextBox.Text)));
                    CoursessListBox.Items.Add(CourseNumberTextBox.Text);
                }
                else if (students[StudentsListBox.SelectedIndex].GetType().Equals(typeof(Grad)) && int.Parse(CourseNumberTextBox.Text) > 5000)
                {
                    students[StudentsListBox.SelectedIndex].addCourse(new Course(CourseNameTextBox.Text, int.Parse(CourseNumberTextBox.Text), double.Parse(CreditHoursTextBox.Text), double.Parse(GPATextBox.Text)));
                    CoursessListBox.Items.Add(CourseNumberTextBox.Text);
                }
                else
                    MessageBox.Show("Please enter a correct Course Level");
                  
            }
            
        }
    }
}
