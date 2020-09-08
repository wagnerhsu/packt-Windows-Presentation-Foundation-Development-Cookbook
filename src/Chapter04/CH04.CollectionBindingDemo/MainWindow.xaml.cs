﻿using System.Collections.ObjectModel;
using System.Windows;

namespace CH04.CollectionBindingDemo
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
                    FirstName = "Kunal", LastName ="Chowdhury",
                    Department="Software Division"
                },

                new Employee
                {
                    FirstName = "Michael", LastName ="Washington",
                    Department="Software Division"
                },

                new Employee
                {
                    FirstName = "John", LastName ="Strokes",
                    Department="Finance Department"
                },
            };

            dataGrid.ItemsSource = Employees;
        }
    }
}