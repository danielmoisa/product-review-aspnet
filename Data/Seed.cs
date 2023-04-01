using ProductReview.Models;

namespace ProductReview.Data
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.ProductOwners.Any())
            {
                var productOwners = new List<ProductOwner>()
                {
                    new ProductOwner()
                    {
                        Product = new Product()
                        {
                            Name = "Nike T-Shirt",
                            Description = " Lorem lorem desc",
                            Price = 30,
                            ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { Name = "Sport"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Nike",Text = "This Nike t-shirt is a very good product", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } }
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Jack",
                            LastName = "London",
                            Email = "jackl@gamail.com",
                            Country = new Country()
                            {
                                Name = "Kanto"
                            }
                        }
                    },

                    new ProductOwner()
                    {
                        Product = new Product()
                        {
                            Name = "Nike T-Shirt",
                            Description = " Lorem lorem desc",
                            Price = 30,
                            ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { Name = "Sport"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Nike",Text = "This Nike t-shirt is a very good product", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } }
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Jack",
                            LastName = "London",
                            Email = "jackl@gmail.com",
                            Country = new Country()
                            {
                                Name = "Kanto"
                            }
                        }
                    },

                };
                dataContext.ProductOwners.AddRange(productOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
