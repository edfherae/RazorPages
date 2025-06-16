namespace RP_9_10.Models
{
	public abstract class Address
	{
		public string City { get; set; }
		public string Street { get; set; }
		public int BuildingNumber { get; set; }
		public int PostalIndex { get; set; }
		public string ContactNumber { get; set; }

		
	}
	public class RestaurantAddress : Address
	{
		public RestaurantAddress(string city, string street, int buildingNumber, int postalIndex, string number)
		{
			City = city;
			Street = street;
			BuildingNumber = buildingNumber;
			PostalIndex = postalIndex;
			ContactNumber = number;
		}
		public override string ToString()
		{
			return $"{City}, {Street}, д. {BuildingNumber}, индекс {PostalIndex}, контактный номер: {ContactNumber}";
		}
	}
}
