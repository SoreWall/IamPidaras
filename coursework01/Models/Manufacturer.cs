using System;
using System.Collections.Generic;

namespace coursework01.Models;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string HotlinePhoneNumber { get; set; } = null!;

    public string Website { get; set; } = null!;

    public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
}
