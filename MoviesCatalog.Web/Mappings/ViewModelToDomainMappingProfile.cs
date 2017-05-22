using AutoMapper;
using MoviesCatalog.Model;
using MoviesCatalog.Web.ViewModels;

namespace MoviesCatalog.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<MovieViewModel, Movie>()
                .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(g => g.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
                .ForMember(g => g.Year, map => map.MapFrom(vm => vm.Year))
                .ForMember(g => g.Producer, map => map.MapFrom(vm => vm.Producer))
                .ForMember(g => g.ImageName, map => map.MapFrom(vm => vm.ImageName))
                .ForMember(g => g.User, map => map.MapFrom(vm => vm));

            Mapper.CreateMap<MovieViewModel, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(model => model.UserName));

            Mapper.CreateMap<Movie, MovieViewModel>()
               .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
               .ForMember(g => g.UserId, map => map.MapFrom(vm => vm.UserId))
               .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
               .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
               .ForMember(g => g.Year, map => map.MapFrom(vm => vm.Year))
               .ForMember(g => g.Producer, map => map.MapFrom(vm => vm.Producer))
               .ForMember(g => g.ImageName, map => map.MapFrom(vm => vm.ImageName));
        }
    }
}