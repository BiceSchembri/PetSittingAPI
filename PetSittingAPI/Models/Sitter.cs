namespace PetSittingAPI.Models
{
    public class Sitter
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        // Inactive when on vacation, etc
        public bool? IsActive { get; set; }
        public bool? HasOwnPlace { get; set;}
        public bool? DoesHomeVisits { get; set; }
        public bool? DoesWalks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
