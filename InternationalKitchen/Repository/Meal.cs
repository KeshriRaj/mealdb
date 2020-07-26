using InternationalKitchen.DTO;
using InternationalKitchen.Models;
using InternationalKitchen.Request;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Threading.Tasks;

namespace InternationalKitchen.Repository
{
    public class Meal:IMeal
    {
        private readonly MealDBContext _db;

        public Meal(MealDBContext db)
        {
            this._db = db;
        }

        public List<Country> AllCountries()
        {
            return _db.Countries.ToList();
        }
        public List<Ingredients> AllIngredients()
        {
            return _db.Ingredients.ToList();
        }

        public bool AddSignup(AddSignupRequest request)
        {
            if (request != null)
            {
                SignUp data = new SignUp();
                data.Username = request.Username;
                data.Password = request.Password;

                _db.Signup.Add(data);
                _db.SaveChanges();

                return true;
            }
            if (request == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return false;


        }
        public bool AddLogin(AddLoginRequest request)
        {
            if(request!=null)
            {
                SignUp data = new SignUp();
                data = _db.Signup.Where(a => a.Username == request.Username && a.Password==request.Password).FirstOrDefault();
                
                if (data!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

        }

        public bool AddMealData(AddMealRequest request)
        {
            if (request != null)
            {
                Meals Meal = new Meals();
                Meal.MealName = request.Name;
                Meal.Image = request.Image;
                Meal.CountryId = request.CountryId;
                Meal.ingredientsId = request.IngredientsId;
                _db.Meals.Add(Meal);
                _db.SaveChanges();
                int maxm = _db.Meals.Max(p => p.Id);

                Requirements IngredientsData = new Requirements();
           
                IngredientsData.Components = request.components;
                IngredientsData.ImagesIngredients = request.ImageIngredients;
                IngredientsData.Instructions = request.Instructions;
                IngredientsData.MealsId = maxm;
                _db.Requirements.Add(IngredientsData);
                _db.SaveChanges();
                return true;
            }
          
                return false;
            
        }

        public bool DeleteMeal(DeleteMealRequest request)
        {
            if(request!=null)
            {
                Requirements DeleteRequirements = _db.Requirements.Where(a => a.MealsId == request.MealId).FirstOrDefault();
                _db.Requirements.Remove(DeleteRequirements);
                _db.SaveChanges();

                Meals DeleteMeal = _db.Meals.Where(a => a.Id == request.MealId).FirstOrDefault();
                _db.Meals.Remove(DeleteMeal);
                _db.SaveChanges();
               
                return true;
            }
            else
            {
                return false;
            }
        }

        public MealByIdDTO GetMealById(AddMealIdRequest request)
        {
            MealByIdDTO Meal = new MealByIdDTO();
            Meals GetMeal = _db.Meals.Where(a => a.Id == request.MealId).FirstOrDefault();
            Requirements GetRequirements = _db.Requirements.Where(a => a.MealsId == request.MealId).FirstOrDefault();
            Meal.MealName = GetMeal.MealName;
            Meal.MealImage = GetMeal.Image;
            string requirements = GetRequirements.Components;
            //List<String> ArrayValue = new List<string>();
            string [] arrayRequirements = requirements.Split(",");
            

            string requirementsImage = GetRequirements.ImagesIngredients;
            //List<String> ArrayValueImage = new List<string>();
            string[] arrayRequirementsImage = requirementsImage.Split(",");
            List<IngredientsDetails> GetIngredientsDetails = new List<IngredientsDetails>();
            for(var i=0;i<arrayRequirements.Length-1;i++)
            {
                GetIngredientsDetails.Add(new IngredientsDetails
                {
                    IngredientsName=arrayRequirements[i],
                    IngredientsImage=arrayRequirementsImage[i]
                });
            }

            string instructions = GetRequirements.Instructions;
            List<String> ArrayInstructions = new List<string>();
            string[] arrayInstructions = instructions.Split(".");

            foreach (string data in arrayInstructions)
            {
                ArrayInstructions.Add(data);
            }

            Meal.Requirements = GetIngredientsDetails;
            Meal.Instructions = ArrayInstructions;
            return Meal;
        }

        public MealByIngredientsDTO GetMealsByIngredientId(AddMealIngredientRequest request)
        {
            Ingredients GetIngredients = new Ingredients();
            MealByIngredientsDTO MealByIngredients = new MealByIngredientsDTO();
            List<Meals> GetMeal = _db.Meals.Where(a => a.ingredientsId == request.IngredientId).ToList();
            List<MealsData> GetMealData = new List<MealsData>();
            foreach(Meals data in GetMeal)
            {
                GetMealData.Add(new MealsData
                {
                    MealName=data.MealName,
                    MealImage=data.Image,
                    MealId=data.Id
                });
            }
            MealByIngredients.GetMeal = GetMealData;
            
            GetIngredients = _db.Ingredients.Where(a => a.Id == request.IngredientId).FirstOrDefault();
            MealByIngredients.IngredientName = GetIngredients.MainComponent;
            MealByIngredients.IngredientImage = GetIngredients.MainImage;
            return MealByIngredients;



        }
        public List<MealsData> GetMealsByCountry(AddMealsCountry request)
        {
            List<MealsData> GetData = new List<MealsData>();
            List<Meals> MealData = _db.Meals.Where(a => a.CountryId == request.CountryId).ToList();
            foreach(Meals data in MealData)
            {
                GetData.Add(new MealsData
                {
                    MealId=data.Id,
                    MealName=data.MealName,
                    MealImage=data.Image
                });
            }
            return  GetData;
        }
        public List<MealsData> GetMealsByLetter(AddLettersRequest request)
        {
            List<MealsData> GetData = new List<MealsData>();
            List<Meals> MealData = _db.Meals.Where(a => a.MealName.StartsWith(request.Letter)).ToList();
            foreach (Meals data in MealData)
            {
                GetData.Add(new MealsData
                {
                    MealId = data.Id,
                    MealName = data.MealName,
                    MealImage = data.Image
                });
            }

            return GetData;
        }

        public List<MealsData> GetMealsBySearch(AddSearchRequest request)
        {
            List<MealsData> GetData = new List<MealsData>();
            List<Meals> MealData = _db.Meals.Where(a => a.MealName.Contains(request.Search)).ToList();
            foreach (Meals data in MealData)
            {
                GetData.Add(new MealsData
                {
                    MealId = data.Id,
                    MealName = data.MealName,
                    MealImage = data.Image
                });
            }

            return GetData;

        }

        public List<MealsData> GetMealsList()
        {
          List<MealsData> DisplayData = new List<MealsData>();

          List<Meals> LastTenData = _db.Meals.ToList();
            int count = 0;
            for(int i= LastTenData.Count - 1; i >= 0;i--)
            {
                if (count >= 12)
                    break;

                DisplayData.Add(new MealsData
                {
                    MealId = LastTenData[i].Id,
                    MealName = LastTenData[i].MealName,
                    MealImage = LastTenData[i].Image
                });
                count++;
            }
            return DisplayData;
            

        }

        public List<MealsData> GetMealsRandomly()
        {
            List<MealsData> GetMeals = new List<MealsData>();
            List<Meals> randomMeals = _db.Meals.Take(12).ToList();
            
            foreach(Meals Data in randomMeals)
            {
                GetMeals.Add(new MealsData
                {
                    MealId=Data.Id,
                    MealImage=Data.Image,
                    MealName=Data.MealName
                });
            }
            return GetMeals;
        }

        public List<MealsData> GetAllMeals()
        {
            List<MealsData> GetMeals = new List<MealsData>();
            List<Meals> Meals = _db.Meals.ToList();

            foreach (Meals data in Meals)
            {
                GetMeals.Add(new MealsData
                {
                    MealId = data.Id,
                    MealImage = data.Image,
                    MealName = data.MealName
                });
            }
            return GetMeals;

        }
        public List<FrequentlyAskedQuestion> Faqs()
        {
            return _db.FAQ.ToList();
        }
    }

   


    [Serializable]
    internal class HttpResponseException : Exception
    {
        private object notFound;

        public HttpResponseException()
        {
        }

        public HttpResponseException(object notFound)
        {
            this.notFound = notFound;
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
