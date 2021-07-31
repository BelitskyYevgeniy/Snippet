using AutoMapper;
using Repository.Entities;
using Snippet.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snippet.BLL.Mapping
{
    public class MappingConfiguration:Profile
    {
        public MappingConfiguration()
        {
            CreateMap<CommentEntity, Comment>().ReverseMap();
            CreateMap<LanguageEntity, Language>().ReverseMap();
            CreateMap<LikeEntity, Like>().ReverseMap();
            CreateMap<PostEntity, Post>().ReverseMap();
            CreateMap<TagEntity, Tag>().ReverseMap();
            CreateMap<UserEntity, User>().ReverseMap();
        }
    }
}
