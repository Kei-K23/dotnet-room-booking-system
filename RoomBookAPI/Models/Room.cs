namespace RoomBookAPI.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public string RoomType { get; set; } = string.Empty; // Single, Double, Suite
    }
}
