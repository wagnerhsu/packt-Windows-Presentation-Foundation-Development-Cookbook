using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;

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
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Employee item in dataGrid.ItemsSource)
            {
                DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (item.ID == "EMP0002")
                {
                    if (row != null)
                        row.Background = Brushes.Red;
                }
                else if (item.ID == "EMP0001")
                {
                    if (row != null)
                        row.Background = Brushes.LightGreen;
                }
            }
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

        private void ModifyRowColor_Click(object sender, RoutedEventArgs e)
        {
            foreach (Employee item in dataGrid.ItemsSource)
            {
                DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (item.ID == "EMP0002")
                {
                    if (row != null)
                        row.Background = Brushes.Red;
                }
            }

        }

        
    }
}