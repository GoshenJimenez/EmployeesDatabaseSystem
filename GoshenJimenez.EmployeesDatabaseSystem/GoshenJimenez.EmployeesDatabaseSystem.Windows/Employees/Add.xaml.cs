﻿using GoshenJimenez.EmployeesDatabaseSystem.Windows.BLL;
using GoshenJimenez.EmployeesDatabaseSystem.Windows.Models;
using GoshenJimenez.EmployeesDatabaseSystem.Windows.Models.Enums;
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
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {

        List myParentWindow = new List();
        public Add(List parentWindow)
        {
            InitializeComponent();
            cboAssignment.ItemsSource = new List<string>() { "None", "Field", "Office" };
            cboStatus.ItemsSource = new List<string>() { "None", "Regular", "Probationary" };
            myParentWindow = parentWindow;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                errors.Add("First Name is required.");
            };

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                errors.Add("Last Name is required.");
            };

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                errors.Add("Email Address is required.");
            };

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                errors.Add("Salary is required.");
            };

            if (cboAssignment.SelectedValue == null)
            {
                errors.Add("Please select an Assignment.");
            }

            if (cboStatus.SelectedValue == null)
            {
                errors.Add("Please select a Status.");
            }

            decimal salary = 0;            
            if (!decimal.TryParse(txtSalary.Text, out salary))
            {
                errors.Add("Please enter a valid decimal for Salary.");
            }

            if (errors.Count > 0)
            {
                foreach (var error in errors)
                {
                    txtbErrors.Text = txtbErrors.Text + error + "\n";
                }

                return;
            }



            Assignment assignment = Assignment.Field;
            if(cboAssignment.SelectedValue.ToString().ToLower() == "office")
            {
                assignment = Assignment.Office;
            }

            Status status = Status.Regular;
            if (cboStatus.SelectedValue.ToString().ToLower() == "probationary")
            {
                status = Status.Probationary;
            }

            var op = EmployeeBLL.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Salary = salary,
                EmailAddress = txtEmailAddress.Text,
                Status = status,
                Assignment = assignment
            });

            if(op.Code != "200")
            {
                MessageBox.Show("Error : " + op.Message);
            }
            else
            {
                MessageBox.Show("Employee is successfully added to table");
            }

            myParentWindow.showData();
            this.Close();

        }
    }
}
