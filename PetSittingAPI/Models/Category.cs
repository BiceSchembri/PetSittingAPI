namespace PetSittingAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        // Navigation property for the Pets relationship
        public ICollection<Pet>? Pets { get; set; }
    }
}
