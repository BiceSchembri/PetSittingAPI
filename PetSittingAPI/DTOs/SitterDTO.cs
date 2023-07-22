namespace PetSittingAPI.DTOs
{
    public class SitterDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
        public bool? HasOwnPlace { get; set; }
        public bool? DoesHomeVisits { get; set; }
        public bool? DoesWalks { get; set; }
    }
}
