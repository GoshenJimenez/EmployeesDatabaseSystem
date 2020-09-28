using GoshenJimenez.EmployeesDatabaseSystem.Windows.DAL;
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

namespace GoshenJimenez.EmployeesDatabaseSystem.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            EmployeesDBContext context = new EmployeesDBContext();

            var employee = context.Employees.FirstOrDefault();

            if(employee != null)
            {
                MessageBox.Show(employee.EmailAddress);
            }
        }
    }
}
