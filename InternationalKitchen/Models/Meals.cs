using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalKitchen.Models
{
    public class Meals
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public string Image { get; set; }

        public Country country { get; set; }
        public Ingredients ingredients { get; set; }
        public int CountryId { get; internal set; }
        public int ingredientsId { get; internal set; }

    }
}
