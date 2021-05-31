namespace Webmotors.Domain.ValueObjects.OnlineChallenge.Vehicles
{
    public class Response
    {
        public int ID { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public string Version { get; private set; }
        public string Image { get; private set; }
        public int KM { get; private set; }
        public decimal Price { get; private set; }
        public int YearModel { get; private set; }
        public int YearFab { get; private set; }
        public string Color { get; private set; }
    }
}
