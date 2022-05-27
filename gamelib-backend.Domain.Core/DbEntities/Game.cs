namespace gamelib_backend.Domain.Core.DbEntities {
    public class Game : DbEntity {
        public string Name { get; set; }
        public Company Company { get; set; }
        public IList<Genre> Genres { get; set; }
    }
}
