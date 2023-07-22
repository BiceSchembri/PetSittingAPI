namespace PetSittingAPI.DTOs
{
    public class PetDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Sex { get; set; }
        public string? PhysicalDescription { get; set; }
        public string? Behaviour { get; set; }
        public string? Needs { get; set; }
        public int OwnerId { get; set; }
        public int? SitterId { get; set; }

        // No need to include CreatedAt, UpdatedAt, and DeletedAt properties in the DTO
        // The timestamps are automatically assigned, so they don't need to be part of the API input.

        // No need to include navigation properties (Category, Owner, and Sitter) in the DTO
        // Navigation properties are used to navigate the object graph, not necessary for API output.
    }
}