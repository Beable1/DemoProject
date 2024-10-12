using AutoMapper;
using CoreLayer.DTOs;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mappers
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
           
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Blog, BlogDto>().ReverseMap();
            CreateMap<Blog, BlogDetailsDto>().ReverseMap();
            CreateMap<BlogDetailsDto, BlogDto>().ReverseMap();
            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<WriterDto, Writer>().ReverseMap();
            CreateMap<ContactDto, Contact>().ReverseMap();
            CreateMap<WriterLoginDto, Writer>().ReverseMap();
            CreateMap<Blog, BlogWithCommentsDto>().ReverseMap();
            CreateMap<Message2, MessageDto>().ReverseMap();
        }
    }
}
