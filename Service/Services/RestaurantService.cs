using AutoMapper;
using DAL.Models;
using DAL.Repositories;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task<RestaurantDto> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await _restaurantRepository.GetRestaurantByIdAsync(id);
            return _mapper.Map<RestaurantDto>(restaurant);
        }

        public async Task<IEnumerable<RestaurantDto>> GetRestaurantsAsync()
        {
            var restaurants = await _restaurantRepository.GetRestaurantsAsync();
            return _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        }

        public async Task AddRestaurantAsync(RestaurantDto restaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDto);
            await _restaurantRepository.AddRestaurantAsync(restaurant);
            await _restaurantRepository.SaveChangesAsync();
        }

        public async Task UpdateRestaurantAsync(RestaurantDto restaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDto);
            await _restaurantRepository.UpdateRestaurantAsync(restaurant);
            await _restaurantRepository.SaveChangesAsync();
        }

        public async Task DeleteRestaurantAsync(int id)
        {
            await _restaurantRepository.DeleteRestaurantAsync(id);
            await _restaurantRepository.SaveChangesAsync();
        }
    }
}
