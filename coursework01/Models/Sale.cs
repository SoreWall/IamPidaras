using System;
using System.Collections.Generic;

namespace coursework01.Models;

public partial class Sale
{
    public int Id { get; set; }

    public DateOnly SaleDate { get; set; }

    public int SalePrice { get; set; }

    public int Commission { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public int Car { get; set; }

    public int Customer { get; set; }

    public int Employee { get; set; }

    public string CarName 
    {
        get
        {
            Car car = App.DB.Cars.FirstOrDefault(x=>x.Id == this.Car);
            return $"{car.Manufacturer.Trim()} {car.Model.Trim()}";
        }
    }

    public string CustomerName
    {
        get
        {
            Customer customer = App.DB.Customers.FirstOrDefault(x=>x.Id == this.Customer);
            return $"{customer.Surname.Trim()} {customer.FirstName.Trim()} {customer.MiddleName.Trim()}";
        }
    }

    public string EmployeeName
    {
        get
        {
            Employee employee = App.DB.Employees.FirstOrDefault(x => x.Id == this.Employee);
            return $"{employee.Surname.Trim()} {employee.FirstName.Trim()} {employee.MiddleName.Trim()}";
        }
    }

    public virtual Car CarNavigation { get; set; } = null!;

    public virtual Customer CustomerNavigation { get; set; } = null!;

    public virtual Employee EmployeeNavigation { get; set; } = null!;
}
