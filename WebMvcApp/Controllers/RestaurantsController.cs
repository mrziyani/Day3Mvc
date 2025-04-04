using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        // GET: /Restaurants
     
        public async Task<IActionResult> Index()
        {
            var restaurants = await _restaurantService.GetRestaurantsAsync();
            return View(restaurants);
        }

        // GET: /Restaurants/Details/5
        [HttpGet("Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // GET: /Restaurants/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Restaurants/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RestaurantDto restaurantDto)
        {
            if (ModelState.IsValid)
            {
                await _restaurantService.AddRestaurantAsync(restaurantDto);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantDto);
        }

        // GET: /Restaurants/Edit/5
        [HttpGet("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: /Restaurants/Edit/5
        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RestaurantDto restaurantDto)
        {
            if (id != restaurantDto.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _restaurantService.UpdateRestaurantAsync(restaurantDto);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantDto);
        }

        // GET: /Restaurants/Delete/5
        [HttpGet("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: /Restaurants/Delete/5
        [HttpPost("Delete/{id:int}")]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _restaurantService.DeleteRestaurantAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // Bonus: Filtrer par cuisine via un routage par attribut
        // Ex: /Restaurants/Cuisine/Italienne
        [HttpGet("Cuisine/{cuisine}")]
        public async Task<IActionResult> ByCuisine(string cuisine)
        {
            var restaurants = await _restaurantService.GetRestaurantsAsync();
            var filtered = restaurants.Where(r => r.Cuisine.Equals(cuisine, StringComparison.OrdinalIgnoreCase));
            return View("Index", filtered);
        }
    }
}
