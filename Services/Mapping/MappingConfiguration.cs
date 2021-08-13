using AutoMapper;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using Snippet.Data.Entities;

namespace Services.Mapping
{
    public class MappingConfiguration:Profile
    {
        public MappingConfiguration()
        {


            CreateMap<PostEntity, PostRequest>().ReverseMap();
            CreateMap<TagEntity, TagRequest>().ReverseMap();
            CreateMap<CommentEntity, CommentRequest>().ReverseMap();
            CreateMap<LanguageEntity, LanguageRequest>().ReverseMap();
            CreateMap<LikeEntity, LikeRequest>().ReverseMap();
            CreateMap<UserEntity, UserRequest>().ReverseMap();

            CreateMap<PostEntity, PostResponse>().ReverseMap();
            CreateMap<TagEntity, TagResponse>().ReverseMap();
            CreateMap<CommentEntity, CommentResponse>().ReverseMap();
            CreateMap<LanguageEntity, LanguageResponse>().ReverseMap();
            CreateMap<UserEntity, UserResponse>().ReverseMap();

        }
    }
}
