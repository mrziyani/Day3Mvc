using DAL.Models;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IRestaurantService
    {
        Task<RestaurantDto> GetRestaurantByIdAsync(int id);
        Task<IEnumerable<RestaurantDto>> GetRestaurantsAsync();
        Task AddRestaurantAsync(RestaurantDto restaurant);
        Task UpdateRestaurantAsync(RestaurantDto restaurant);
        Task DeleteRestaurantAsync(int id);
    }
}
