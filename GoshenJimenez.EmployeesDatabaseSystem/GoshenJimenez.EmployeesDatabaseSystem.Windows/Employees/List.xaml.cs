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
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class List : Window
    {
        private string sortBy = "lastname";
        private string sortOrder = "asc";
        private string filterAssignment = "";
        private string filterStatus = "";
        private string keyword = "";
        private int pageSize = 5;
        private int pageIndex = 1;
        private long pageCount = 1;
        public List()
        {
            InitializeComponent();

            cboSortBy.ItemsSource = new List<string>() { "Salary", "LastName" };
            cboSortOrder.ItemsSource = new List<string>() { "Ascending", "Descending" };
            cboFilterAssignment.ItemsSource = new List<string>() { "None", "Field", "Office" };
            cboFilterStatus.ItemsSource = new List<string>() { "None", "Regular", "Probationary" };
            showData();
        }

        private void cboSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sortBy = cboSortBy.SelectedValue.ToString();
            showData();
        }

        public void showData()
        {


            var employees = EmployeeBLL.Search(pageIndex, pageSize, sortBy, sortOrder, filterAssignment, filterStatus, keyword);

            dgEmployees.ItemsSource = employees.Items;
            pageCount = employees.PageCount;

        }

        private void cboSortOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboSortOrder.SelectedValue.ToString().ToLower() == "ascending")
            {
                sortOrder = "asc";
            }
            else
            {
                sortOrder = "desc";
            }
            showData();
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = 1;
            showData();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = pageIndex - 1;
            if(pageIndex < 1)
            {
                pageIndex = 1;
            };
            showData();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = pageIndex + 1;
            if (pageIndex > pageCount)
            {
                pageIndex = (int)pageCount;
            };
            showData();
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = (int)pageCount;
            showData();
        }

        private void txtPageSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPageSize.Text.Length > 0)
            {
                int.TryParse(txtPageSize.Text, out pageSize);
            }

            showData();
        }

        private void cboFilterAssignment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboFilterAssignment.SelectedValue.ToString().ToLower() == "office")
            {
                filterAssignment = "office";
            }
            else if (cboFilterAssignment.SelectedValue.ToString().ToLower() == "field")
            {
                filterAssignment = "field";
            }
            else
            {
                filterAssignment = "";
            }
            showData();
        }

        private void cboFilterStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboFilterStatus.SelectedValue.ToString().ToLower() == "regular")
            {
                filterStatus = "regular";
            }
            else if (cboFilterStatus.SelectedValue.ToString().ToLower() == "probationary")
            {
                filterStatus = "probationary";
            }
            else
            {
                filterStatus = "";
            }
            showData();
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                keyword = txtKeyword.Text;
                showData();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Add addWindow = new Employees.Add(this);
            addWindow.Show();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDto employee = ((FrameworkElement)sender).DataContext as EmployeeDto;
            Update updateForm = new Update(employee, this);
            updateForm.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDto employee = ((FrameworkElement)sender).DataContext as EmployeeDto;

            if (MessageBox.Show("Are you sure you want to delete " + employee.FirstName + " " + employee.LastName + "?",
                        "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var op = EmployeeBLL.Delete(employee.Id);

                if (op.Code != "200")
                {
                    MessageBox.Show("Error : " + op.Message);
                }
                else
                {
                    MessageBox.Show("Employee is successfully deleted from table");
                    showData();
                }
            };
        }

        private void btnDeactivate_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDto employee = ((FrameworkElement)sender).DataContext as EmployeeDto;

            if (MessageBox.Show("Are you sure you want to deactivate " + employee.FirstName + " " + employee.LastName + "?",
                        "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var op = EmployeeBLL.Deactivate(employee.Id);

                if (op.Code != "200")
                {
                    MessageBox.Show("Error : " + op.Message);
                }
                else
                {
                    MessageBox.Show("Employee is successfully deactivated from table");
                    showData();
                }
            };
        }

        private void btnDeductions_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDto employee = ((FrameworkElement)sender).DataContext as EmployeeDto;
            Deductions deductionsForm = new Deductions(employee);
            deductionsForm.Show();
        }
    }
}
