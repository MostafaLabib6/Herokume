using AutoMapper;
using Herokume.Application.Dtos.Category;
using Herokume.Application.Dtos.Comment;
using Herokume.Application.Dtos.Episode;
using Herokume.Application.Dtos.Series;
using Herokume.Domain.Entities;

namespace Herokume.Application.AutoMapper;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Mapping for Series
        CreateMap<Series, SeriesDetailsDto>().ReverseMap();
        CreateMap<Series, SeriesListDto>();
        CreateMap<Series, CreateSeriesDto>().ReverseMap();
        CreateMap<Series, UpdateSeriesDto>().ReverseMap();


        //Mapping for Episodes
        CreateMap<Episode, EpisodeDetailsDto>().ReverseMap();
        CreateMap<Episode, EpisodeListDto>();
        CreateMap<Episode, CreateEpisodeDto>().ReverseMap();
        CreateMap<Episode, UpdateEpisodeDto>().ReverseMap();

        //Mapping for Comments
        CreateMap<Comment, CommentsListDto>();
        CreateMap<Comment, CreateCommentDto>().ReverseMap();
        CreateMap<Comment, BaseComment>().ReverseMap();


        //Mapping for Categories
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryListDto>().ReverseMap();

    }
}

