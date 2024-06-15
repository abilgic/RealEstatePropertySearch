namespace RealEstatePropertySearch.Server.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public string PropertyType { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public decimal LandSize { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBathrooms { get; set; }

    }
}
