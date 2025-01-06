using AutoMapper;
using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Module.Dto;

namespace OnlineFoodDelivery.Utility
{
    public class ManageMapping : Profile
    {
public ManageMapping()
        {
           
            CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.Password, opt=> opt.Ignore()).ForMember(dest => dest.CreatedDate, opt=> opt.MapFrom(_=>DateTime.UtcNow));
            CreateMap<RestaurentOwnerDto, RestaurentOwner>()
                .ForMember(dest => dest.Password, opt => opt.Ignore()).ForMember( dest => dest.createdDare,opt => opt.MapFrom(_ => DateTime.UtcNow));

            
        
        
        }
    }
}
