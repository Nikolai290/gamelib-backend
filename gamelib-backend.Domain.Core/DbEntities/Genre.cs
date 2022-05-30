namespace gamelib_backend.Domain.Core.DbEntities {
    public class Genre : DbEntity {
        public string Name { get; set; }
        public virtual IList<Game> Games { get; set; }
    }
}
