using System;
using System.Collections.Generic;

namespace coursework01.Models;

public partial class Customer
{
    public Customer(int id, string surname, string firstName, string middleName, string phoneNumber, string login, string password,
            string email, string address)
    {
        Id = id;
        Surname = surname;
        FirstName = firstName;
        MiddleName = middleName;
        PhoneNumber = phoneNumber;
        Login = login;
        Password = password;
        Email = email;
        Address = address;
    }

    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<PurchaseRequisition> PurchaseRequisitions { get; set; } = new List<PurchaseRequisition>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
