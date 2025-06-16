using RP_9_10.Models;

namespace RP_9_10.Services.Implementations
{
	public class AddressStorageService : IAddressStorageService
	{
		private RestaurantAddress[] restaurantAddresses =
			[new RestaurantAddress("Москва", "ул. Тверская", 12, 125009, "+7 (495) 123-45-67"),
			new RestaurantAddress("Москва", "ул. Старый Арбат", 25, 119002, "+7 (495) 234-56-78"),
			new RestaurantAddress("Москва", "Кутузовский проспект", 2, 121248, "+7 (495) 345-67-89"),
			new RestaurantAddress("Санкт-Петербург", "Невский проспект", 45, 191186, "+7 (812) 456-78-90"),
			new RestaurantAddress("Санкт-Петербург", "6-я линия Васильевского острова", 17, 199034, "+7 (812) 567-89-01"),
			new RestaurantAddress("Лондон", "Grosvenor Street", 28, 0, "+44 (0)20 1234 5678"),
			new RestaurantAddress("Лондон", "Embankment Place", 15, 0, "+44 (0)20 2345 6789")];
		public RestaurantAddress[] GetRestaurantAddresses()
		{
			return restaurantAddresses;
		}
	}
}
