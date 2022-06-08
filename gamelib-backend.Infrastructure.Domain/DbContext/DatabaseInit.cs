using gamelib_backend.Domain.Core.DbEntities;
using gamelib_backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace gamelib_backend.Infrastructure.Domain {

    public static class DatabaseInit {
        private static IList<Company> Companies = new List<Company>(){
            new Company() {
                Name = "Blizzard"
            },
            new Company() {
                Name = "GSC"
            },
            new Company() {
                Name = "Rockstar"
            },
            new Company() {
                Name = "SCS Software"
            }
        };
        private static IList<Genre> Genres = new List<Genre>() {
            new Genre(){
                Name = "RTS"
            },
            new Genre() {
                Name = "RPG"
            },
            new Genre() {
                Name = "Shooter"
            },
            new Genre() {
                Name = "Action"
            },
            new Genre() {
                Name = "Simulator"
            }
        };

        private static IList<Game> Games = new List<Game>(){
            new Game(){
                Name = "Warcraft III: Frozen Throne",
                Company = Companies[0],
                Genres = new List<Genre>() {
                    Genres[0],
                    Genres[1]
                }
            },
            new Game(){
                Name = "S.T.A.L.K.E.R. Shadow of Chernobyl",
                Company = Companies[1],
                Genres = new List<Genre>(){
                    Genres[2]
                }
            },
            new Game(){
                Name = "GTA V",
                Company = Companies[2],
                Genres = new List<Genre>(){
                    Genres[2],
                    Genres[3]
                }
            },
            new Game(){
                Name = "American Truck Simulator",
                Company = Companies[3],
                Genres = new List<Genre>(){
                    Genres[4]
                }
            }
        };

        public static void Init(IDbContext dbContext) {
            if (
                dbContext.Games.Count() == 0
                && dbContext.Companies.Count() == 0
                && dbContext.Genres.Count() == 0
            ) {
                dbContext.Games.AddRange(Games);
                ((DbContext)dbContext).SaveChanges();
            }
        }
    }
}