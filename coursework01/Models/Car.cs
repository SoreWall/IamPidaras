using System;
using System.Collections.Generic;

namespace coursework01.Models;

public partial class Car
{
    public int Id { get; set; }

    public string Vin { get; set; } = null!;

    public int Year { get; set; }

    public int Mileage { get; set; }

    public int Quantity { get; set; }

    public int Price { get; set; }

    public string? Image { get; set; }

    public int CarModel { get; set; }

    public string Model
    {
        get
        {
            return App.DB.CarModels.FirstOrDefault(x=>x.Id == this.CarModel).Name;
        }
    }

    public string BodyType
    {
        get
        {
            return App.DB.CarModels.FirstOrDefault(x => x.Id == this.CarModel).BodyType;
        }
    }

    public string EngineType
    {
        get
        {
            return App.DB.CarModels.FirstOrDefault(x => x.Id == this.CarModel).EngineType;
        }
    }

    public string Manufacturer
    {
        get
        {
            CarModel model = App.DB.CarModels.FirstOrDefault(x => x.Id == this.CarModel);
            return App.DB.Manufacturers.FirstOrDefault(x=>x.Id==model.Manufacturer).Name;
        }
    }

    public string Country
    {
        get
        {
            CarModel model = App.DB.CarModels.FirstOrDefault(x => x.Id == this.CarModel);
            return App.DB.Manufacturers.FirstOrDefault(x => x.Id == model.Manufacturer).Country;
        }
    }

    public string HotlinePhoneNumber
    {
        get
        {
            CarModel model = App.DB.CarModels.FirstOrDefault(x => x.Id == this.CarModel);
            return App.DB.Manufacturers.FirstOrDefault(x => x.Id == model.Manufacturer).HotlinePhoneNumber;
        }
    }

    public string Website
    {
        get
        {
            CarModel model = App.DB.CarModels.FirstOrDefault(x => x.Id == this.CarModel);
            return App.DB.Manufacturers.FirstOrDefault(x => x.Id == model.Manufacturer).Website;
        }
    }

    public virtual CarModel CarModelNavigation { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
