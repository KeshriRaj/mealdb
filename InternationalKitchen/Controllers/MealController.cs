using InternationalKitchen.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalKitchen.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]

    public class MealController : ControllerBase
    {
        private readonly IMeal repository;

        public MealController(IMeal repository)
        {
            this.repository = repository;
        }

        [HttpGet("Countries")]
        public IActionResult Countries()
        {
            return Ok(repository.AllCountries());
        }

        [HttpGet("Ingredients")]
        public IActionResult Ingredients()
        {
            return Ok(repository.AllIngredients());
        }

        [HttpPost("Signup")]
        public IActionResult Signup(Request.AddSignupRequest data)
        {
            return Ok(repository.AddSignup(data));
        }

        [HttpPost("Login")]
        public IActionResult Login(Request.AddLoginRequest data)
        {
            return Ok(repository.AddLogin(data));
        }

        [HttpPost("AddMeal")]
        public IActionResult AddMeal(Request.AddMealRequest data)
        {
            return Ok(repository.AddMealData(data));
        }

        [HttpDelete("DeleteMeal")]

        public IActionResult DeleteMeal(Request.DeleteMealRequest data)
        {
            return Ok(repository.DeleteMeal(data));
        }

        [HttpPost("GetMealById")]

        public IActionResult GetMealBySearch(Request.AddMealIdRequest data)
        {
            return Ok(repository.GetMealById(data));
        }

        [HttpPost("GetMealByIngredientId")]

        public IActionResult GetMealByIngredientId(Request.AddMealIngredientRequest data)
        {
            return Ok(repository.GetMealsByIngredientId(data));
        }

        [HttpPost("GetMealByCountry")]

        public IActionResult GetMealByCountry(Request.AddMealsCountry data)
        {
            return Ok(repository.GetMealsByCountry(data));
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("GetMealsByLetters")]

        public IActionResult GetMealsByLetters(Request.AddLettersRequest data)
        {
            return Ok(repository.GetMealsByLetter(data));
        }

        [HttpPost("GetMealsBySearch")]

        public IActionResult GetMealsBySearch(Request.AddSearchRequest data)
        {
            return Ok(repository.GetMealsBySearch(data));
        }

        [HttpGet("GetMealList")]

        public IActionResult GetMealList()
        {
            return Ok(repository.GetMealsList());
        }

        [HttpGet("GetMealRandomly")]

        public IActionResult GetMealRandomly()
        {
            return Ok(repository.GetMealsRandomly());
        }

        [HttpGet("GetAllMeals")]

        public IActionResult GetAllMeals()
        {
            return Ok(repository.GetAllMeals());
        }

        [HttpGet("Faqs")]
        public IActionResult Faqs()
        {
            return Ok(repository.Faqs());
        }


    }

}
