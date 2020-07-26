using InternationalKitchen.Models;
using InternationalKitchen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalKitchen.DTO
{
    public class MealByIngredientsDTO
    {
        public string IngredientName { get; set; }
        public string IngredientImage { get; set; }
        public List<MealsData> GetMeal { get; set; }
    }
}
