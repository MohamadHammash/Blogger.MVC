using AutoMapper;
using Blogger.Core.Entities;
using Blogger.Ui.Models.ViewModels.ApplicationUsersViewModels;
using Blogger.Ui.Models.ViewModels.PostingCardsViewModels;
using Blogger.Ui.Models.ViewModels.QAsViewModels;
using Blogger.Ui.Models.ViewModels.VideosListsViewModels;
using Blogger.Ui.Models.ViewModels.VideosViewModels;
using System;

namespace Blogger.Ui.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Videos
            CreateMap<Video, CreateVideoViewModel>().ReverseMap();
            CreateMap<Video, ListVideosViewModel>();
            CreateMap<Video, DetailsVideoViewModel>();



            CreateMap<Video, EditVideoViewModel>();


            CreateMap<EditVideoViewModel,Video>()
                .ForMember(from=>from.PublishingDate , act=>act.Ignore())
                .ForMember(dest=>dest.VideosListId , from=>from.MapFrom(vl=>(Guid)vl.VideosListId))
                
                ;




            CreateMap<Video, DeleteVideoViewModel>();



            // Posting Cards

            CreateMap<PostingCard, CreatePostingCardViewModel>().ReverseMap();
            CreateMap<PostingCard, ListPostingCardsViewModel>();
            CreateMap<PostingCard, DetailsPostingCardViewModel>();


            CreateMap<PostingCard, EditPostingCardViewModel>();
            CreateMap<EditPostingCardViewModel, PostingCard>()
                .ForMember(dest=>dest.ImagePath, act=>act.Ignore())
                .ForMember(dest=>dest.PublishingDate, act=>act.Ignore())
                ;


            CreateMap<PostingCard, DeletePostingCardViewModel>().ReverseMap();

            // VideosLists
            CreateMap<VideosList, CreateVideosListViewModel>().ReverseMap();
            CreateMap<VideosList, ListVideosListsViewModel>();


            CreateMap<VideosList, EditVideosListViewModel>()
              ;
            CreateMap<EditVideosListViewModel, VideosList>()
                .ForMember(from => from.ImagePath, act => act.Ignore())
                .ForMember(from => from.Videos, act => act.Ignore())
                ;


            CreateMap<VideosList, DetailsVideosListViewModel>().ReverseMap();
            CreateMap<VideosList, DeleteVideosListViewModel>().ReverseMap();





            // QAs

            CreateMap<QA, CreateQAViewModel>().ReverseMap();
            CreateMap<QA, DeleteQAViewModel>().ReverseMap();
            CreateMap<QA, ListQAsViewModel>();
            CreateMap<QA, DetailsQAViewModel>();


            CreateMap<QA, EditQAViewModel>();
            CreateMap<QA, AnswerQAViewModel>();

            CreateMap<EditQAViewModel, QA>()
                .ForMember(from => from.FirstName, act => act.Ignore())
                .ForMember(from => from.LastName, act => act.Ignore())

                
                ;


            CreateMap<AnswerQAViewModel, QA>()
                .ForMember(from => from.FirstName, act => act.Ignore())
                .ForMember(from => from.LastName, act => act.Ignore())
                .ForMember(from => from.Subject, act => act.Ignore())
                .ForMember(from => from.Question, act => act.Ignore())
                ;










            // ApplicationUsers
            CreateMap<ApplicationUser, CreateApplicationUserViewModel>().ReverseMap();
            CreateMap<ApplicationUser, ListApplicationUsersViewModel>();
            CreateMap<ApplicationUser, DetailsApplicationUserViewModel>();
            CreateMap<ApplicationUser, EditApplicationUserViewModel>().ReverseMap();
            CreateMap<ApplicationUser, DetailsApplicationUserViewModel>().ReverseMap();
            CreateMap<ApplicationUser, DeleteApplicationUserViewModel>().ReverseMap();
        }
    }
}