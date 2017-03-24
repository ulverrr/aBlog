using aBlog.Core.DTOs;
using aBlog.Core.ViewModels;
using aBlog.DataModel.Models;
using AutoMapper;

namespace aBlog.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // db to DTo
            CreateMap<FavouritePost, FavouritePostDto>();

            // db to viewModel
            CreateMap<Post, PostFormViewModel>();
            CreateMap<Post, PostCommentViewModel>();

            // DTo to db
            CreateMap<FavouritePostDto, FavouritePost>();

            // viewModel to db
            CreateMap<PostFormViewModel, Post>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Category, opt => opt.Ignore());
            CreateMap<PostCommentViewModel, Comment>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.PostId, opt => opt.MapFrom(m => m.Id))
                .ForMember(p => p.Post, opt => opt.Ignore());


        }
    }
}
