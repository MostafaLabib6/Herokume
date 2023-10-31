using AutoMapper;
using Herokume.Application.Dtos.Category;
using Herokume.Application.Dtos.Comment;
using Herokume.Application.Dtos.Episode;
using Herokume.Application.Dtos.Series;
using Herokume.Domain.Entities;

namespace Herokume.Application.AutoMapper;
public class MappingProfile:Profile
{
    public MappingProfile()
    {
        //Mapping for Series
        CreateMap<Series,SeriesDetailsDto>().ReverseMap();
        CreateMap<Series,SeriesListDto>();

        //Mapping for Episodes
        CreateMap<Episode,EpisodeDetailsDto>().ReverseMap();
        CreateMap<Episode,EpisodeListDto>();

        //Mapping for Comments
        CreateMap<Comment,CommentsListDto>();
        
        //Mapping for Categories
        CreateMap<Category,CategoryDto>();
        CreateMap<Category,CategoryListDto>();

    }
}

