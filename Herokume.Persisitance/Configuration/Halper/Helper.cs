
using Herokume.Domain.Entities;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Herokume.Persisitance.Configuration.Halper
{
    public static class Helper
    {
        public static Series series { get; set; } = new Series
        {
            Name = "JUJUTSU KAISEN",
            Image = "https://res.cloudinary.com/dgywrpedk/image/upload/v1700066123/images_amp6oa.jpg",
            ShowInSlides = true,
            AddToWatchList = true,
            SeasonNumber = 1,
            CreatedAt = DateTime.Now,
            Trailer = "https://youtu.be/pkKu9hLT-t8?si=LF-m35iyYQaBN36y",
            Description = "Yuji Itadori is a boy with tremendous physical strength, though he lives a completely ordinary high school life. One day, to save a classmate who has been attacked by curses, he eats the finger of Ryomen Sukuna, taking the curse into his own soul. From then on, he shares one body with Ryomen Sukuna. Guided by the most powerful of sorcerers, Satoru Gojo, Itadori is admitted to Tokyo Jujutsu High School, an organization that fights the curses... and thus begins the heroic tale of a boy who became a curse to exorcise a curse, a life from which he could never turn back.",
            Episodes = new List<Episode> { episode1, episode2 },
            Comments = SeriesComment,
            categories = categories,
            Likes = 2580404,
            Rating = 4.7f,
        };
        public static Episode episode1 { get; set; } = new Episode
        {
            Name = "S1 E1 - Ryomen Sukuna",
            EpisodeNumber = 1,
            Length = 23,
            Series = series,
            EpisodeURL = "https://youtu.be/pkKu9hLT-t8?si=LF-m35iyYQaBN36y",
            Comments = SeriesComment,

        };
        public static Episode episode2 { get; set; } = new Episode
        {
            Name = "S1 E2 - For Myself",
            EpisodeNumber = 2,
            Length = 25,
            Series = series,
            EpisodeURL = "https://youtu.be/pkKu9hLT-t8?si=LF-m35iyYQaBN36y",
            Comments = SeriesComment,

        };

        public static List<Comment> SeriesComment { get; set; } = new List<Comment>
        {
            new Comment{
                Content = "Shonen anime is the most popular genre in the industry. The best of them have solid and fluid animation, epic fight scenes, awesome openings, quirky dialogue, easy to follow plot, entertaining characters with exaggerated but fun expressions, etc. In just one episode, JUJUTSU KAISEN showed all those qualities indicating we might be witnessing the next hit shonen. This one has a more supernatural element compared to the fantasy centered aspect of other shonen, so in a sense it's refreshing and interesting. Nonetheless, if you enjoyed the big hitters like Naruto, Bleach, etc., JUJUTSU KAISEN will feel right at home.",
                CreatedAt= DateTime.Now,
                Series = series,
                Episode = null,
                Likes = 22,
                },
            new Comment
            {
                Content = "I HAVE BEEN WAITING FOR SO LONG\r\nthis series needs no introduction... If you are a fan of Bleach, Naruto, Hunter x Hunter... then you will enjoy this series. The character design is phenomenal, the writing is fantastic and the power system is incredibly enjoyable.. I think it reminds me of HxH powers... people, WATCH THIS SHOW",
                Series = series,
                Episode = null,
                Likes = 8,
                CreatedAt = DateTime.Now.AddYears(-8),
            }
        };
        public static List<Comment> EpisodeComment { get; set; } = new List<Comment>
        {
            new Comment{
                Content = "Shonen anime is the most popular genre in the industry. The best of them have solid and fluid animation, epic fight scenes, awesome openings, quirky dialogue, easy to follow plot, entertaining characters with exaggerated but fun expressions, etc. In just one episode, JUJUTSU KAISEN showed all those qualities indicating we might be witnessing the next hit shonen. This one has a more supernatural element compared to the fantasy centered aspect of other shonen, so in a sense it's refreshing and interesting. Nonetheless, if you enjoyed the big hitters like Naruto, Bleach, etc., JUJUTSU KAISEN will feel right at home.",
                CreatedAt= DateTime.Now,
                Series = series,
                Episode = null,
                Likes = 22,
                },
            new Comment
            {
                Content = "I HAVE BEEN WAITING FOR SO LONG\r\nthis series needs no introduction... If you are a fan of Bleach, Naruto, Hunter x Hunter... then you will enjoy this series. The character design is phenomenal, the writing is fantastic and the power system is incredibly enjoyable.. I think it reminds me of HxH powers... people, WATCH THIS SHOW",
                Series = series,
                Episode = null,
                Likes = 8,
                CreatedAt = DateTime.Now.AddYears(-8),
            }
        };
        public static Category category1 { get; set; } = new Category
        {
            ID = Guid.NewGuid(),
            Name = "Action",
            Description = "Action",
            Series = new List<Series> { series },
        };
        public static Category category2 { get; set; } = new Category
        {
            ID = Guid.NewGuid(),
            Name = "Shonen",
            Description = "Shonen",
            Series = new List<Series> { series },
        };
        public static List<Category> categories { get; set; } = new List<Category>
        {
            new Category
            {
                ID = Guid.NewGuid(),
                Name = "Action",
                Description = "Action",
                Series = new List<Series>{series},
            },

            new Category
            {
                ID = Guid.NewGuid(),
                Name = "Shonen",
                Description = "Shonen",
                Series = new List<Series>{series},
            }
        };

    }
}
