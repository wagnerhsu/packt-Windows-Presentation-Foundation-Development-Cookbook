using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace GridControl01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> Employees
        {
            get { return (ObservableCollection<Employee>)GetValue(EmployeesProperty); }
            set { SetValue(EmployeesProperty, value); }
        }

        public static readonly DependencyProperty EmployeesProperty =
            DependencyProperty.Register("Employees", typeof(ObservableCollection<Employee>), typeof(MainWindow), new PropertyMetadata(null));

        public MainWindow()
        {
            InitializeComponent();
            Employees = new ObservableCollection<Employee>
            {
                new Employee
                {
                    ID = "EMP0001",
                    FirstName = "Kunal", LastName = "Chowdhury",
                    Department = "Software Division"
                },

                new Employee
                {
                    ID = "EMP0002",
                    FirstName = "Michael", LastName = "Washington",
                    Department = "Software Division"
                },

                new Employee
                {
                    ID = "EMP0003",
                    FirstName = "John", LastName = "Strokes",
                    Department = "Finance Department"
                },

                new Employee
                {
                    ID = "EMP0004",
                    FirstName = "Ramesh", LastName = "Shukla",
                    Department = "Finance Department"
                }
            };

            dataGrid.ItemsSource = Employees;
        }

        private void ModifyData_Click(object sender, RoutedEventArgs e)
        {
            // Modify EMP002
            var employee = Employees.First(x => x.ID == "EMP0002");
            Employees.Remove(employee);
            employee.FirstName = "Wagner";
            employee.LastName = "Xu";
            Employees.Add(employee);
        }
    }
}