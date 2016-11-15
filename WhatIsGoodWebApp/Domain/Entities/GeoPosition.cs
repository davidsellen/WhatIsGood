namespace WhatsGood.Domain.Entities
{
    public class GeoPosition
    {
        public GeoPosition()
        {
            
        }

        public GeoPosition(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;

        }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}