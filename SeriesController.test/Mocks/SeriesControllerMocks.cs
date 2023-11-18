using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Features.Queries.Series;
using Herokume.Domain.Entities;
using Moq;

namespace SeriesController.test.Mocks;

public static class SeriesControllerMocks
{
    public static Mock<ISeriesRepository> GetSeriesRepository()
    {
        var seriesList = new List<Series>()
        {
            new Series()
            {
            Name = "JUJUTSU KAISEN 1",
            Image = "https://res.cloudinary.com/dgywrpedk/image/upload/v1700066123/images_amp6oa.jpg",
            ShowInSlides = true,
            AddToWatchList = true,
            SeasonNumber = 1,
            CreatedAt = DateTime.Now,
            Trailer = "https://youtu.be/pkKu9hLT-t8?si=LF-m35iyYQaBN36y",
            Description = "Yuji Itadori is a boy with tremendous physical strength, though he lives a completely ordinary high school life. One day, to save a classmate who has been attacked by curses, he eats the finger of Ryomen Sukuna, taking the curse into his own soul. From then on, he shares one body with Ryomen Sukuna. Guided by the most powerful of sorcerers, Satoru Gojo, Itadori is admitted to Tokyo Jujutsu High School, an organization that fights the curses... and thus begins the heroic tale of a boy who became a curse to exorcise a curse, a life from which he could never turn back.",
            Episodes =  null,
            Comments = null,
            categories = null,
            Likes = 2580404,
            Rating = 4.7f,
            ID = new Guid("C831A519-1B9C-4CDE-BB38-8C0D76858726")
            },
            new Series()
            {
            Name = "JUJUTSU KAISEN 2",
            Image = "https://res.cloudinary.com/dgywrpedk/image/upload/v1700066123/images_amp6oa.jpg",
            ShowInSlides = true,
            AddToWatchList = true,
            SeasonNumber = 1,
            CreatedAt = DateTime.Now,
            Trailer = "https://youtu.be/pkKu9hLT-t8?si=LF-m35iyYQaBN36y",
            Description = "Yuji Itadori is a boy with tremendous physical strength, though he lives a completely ordinary high school life. One day, to save a classmate who has been attacked by curses, he eats the finger of Ryomen Sukuna, taking the curse into his own soul. From then on, he shares one body with Ryomen Sukuna. Guided by the most powerful of sorcerers, Satoru Gojo, Itadori is admitted to Tokyo Jujutsu High School, an organization that fights the curses... and thus begins the heroic tale of a boy who became a curse to exorcise a curse, a life from which he could never turn back.",
            Episodes =  null,
            Comments = null,
            categories = null,
            Likes = 2580404,
            Rating = 4.7f,
            ID = new Guid("C831A519-1B9C-4CDE-BB38-8C0D76858111")

            }
        };

        var mock = new Mock<ISeriesRepository>();
        mock.Setup(x => x.GetAll()).ReturnsAsync(seriesList);// First Tast
        mock.Setup(x => x.GetSeriesDetails(new Guid("C831A519-1B9C-4CDE-BB38-8C0D76858726"))).ReturnsAsync(seriesList[0]);

        return mock;
    }
}
