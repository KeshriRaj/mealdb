using InternationalKitchen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalKitchen.DTO
{
    public class MealByIdDTO
    {
        public string MealName { get; set; }

        public string MealImage { get; set; }
        public  List<IngredientsDetails>  Requirements { get; set; }

        public List<String> Instructions { get; set; }
    }
}
