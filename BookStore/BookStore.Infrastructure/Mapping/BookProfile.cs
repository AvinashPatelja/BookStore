using AutoMapper;
using BookStore.Domain.Entities;
using BookStore.Infrastructure.ViewModel;
using System.Collections.Generic;

namespace BookStore.Infrastructure.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookModel, Books>()
                .ForMember(dest => dest.Id,
                        opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
