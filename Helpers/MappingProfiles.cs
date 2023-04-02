using AutoMapper;
using ProductReview.Dtos;
using ProductReview.Models;

namespace ProductReview.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
