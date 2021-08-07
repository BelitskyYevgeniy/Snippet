using AutoMapper;
using Services.Models;
using Services.Models.RequestModels;
using Snippet.BLL.Models.FilterModels;
using Snippet.Data.Entities;
using Snippet.Data.Filters.FilterModels;

namespace Services.Mapping
{
    public class MappingConfiguration:Profile
    {
        public MappingConfiguration()
        {
            CreateMap<CommentEntity, Comment>().ReverseMap();
            CreateMap<LanguageEntity, Language>().ReverseMap();
            CreateMap<LikeEntity, Like>().ReverseMap();

            CreateMap<TagEntity, Tag>().ReverseMap();
            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<PostEntityFilterModel, PostFiltersRequest>().ReverseMap();

            CreateMap<PostEntity, PostRequest>().ReverseMap();
            CreateMap<TagEntity, TagRequest>().ReverseMap();
            CreateMap<CommentEntity, CommentRequest>().ReverseMap();
            CreateMap<LanguageEntity, LanguageRequest>().ReverseMap();
            CreateMap<LikeEntity, LikeRequest>().ReverseMap();
            CreateMap<UserEntity, UserRequest>().ReverseMap();

        }
    }
}
