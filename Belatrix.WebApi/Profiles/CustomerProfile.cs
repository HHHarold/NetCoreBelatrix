using AutoMapper;

namespace Belatrix.WebApi.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Models.Customer, ViewModels.Customer>();
        }
    }
}
