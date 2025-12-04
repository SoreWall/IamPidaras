using System;
using System.Collections.Generic;

namespace coursework01.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Position { get; set; } = null!;

    public int Salary { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
