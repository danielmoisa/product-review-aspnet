namespace ProductReview.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Country Country { get; set; } = new Country();
        public ICollection<ProductOwner> ProductOwners { get; set; } = new List<ProductOwner>();

    }
}
