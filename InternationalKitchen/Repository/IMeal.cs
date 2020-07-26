using InternationalKitchen.DTO;
using InternationalKitchen.Models;
using InternationalKitchen.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalKitchen.Repository
{
    public interface IMeal
    {
        public List<Country> AllCountries();
        public List<Ingredients> AllIngredients();
        public bool AddSignup(Request.AddSignupRequest data);
        public bool AddLogin(Request.AddLoginRequest data);

        public bool AddMealData(Request.AddMealRequest data);

        public bool DeleteMeal(Request.DeleteMealRequest data);

        public MealByIdDTO GetMealById(Request.AddMealIdRequest data);

        public MealByIngredientsDTO GetMealsByIngredientId(Request.AddMealIngredientRequest data);

        public List<MealsData> GetMealsByCountry(Request.AddMealsCountry data);

        public List<MealsData> GetMealsByLetter(Request.AddLettersRequest data);

        public List<MealsData> GetMealsBySearch(Request.AddSearchRequest data);

        public List<MealsData> GetMealsList();

        public List<MealsData> GetMealsRandomly();

        public List<MealsData> GetAllMeals();

        public List<FrequentlyAskedQuestion> Faqs();
    }
}
