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

    public virtual Car CarNavigation { get; set; } = null!;

    public virtual Customer CustomerNavigation { get; set; } = null!;

    public virtual Employee EmployeeNavigation { get; set; } = null!;
}
