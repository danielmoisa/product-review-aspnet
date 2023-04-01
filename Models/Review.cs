namespace ProductReview.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public int Rating { get; set; }
        public Reviewer Reviewer { get; set; } = new Reviewer();
        public Product Product { get; set; } = new Product();

    }
}
