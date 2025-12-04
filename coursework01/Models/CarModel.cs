using System;
using System.Collections.Generic;

namespace coursework01.Models;

public partial class CarModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string BodyType { get; set; } = null!;

    public string EngineType { get; set; } = null!;

    public int Manufacturer { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual Manufacturer ManufacturerNavigation { get; set; } = null!;
}
