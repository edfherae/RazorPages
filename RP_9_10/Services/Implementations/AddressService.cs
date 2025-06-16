using RP_9_10.Models;

namespace RP_9_10.Services.Implementations
{
	public class AddressService : IAddressService
	{
		IAddressStorageService _addressStorageService;
		public AddressService(IAddressStorageService addressStorageService) 
		{
			_addressStorageService = addressStorageService;
		}
		public RestaurantAddress[] GetRestaurantAddresses()
		{
			return _addressStorageService.GetRestaurantAddresses();
		}
	}
}
