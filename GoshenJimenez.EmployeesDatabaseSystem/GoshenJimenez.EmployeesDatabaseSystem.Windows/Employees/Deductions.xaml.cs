using GoshenJimenez.EmployeesDatabaseSystem.Windows.BLL;
using GoshenJimenez.EmployeesDatabaseSystem.Windows.DataTransferObjects;
using GoshenJimenez.EmployeesDatabaseSystem.Windows.Models;
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

namespace GoshenJimenez.EmployeesDatabaseSystem.Windows.Employees
{
    /// <summary>
    /// Interaction logic for Deductions.xaml
    /// </summary>
    public partial class Deductions : Window
    {
        public Deductions(EmployeeDto employee)
        {
            InitializeComponent();

            var employeeDeductions = DeductionBLL.List(employee.Id);

            dgDeductions.ItemsSource = employeeDeductions;

        }
    }
}
