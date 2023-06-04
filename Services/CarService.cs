using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Basic.Areas.CarArea.Models;

namespace MVC_Basic.Services
{
    public class CarService
    {
        public CarService()
        {
            Cars = new List<CarModel>(){
                new CarModel(0, "Lamborghini Aventador", 1800000),
                new CarModel(1, "Lamborghini Huracan", 800000),
                new CarModel(2, "Ferrari Laferrari", 2800000),
                new CarModel(3, "Ferrari 488 GTB", 600000),
                new CarModel(4, "Bugatti La noire", 3200000),
                new CarModel(5, "Bugatti Chiron", 1500000),
                new CarModel(6, "McLaren 720S", 1200000),
                new CarModel(7, "McLaren P1", 900000)
            };
        }

        public List<CarModel> Cars { get; set; }

        public List<CarModel> Search(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return null;
            int num;
            if (Int32.TryParse(key, out num))
            {
                if (num < Cars.Count)
                {
                    return Cars.Where(c => c.Id == num).ToList();
                }
                return Cars.Where(c => c.Price <= num).ToList();
            }
            return Cars.Where(c => c.Name.ToLower().Contains(key.ToLower())).ToList();
        }
    }
}