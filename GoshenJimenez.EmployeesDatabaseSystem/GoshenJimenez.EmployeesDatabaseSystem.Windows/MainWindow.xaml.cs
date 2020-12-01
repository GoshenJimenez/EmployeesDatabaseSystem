using GoshenJimenez.EmployeesDatabaseSystem.Windows.DAL;
using GoshenJimenez.EmployeesDatabaseSystem.Windows.Helpers;
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

            lblUserName.Content = "Welcome, " + ProgramUser.FullName;
        }

        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            Employees.List listWindow = new Employees.List();
            listWindow.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            ProgramUser.Id = null;
            ProgramUser.FirstName = null;
            ProgramUser.LastName = null;
            ProgramUser.EmailAddress = null;
            ProgramUser.Roles = null;

            LoginWindow login = new LoginWindow();
            login.Show();

            this.Close();

        }
    }
}
