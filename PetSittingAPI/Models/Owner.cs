namespace PetSittingAPI.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        // Navigation property for the Pets relationship
        // public Pet? Pet { get; set; }
        public ICollection<Pet>? Pets { get; set; }
    }
}
