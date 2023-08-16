using System;
using AutoMapper;
using Application.DTOs;
using Application.DTOs.Posts;
using Domain;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, PostListDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
        }
    }
}