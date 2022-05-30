namespace gamelib_backend.Domain.Core.DbEntities {
    public class Game : DbEntity {
        public string Name { get; set; }
        public virtual Company Company { get; set; }
        public virtual IList<Genre> Genres { get; set; }
    }
}
