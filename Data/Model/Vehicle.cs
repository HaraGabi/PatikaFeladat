namespace Data.Model
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }

        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
    }
}