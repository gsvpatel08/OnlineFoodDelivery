using AutoMapper;
using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.Module;

namespace OnlineFoodDelivery.Utility
{
    public class ManageMapping : Profile
    {
public ManageMapping()
        {
           
            CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.Password, opt=> opt.Ignore()).ForMember(dest => dest.CreatedDate, opt=> opt.MapFrom(_=>DateTime.UtcNow));
            
        
        
        }
    }
}
