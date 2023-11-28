using Herokume.Application.Dtos.Series;
using Herokume.Application.Features.Queries.Series;
using Herokume.API.Controllers;
using MediatR;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Herokume.Application.Contracts.Persistance;
using SeriesController.test.Mocks;
using AutoMapper;
using Herokume.Application.AutoMapper;
using Herokume.Application.Features.Queries.Series.Handlers;
using Shouldly;
using Herokume.Application.Features.Queries.Series.Handler;

namespace SeriesController.test;

public class tests
{
    private readonly Mock<ISeriesRepository> _seriesRepositoryMock;
    private readonly IMapper _mapper;

    public tests()
    {
        _seriesRepositoryMock = SeriesControllerMocks.GetSeriesRepository();
        var mapconfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapconfig.CreateMapper();
    }

    [Fact]
    public async Task GetSeries_ValidateReturnStatusCode_OKStatusCode()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var seriesList = new List<SeriesListDto> { };
        mediatorMock.Setup(m => m.Send(It.IsAny<GetSeriesList>(), It.IsAny<CancellationToken>()))
        .ReturnsAsync(seriesList);

        var controller = new Herokume.API.Controllers.SeriesController(mediatorMock.Object);

        // Act
        var result = await controller.GetSeries();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedSeries = Assert.IsAssignableFrom<List<SeriesListDto>>(okResult.Value);
        Assert.Equal(seriesList, returnedSeries);

    }

    [Fact]
    public async Task GetAllSeries_ValidateSeriesCount_CorrectCount()
    {
        //Act
        var handler = new GetSeriesListHandler(
            _seriesRepositoryMock.Object
            , _mapper);

        var result = await handler.Handle(new GetSeriesList() { }, CancellationToken.None);


        //Assert
        result.ShouldNotBeNull();
        result.Count.ShouldBe(3);

    }

    [Fact]
    public async Task GetSeries_ValidateSeries_ValidSeries()
    {
        var handler = new GetSeriesDetailsHandler(
            _seriesRepositoryMock.Object,
            _mapper
            );
        var result = await handler.Handle(new GetSeriesDetails() { Id = new Guid("C831A519-1B9C-4CDE-BB38-8C0D76858726") }, CancellationToken.None);

        result.ShouldNotBeNull();
        result.Id.ShouldBe(new Guid("C831A519-1B9C-4CDE-BB38-8C0D76858726"));
    }

    //[Theory]
    //[InlineData(2)]
    [Fact] // have problem here The Test Fail When using theory :>
    public async Task GetRandomSeries_ValidateTheCountofSeries_ValidRandomCount()
    {
        var handler = new GetRandomSeriesHandler(_seriesRepositoryMock.Object, _mapper);

        //count = int.Parse(count);
        var result = await handler.Handle(new GetRandomSeries() { Count = 2 }, CancellationToken.None);

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
    }

}