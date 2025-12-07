using System;
using System.Collections.Generic;

namespace coursework01.Models;

public partial class PurchaseRequisition
{
    public int Id { get; set; }

    public int Customer { get; set; }

    public int Car { get; set; }

    public string CustomerName
    {
        get
        {
            Customer customer = App.DB.Customers.FirstOrDefault(x=>x.Id == this.Customer);
            return $"{customer.Surname.Trim()} {customer.FirstName.Trim()} {customer.MiddleName.Trim()}";
        }
    }

    public string CarName
    {
        get
        {
            Car car = App.DB.Cars.FirstOrDefault(x=>x.Id == this.Car);
            return $"{car.Manufacturer.Trim()} {car.Model.Trim()}";
        }
    }

    public virtual Car CarNavigation { get; set; } = null!;

    public virtual Customer CustomerNavigation { get; set; } = null!;
}
