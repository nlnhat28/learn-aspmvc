using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basic.Models
{
    public class CarModel
    {
        public CarModel(int id, string name, int price) 
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
   
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string PrintInfo()
        {
            return $"{Id}, {Name}: {Price}";
        }
    }
}