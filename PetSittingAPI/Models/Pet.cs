
using Microsoft.EntityFrameworkCore;

namespace PetSittingAPI.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; } // Foreign key referencing the Categories table
        public DateTime DateOfBirth { get; set; }
        public string? Sex { get; set; }
        public string? PhysicalDescription { get; set; }
        public string? Behaviour { get; set; }
        public string? Needs { get; set; }
        public int OwnerId { get; set; } // Foreign key referencing the Owners table
        public int? SitterId { get; set; } // Nullable foreign key for the Sitters table

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        // Navigation properties
        public Category? Category { get; set; } // Navigation property for the Species relationship
        public Owner? Owner { get; set; } // Navigation property for the Owner relationship
        public Sitter? Sitter { get; set; } // Navigation property for the PetSitter relationship
    }
}
